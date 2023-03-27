using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportStore.Shared.Services;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Controllers;

[Authorize]
public class ProductsController : Controller
{
    private readonly ICatalogService _catalogService;
    private readonly ISharedIdentityService _sharedIdentityService;

    public ProductsController(ICatalogService catalogService, ISharedIdentityService sharedIdentityService)
    {
        this._catalogService = catalogService;
        this._sharedIdentityService = sharedIdentityService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _catalogService.GetAllProductByUserId(_sharedIdentityService.GetUserId));
    }
}

