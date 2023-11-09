using Barroc_intens.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
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
                }
            );
            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "action",
                   phone = 1234567890,
                   street = "LangeStraat",
                   houseNumber = 69,
                   city = "breda",
                   countryCode = 133,
                },
               new Company
               {
                   Id = 2,
                   Name = "action",
                   phone = 1234567890,
                   street = "LangeStraat",
                   houseNumber = 69,
                   city = "breda",
                   countryCode = 133,
               }
           );
        }
    }
}
