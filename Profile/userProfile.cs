using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class UserReadProfile : Profile
    {

        private readonly IMapper _mapper;
        public UserReadProfile(IMapper mapper)
        {

            _mapper = mapper;
        }
        public UserReadProfile()
        {
            CreateMap<User, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.IdentificationCard, opt => opt.MapFrom(src => src.IdentificationCard))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));


            CreateMap<UserDto, User>();

        }



    }

}