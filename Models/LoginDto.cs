using System.ComponentModel;

namespace Final_Project.Models
{
	public class LoginDto
	{
		public int Id { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }

		[DisplayName("Password")]
		public string Password { get; set; }
	}
}
