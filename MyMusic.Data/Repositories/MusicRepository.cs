using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyMusic.Core;
using MyMusic.Core.Repositories;

namespace MyMusic.Data.Repositories
{
    public class MusicRepository : Repository<Music>,IMusicRepository
    {
       
        public MusicRepository(MyMusicDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await MyMusicDbContext.Musics
                .Include(m => m.Artist)
                .ToListAsync();
        }

        public async Task<Music> GetWithArtistById(int musicId)
        {
            return await MyMusicDbContext.Musics
                .Include(m => m.Artist)
                .SingleOrDefaultAsync(m => m.Id == musicId);
        }

        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistId(int artistId)
        {
            return await MyMusicDbContext.Musics
                .Include(m => m.Artist)
                .Where(m => m.Id == artistId)
                .ToListAsync();
        }
        private MyMusicDbContext MyMusicDbContext
        {
            get { return MyMusicDbContext; }
        }
    }
}