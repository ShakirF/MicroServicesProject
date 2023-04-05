using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SportStore.Web.Models;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.Controllers;

public class AuthController : Controller
{
	private readonly IIdentityService _identityService;
	private readonly IRegisterService _registerService;


	public AuthController(IIdentityService identityService, IUserService userService, IRegisterService registerService)
	{
		this._identityService = identityService;
		this._registerService = registerService;
	}

	public IActionResult SignIn()
	{
		return View();
	}
	[HttpPost]
	public async Task<IActionResult> SignIn(SigninInput signinInput)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		var response = await _identityService.SignIn(signinInput);
		if (!response.IsSuccessful)
		{
			response.Errors.ToList().ForEach(x =>
			{
				ModelState.AddModelError(String.Empty, x);
			});


			return View();
		}


		return RedirectToAction(nameof(Index), "Home");

	}
	public IActionResult SignUp()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> SignUp(SignUpInput signUpInput)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		var response = await _registerService.SignUp(signUpInput);
		if (!response)
		{
			return View();
		}

		return RedirectToAction("SignIn", "Auth");

	}


	public async Task<IActionResult> LogOut()
	{
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		await _identityService.RevokeRefreshToken();
		return RedirectToAction(nameof(HomeController.Index), "Home");
	}
}

