using SportStore.Shared.Dtos;
using SportStore.Web.Models.Catalogs;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class CatalogService : ICatalogService
{
    private readonly HttpClient _httpClient;

    public CatalogService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<bool> CreateProductAsync(ProductCreateInput productCreateInput)
    {
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
        return responseSuccess.Data;
    }

    public async Task<ProductViewModel> GetProductById(string productId)
    {
        var response = await _httpClient.GetAsync($"products/{productId}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var responseSuccess = await response.Content.ReadFromJsonAsync<Response<ProductViewModel>>();
        return responseSuccess.Data;
    }

    public async Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput)
    {
        var response = await _httpClient.PutAsJsonAsync<ProductUpdateInput>("products", productUpdateInput);
        return response.IsSuccessStatusCode;
    }
}

