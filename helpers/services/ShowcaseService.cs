using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
	public class ShowcaseService
	{
		private readonly ShowcaseRepo _showcaseRepository;
		private readonly IMapper _mapper;

		public ShowcaseService(ShowcaseRepo showcaseRepository, IMapper mapper)
		{
			_showcaseRepository = showcaseRepository;
			_mapper = mapper;
		}

		public async Task<bool> AddShowcaseAsync(AddShowcaseDto dto)
		{
			var entity = _mapper.Map<ShowcaseEntity>(dto);
			entity.CreatedAt = DateTime.Now;
			return await _showcaseRepository.AddShowcaseAsync(entity);
		}

		public async Task<ShowcaseDto> GetNewShowcaseAsync()
		{
			return await _showcaseRepository.GetNewShowcaseAsync();
		}

		public async Task<ICollection<ShowcaseDto>> GetAllShowcasesAsync()
		{
			return await _showcaseRepository.GetAllShowcasesAsync();
		}
	}
}
