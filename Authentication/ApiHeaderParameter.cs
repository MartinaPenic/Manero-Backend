using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Authentication
{
	public class ApiHeaderParameter : IOperationFilter
	{
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			operation.Parameters ??= new List<OpenApiParameter>();
			operation.Parameters.Add(new OpenApiParameter
			{
				Name = ApiConstants.ApiKeyHeaderName,
				Required = true,
				In = ParameterLocation.Header,
				Schema = new OpenApiSchema
				{
					Type = "string",
					Default = new OpenApiString("12ff4ab767034f91b7fbf4109bf03af8")
				}
			});
		}
	}
}
