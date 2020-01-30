using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Core.Repositories
{
    public interface IMusicRepository
    {
        Task<IEnumerable<Music>> GetAllWithArtist();
        Task<Music> GetWithArtistById();
        Task<IEnumerable<Music>> GetAllWithArtistByArtistId(int artistId);
    }
}
