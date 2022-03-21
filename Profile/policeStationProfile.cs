using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class PoliceStationProfile : Profile
    {
        public PoliceStationProfile()
        {
            CreateMap<PoliceStation, PoliceStationDto>()
            .ForMember(dest => dest.PoliceStationId, opt => opt.MapFrom(src => src.PoliceStationId))
            .ForMember(dest => dest.PoliceStationName, opt => opt.MapFrom(src => src.PoliceStationName))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
            .ForMember(dest => dest.Subcity, opt => opt.MapFrom(src => src.Subcity))
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
            .ForMember(dest => dest.Longtiude, opt => opt.MapFrom(src => src.Longtiude))
            .ForMember(dest => dest.Wereda, opt => opt.MapFrom(src => src.Wereda));


            CreateMap<PoliceStationDto, PoliceStation>();

        }



    }

}