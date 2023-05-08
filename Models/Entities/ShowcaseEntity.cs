using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
	public class ShowcaseEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public string Subtitle { get; set; }

		[Required]
		public string ImageUrl { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; }	
	}
}
