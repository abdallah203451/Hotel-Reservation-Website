using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Final_Project.Models
{
	public class City
	{
		public int Id { get; set; }


		[DisplayName("City Name")]
		[Required(ErrorMessage = "You have to provide a valid City Name.")]
		[MinLength(3, ErrorMessage = "City Name mustn't be less than 3 characters.")]
		[MaxLength(30, ErrorMessage = "City Name mustn't exceed 30 characters.")]
		public string CityName { get; set; }

		[DisplayName("Country Name")]
		[Required(ErrorMessage = "You have to provide a valid Country Name.")]
		[MinLength(3, ErrorMessage = "Country Name mustn't be less than 3 characters.")]
		[MaxLength(30, ErrorMessage = "Country Name mustn't exceed 30 characters.")]
		public string CountryName { get; set; }

		[DisplayName("Image")]
		[ValidateNever]//make this prop can be missing bec. the default of prop is that it must be entered
		public string ImageUrl { get; set; }

		//Navigation Property
		[ValidateNever]
		public List<Hotel> Hotels { get; set; }
	}
}
