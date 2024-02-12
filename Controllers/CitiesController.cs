using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
	public class CitiesController : Controller
	{
		ApplicationDbContext _context;
		IWebHostEnvironment _webHostEnvironment;

		public CitiesController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context)
		{
			_webHostEnvironment = webHostEnvironment;
			_context = context;
		}

		[HttpGet]
		public IActionResult GetIndexView(string search2)
		{
			if (search2 == null)
			{
				return View("Index", _context.Cities.ToList());
			}
			else
			{
				return View("Index", _context.Cities.Where(e => e.CityName.Contains(search2.Trim())).ToList());
			}
		}

		[HttpGet]
		public IActionResult GetDetailsView(int id)
		{
			City city = _context.Cities.Include(e => e.Hotels).FirstOrDefault(e => e.Id == id);

			return View("Details", city);
		}

		[HttpGet]
		public IActionResult GetCreateView()
		{
			return View("Create");
		}

		[HttpPost]
		public IActionResult AddNew(City city, IFormFile? imageFormFile) // FolanAlfolani.png
		{
			// GUID -> Globally Unique Identifier
			if (imageFormFile != null)
			{
				string imgExtension = Path.GetExtension(imageFormFile.FileName); // .png
				Guid imgGuid = Guid.NewGuid(); // xm789-f07li-624yn-uvx98
				string imgName = imgGuid + imgExtension; // xm789-f07li-624yn-uvx98.png
				string imgUrl = "\\images\\" + imgName; //  \images\xm789-f07li-624yn-uvx98.png
				city.ImageUrl = imgUrl;

				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				// FileStream 
				FileStream imgStream = new FileStream(imgPath, FileMode.Create);
				imageFormFile.CopyTo(imgStream);
				imgStream.Dispose();
			}
			else
			{
				city.ImageUrl = "\\images\\No_Image.png";
			}

			if (ModelState.IsValid == true)
			{
				_context.Cities.Add(city);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			else
			{
				return View("Create");
			}
		}


		[HttpGet]
		public IActionResult GetEditView(int id)
		{
			City city = _context.Cities.FirstOrDefault(e => e.Id == id);

			if (city == null)
			{
				return NotFound();
			}
			else
			{
				return View("Edit", city);
			}
		}


		[HttpPost]
		public IActionResult EditCurrent(City city, IFormFile? imageFormFile)
		{
			// GUID -> Globally Unique Identifier
			if (imageFormFile != null)
			{
				if (city.ImageUrl != "\\images\\No_Image.png")
				{
					string oldImgPath = _webHostEnvironment.WebRootPath + city.ImageUrl;

					if (System.IO.File.Exists(oldImgPath) == true)
					{
						System.IO.File.Delete(oldImgPath);
					}
				}


				string imgExtension = Path.GetExtension(imageFormFile.FileName); // .png
				Guid imgGuid = Guid.NewGuid(); // xm789-f07li-624yn-uvx98
				string imgName = imgGuid + imgExtension; // xm789-f07li-624yn-uvx98.png
				string imgUrl = "\\images\\" + imgName; //  \images\xm789-f07li-624yn-uvx98.png
				city.ImageUrl = imgUrl;

				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				// FileStream 
				FileStream imgStream = new FileStream(imgPath, FileMode.Create);
				imageFormFile.CopyTo(imgStream);
				imgStream.Dispose();
			}


			if (ModelState.IsValid == true)
			{
				_context.Cities.Update(city);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			else
			{
				return View("Edit");
			}
		}


		[HttpGet]
		public IActionResult GetDeleteView(int id)
		{
			City city = _context.Cities.Include(e => e.Hotels).FirstOrDefault(e => e.Id == id);

			if (city == null)
			{
				return NotFound();
			}
			else
			{
				return View("Delete", city);
			}
		}


		[HttpPost]
		public IActionResult DeleteCurrent(int id)
		{
			City city = _context.Cities.FirstOrDefault(e => e.Id == id);
			if (city == null)
			{
				return NotFound();
			}
			else
			{
				if (city.ImageUrl != "\\images\\No_Image.png")
				{
					string imgPath = _webHostEnvironment.WebRootPath + city.ImageUrl;

					if (System.IO.File.Exists(imgPath))
					{
						System.IO.File.Delete(imgPath);
					}
				}


				_context.Cities.Remove(city);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
		}


		public string GreetVisitor()
		{
			return "Welcome to Sunrise!";
		}

		public string GreetUser(string name)
		{
			return $"Hi {name}\nHow are you?";
		}

		public string GetAge(string name, int birthYear)
		{
			return $"Hi {name}\nYou are {DateTime.Now.Year - birthYear} years old.";
		}
	}
}
