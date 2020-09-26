using GameLibrary.Pocos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.EntityFrameworkDataAccess
{
    public class GameLibraryContext : DbContext
    {
        public DbSet<DeveloperPoco> Developers { get; set; }
        public DbSet<GamePoco> Games { get; set; }
        public DbSet<PublisherPoco> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase("GameLibraryDB");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePoco>()
               .HasOne(x => x.Developer)
               .WithMany(y => y.Games)
               .HasForeignKey(x => x.DeveloperId);
            modelBuilder.Entity<DeveloperPoco>()
               .HasOne(x => x.Publisher)
               .WithMany(y => y.Developers)
               .HasForeignKey(x => x.PublisherId);
        }
    }
}
