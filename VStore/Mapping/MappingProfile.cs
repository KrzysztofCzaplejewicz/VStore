using AutoMapper;
using VStore.Controllers.Resources;
using VStore.Models;

namespace VStore.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Video, SaveVideoResource>();
            CreateMap<Video, VideoResource>().ForMember(x => x.Genre, opt => opt.MapFrom(x => new KeyValuePair() { Id = x.GenreId, Name = x.Genre.Name }));
            CreateMap<Genre, GenreResource>();
            CreateMap<Genre, KeyValuePair>();


            CreateMap<SaveVideoResource, Video>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<GenreResource, Genre>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
