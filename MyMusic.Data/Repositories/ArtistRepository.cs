using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyMusic.Core;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;

namespace MyMusic.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MyMusicDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Artist>> GetAllWithMusicAsync()
        {
           return await myMusicDbContext.Artists
                .Include(A => A.Musics)
                .ToListAsync();
        }

        public async Task<Artist> GetWithMusicByIdAsync(int id)
        {
            return await myMusicDbContext.Artists
                .Include(A => A.Musics)
                .SingleOrDefaultAsync();
        }

        private MyMusicDbContext myMusicDbContext
        {
            get { return _context as MyMusicDbContext; }
        }
    }
}