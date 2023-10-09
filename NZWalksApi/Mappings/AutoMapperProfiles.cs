using AutoMapper;
using NZWalksApi.Models.Domain;
using NZWalksApi.Models.DTO;

namespace NZWalksApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();

            CreateMap<AddRegionRequestDto, Region>().ReverseMap();

            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();

            CreateMap<Walk, WalkDto>().ReverseMap();

            CreateMap<Dificulty, DifficultyDto>().ReverseMap();

            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            CreateMap<ImageUploadRequestDto, Image>().ReverseMap();

            CreateMap<Country, CountryDtoV1>().ReverseMap();

            CreateMap<Country, CountryDtoV2>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        }
    }
}
