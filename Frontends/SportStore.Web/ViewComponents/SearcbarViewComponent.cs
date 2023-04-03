using Microsoft.AspNetCore.Mvc;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.ViewComponents
{
	[ViewComponent(Name = "SearcbarViewComponent")]
	public class SearcbarViewComponent : ViewComponent
	{
		private readonly ICatalogService _catalogService;

		public SearcbarViewComponent(ICatalogService catalogService)
		{
			_catalogService = catalogService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var response = await _catalogService.GetAllCategoryAsync();

			return View(response);
		}
	}
}
