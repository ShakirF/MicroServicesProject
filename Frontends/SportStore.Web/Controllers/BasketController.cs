﻿using Microsoft.AspNetCore.Mvc;
using SportStore.Web.Models.Baskets;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Controllers;

public class BasketController : Controller
{
    private readonly ICatalogService _catalogService;
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService, ICatalogService catalogService)
    {
        this._basketService = basketService;
        this._catalogService = catalogService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _basketService.Get());
    }

    public async Task<IActionResult> AddBasketItem(string productId)
    {
        var product = await _catalogService.GetProductById(productId);
        var basketItem = new BasketItemViewModel { ProductId = product.Id, ProductName = product.Name, Price = product.Price };
        await _basketService.AddBasketItem(basketItem);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> RemoveBasketItem(string productId)
    {
        await _basketService.RemoveBasketItem(productId);
        return RedirectToAction(nameof(Index));
    }
}
