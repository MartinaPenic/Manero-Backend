using AutoMapper;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

			CreateMap<ProductEntity, ProductDto>();
			CreateMap<ProductRatingEntity, ProductRatingDto>();
			CreateMap<AddProductDto, ProductEntity>();
			CreateMap<AddProductRatingDto, ProductRatingEntity>();
			CreateMap<ProductEntity, ProductDto>();

		} 
    }
}
