using Barroc_intens.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=c_sharp;" +
                "password=Krijnisleider;" +
                "database=Barroc-intens",
                ServerVersion.Parse("8.0.30-mariadb")
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "Alice",
                    Password = "test",
                    JobFunction = "Klant",
                },

                new User
                {
                    Id = 2,
                    Username = "Jane",
                    Password = "wachtwoord",
                    JobFunction = "Finance"
                },

                new User
                {
                    Id = 3,
                    Username = "Henk",
                    Password = "wachtwoord123",
                    JobFunction = "Inkoop"
                },

                new User
                {
                    Id = 4,
                    Username = "Jan",
                    Password = "wachtwoord321",
                    JobFunction = "Sales"
                },

                new User
                {
                    Id = 5,
                    Username = "Hanna",
                    Password = "wachtwoord321",
                    JobFunction = "Maintenance"
                },

                new User
                {
                    Id = 6,
                    Username = "Jimmy",
                    Password = "wachtwoord321",
                    JobFunction = "Planner"
                },

                new User
                {
                    Id = 7,
                    Username = "Paul",
                    Password = "wachtwoord321",
                    JobFunction = "HoofdmedewerkerMaintenance"
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "S234FREKT",
                    Name = "Barroc Intens Italian Light",
                    Dimensions = "",
                    Description = "",
                    Price = 499,
                    Storage = 100,
                },
                new Product
                {
                    Id = "S234KNDPF",
                    Name = "Barroc Intens Italian",
                    Dimensions = "",
                    Description = "",
                    Price = 599,
                    Storage = 100,
                },
                new Product
                {
                    Id = "S234NNBMV",
                    Name = "Barroc Intens Italian Deluxe",
                    Dimensions = "",
                    Description = "",
                    Price = 799,
                    Storage = 100,
                },
                new Product
                {
                    Id = "S234MMPLA",
                    Name = "Barroc Intens Italian Deluxe Special",
                    Dimensions = "",
                    Description = "",
                    Price = 999,
                    Storage = 100,
                }
            );
        }
    }
}
