﻿using Microsoft.EntityFrameworkCore;

namespace Authentication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
    }
}