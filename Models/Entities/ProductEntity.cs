using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace WebApi.Models.Entities
{
	public class ProductEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required]
		public decimal Price { get; set; }

		public int? Discount { get; set; }

		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
		public CategoryEntity Category { get; set; }

		[Required]
		public Color Color { get; set; }

		[Required]
		public Size Size { get; set; }

		[Required]
		public string PictureUrl { get; set; }

		[Required]
		public bool IsFeatured { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; }

		[Required]
		public DateTime ModifiedAt { get; set; }

		[Required]
		public string SKU { get; set; }

		[Required]
		public string Brand { get; set; }

		public List<ProductRatingEntity> Ratings { get; set; } = new List<ProductRatingEntity>();
	}
}
