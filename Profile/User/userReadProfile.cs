using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class UserReadProfile : Profile
    {
        public UserReadProfile()
        {
            CreateMap<User, UserReadDto>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.IdentificationCard, opt => opt.MapFrom(src => src.IdentificationCard))
            .ForMember(dest => dest.PersonReadDto, opt => opt.MapFrom(src => src.Person));
            

            CreateMap<UserReadDto, User>();

        }



    }

}