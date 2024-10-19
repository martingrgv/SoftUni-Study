﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DeskMarket.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);

            //builder
            //    .Entity<Category>()
            //    .HasData(
            //        new Category { Id = 1, Name = "Laptops" },
            //        new Category { Id = 2, Name = "Workstations" },
            //        new Category { Id = 3, Name = "Accessories" },
            //        new Category { Id = 4, Name = "Desktops" },
            //        new Category { Id = 5, Name = "Monitors" });
        }
    }
}
