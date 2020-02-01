using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Core;
using MyMusic.Core.Services;
using MyMusic.Resources;

namespace MyMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicControlller : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        public MusicControlller(IMusicService musicService, IMapper mapper)
        {
            this._musicService = musicService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicResource>>> GetAllMusics()
        {
            var musics = await _musicService.GetAllWithArtist();
            var musicResources = _mapper.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);

            return Ok(musicResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MusicResource>>> GetMusicById(int id)
        {
            var music = await _musicService.GetMusicById(id);
            var musicResources = _mapper.Map<Music,MusicResource>(music);

            return Ok(musicResources);
        }

    }
}
 