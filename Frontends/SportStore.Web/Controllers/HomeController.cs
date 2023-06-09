﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportStore.Web.Exceptions;
using SportStore.Web.Models;
using SportStore.Web.Services.Interfaces;
using System.Diagnostics;

namespace SportStore.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICatalogService _catalogService;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, ICatalogService catalogService)
		{
			_logger = logger;
			_catalogService = catalogService;
		}

		public async Task<IActionResult> Index2()
		{
			return View(await _catalogService.GetAllProductAsync(""));
		}

		public async Task<IActionResult> Index(string categoryId)
		{
			var response = await _catalogService.GetAllProductAsync(categoryId);
			var categories = await _catalogService.GetAllCategoryAsync();

			ViewBag.Categories = categories;
			return View(response);
		}

		public async Task<IActionResult> Detail(string id)
		{
			return View(await _catalogService.GetByProductId(id));
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			var errorFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();

			if (errorFeature != null && errorFeature.Error is UnAuthorizeException)
			{
				return RedirectToAction(nameof(AuthController.LogOut), "Auth");
			}

			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}