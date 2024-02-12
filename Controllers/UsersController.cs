using AutoMapper;
using Final_Project.Data;
using Final_Project.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project.Controllers
{
	public class UsersController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;

		public UsersController(ApplicationDbContext context, UserManager<User> userManager, IMapper mapper)
		{
			_context = context;
			_userManager = userManager;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<IActionResult> Register(UserDto userDto) // FolanAlfolani.png
		{
			if (userDto != null)
			{
				var user = _mapper.Map<User>(userDto);
				user.UserName = userDto.Email;

				var result = await _userManager.CreateAsync(user, userDto.Password);

				if(result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "User");
				}
				return RedirectToAction("GetIndexView", "Hotels");
			}
			else
			{
				return RedirectToAction("GetIndexView", "Hotels");
			}
			
		}

	}
}
