using Barroc_intens.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barroc_intens.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<CustomInvoice> CustomInvoices { get; set; }
        public DbSet<CustomInvoiceProduct> CustomInvoiceProducts { get; set; }
        public DbSet<FaultyRequest> FaultyRequests { get; set; }
        public DbSet<JobFunction> Functies { get; set; }
        public DbSet<MaintenanceAppointment> MaintenanceAppointments { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=;" +
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
                    JobFunctionId = 1,
                },

                new User
                {
                    Id = 2,
                    Username = "Jane",
                    Password = "wachtwoord",
                    JobFunctionId = 2,
                },

                new User
                {
                    Id = 3,
                    Username = "Henk",
                    Password = "wachtwoord123",
                    JobFunctionId = 4,
                },

                new User
                {
                    Id = 4,
                    Username = "Jan",
                    Password = "wachtwoord321",
                    JobFunctionId = 3,
                },

                new User
                {
                    Id = 5,
                    Username = "Hanna",
                    Password = "a",
                    JobFunctionId = 5,
                },

                new User
                {
                    Id = 6,
                    Username = "Paul",
                    Password = "test",
                    JobFunctionId = 5,
                },

                new User
                {
                    Id = 7,
                    Username = "Jimmy",
                    Password = "wachtwoord321",
                    JobFunctionId = 7,
                },

                new User
                {
                    Id = 8,
                    Username = "Poul",
                    Password = "wachtwoord321",
                    JobFunctionId = 6,
                },

                new User
                {
                    Id = 9,
                    Username = "Jan",
                    Password = "test",
                    JobFunctionId = 5,
                }
            );
            modelBuilder.Entity<MaintenanceAppointment>().HasData(
                new MaintenanceAppointment
                {
                    Id = 1,
                    EmployeeId = 1,
                    CompanyId = 1,
                    Location = "Breda",
                    Description = "KoffiezetApparaat is hervuld",
                    ScheduledAt = DateTime.Now,
                    
                });
            modelBuilder.Entity<FaultyRequest>().HasData(
              new FaultyRequest
              {
                  Id = 1,
                  ProductId = "S234FREKT",
                  UserId = 1,
                  EmployeeId = 9,
                  Location = "Terheidenseweg 350",
                  ScheduledAt = DateTime.UtcNow,
                  Description = "dfdfdfdf",
                  Done = false,
              });


            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "action",
                   Phone = 1234567890,
                   Street = "LangeStraat",
                   HouseNumber = 69,
                   City = "breda",
                   CountryCode = "133",
                   ContactId = 1
                },
               new Company
               {
                   Id = 2,
                   Name = "kruidvat",
                   Phone = 1234567890,
                   Street = "LangeStraat",
                   HouseNumber = 69,
                   City = "breda",
                   CountryCode = "133",
                   ContactId = 1
               }
           );
            
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Materiaal/Gereedschap",
                    IsEmployeeOnly = true,
                },
                new Category
                {
                    Id = 2,
                    Name = "Product",
                    IsEmployeeOnly = false,
                },
                new Category
                {
                    Id = 3,
                    Name = "Deluxe",
                    IsEmployeeOnly = false,
                },
                new Category
                {
                    Id = 4,
                    Name = "Special",
                    IsEmployeeOnly = false,
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "S234FREKT",
                    Name = "Barroc Intens Italian Light",
                    Description = "",
                    Price = 499,
                    Storage = 100,
                    CategoryId = 2
                },
                new Product
                {
                    Id = "S234KNDPF",
                    Name = "Barroc Intens Italian",
                    Description = "",
                    Price = 599,
                    Storage = 100,
                    CategoryId = 2
                },
                new Product
                {
                    Id = "S234NNBMV",
                    Name = "Stroom Kabel",
                    Description = "",
                    Price = 45,
                    Storage = 50,
                    CategoryId = 1
                },
                new Product
                {
                    Id = "S234UUQRF",
                    Name = "Barroc Intens Italian Deluxe",
                    Description = "",
                    Price = 799,
                    Storage = 100,
                    CategoryId = 3
                },
                new Product
                {
                    Id = "S234MMPLA",
                    Name = "Barroc Intens Italian Deluxe Special",
                    Description = "",
                    Price = 999,
                    Storage = 100,
                    CategoryId = 4
                }
                
            );

            modelBuilder.Entity<JobFunction>().HasData(
                new JobFunction
                {
                    Id = 1,
                    Name = "Klant",
                },
                new JobFunction
                {
                    Id = 2,
                    Name = "Finance",
                },
                new JobFunction
                {
                    Id = 3,
                    Name = "Sales",
                },
                new JobFunction
                {
                    Id = 4,
                    Name = "Inkoop",
                },
                new JobFunction
                {
                    Id = 5,
                    Name = "Maintenance",
                },
                new JobFunction
                {
                    Id = 6,
                    Name = "HoofdmedewerkerMaintenance",
                },
                new JobFunction
                {
                    Id = 7,
                    Name = "Planner",
                }
                
            );
            
        }
    }
}
