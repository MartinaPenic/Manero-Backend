using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
