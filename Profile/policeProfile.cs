using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace  WeSafe.Profiles
{
    

    public class PoliceProfile : Profile
    {
        public PoliceProfile()
        {
            CreateMap<Police, PoliceDto>()
            .ForMember(dest => dest.PoliceId, opt => opt.MapFrom(src => src.PoliceId))
            .ForMember(dest => dest.Experiance, opt => opt.MapFrom(src => src.Experiance))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Level))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person)) 
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
            // .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.PoliceStation, opt => opt.MapFrom(src => src.PoliceStation));
         
            
            CreateMap<PersonDto, Person>();

  



    }

}
}