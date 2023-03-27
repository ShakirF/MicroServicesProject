using SportStore.Web.Models.PhotoStocks;

namespace SportStore.Web.Services.Interfaces;

public interface IPhotoStockService
{
    Task<PhotoViewModel> UploadPhoto(IFormFile photo);
    Task<bool> DeletePhoto(string photoUrl);
}

