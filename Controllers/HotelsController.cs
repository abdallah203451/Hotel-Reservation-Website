using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
	public class HotelsController : Controller
	{
		ApplicationDbContext _context;
		//SignInManager<User> signinManager;
		UserManager<User> userManager;
		IWebHostEnvironment _webHostEnvironment;

		public HotelsController(IWebHostEnvironment webHostEnvironment, ApplicationDbContext context, UserManager<User> userManager)
		{
			_webHostEnvironment = webHostEnvironment;
			_context = context;
			this.userManager = userManager;
			//this.signinManager = signinManager;
			this.userManager = userManager;
		}

		[HttpGet]
		public IActionResult GetIndexView(string search, float search1)
		{
			if (search == null)
			{
				if (search1 == 0)
				{
					return View("Index", _context.Hotels.ToList());
				}
				else
				{
					return View("Index", _context.Hotels.Where(e => e.Price <= search1).ToList());
				}
			}
			else
			{
				if (search1 == 0)
				{
					return View("Index", _context.Hotels.Where(e => e.Name.Contains(search.Trim())).ToList());
				}
				else
				{
					return View("Index", _context.Hotels.Where(e => e.Name.Contains(search.Trim()) && e.Price <= search1).ToList());
				}
			}
		}

		[HttpGet]
		public IActionResult GetDetailsView(int id)
		{
			Hotel hotel = _context.Hotels.Include(e => e.City).FirstOrDefault(e => e.Id == id);

			return View("Details", hotel);
		}

		[HttpGet]
		public IActionResult GetCreateView()
		{
			ViewBag.CitySelectItems = new SelectList(_context.Cities.ToList(), "Id", "CityName");
			return View("Create");
		}

		[HttpPost]
		public IActionResult AddNew(Hotel hotel, IFormFile? imageFormFile) // FolanAlfolani.png
		{
			// GUID -> Globally Unique Identifier
			if (imageFormFile != null)
			{
				string imgExtension = Path.GetExtension(imageFormFile.FileName); // .png
				Guid imgGuid = Guid.NewGuid(); // xm789-f07li-624yn-uvx98
				string imgName = imgGuid + imgExtension; // xm789-f07li-624yn-uvx98.png
				string imgUrl = "\\images\\" + imgName; //  \images\xm789-f07li-624yn-uvx98.png
				hotel.ImageUrl = imgUrl;

				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				// FileStream 
				FileStream imgStream = new FileStream(imgPath, FileMode.Create);
				imageFormFile.CopyTo(imgStream);
				imgStream.Dispose();
			}
			else
			{
				hotel.ImageUrl = "\\images\\No_Image.png";
			}

			if (hotel.Rate > 10 || hotel.Rate < 0)
            {
                ModelState.AddModelError(string.Empty, "Rate mustn't be less than 0 or greater than 10.");
            }
            if (hotel.Star > 7 || hotel.Star < 3)
            {
                ModelState.AddModelError(string.Empty, "Star mustn't be less than 3 or greater than 7.");
            }
            if (hotel.Price < 100)
            {
                ModelState.AddModelError(string.Empty, "Price mustn't be less than 100.");
            }

			if (ModelState.IsValid == true)
			{
				_context.Hotels.Add(hotel);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			else
			{
				ViewBag.CitySelectItems = new SelectList(_context.Cities.ToList(), "Id", "CityName");
				return View("Create");
			}
		}


		[HttpGet]
		public IActionResult GetEditView(int id)
		{
			Hotel hotel = _context.Hotels.FirstOrDefault(e => e.Id == id);

			if (hotel == null)
			{
				return NotFound();
			}
			else
			{
				ViewBag.CitySelectItems = new SelectList(_context.Cities.ToList(), "Id", "CityName");
				return View("Edit", hotel);
			}
		}


		[HttpPost]
		public IActionResult EditCurrent(Hotel hotel, IFormFile? imageFormFile)
		{
			// GUID -> Globally Unique Identifier
			if (imageFormFile != null)
			{
				if (hotel.ImageUrl != "\\images\\No_Image.png")
				{
					string oldImgPath = _webHostEnvironment.WebRootPath + hotel.ImageUrl;

					if (System.IO.File.Exists(oldImgPath) == true)
					{
						System.IO.File.Delete(oldImgPath);
					}
				}


				string imgExtension = Path.GetExtension(imageFormFile.FileName); // .png
				Guid imgGuid = Guid.NewGuid(); // xm789-f07li-624yn-uvx98
				string imgName = imgGuid + imgExtension; // xm789-f07li-624yn-uvx98.png
				string imgUrl = "\\images\\" + imgName; //  \images\xm789-f07li-624yn-uvx98.png
				hotel.ImageUrl = imgUrl;

				string imgPath = _webHostEnvironment.WebRootPath + imgUrl;

				// FileStream 
				FileStream imgStream = new FileStream(imgPath, FileMode.Create);
				imageFormFile.CopyTo(imgStream);
				imgStream.Dispose();
			}




            if (ModelState.IsValid == true)
			{
				_context.Hotels.Update(hotel);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
			else
			{
				ViewBag.CitySelectItems = new SelectList(_context.Cities.ToList(), "Id", "CityName");
				return View("Edit", hotel);
			}
		}


		[HttpGet]
		public IActionResult GetDeleteView(int id)
		{
			Hotel hotel = _context.Hotels.Include(e => e.City).FirstOrDefault(e => e.Id == id);

			if (hotel == null)
			{
				return NotFound();
			}
			else
			{
				return View("Delete", hotel);
			}
		}


		[HttpPost]
		public IActionResult DeleteCurrent(int id)
		{
			Hotel hotel = _context.Hotels.FirstOrDefault(e => e.Id == id);
			if (hotel == null)
			{
				return NotFound();
			}
			else
			{
				if (hotel.ImageUrl != "\\images\\No_Image.png")
				{
					string imgPath = _webHostEnvironment.WebRootPath + hotel.ImageUrl;

					if (System.IO.File.Exists(imgPath))
					{
						System.IO.File.Delete(imgPath);
					}
				}


				_context.Hotels.Remove(hotel);
				_context.SaveChanges();
				return RedirectToAction("GetIndexView");
			}
		}

		[HttpGet]
		public async Task<IActionResult> BookHotel(int id, string? email)
		{

			Hotel hotel = _context.Hotels.FirstOrDefault(e=> e.Id == id);

			User user = await userManager.FindByEmailAsync(email);

			//hotel.Users.Add(user);
			user.Hotels.Add(hotel);

			_context.SaveChanges();
			return RedirectToAction("GetIndexView");
		}

	}
}
