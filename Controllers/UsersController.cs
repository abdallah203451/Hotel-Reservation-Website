using AutoMapper;
using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Final_Project.Controllers
{
	public class UsersController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly SignInManager<User> _signManager;

		public UsersController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper, SignInManager<User> signManager)
		{
			_context = context;
			_userManager = userManager;
			_mapper = mapper;
			_signManager = signManager;
		}

		[HttpGet]
		public IActionResult GetIndexViewLogin()
		{
			return View("Login");
		}

		[HttpGet]
		public IActionResult GetIndexViewRegister()
		{
			return View("Register");
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserDto userDto, bool isAdmin) // FolanAlfolani.png
		{
			if (userDto != null)
			{
				var user = _mapper.Map<User>(userDto);
				user.UserName = userDto.Email;

				var result = await _userManager.CreateAsync(user, userDto.Password);

				if(result.Succeeded)
				{
					if(isAdmin)
					{
						await _userManager.AddToRoleAsync(user, "Administrator");
					}
					else
					{
						await _userManager.AddToRoleAsync(user, "User");
					}
				}
				return RedirectToAction("GetIndexView", "Hotels");
			}
			else
			{
				return RedirectToAction("GetIndexView", "Hotels");
			}
			
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginDto loginDto) // FolanAlfolani.png
		{
			bool isvalidUser = false;

			try
			{
				var user = await _userManager.FindByEmailAsync(loginDto.Email);
				isvalidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);
				if (isvalidUser)
				{
					await _signManager.SignInAsync(user,true);
					return RedirectToAction("GetIndexView", "Hotels");
				}
			}
			catch (Exception ex)
			{
				return Unauthorized();
			}

			return Unauthorized();
		}

	}
}
