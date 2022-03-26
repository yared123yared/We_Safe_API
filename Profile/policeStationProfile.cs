using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class PoliceStationProfile : Profile
    {
        public PoliceStationProfile()
        {
            CreateMap<Station, StationDto>()
            .ForMember(dest => dest.StationId, opt => opt.MapFrom(src => src.StationId))
            .ForMember(dest => dest.StationName, opt => opt.MapFrom(src => src.StationName))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Subcity, opt => opt.MapFrom(src => src.Subcity))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
            .ForMember(dest => dest.Longtiude, opt => opt.MapFrom(src => src.Longtiude));
            CreateMap<StationDto, Station>();

        }



    }

}