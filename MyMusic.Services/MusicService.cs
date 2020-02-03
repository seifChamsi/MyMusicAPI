﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMusic.Core;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

namespace MyMusic.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MusicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Music>> GetAllWithArtist()
        {
            return await _unitOfWork.Musics.GetAllWithArtistAsync();
        }
        public async Task<Music> GetMusicById(int id)
        {
            return await _unitOfWork.Musics.GetWithArtistById(id);
        }
        public async Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId)
        {
            return await _unitOfWork.Musics.GetAllWithArtistByArtistId(artistId);
        }
        public async Task<Music> CreateMusic(Music newMusic)
        {
            await _unitOfWork.Musics.AddAsync(newMusic);
            await _unitOfWork.CommitAsync();
            return newMusic;
        }
        public async Task UpdateMusic(Music musicToBeUpdated, Music music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.ArtistId = music.ArtistId;
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteMusic(Music music)
        {
             _unitOfWork.Musics.Remove(music);
             await _unitOfWork.CommitAsync();
        }
    }
}
