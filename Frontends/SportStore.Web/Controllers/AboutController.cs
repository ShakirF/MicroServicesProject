using Microsoft.AspNetCore.Mvc;

namespace SportStore.Web.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult About()
		{
			return View();
		}
	}
}
