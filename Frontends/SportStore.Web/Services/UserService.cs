using SportStore.Web.Models;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public async Task<UserViewModel> GetUser()
    {
        return await _httpClient.GetFromJsonAsync<UserViewModel>("/api/user/getuser");
    }
}

