namespace WebApi.Models.Dtos
{
	public class AddProductRatingDto
	{
		public int Rating { get; set; }
		public string Comment { get; set; }
		public string User { get; set; }
	}
}
