using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Dtos
{
	public class AddShowcaseDto
	{
		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string Subtitle { get; set; }

		[Required]
		public string ImageUrl { get; set; }
	}
}
