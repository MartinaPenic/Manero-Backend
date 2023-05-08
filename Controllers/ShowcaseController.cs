using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShowcaseController : ControllerBase
	{
		private readonly ShowcaseService _showcaseService;

		public ShowcaseController(ShowcaseService showcaseService)
		{
			_showcaseService = showcaseService;
		}

		[Route("create")]
		[HttpPost]
		public async Task<IActionResult> AddShowcase(AddShowcaseDto dto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _showcaseService.AddShowcaseAsync(dto);

			if (result == true) { return Ok(dto); }
			return StatusCode(500);
		}


		[Route("new")]
		[HttpGet]
		public async Task<IActionResult> GetNewShowcase()
		{
			var showcase = await _showcaseService.GetNewShowcaseAsync();

			if (showcase is null) return NoContent();
			return Ok(showcase);
		}
	}
}
