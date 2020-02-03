
using AutoMapper;
using MyMusic.Core.Models;
using MyMusic.Resources;

namespace MyMusic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();

            CreateMap<MusicResource,Music>();
           
            CreateMap<ArtistResource, Artist>();

            CreateMap<SaveMusicResource, Music>();
            CreateMap<Music,SaveMusicResource>();
        }
    }
}
