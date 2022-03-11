using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SenderApp.Models;

namespace SenderApp.Data
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        public DbSet<Email> Emails { get; set; }
        public DbSet<Config> Configs { get; set; }
        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            Database.Migrate();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            ///////Seed Config////////
            modelBuilder.Entity<Config>(entity => { entity.Property(e => e.Id).IsRequired(); });

            modelBuilder.Entity<Config>().HasData(new Config
            {
                IsStarted = false
            });

            ///////Seed Emails////////
            modelBuilder.Entity<Email>(entity => { entity.Property(e => e.Id).IsRequired(); });

            modelBuilder.Entity<Email>().HasData(new Email
            {
                Name = $"My", 
                Address = "Zoomskij@gmail.com"
            });
        }
    }
}
