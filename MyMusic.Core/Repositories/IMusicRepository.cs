using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyMusic.Core.Models;

namespace MyMusic.Core.Repositories
{
    public interface IMusicRepository : IRepository<Music>
    {
        Task<IEnumerable<Music>> GetAllWithArtistAsync();
        Task<Music> GetWithArtistById(int musicId);
        Task<IEnumerable<Music>> GetAllWithArtistByArtistId(int artistId);
    }
}
