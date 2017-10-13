using AutoMapper;
using VStore.Controllers.Resources;
using VStore.Models;

namespace VStore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, VideoResource>();
            CreateMap<Genre, GenreResource>();

            CreateMap<VideoResource, Video>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<GenreResource, Genre>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
