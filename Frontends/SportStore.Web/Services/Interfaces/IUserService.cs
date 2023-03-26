using SportStore.Web.Models;

namespace SportStore.Web.Services.Interfaces;

public interface IUserService
{
    Task<UserViewModel> GetUser();

}

