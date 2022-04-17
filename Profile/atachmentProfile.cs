using WeSafe.DTO;
using WeSafe.Models;

using AutoMapper;
namespace WeSafe.Profiles
{


    public class AttachmentProfile : Profile
    {

        private readonly IMapper _mapper;
        public AttachmentProfile(IMapper mapper)
        {

            _mapper = mapper;
        }
        public AttachmentProfile()
        {
            CreateMap<Attachment, AttachmentDto>()
            .ForMember(dest => dest.AttachmentId, opt => opt.MapFrom(src => src.AttachmentId))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                    .ForMember(dest => dest.video, opt => opt.MapFrom(src => src.video))
            .ForMember(dest => dest.Voice, opt => opt.MapFrom(src => src.Voice));


            CreateMap<AttachmentDto, Attachment>();

        }



    }

}