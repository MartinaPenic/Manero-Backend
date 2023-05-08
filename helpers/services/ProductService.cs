using AutoMapper;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
	public class ProductService
	{
		private readonly ProductRepo _productRepo;
		private readonly IMapper _mapper;


		public ProductService(ProductRepo productRepo, IMapper mapper)
		{
			_productRepo = productRepo;
			_mapper = mapper;
		}

		public async Task<bool> AddProductAsync(AddProductDto dto)
		{
			var entity = _mapper.Map<ProductEntity>(dto);
			entity.CreatedAt = DateTime.Now;
			entity.ModifiedAt = DateTime.Now;

			return await _productRepo.AddProductAsync(entity);
		}

		public async Task<ICollection<ProductDto>> GetFeaturedProductsAsync()
		{
			return await _productRepo.GetFeaturedProductsAsync();
		}

		public async Task<ICollection<ProductDto>> GetBestSellerProductsAsync()
		{
			return await _productRepo.GetBestSellerProductsAsync();
		}

		public async Task<ProductDto> GetProductAsync(int productId)
		{
			return await _productRepo.GetProductAsync(productId);
		}

		public async Task<ICollection<ProductDto>> GetSpecialOfferProductsAsync(int value)
		{
			return await _productRepo.GetSpecialOfferProductsAsync(value);
		}

		public async Task<ICollection<ProductDto>> GetSearchedProductsAsync(string value)
		{
			return await _productRepo.GetSearchedProductsAsync(value);
		}

		public async Task<ICollection<ProductDto>> GetProductsByCategoryAsync(string categoryName)
		{
			return await _productRepo.GetProductsByCategoryAsync(categoryName);
		}

		public async Task<ICollection<ProductRatingDto>> GetProductRatingsAsync(int productId)
		{
			return await _productRepo.GetProductRatingsAsync(productId);
		}

		public async Task<bool> AddProductRatingAsync(int productId, AddProductRatingDto dto)
		{
			var entity = _mapper.Map<ProductRatingEntity>(dto);
			entity.ProductId = productId;
			entity.CreatedAt = DateTime.Now;

			return await _productRepo.AddProductRatingAsync(entity);
		}

		public async Task<ICollection<ProductDto>> SortByNewestDateAsync()
		{
			return await _productRepo.SortByNewestDateAsync();
		}

		public async Task<ICollection<ProductDto>> SortByOldestDateAsync()
		{
			return await _productRepo.SortByOldestDateAsync();
		}

		public async Task<ICollection<ProductDto>> SortByHighestPriceAsync()
		{
			return await _productRepo.SortByHighestPriceAsync();
		}

		public async Task<ICollection<ProductDto>> SortByLowestPriceAsync()
		{
			return await _productRepo.SortByLowestPriceAsync();
		}

		public async Task<ICollection<ProductDto>> SortByColorAsync(string color)
		{
			return await _productRepo.SortByColorAsync(color);
		}

		public async Task<ICollection<ProductDto>> SortBySizeAsync(string size)
		{
			return await _productRepo.SortBySizeAsync(size);
		}

		public async Task<ICollection<ProductDto>> SortByCategoryAndTypeAsync(string type, string categoryName)
		{
			return await _productRepo.SortByCategoryAndTypeAsync(type, categoryName);
		}
	}
}

	