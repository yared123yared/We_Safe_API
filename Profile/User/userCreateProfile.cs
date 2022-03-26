using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class UserCreatProfile : Profile
    {
        private readonly IMapper _mapper;
        public UserCreatProfile(IMapper mapper)
        {

            _mapper = mapper;
        }

        public UserCreatProfile()
        {
            CreateMap<User, UserCreatDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.IdentificationCard, opt => opt.MapFrom(src => src.IdentificationCard))
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));


            CreateMap<UserCreatDto, User>();

        }



    }

}