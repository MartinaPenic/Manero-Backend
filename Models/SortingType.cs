using System.Text.Json.Serialization;

namespace WebApi.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]
	public enum SortingType
	{
		Men,
		Women,
		Kids
	}
}
