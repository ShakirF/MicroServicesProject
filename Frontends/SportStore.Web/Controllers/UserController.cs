using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Controllers;

[Authorize]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _userService.GetUser());
    }
}

