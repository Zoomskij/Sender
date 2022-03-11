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
        public DbSet<Email> News { get; set; }
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

            ///////Seed News////////
            modelBuilder.Entity<Email>(entity => { entity.Property(e => e.Id).IsRequired(); });
            for (byte i = 1; i < 5; i++)
            {
                modelBuilder.Entity<Email>().HasData(new Email
                {
                    Name = $"Test Name {i}", 
                });
            }
        }
    }
}
