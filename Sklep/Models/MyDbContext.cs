using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Sklep.Models.DbModels;

namespace Sklep.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieGenre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        // configures one-to-many relationship
            modelBuilder.Entity<UserAccount>()
            .HasRequired<Role>(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey<int>(u => u.RoleId);

            modelBuilder.Entity<Movie>()
            .HasRequired<Director>(m => m.Director)
            .WithMany(d => d.Movies)
            .HasForeignKey<int>(m => m.DirectorId);

            modelBuilder.Entity<Movie>()
            .HasRequired<MovieGenre>(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey<int>(m => m.GenreId); 
               
        }
    }
}