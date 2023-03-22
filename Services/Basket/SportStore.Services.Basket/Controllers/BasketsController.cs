using Microsoft.AspNetCore.Mvc;
using SportStore.Services.Basket.Dtos;
using SportStore.Services.Basket.Services;
using SportStore.Shared.ControllerBases;
using SportStore.Shared.Services;

namespace SportStore.Services.Basket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BasketsController : CustomBaseController
{
    private readonly IBasketService _basketService;
    private readonly ISharedIdentityService _sharedIdentityService;

    public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
    {
        this._basketService = basketService;
        this._sharedIdentityService = sharedIdentityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBasket()
    {
        return CreateActionResultInstance(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
    {
        var response = await _basketService.SaveOrUpdate(basketDto);
        return CreateActionResultInstance(response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBasket()
    {
        return CreateActionResultInstance(await _basketService.DeleteBasket(_sharedIdentityService.GetUserId));
    }
}

