using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class CriminalProfile : Profile
    {
        public CriminalProfile()
        {
            CreateMap<Criminal, CriminalDto>()

            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images));
            CreateMap<CriminalDto, Criminal>();
        }

    }
}