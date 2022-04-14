using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class PersonProfile : Profile
    {

        private readonly IMapper _mapper;
        public PersonProfile(IMapper mapper)
        {

            _mapper = mapper;
        }
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
             .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
              .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));


            CreateMap<PersonDto, Person>();

        }



    }

}
