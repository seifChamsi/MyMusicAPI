using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusic.Core;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

namespace MyMusic.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Artist>> GetAllArtists()
        {
            return await _unitOfWork.Artists.GetAllWithMusicAsync();
        }
        public async Task<Artist> GetArtistById(int id)
        {
            return await _unitOfWork.Artists.GetWithMusicByIdAsync(id);
        }
        public async Task<Artist> CreateArtist(Artist newArtist)
        {
             await _unitOfWork.Artists.AddAsync(newArtist);
             await _unitOfWork.CommitAsync();
             return newArtist;
        }
        public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            artistToBeUpdated.Name = artist.Name;
            await _unitOfWork.CommitAsync();

        }
        public async Task DeleteArtist(Artist artist)
        {
            _unitOfWork.Artists.Remove(artist);
           await _unitOfWork.CommitAsync();
        }
    }
}
