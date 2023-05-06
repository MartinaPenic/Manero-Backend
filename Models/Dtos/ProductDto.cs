using WebApi.Models.Entities;

namespace WebApi.Models.Dtos
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int? Discount { get; set; }
		public int CategoryId { get; set; }
		public Color Color { get; set; }
		public Size Size { get; set; }
		public SortingType SortingType { get; set; }
		public string ImageUrl { get; set; }
		public bool IsFeatured { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
		public string SKU { get; set; }
		public string Brand { get; set; }
		public List<ProductRatingEntity> ProductRatings { get; set; }
		public decimal AverageRating => (ProductRatings?.Count is 0) ? 0 : (decimal)ProductRatings.Average(r => r.Rating);
	}
}
