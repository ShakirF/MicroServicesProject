using Microsoft.AspNetCore.Mvc;

namespace SportStore.Web.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Contact()
		{
			return View();
		}
	}
}
