using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers.Services;
using WebApi.Models.Dtos;

namespace WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ProductService _productService;

		public ProductController(ProductService productService)
		{
			_productService = productService;
		}

		[Route("create")]
		[HttpPost]
		public async Task<IActionResult> AddProduct(AddProductDto newProduct)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var result = await _productService.AddProductAsync(newProduct);

			if (result) return Ok();
			return StatusCode(500);
		}

		[Route("featured")]
		[HttpGet]
		public async Task<IActionResult> GetFeaturedProducts()
		{
			var products = await _productService.GetFeaturedProductsAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[Route("bestseller")]
		[HttpGet]
		public async Task<IActionResult> GetBestSellerProducts()
		{
			var products = await _productService.GetBestSellerProductsAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[HttpGet("{productId}")]
		public async Task<IActionResult> GetProduct(int productId)
		{
			var product = await _productService.GetProductAsync(productId);

			if (product == null) return NotFound();
			return Ok(product);
		}

		[Route("offer/{discountValue}")]
		[HttpGet]
		public async Task<IActionResult> GetSpecialOffer(int discountValue)
		{
			var products = await _productService.GetSpecialOfferProductsAsync(discountValue);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[Route("search/{value}")]
		[HttpGet]
		public async Task<IActionResult> GetSearchedProducts(string value)
		{
			var products = await _productService.GetSearchedProductsAsync(value);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[Route("sort/category/{categoryName}")]
		[HttpGet]
		public async Task<IActionResult> GetProductsByCategory(string categoryName)
		{
			var products = await _productService.GetProductsByCategoryAsync(categoryName);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}


		[Route("{productId}/ratings")]
		[HttpGet]
		public async Task<IActionResult> GetProductRatings(int productId)
		{
			var ratings = await _productService.GetProductRatingsAsync(productId);

			if (ratings.Count() == 0) return NoContent();
			return Ok(ratings);
		}

		[Route("{productId}/ratings/create")]
		[HttpPost]
		public async Task<IActionResult> AddProductRating(int productId, AddProductRatingDto productRating)
		{
			var product = await _productService.GetProductAsync(productId);
			if (product is null) return NotFound();

			var result = await _productService.AddProductRatingAsync(productId, productRating);

			if (result) return Ok();
			return StatusCode(500);
		}

		[Route("sort/newest-date")]
		[HttpGet]
		public async Task<IActionResult> SortByNewestDate()
		{
			var products = await _productService.SortByNewestDateAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}


		[Route("sort/oldest-date")]
		[HttpGet]
		public async Task<IActionResult> SortByOldestDate()
		{
			var products = await _productService.SortByOldestDateAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[Route("sort/highest-price")]
		[HttpGet]
		public async Task<IActionResult> SortByHighestPrice()
		{
			var products = await _productService.SortByHighestPriceAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[Route("sort/lowest-price")]
		[HttpGet]
		public async Task<IActionResult> SortByLowestPrice()
		{
			var products = await _productService.SortByLowestPriceAsync();

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[Route("sort/color/{color}")]
		[HttpGet]
		public async Task<IActionResult> SortByColor(string color)
		{
			var products = await _productService.SortByColorAsync(color);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}

		[Route("sort/size/{size}")]
		[HttpGet]
		public async Task<IActionResult> SortBySize(string size)
		{
			var products = await _productService.SortBySizeAsync(size);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}


		[Route("sort/type/{type}/{categoryName}")]
		[HttpGet]
		public async Task<IActionResult> SortByCategoryAndType(string type, string categoryName)
		{
			var products = await _productService.SortByCategoryAndTypeAsync(type, categoryName);

			if (products.Count() == 0) return NoContent();
			return Ok(products);
		}
	}
}

