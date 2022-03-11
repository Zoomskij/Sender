using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrintLayer.Models;

namespace PrintLayer.Data
{
    public class Context : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<VotePrint> VotePrints { get; set; }
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
            //////Seed Users//////
            modelBuilder.Entity<User>(entity => { entity.Property(e => e.Id).IsRequired(); });
            var user = new User()
            {
                Email = "admin",
                PasswordHash = "a322b9c0b8e19ef16d4d308cd4e1222106d0edf8fbb3c8f1649242dff54a740c",
                EmailConfirmed = true,
                UserName = "Admin Admin"
            };
            modelBuilder.Entity<User>().HasData(user);

            //////Seed Orders///////
            modelBuilder.Entity<Order>(entity => { entity.Property(e => e.Id).IsRequired(); });
            for (var i = 0; i < 20; i++)
            {
                var order = new Order
                {
                    UserId = user.Id,
                    Address = $"Moscow Kremlin st {i}",
                    Status = OrderStatus.New,
                    Phone = "+71234567890",
                    Description = $"Sample Description {i}"
                };
                modelBuilder.Entity<Order>().HasData(order);
            }


            //////Seed Reviews///////
            modelBuilder.Entity<Review>(entity => { entity.Property(e => e.Id).IsRequired(); });
            for (byte i = 1; i < 5; i++)
            {
                var review = new Review
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Description = $"Sample review Description {i}",
                    Grade = i
                };
                modelBuilder.Entity<Review>().HasData(review);
            }

            ///////Seed News////////
            modelBuilder.Entity<News>(entity => { entity.Property(e => e.Id).IsRequired(); });
            for (byte i = 1; i < 5; i++)
            {
                modelBuilder.Entity<News>().HasData(new News
                {
                    Name = $"Test Name {i}",
                    Description = $"This is a test news description {i}"
                });
            }
        }
    }
}
