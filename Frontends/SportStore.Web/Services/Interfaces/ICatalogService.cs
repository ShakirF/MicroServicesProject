using SportStore.Web.Models.Catalogs;

namespace SportStore.Web.Services.Interfaces;

public interface ICatalogService
{
    Task<List<ProductViewModel>> GetAllProductAsync();
    Task<List<CategoryViewModel>> GetAllCategoryAsync();
    Task<List<ProductViewModel>> GetAllProductByUserId(string userId);
    Task<ProductViewModel> GetByProductId(string productId);
    Task<bool> CreateProductAsync(ProductCreateInput productCreateInput);
    Task<bool> UpdateProductAsync(ProductUpdateInput productUpdateInput);
    Task<bool> DeleteProductAsync(string productId);
}

