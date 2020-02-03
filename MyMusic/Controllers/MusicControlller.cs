using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Core;
using MyMusic.Core.Models;
using MyMusic.Core.Services;
using MyMusic.Resources;
using MyMusic.Validators;

namespace MyMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService _musicService;
        private readonly IMapper _mapper;
        public MusicController(IMusicService musicService, IMapper mapper)
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


        [HttpPost]
        public async Task<ActionResult<MusicResource>> CreateMusic([FromBody] SaveMusicResource saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);
            Console.WriteLine(saveMusicResource);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var musicToCreate =   _mapper.Map<SaveMusicResource, Music>(saveMusicResource);
            var newMusic = await _musicService.CreateMusic(musicToCreate);

            var music = await _musicService.GetMusicById(newMusic.Id);
            var musicResource = _mapper.Map<Music, MusicResource>(music);
           
            return Ok(musicResource);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MusicResource>> UpdateMusic(int id,
            [FromBody] SaveMusicResource saveMusicResource)
        {
            var validator = new SaveMusicResourceValidator();
            var validationResult = await validator.ValidateAsync(saveMusicResource);

            var requestInvalid = id == 0 || !validationResult.IsValid;
            if (requestInvalid)
                return BadRequest();

            var musicToBeUpdated = _musicService.GetMusicById(id);
            if (musicToBeUpdated == null)
                return NotFound();

            var music = _mapper.Map<SaveMusicResource, Music>(saveMusicResource);

            await _musicService.UpdateMusic(await musicToBeUpdated, music);

            var updatedMusic = await _musicService.GetMusicById(id);
            var updateMusicResource = _mapper.Map<Music, MusicResource>(updatedMusic);

            return Ok(updateMusicResource);

        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteMusic(int id)
        {
            if (id == 0)
                BadRequest();

            var musicToDelete = _musicService.GetMusicById(id);
            if (musicToDelete == null)
                return NotFound();

            await _musicService.DeleteMusic(await musicToDelete);

            return NoContent();
        }
    }
}
 