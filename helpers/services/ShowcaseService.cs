using AutoMapper;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
	public class ShowcaseService
	{
		private readonly ShowcaseRepo _showcaseRepo;
		private readonly IMapper _mapper;

		public ShowcaseService(ShowcaseRepo showcaseRepo, IMapper mapper)
		{
			_showcaseRepo = showcaseRepo;
			_mapper = mapper;
		}

		public async Task<bool> AddShowcaseAsync(AddShowcaseDto dto)
		{
			var entity = _mapper.Map<ShowcaseEntity>(dto);
			entity.CreatedAt = DateTime.Now;
			return await _showcaseRepo.AddShowcaseAsync(entity);
		}

		public async Task<ShowcaseDto> GetNewShowcaseAsync()
		{
			return await _showcaseRepo.GetNewShowcaseAsync();
		}

		public async Task<ICollection<ShowcaseDto>> GetAllShowcasesAsync()
		{
			return await _showcaseRepo.GetAllShowcasesAsync();
		}
	}
}
