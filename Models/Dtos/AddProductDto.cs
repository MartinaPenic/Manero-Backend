using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class AddProductDto
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		public int? Discount { get; set; }

		[Required]
		public int CategoryId { get; set; }

		[Required]
		public Color Color { get; set; }

		[Required]
		public Size Size { get; set; }

		[Required]
		public SortingType SortingType { get; set; }

		[Required]
		public string ImageUrl { get; set; }

		[Required]
		public bool IsFeatured { get; set; }

		[Required]
		public string SKU { get; set; }

		[Required]
		public string Brand { get; set; }

	}
}
