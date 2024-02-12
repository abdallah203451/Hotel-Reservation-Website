using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Final_Project.Models
{
	public class Hotel
	{
		public int Id { get; set; }


		[DisplayName("Name")]
		[Required(ErrorMessage = "You have to provide a valid name.")]
		[MinLength(2, ErrorMessage = "Name mustn't be less than 2 characters.")]
		[MaxLength(20, ErrorMessage = "Name mustn't exceed 20 characters.")]
		public string Name { get; set; }

		[DisplayName("Description")]
		[Required(ErrorMessage = "You have to provide a valid Description.")]
		[MinLength(10, ErrorMessage = "Description mustn't be less than 10 characters.")]
		[MaxLength(120, ErrorMessage = "Description mustn't exceed 120 characters.")]
		public string Description { get; set; }

		[DisplayName("Rate")]
		[Required(ErrorMessage = "You have to provide a valid Rate.")]
		[Range(0, 10, ErrorMessage = "Rate must be brtween 0 and 10.")]
		public float Rate { get; set; }

		[DisplayName("Star")]
		[Required(ErrorMessage = "You have to provide a valid number of Stars.")]
		[Range(3, 7, ErrorMessage = "number of Stars must be brtween 3 and 7.")]
		public byte Star { get; set; }

		[DisplayName("Price")]
		[Required(ErrorMessage = "You have to provide a valid Price.")]
		[Range(200, int.MaxValue, ErrorMessage = "Price must be greater than 200 EGP per day.")]
		public float Price { get; set; }

		[DisplayName("Image")]
		[ValidateNever]//make this prop can be missing bec. the default of prop is that it must be entered
		public string ImageUrl { get; set; }

		[DisplayName("City Name")]
		public int CityId { get; set; }

		//Navigation Property
		[ValidateNever]
		public City City { get; set; }

	}
}
