using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Repositories
{
	public class ShowcaseRepo
	{

		private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ShowcaseRepo(DataContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<bool> AddShowcaseAsync(ShowcaseEntity entity)
		{
			try
			{
				_context.Showcases.Add(entity);
				await _context.SaveChangesAsync();

				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<ShowcaseEntity> GetNewShowcaseAsync()
		{
			return await _context.Showcases.OrderByDescending(s => s.CreatedAt).FirstOrDefaultAsync();
		}
	}
}
