using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportStore.Shared.Services;
using SportStore.Web.Models.Catalogs;
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
    public async Task<IActionResult> Create()
    {
        var categories = await _catalogService.GetAllCategoryAsync();

        ViewBag.categoryList = new SelectList(categories, "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateInput productCreateInput)
    {
        var categories = await _catalogService.GetAllCategoryAsync();
        ViewBag.categoryList = new SelectList(categories, "Id", "Name");
        if (!ModelState.IsValid)
        {
            return View();
        }
        productCreateInput.UserId = _sharedIdentityService.GetUserId;

        await _catalogService.CreateProductAsync(productCreateInput);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(string id)
    {
        var product = await _catalogService.GetProductById(id);
        var categories = await _catalogService.GetAllCategoryAsync();


        if (product == null)
        {
            RedirectToAction(nameof(Index));
        }

        ViewBag.categoryList = new SelectList(categories, "Id", "Name", product.Id);
        ProductUpdateInput productUpdateInput = new()
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Feature = product.Feature,
            CategoryId = product.CategoryId,
            UserId = product.UserId,
            Picture = product.Picture


        };

        return View(productUpdateInput);
    }

    [HttpPost]
    public async Task<IActionResult> Update(ProductUpdateInput productUpdateInput)
    {

        var categories = await _catalogService.GetAllCategoryAsync();
        ViewBag.categoryList = new SelectList(categories, "Id", "Name", productUpdateInput.Id);
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _catalogService.UpdateProductAsync(productUpdateInput);
        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(string id)
    {
        await _catalogService.DeleteProductAsync(id);

        return RedirectToAction(nameof(Index));
    }
}

