using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Entities;

namespace WebApi.Models.Entities
{
	public class ProductRatingEntity
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		public ProductEntity Product { get; set; }

		[Required, Range(1, 5)]
		public int Rating { get; set; }

		[Required]
		public DateTime CreatedAt { get; set; }

		public string Comment { get; set; }

		public string User { get; set; }
	}
}
