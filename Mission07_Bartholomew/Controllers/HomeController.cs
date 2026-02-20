using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission07_Bartholomew.Models;
using System.Linq;

namespace Mission07_Bartholomew.Controllers
{
	public class HomeController : Controller
	{
		private MovieCollectionContext _context;

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
			// Pass categories to the view for the dropdown
			ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
			return View(new Movie());
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
				ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
				return View(response);
			}
		}

		// Action to list out all movies from the database
		[HttpGet]
		public IActionResult MovieList()
		{
			var movies = _context.Movies
				.Include(x => x.Category) // Include the category data to display the name instead of the ID
				.OrderBy(x => x.Title)
				.ToList();

			return View(movies);
		}

		// Action to load the edit view
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var recordToEdit = _context.Movies.Single(x => x.MovieId == id);
			ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();

			return View("MovieForm", recordToEdit);
		}

		// Action to save the edits
		[HttpPost]
		public IActionResult Edit(Movie updatedInfo)
		{
			if (ModelState.IsValid)
			{
				_context.Update(updatedInfo);
				_context.SaveChanges();
				return RedirectToAction("MovieList");
			}
			else
			{
				ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
				return View("MovieForm", updatedInfo);
			}
		}

		// Action to load the delete confirmation view
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
			return View(recordToDelete);
		}

		// Action to execute the deletion
		[HttpPost]
		public IActionResult Delete(Movie movie)
		{
			_context.Movies.Remove(movie);
			_context.SaveChanges();
			return RedirectToAction("MovieList");
		}
	}
}