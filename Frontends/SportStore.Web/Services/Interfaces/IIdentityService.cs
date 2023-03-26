using IdentityModel.Client;
using SportStore.Shared.Dtos;
using SportStore.Web.Models;

namespace SportStore.Web.Services.Interfaces;

public interface IIdentityService
{
    Task<Response<bool>> SignIn(SigninInput signinInput);

    Task<TokenResponse> GetAccesTokenByRefreshToken();

    Task RevokeRefreshToken();
}

