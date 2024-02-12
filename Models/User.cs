using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace Final_Project.Models
{
	public class User : IdentityUser
	{
		[DisplayName("FirstName")]
		public string FirstName { get; set; }

		[DisplayName("LastName")]
		public string LastName { get; set; }

		[DisplayName("Phone")]
		public string Phone { get; set; }
    }

	public class UserDto
	{
		[DisplayName("FirstName")]
		public string FirstName { get; set; }

		[DisplayName("LastName")]
		public string LastName { get; set; }

		[DisplayName("Email")]
		public string Email { get; set; }

		[DisplayName("Password")]
		public string Password { get; set; }

		[DisplayName("Phone")]
		public string Phone { get; set; }
	}

}
