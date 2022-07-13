using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyPlaylists.Models;

namespace MyPlaylists
{
    public class MyPlaylistsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<PlaylistSong> PlaylistsSongs { get; set; }
        public DbSet<Tag> Tags { get; set; } 
        public DbSet<TagPlaylist> TagsPlaylists { get; set; }
        public string DbPath { get; }
        public MyPlaylistsDbContext()
        {
           
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "MyPlaylists.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasMany(e => e.Playlists)
                .WithOne(e => e.User);

            modelBuilder
                .Entity<Playlist>()
                .HasMany(e => e.PlaylistsSongs)
                .WithOne(e => e.Playlist);

            modelBuilder
                .Entity<Song>()
                .HasMany(e => e.PlaylistsSongs)
                .WithOne(e => e.Song);
            modelBuilder

                .Entity<Tag>()
                .HasMany(e => e.TagsPlaylists)
                .WithOne(e => e.Tag);

            //modelBuilder.Entity<PlaylistSong>()
            //.HasKey(x => new { x.PlaylistId, x.SongId });

            //modelBuilder.Entity<PlaylistSong>()
            //    .HasOne(p => p.Playlist)
            //    .WithMany(p => p.PlaylistsSongs)
            //    .IsRequired();

            //modelBuilder.Entity<PlaylistSong>()
            //    .HasOne(p => p.Song)
            //    .WithMany(p => p.PlaylistsSongs)
            //    .IsRequired();

            //modelBuilder.Entity<TagPlaylist>()
            //.HasKey(x => new { x.TagId, x.PlaylistId });

            //modelBuilder.Entity<TagPlaylist>()
            //    .HasOne(p => p.Playlist)
            //    .WithMany(p => p.TagPlaylists)
            //   .IsRequired();

            //modelBuilder.Entity<TagPlaylist>()
            //    .HasOne(p => p.Tag)
            //    .WithMany(p => p.TagsPlaylists)
            //    .IsRequired();
        }
    }
}
