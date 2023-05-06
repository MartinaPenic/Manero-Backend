using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
	public class ProductRepo
	{
		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ProductRepo(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<bool> AddProductAsync(ProductEntity newProduct)
		{
			try
			{
				_context.Products.Add(newProduct);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<ICollection<ProductDto>> GetFeaturedProductsAsync()
		{
			var products =
				await _context.Products
				.Where(p => p.IsFeatured)
				.Include(p => p.ProductRatings)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> GetBestSellerProductsAsync()
		{
			var products = await
				_context.Products
				.Where(p => p.ProductRatings.Count > 0)
				.Include(p => p.ProductRatings)
				.OrderByDescending(p => p.ProductRatings.Average(r => r.Rating))
				.Take(2)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ProductDto> GetProductAsync(int productId)
		{
			var product =
				await _context.Products
				.Include(p => p.ProductRatings)
				.FirstOrDefaultAsync(p => p.Id == productId);

			return _mapper.Map<ProductDto>(product);
		}

		// Offer

		public async Task<ICollection<ProductDto>> GetSpecialOfferProductsAsync(int discountValue)
		{
			var products =
				await _context.Products
				.Include(p => p.ProductRatings)
				.Where(p => p.Discount != 0 && p.Discount == discountValue)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		// Search

		public async Task<ICollection<ProductDto>> GetSearchedProductsAsync(string value)
		{
			var products =
				await _context.Products
				.Where(p => p.Name.Contains(value) || p.Description.Contains(value))
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		// ProductRating

		public async Task<bool> AddProductRatingAsync(ProductRatingEntity productRating)
		{
			try
			{
				_context.ProductRatings.Add(productRating);
				await _context.SaveChangesAsync();

				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<ICollection<ProductRatingDto>> GetProductRatingsAsync(int productId)
		{
			var ratings = await _context.ProductRatings
				.Where(r => r.ProductId == productId)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductRatingDto>>(ratings);
		}

		// Sorting

		public async Task<ICollection<ProductDto>> GetProductsByCategoryAsync(string categoryName)
		{
			var products =
				await _context.Products
				.Where(p => p.Category.CategoryName == categoryName)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> SortByNewestDateAsync()
		{
			var products = await _context.Products
				.OrderByDescending(p => p.CreatedAt)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> SortByOldestDateAsync()
		{
			var products = await _context.Products
				.OrderBy(p => p.CreatedAt)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> SortByHighestPriceAsync()
		{
			var products = await _context.Products
				.OrderByDescending(p => p.Price)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> SortByLowestPriceAsync()
		{
			var products = await _context.Products
				.OrderBy(p => p.Price)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> SortByColorAsync(string color)
		{
			if (!Enum.TryParse<Color>(color, true, out var colorEnum))
			{
				throw new ArgumentException($"Invalid color value: {color}");
			}

			var products = await _context.Products
				.Where(p => p.Color == colorEnum)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> SortBySizeAsync(string size)
		{
			if (!Enum.TryParse<Size>(size, true, out var sizeEnum))
			{
				throw new ArgumentException($"Invalid size value: {size}");
			}

			var products = await _context.Products
				.Where(p => p.Size == sizeEnum)
				.ToListAsync();

			return _mapper.Map<ICollection<ProductDto>>(products);
		}

		public async Task<ICollection<ProductDto>> SortByCategoryAndTypeAsync(string type, string categoryName)
		{
			if (!Enum.TryParse<SortingType>(type, true, out var typeEnum))
			{
				throw new ArgumentException($"Invalid type value: {type}");
			}

			var products = await _context.Products
				.Where(p => p.Category.CategoryName == categoryName && p.SortingType == typeEnum)
				.ToListAsync();	
		
			return _mapper.Map<ICollection<ProductDto>>(products);
		}
	}
}

