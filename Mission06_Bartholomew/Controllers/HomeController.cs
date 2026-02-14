using Microsoft.AspNetCore.Mvc;
using Mission06_Bartholomew.Models;
using System.Diagnostics;

namespace Mission06_Bartholomew.Controllers
{
	public class HomeController : Controller
	{
		private MovieCollectionContext _context;

		// Constructor must use MovieCollectionContext
		public HomeController(MovieCollectionContext temp)
		{
			_context = temp;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetToKnowJoel()
		{
			return View();
		}

		[HttpGet]
		public IActionResult MovieForm()
		{
			return View();
		}

		[HttpPost]
		public IActionResult MovieForm(Movie response)
		{
			if (ModelState.IsValid)
			{
				_context.Movies.Add(response);
				_context.SaveChanges();
				return View("Confirmation", response);
			}
			else
			{
				return View(response);
			}
		}
	}
}