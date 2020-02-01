using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusic.Core;

namespace MyMusic.Services
{
    public class ArtistService : IArtistService
    {
        public Task<IEnumerable<Artist>> GetAllArtists()
        {
            throw new NotImplementedException();
        }
        public Task<Artist> GetArtistById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Artist> CreateArtist(Artist newArtist)
        {
            throw new NotImplementedException();
        }
        public Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            throw new NotImplementedException();
        }
        public Task DeleteArtist(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
