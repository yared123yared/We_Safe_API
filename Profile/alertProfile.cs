using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class AlertProfile : Profile
    {
        public AlertProfile()
        {
            CreateMap<Alert, AlertDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                      .ForMember(dest => dest.Longtiude, opt => opt.MapFrom(src => src.Longtiude))
                       .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            CreateMap<AlertDTO, Alert>();

        }

    }

}