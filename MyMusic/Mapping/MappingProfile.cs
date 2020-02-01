using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyMusic.Core;
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
        }
    }
}
