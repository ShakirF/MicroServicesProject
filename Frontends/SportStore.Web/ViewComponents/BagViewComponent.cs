using Microsoft.AspNetCore.Mvc;
using SportStore.Web.Models.Baskets;
using SportStore.Web.Services.Interfaces;

namespace SportStore.Web.ViewComponents
{

	[ViewComponent(Name = "BagViewComponent")]
	public class BagViewComponent : ViewComponent
	{
		private readonly IBasketService _basketService;

		public BagViewComponent(IBasketService basketService)
		{
			_basketService = basketService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{

			var response = await _basketService.Get();
			if (response != null)
			{
				return View(response);
			}
			else
			{
				return View(new BasketViewModel());
			}

		}
	}
}
