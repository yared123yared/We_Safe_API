using WeSafe.DTO;
using WeSafe.Models;
namespace WeSafe.Profile
using AutoMapper;
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)) 
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            // .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture))
            .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            
            CreateMap<PersonDto, Person>();

        }





    }

}