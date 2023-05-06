namespace WebApi.Models.Dtos
{
	public class ProductRatingDto
	{
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int Rating { get; set; }
		public DateTime CreatedAt { get; set; }
		public string Comment { get; set; }
		public string User { get; set; }
	}
}
