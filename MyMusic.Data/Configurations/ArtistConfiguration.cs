﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMusic.Core;
using MyMusic.Core.Models;

namespace MyMusic.Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            
        }
    }
}