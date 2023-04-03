using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SportStore.Services.FakePayment.Models;
using SportStore.Shared.ControllerBases;
using SportStore.Shared.Dtos;
using SportStore.Shared.Messages;

namespace SportStore.Services.FakePayment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FakePaymentsController : CustomBaseController
{
	private readonly ISendEndpointProvider _sendEndpointProvider;

	public FakePaymentsController(ISendEndpointProvider sendEndpointProvider)
	{
		this._sendEndpointProvider = sendEndpointProvider;
	}

	[HttpPost]
	public async Task<IActionResult> ReceivePaymnet(PaymentDto paymentDto)
	{
		var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

		var createOrderMessageCommand = new CreateOrderMessageCommand();
		createOrderMessageCommand.BuyerId = paymentDto.Order.BuyerId;
		createOrderMessageCommand.Province = paymentDto.Order.Address.Province;
		createOrderMessageCommand.District = paymentDto.Order.Address.District;
		createOrderMessageCommand.Street = paymentDto.Order.Address.Street;
		createOrderMessageCommand.ZipCode = paymentDto.Order.Address.ZipCode;
		createOrderMessageCommand.Line = paymentDto.Order.Address.Line;

		paymentDto.Order.OrderItems.ForEach(x =>
		{
			createOrderMessageCommand.OrderItems.Add(new OrderItem
			{
				PictureUrl = x.PictureUrl,
				Price = x.Price,
				ProductId = x.ProductId,
				Quantity = x.Quantity,
				ProductName = x.ProductName
			});
		});
		await sendEndpoint.Send<CreateOrderMessageCommand>(createOrderMessageCommand);
		return CreateActionResultInstance(Shared.Dtos.Response<NoContent>.Success(200));
	}
}

