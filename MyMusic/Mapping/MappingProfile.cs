
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
            CreateMap<MusicResource,Music>();
           
            CreateMap<ArtistResource, Artist>();
            CreateMap<Artist, ArtistResource>();

            CreateMap<SaveMusicResource, Music>();
            CreateMap<Music,SaveMusicResource>();

            CreateMap<SaveArtistResource, Artist>();
            CreateMap<Artist, SaveArtistResource>();

        }
    }
}
