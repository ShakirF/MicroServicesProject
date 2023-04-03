using SportStore.Shared.Dtos;
using SportStore.Shared.Services;
using SportStore.Web.Models.FakePayments;
using SportStore.Web.Models.Orders;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class OrderService : IOrderService
{
	private readonly IPaymentService _paymentService;
	private readonly HttpClient _httpClient;
	private readonly IBasketService _basketService;
	private readonly ISharedIdentityService _sharedIdentityService;

	public OrderService(IPaymentService paymentService, HttpClient httpClient, IBasketService basketService, ISharedIdentityService sharedIdentityService)
	{
		this._paymentService = paymentService;
		this._httpClient = httpClient;
		this._basketService = basketService;
		this._sharedIdentityService = sharedIdentityService;

	}

	public async Task<OrderCreatedViewModel> CreateOrder(CheckoutInfoInput checkoutInfoInput)
	{
		var basket = await _basketService.Get();

		var paymentInfoInput = new PaymentInfoInput()
		{
			CardName = checkoutInfoInput.CardName,
			CardNumber = checkoutInfoInput.CardNumber,
			Expiration = checkoutInfoInput.Expiration,
			CVV = checkoutInfoInput.CVV,
			TotalPrice = basket.TotalPrice
		};

		var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);

		if (!responsePayment)
		{
			return new OrderCreatedViewModel() { Error = "Ödəmə alınmadı", IsSuccessful = false };
		}

		var orderCreateInput = new OrderCreateInput()
		{
			BuyerId = _sharedIdentityService.GetUserId,
			Address = new AddressCreateInput
			{
				Province = checkoutInfoInput.Province,
				District = checkoutInfoInput.District,
				Street = checkoutInfoInput.Street,
				ZipCode = checkoutInfoInput.ZipCode,
				Line = checkoutInfoInput.Line
			}
		};
		basket.BasketItems.ForEach(x =>
		{
			var orderItem = new OrderItemCreateInput
			{
				ProductId = x.ProductId,
				Price = x.GetCurrentPrice,
				PictureUrl = "",
				Quantity = x.Quantity,
				ProductName = x.ProductName
			};
			orderCreateInput.OrderItems.Add(orderItem);
		});

		var response = await _httpClient.PostAsJsonAsync<OrderCreateInput>("orders", orderCreateInput);

		if (!response.IsSuccessStatusCode)
		{
			return new OrderCreatedViewModel() { Error = "Sifariş alınmadı", IsSuccessful = false };
		}

		var orderCreatedViewModel = await response.Content.ReadFromJsonAsync<Response<OrderCreatedViewModel>>();

		orderCreatedViewModel.IsSuccessful = true;
		await _basketService.Delete();
		return orderCreatedViewModel.Data;
	}

	public async Task<List<OrderViewModel>> GetOrder()
	{
		var response = await _httpClient.GetFromJsonAsync<Response<List<OrderViewModel>>>("orders");
		return response.Data;
	}

	public async Task<OrderSuspendViewModel> SuspendOrder(CheckoutInfoInput checkoutInfoInput)
	{
		var basket = await _basketService.Get();

		var orderCreateInput = new OrderCreateInput()
		{
			BuyerId = _sharedIdentityService.GetUserId,
			Address = new AddressCreateInput
			{
				Province = checkoutInfoInput.Province,
				District = checkoutInfoInput.District,
				Street = checkoutInfoInput.Street,
				ZipCode = checkoutInfoInput.ZipCode,
				Line = checkoutInfoInput.Line
			}
		};
		basket.BasketItems.ForEach(x =>
		{
			var orderItem = new OrderItemCreateInput
			{
				ProductId = x.ProductId,
				Price = x.GetCurrentPrice,
				PictureUrl = "",
				Quantity = x.Quantity,
				ProductName = x.ProductName
			};
			orderCreateInput.OrderItems.Add(orderItem);
		});



		var paymentInfoInput = new PaymentInfoInput()
		{
			CardName = checkoutInfoInput.CardName,
			CardNumber = checkoutInfoInput.CardNumber,
			Expiration = checkoutInfoInput.Expiration,
			CVV = checkoutInfoInput.CVV,
			TotalPrice = basket.TotalPrice,
			Order = orderCreateInput
		};

		var responsePayment = await _paymentService.ReceivePayment(paymentInfoInput);

		if (!responsePayment)
		{
			return new OrderSuspendViewModel() { Error = "Ödəmə alınmadı", IsSuccessful = false };
		}

		await _basketService.Delete();
		return new OrderSuspendViewModel() { IsSuccessful = true };

	}
}

