using Microsoft.Extensions.Options;
using SportStore.Web.Models;

namespace SportStore.Web.Helpers;

public class PhotoHelper
{
    private readonly ServiceApiSettings _serviceApiSettings;

    public PhotoHelper(IOptions<ServiceApiSettings> serviceApiSettings)
    {
        this._serviceApiSettings = serviceApiSettings.Value;
    }

    public string GetPhotoStockUrl(string photoUrl)
    {
        return $"{_serviceApiSettings.PhotoStockUri}/photos/{photoUrl}";


    }
}