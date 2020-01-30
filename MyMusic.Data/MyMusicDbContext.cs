using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using MyMusic.Core;
using MyMusic.Data.Configurations;

namespace MyMusic.Data
{
    public class MyMusicDbContext : DbContext
    {
        public DbSet<Music> Musics { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public MyMusicDbContext(DbContextOptions<MyMusicDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new MusicConfiguration());

            modelBuilder
                .ApplyConfiguration(new ArtistConfiguration());
        }
    }
}