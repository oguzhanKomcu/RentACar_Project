﻿using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public DbSet<Brand> Brands { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;

        }


        //Veritabanında modelim yaratılırken olucak kurallar
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");



            });

            //SeedData için ; SeedData veritabanı oluşturulurken beraberinde hazır veriler ile oluşturulması içindir.
            //Bunu test zamanında tekrardan veri eklememek ve daha kolay test yapmak için yaparız.

            Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Mercedes"), new(3, "Honda") };
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

        }
    }
}