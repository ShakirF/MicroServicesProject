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
        ViewBag.basket = basket;
        return View(new CheckoutInfoInput());
    }

    [HttpPost]
    public async Task<IActionResult> Checkout(CheckoutInfoInput checkoutInfoInput)
    {
        //1. sinxron elaqe
        //var orderStatus = await _orderService.CreateOrder(checkoutInfoInput);

        //2. asinxrin elaqe
        var orderSuspend = await _orderService.SuspendOrder(checkoutInfoInput);
        if (!orderSuspend.IsSuccessful)
        {

            var basket = await _basketService.Get();
            ViewBag.basket = basket;
            ViewBag.error = orderSuspend.Error;
            return View();
        }

        //1. sinxron elaqe
        //return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = orderStatus.OrderId });

        //2. asenxron elaqe

        return RedirectToAction(nameof(SuccessfulCheckout), new { orderId = new Random().Next(1, 1000) });

    }

    public IActionResult SuccessfulCheckout(int orderId)
    {
        ViewBag.orderId = orderId;
        return View();
    }

    public async Task<IActionResult> CheckoutHistory()
    {
        return View(await _orderService.GetOrder());
    }
}

