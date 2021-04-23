﻿using System;
using FakeXiecheng.API.Models;
using Microsoft.EntityFrameworkCore;
namespace FakeXiecheng.API.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<TouristRoute> TouristRoutes { get; set; }
        public DbSet<TouristRoutePicture> TourisitRoutePictures { get; set; }
    }
}
