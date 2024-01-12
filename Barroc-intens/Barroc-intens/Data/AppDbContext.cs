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
                "password=18nlw;" +
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
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },
                

                new User
                {
                    Id = 2,
                    Username = "Jane",
                    Password = "a",
                    JobFunctionId = 2,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 3,
                    Username = "Henk",
                    Password = "wachtwoord123",
                    JobFunctionId = 4,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 4,
                    Username = "Jan",
                    Password = "a",
                    JobFunctionId = 3,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 5,
                    Username = "Hanna",
                    Password = "a",
                    JobFunctionId = 5,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 6,
                    Username = "Paul",
                    Password = "test",
                    JobFunctionId = 5,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 7,
                    Username = "Jimmy",
                    Password = "wachtwoord321",
                    JobFunctionId = 7,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 8,
                    Username = "Piet",
                    Password = "123",
                    JobFunctionId = 6,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 9,
                    Username = "Jan",
                    Password = "test",
                    JobFunctionId = 5,
                    CompanyId = 1,
                    IsCompanyAdmin = false,
                },

                new User
                {
                    Id = 10,
                    Username = "BarrocAdmin",
                    Password = "admin",
                    JobFunctionId = 1,
                    CompanyId = 1,
                    IsCompanyAdmin = true,
                },

                new User
                {
                    Id = 11,
                    Username = "Action",
                    Password = "admin",
                    JobFunctionId = 1,
                    CompanyId = 2,
                    IsCompanyAdmin = true,
                },

                new User
                {
                    Id = 12,
                    Username = "Kruidvat",
                    Password = "admin",
                    JobFunctionId = 1,
                    CompanyId = 3,
                    IsCompanyAdmin = true,
                }
            );
            // S234UUQRF

            modelBuilder.Entity<CustomInvoiceProduct>().HasData(
                new CustomInvoiceProduct
                {
                    Id = 1,
                    ProductId = "S234UUQRF",
                    CustomInvoiceId = 1,
                    PricePerProduct = 0,
                });
            modelBuilder.Entity<CustomInvoice>().HasData(
                new CustomInvoice
                {
                    Id = 1,
                    Date = new DateTime(2023, 11, 30),
                    CompanyId = 1,
                    PaidAt = default( DateTime ),
                });
            modelBuilder.Entity<MaintenanceAppointment>().HasData(
                new MaintenanceAppointment
                {
                    Id = 1,
                    CompanyId = 1,
                    Remark = "KoffiezetApparaat is hervuld",
                    DateAdded = DateTime.Now,
                    
                });
            modelBuilder.Entity<FaultyRequest>().HasData(
              new FaultyRequest
              {
                  Id = 1,
                  ProductId = "S234FREKT",
                  UserId = 1,
                  EmployeeId = 2,
                  Location = "Terheidenseweg 350",
                  ScheduledAt = DateTime.UtcNow,
                  Description = "dfdfdfdf",
                  Done = false,
              });


            modelBuilder.Entity<Company>().HasData(
               new Company {
                   Id = 1,
                   Name = "Barroc Intens",
                   Phone = 123123123,
                   Street = "BarrocStraat",
                   HouseNumber = 69,
                   City = "Breda",
                   CountryCode = "6969",
               },
               new Company
               {
                   Id = 2,
                   Name = "action",
                   Phone = 1234567890,
                   Street = "LangeStraat",
                   HouseNumber = 69,
                   City = "breda",
                   CountryCode = "133",
                },
               new Company
               {
                   Id = 3,
                   Name = "kruidvat",
                   Phone = 1234567890,
                   Street = "LangeStraat",
                   HouseNumber = 69,
                   City = "breda",
                   CountryCode = "133",
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
