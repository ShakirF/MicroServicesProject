using SportStore.Shared.Dtos;
using SportStore.Web.Helpers;
using SportStore.Web.Models.Catalogs;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;
    private readonly IPhotoStockService _photoStockService;
    private readonly PhotoHelper _photoHelper;

    public CatalogService(HttpClient httpClient, IPhotoStockService photoStockService, PhotoHelper photoHelper)
    {
        this._httpClient = httpClient;
        this._photoStockService = photoStockService;
        this._photoHelper = photoHelper;
    }

    public async Task<bool> CreateProductAsync(ProductCreateInput productCreateInput)
    {
        var resultPhotoService = await _photoStockService.UploadPhoto(productCreateInput.PhotoFormFile);

        if (resultPhotoService != null)
        {
            productCreateInput.Picture = resultPhotoService.Url;
        }

        var response = await _httpClient.PostAsJsonAsync<ProductCreateInput>("products", productCreateInput);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProductAsync(string productId)
    {
        var response = await _httpClient.DeleteAsync($"products/{productId}");
        return response.IsSuccessStatusCode;
    }

    public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
    {
        var response = await _httpClient.GetAsync("categories");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<CategoryViewModel>>>();
        return responseSuccess.Data;
    }

    public async Task<List<ProductViewModel>> GetAllProductAsync()
    {
        var response = await _httpClient.GetAsync("products");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();
        responseSuccess.Data.ForEach(x =>
        {
            x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
        });
        return responseSuccess.Data;
    }

    public async Task<List<ProductViewModel>> GetAllProductByUserId(string userId)
    {
        var response = await _httpClient.GetAsync($"products/GetAllByUserId/{userId}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var responseSuccess = await response.Content.ReadFromJsonAsync<Response<List<ProductViewModel>>>();

        responseSuccess.Data.ForEach(x =>
        {
            x.StockPictureUrl = _photoHelper.GetPhotoStockUrl(x.Picture);
        });
        return responseSuccess.Data;
    }

    public async Task<ProductViewModel> GetByProductId(string productId)
    {
        var response = await _httpClient.GetAsync($"products/{productId}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ProductViewModel>>();
        responseSuccess.Data.StockPictureUrl = _photoHelper.GetPhotoStockUrl(responseSuccess.Data.Picture);

        return responseSuccess.Data;
    }

    public async Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput)
    {

        var resultPhotoService = await _photoStockService.UploadPhoto(productUpdateInput.PhotoFormFile);

        if (resultPhotoService != null)
        {
            await _photoStockService.DeletePhoto(productUpdateInput.Picture);
            productUpdateInput.Picture = resultPhotoService.Url;
        }

        var response = await _httpClient.PutAsJsonAsync<ProductUpdateInput>("products", productUpdateInput);
        return response.IsSuccessStatusCode;
    }
}

