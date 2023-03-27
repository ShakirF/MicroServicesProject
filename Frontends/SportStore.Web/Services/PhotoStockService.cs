using SportStore.Web.Models.PhotoStocks;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class PhotoStockService : IPhotoStockService
{
    private readonly HttpClient _httpClient;

    public PhotoStockService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<bool> DeletePhoto(string photoUrl)
    {
        var response = await _httpClient.DeleteAsync($"photos?photoUrl={photoUrl}");
        return response.IsSuccessStatusCode;
    }

    public async Task<PhotoViewModel> UploadPhoto(IFormFile photo)
    {
        if (photo == null || photo.Length <= 0)
        {
            return null;
        }

        var randomFilename = $"{Guid.NewGuid().ToString()}{Path.GetExtension(photo.FileName)}";

        using var ms = new MemoryStream();

        await photo.CopyToAsync(ms);

        var multipartContent = new MultipartFormDataContent();

        multipartContent.Add(new ByteArrayContent(ms.ToArray()), "photo", randomFilename);

        var response = await _httpClient.PostAsync("photos", multipartContent);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<PhotoViewModel>();



    }
}

