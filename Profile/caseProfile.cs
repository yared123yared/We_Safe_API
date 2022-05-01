using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class CaseProfile : Profile
    {
        public CaseProfile()
        {
            CreateMap<Case, CaseDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.OpenedDate, opt => opt.MapFrom(src => src.OpenedDate))
            .ForMember(dest => dest.ClosedDate, opt => opt.MapFrom(src => src.ClosedDate))
            .ForMember(dest => dest.PoliceId, opt => opt.MapFrom(src => src.PoliceId))
            .ForMember(dest => dest.AssignedPolice, opt => opt.MapFrom(src => src.AssignedPolice))
            .ForMember(dest => dest.ReporterId, opt => opt.MapFrom(src => src.ReporterId))
            .ForMember(dest => dest.ReporterAdmin, opt => opt.MapFrom(src => src.ReporterAdmin))
            .ForMember(dest => dest.Evidence, opt => opt.MapFrom(src => src.Evidence))
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
            // .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            CreateMap<CaseDto, Case>();
        }

    }
}