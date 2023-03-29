using Microsoft.AspNetCore.Mvc;
using SportStore.Web.Models.Orders;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Controllers;

public class OrderController : Controller
{
    private readonly IBasketService _basketService;
    private readonly IOrderService _orderService;

    public OrderController(IBasketService basketService, IOrderService orderService)
    {
        this._basketService = basketService;
        this._orderService = orderService;
    }

    public async Task<IActionResult> Checkout()
    {
        var basket = await _basketService.Get();
        ViewBag.baket = basket;
        return View(new CheckoutInfoInput());
    }

    [HttpPost]
    public async Task<IActionResult> Checkout(CheckoutInfoInput checkoutInfoInput)
    {
        var orderStatus = await _orderService.CreateOrder(checkoutInfoInput);
        if (!orderStatus.IsSuccessful)
        {

            var basket = await _basketService.Get();
            ViewBag.baket = basket;
            ViewBag.error = orderStatus.Error;
            return View();
        }

        return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = orderStatus.OrderId });

    }

    public IActionResult SuccessfulCheckout(int orderId)
    {
        ViewBag.orderId = orderId;
        return View();
    }
}

