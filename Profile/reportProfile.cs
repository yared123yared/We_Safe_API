using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.ReportDate, opt => opt.MapFrom(src => src.ReportDate))
            .ForMember(dest => dest.ReportedBy, opt => opt.MapFrom(src => src.ReportedBy))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Evidence, opt => opt.MapFrom(src => src.Evidence));

            CreateMap<ReportDto, Report>();

        }


    }

}