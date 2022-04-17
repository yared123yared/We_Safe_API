using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class PoliceProfile : Profile
    {
        public PoliceProfile()
        {
            CreateMap<Police, PoliceDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Experiance, opt => opt.MapFrom(src => src.Experiance))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
            .ForMember(dest => dest.StationId, opt => opt.MapFrom(src => src.StationId))
            // .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
            .ForMember(dest => dest.Station, opt => opt.MapFrom(src => src.Station));


            CreateMap<PoliceDto, Police>();





        }

        // public Person changeToPerson(PersonDto personDto){

        // }



    }
}