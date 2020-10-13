using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
    public class MovieDbContext : DbContext
    {
        public DbSet<MovieAPI.Models.Movie> Movies { get; set; }
        public DbSet<MovieAPI.Models.Genre> Genres { get; set; }
        public DbSet<MovieAPI.Models.MovieGenre> MovieGenres { get; set; }

        public MovieDbContext (DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
            .HasKey(m => new { m.MovieID, m.GenreID });
            modelBuilder.Entity<MovieGenre>()
                .HasOne(m => m.Movie)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(g => g.Genre)
                .WithMany(mg => mg.MovieGenres)
                .HasForeignKey(g => g.GenreID);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=movie4;User Id = dora; Password=0000");
            base.OnConfiguring(optionsBuilder);
        }
            
    }

}
