using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Core.Models;
using MyMusic.Core.Services;
using MyMusic.Resources;
using MyMusic.Validators;

namespace MyMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistController(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }
        // GET: api/Artist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistResource>>> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtists();
           var artistResource =  _mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistResource>>(artists);

            return Ok(artistResource);
        }

        // GET: api/Artist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistResource>> GetArtistById(int id)
        {
            if (id == 0)
                return BadRequest();

            var artist = await _artistService.GetArtistById(id);
            if (artist == null)
                return NotFound();
            var artistResource = _mapper.Map<Artist, ArtistResource>(artist);
            return Ok(artistResource);
        }

        // POST: api/Artist
        [HttpPost]
        public async Task<ActionResult<ArtistResource>> CreateArtist([FromBody] SaveArtistResource saveArtistResource)
        {
            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var artistToCreate = _mapper.Map<SaveArtistResource, Artist>(saveArtistResource);
            var newArtist = await _artistService.CreateArtist(artistToCreate);

            var artistResource = _mapper.Map<Artist, SaveArtistResource>(newArtist);

            return Ok(artistResource);
        }

        // PUT: api/Artist/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ArtistResource>> UpdateArtist(int id, [FromBody] SaveArtistResource saveArtistResource)
        {

            var validator = new SaveArtistResourceValidator();
            var validationResult = await validator.ValidateAsync(saveArtistResource);

            if (!validationResult.IsValid || id == 0)
            {
                return BadRequest(validationResult.Errors);
            }

            var artistToUpdated = await _artistService.GetArtistById(id);

            if (artistToUpdated == null)
                return BadRequest();

            var artist = _mapper.Map<SaveArtistResource, Artist>(saveArtistResource);
            await _artistService.UpdateArtist(artistToUpdated, artist);

            var updatedArtist = _artistService.GetArtistById(artist.Id);
            var updatedArtistResource = _mapper.Map<Artist, ArtistResource>(await updatedArtist);

            return Ok(updatedArtistResource);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            if (id == 0)
                return BadRequest();
            var ArtistToDelete = _artistService.GetArtistById(id);

            await _artistService.DeleteArtist(await ArtistToDelete);

            return NoContent();
        }
    }
}
