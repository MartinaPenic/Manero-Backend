using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Models.Dtos;
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

		public async Task<ShowcaseDto> GetNewShowcaseAsync()
		{
			var showcase = await _context.Showcases.OrderByDescending(s => s.CreatedAt).FirstOrDefaultAsync();

			return _mapper.Map<ShowcaseDto>(showcase);
		}

		public async Task<ICollection<ShowcaseDto>> GetAllShowcasesAsync()
		{
			var showcases = await _context.Showcases.ToListAsync();

			return _mapper.Map<ICollection<ShowcaseDto>>(showcases);
		}
	}
}
