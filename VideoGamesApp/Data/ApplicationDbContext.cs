﻿using Microsoft.EntityFrameworkCore;
using VideoGamesApp.Models;

namespace VideoGamesApp.Data
{
    public class ApplicationDbContext : DbContext // the class inherited everything from package
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Strategy", DisplayOrder = 3 }
                );
        }
    }
}
