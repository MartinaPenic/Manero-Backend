using System.Text.Json.Serialization;

namespace WebApi.Models
{
	[JsonConverter(typeof(JsonStringEnumConverter))]

	public enum Size
	{
		S,
		M,
		L,
		XL
	}
}
