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
            .HasKey(c => new { c.MovieID, c.GenreID });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=movie;User Id = Dora; Password=0000");
            base.OnConfiguring(optionsBuilder);
        }
            
    }

}
