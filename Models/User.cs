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
}
