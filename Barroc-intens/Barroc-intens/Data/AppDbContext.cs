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
        public DbSet<MaintenanceProduct> MaintenanceProducts { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +
                "port=3306;" +
                "user=root;" +
                "password=root;" +
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
                    Password = "wachtwoord321",
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

            modelBuilder.Entity<FaultyRequest>().HasData(
                new FaultyRequest
                {
                    Id = 1,
                    ProductId = "S234FREKT",
                    UserId = 1,
                    EmployeeId = 9,
                    Location = "Terheidenseweg 320",
                    ScheduledAt = DateTime.UtcNow,
                    Description = "Aanknop is moeilijk in te drukken",
                    Done = false,
                },

                new FaultyRequest
                {
                    Id = 2,
                    ProductId = "S234MMPLA",
                    UserId = 1,
                    EmployeeId = 5,
                    Location = "Terheidenseweg 301",
                    ScheduledAt = DateTime.UtcNow,
                    Description = "Blokkade in de slang",
                    Done = false,
                },

                new FaultyRequest
                {
                    Id = 3,
                    ProductId = "S234NNBMV",
                    UserId = 1,
                    EmployeeId = 8,
                    Location = "Terheidenseweg 300",
                    ScheduledAt = DateTime.UtcNow,
                    Description = "Melk klopper werkt niet meer",
                    Done = false,
                },

                new FaultyRequest
                {
                    Id = 4,
                    ProductId = "S234MMPLA",
                    UserId = 1,
                    EmployeeId = 6,
                    Location = "Terheidenseweg 350",
                    ScheduledAt = DateTime.UtcNow,
                    Description = "Machine lekt tijdens gebruik",
                    Done = false,
                });

            modelBuilder.Entity<MaintenanceProduct>().HasData(
                new MaintenanceProduct
                {
                    Id = 1,
                    Name = "Screw",
                    Price = 1,
                    Storage = 1000,
                },
                new MaintenanceProduct
                {
                    Id = 2,
                    Name = "Filter Basket",
                    Price = 5,
                    Storage = 500,
                },
                new MaintenanceProduct
                {
                    Id = 3,
                    Name = "Heating Element",
                    Price = 15,
                    Storage = 200,
                },
                new MaintenanceProduct
                {
                    Id = 4,
                    Name = "Water Pump",
                    Price = 10,
                    Storage = 300,
                },
                new MaintenanceProduct
                {
                    Id = 5,
                    Name = "Thermostat",
                    Price = 8,
                    Storage = 400,
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
               });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = "S234FREKT",
                    Name = "Barroc Intens Italian Light",
                    Description = "",
                    Price = 499,
                    Storage = 100,
                },
                new Product
                {
                    Id = "S234KNDPF",
                    Name = "Barroc Intens Italian",
                    Description = "",
                    Price = 599,
                    Storage = 100,
                },
                new Product
                {
                    Id = "S234NNBMV",
                    Name = "Barroc Intens Italian Deluxe",
                    Description = "",
                    Price = 799,
                    Storage = 100,
                },
                new Product
                {
                    Id = "S234MMPLA",
                    Name = "Barroc Intens Italian Deluxe Special",
                    Description = "",
                    Price = 999,
                    Storage = 100,
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
            modelBuilder.Entity<MaintenanceAppointment>().HasData(
              new MaintenanceAppointment
              {
                  Id = 1,
                  CompanyId = 1,
                  ProductId = "1",
                  Remark = "Printer stuk, moet voor vrijdg gemaakt zijn",
                  DateAdded = DateTime.Now,
              },
              new MaintenanceAppointment
              {
                  Id = 2,
                  CompanyId = 2,
                  ProductId = "1",
                  Remark = "airco gemaakt op 2 de verdieping",
                  DateAdded = DateTime.Now,
              }
              );
        }
    }
}
