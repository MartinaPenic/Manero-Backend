using System.Text.Json.Serialization;

namespace WebApi.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]

	public enum Color
	{
		White,
		Black,
		Red,
		Green,
		Blue,
		Yellow
	}
}