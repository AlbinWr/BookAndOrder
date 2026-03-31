using BookAndOrder.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookAndOrder.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Detta tystar felet så att du kan köra din migration och seeding
            optionsBuilder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Roles
            var adminId = "02174cfc-9412-4cfe-afbf-59f706d72cf6";
            var roleId = "2c5e174e-3b0e-446f-86af-483d56fd7210";

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            //Admin seed
            var admin = new ApplicationUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User"
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = ph.HashPassword(admin, "Admin123");

            modelBuilder.Entity<ApplicationUser>().HasData(admin);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Books" },
                new Category { CategoryId = 2, Name = "Electronics" },
                new Category { CategoryId = 3, Name = "Clothing" },
                new Category { CategoryId = 4, Name = "Home & Kitchen" }
            );

            modelBuilder.Entity<Product>().HasData(
                // BOOKS
                new Product
                {
                    ProductId = 1,
                    CategoryId = 1,
                    Name = "Mastering C# 12",
                    Description = "A deep dive into modern C# features.",
                    Price = 449m,
                    Stock = 15,
                    ImageUrl = "https://images.unsplash.com/photo-1516116216624-53e697fedbea?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 2,
                    CategoryId = 1,
                    Name = "The Clean Coder",
                    Description = "Professionalism in software development.",
                    Price = 329m,
                    Stock = 8,
                    ImageUrl = "https://images.unsplash.com/photo-1544716278-ca5e3f4abd8c?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 3,
                    CategoryId = 1,
                    Name = "Entity Framework Core",
                    Description = "Bridge the gap to databases.",
                    Price = 399m,
                    Stock = 3,
                    ImageUrl = "https://images.unsplash.com/photo-1555066931-4365d14bab8c?w=400&h=400&fit=crop"
                },

                // ELECTRONICS
                new Product
                {
                    ProductId = 4,
                    CategoryId = 2,
                    Name = "Wireless Headphones",
                    Description = "Noise-canceling over-ear headphones.",
                    Price = 1999m,
                    Stock = 25,
                    ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 5,
                    CategoryId = 2,
                    Name = "Mechanical Keyboard",
                    Description = "RGB backlit mechanical keyboard.",
                    Price = 1250m,
                    Stock = 12,
                    ImageUrl = "https://images.unsplash.com/photo-1511467687858-23d96c32e4ae?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 6,
                    CategoryId = 2,
                    Name = "Smart Watch Pro",
                    Description = "Fitness tracker with heart rate monitor.",
                    Price = 2490m,
                    Stock = 60,
                    ImageUrl = "https://images.unsplash.com/photo-1579586337278-3befd40fd17a?q=80&w=1472&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new Product
                {
                    ProductId = 7,
                    CategoryId = 2,
                    Name = "Ultrawide Monitor",
                    Description = "34-inch curved display.",
                    Price = 5495m,
                    Stock = 0,
                    ImageUrl = "https://images.unsplash.com/photo-1527443224154-c4a3942d3acf?w=400&h=400&fit=crop"
                },

                // CLOTHING
                new Product
                {
                    ProductId = 8,
                    CategoryId = 3,
                    Name = "Hoodie Grey Edition",
                    Description = "Warm, comfortable hoodie.",
                    Price = 599m,
                    Stock = 40,
                    ImageUrl = "https://images.unsplash.com/photo-1556821840-3a63f95609a7?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 9,
                    CategoryId = 3,
                    Name = "Denim Jacket",
                    Description = "Classic blue denim jacket.",
                    Price = 899m,
                    Stock = 10,
                    ImageUrl = "https://images.unsplash.com/photo-1537465978529-d23b17165b3b?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new Product
                {
                    ProductId = 10,
                    CategoryId = 3,
                    Name = "Leather Boots",
                    Description = "Durable and stylish boots.",
                    Price = 1495m,
                    Stock = 4,
                    ImageUrl = "https://images.unsplash.com/photo-1511283402428-355853756676?q=80&w=1470&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },

                // HOME & KITCHEN
                new Product
                {
                    ProductId = 11,
                    CategoryId = 4,
                    Name = "Espresso Machine",
                    Description = "Automatic espresso machine.",
                    Price = 4200m,
                    Stock = 7,
                    ImageUrl = "https://images.unsplash.com/photo-1510591509098-f4fdc6d0ff04?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 12,
                    CategoryId = 4,
                    Name = "Air Fryer XL",
                    Description = "Healthy cooking with 90% less oil.",
                    Price = 1290m,
                    Stock = 22,
                    ImageUrl = "https://images.unsplash.com/photo-1584269600464-37b1b58a9fe7?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 13,
                    CategoryId = 4,
                    Name = "Chef's Knife Set",
                    Description = "Professional stainless steel knives.",
                    Price = 850m,
                    Stock = 15,
                    ImageUrl = "https://images.unsplash.com/photo-1593618998160-e34014e67546?w=400&h=400&fit=crop"
                },
                new Product
                {
                    ProductId = 14,
                    CategoryId = 4,
                    Name = "Cast Iron Skillet",
                    Description = "Heavy-duty skillet for perfect searing.",
                    Price = 450m,
                    Stock = 30,
                    ImageUrl = "https://plus.unsplash.com/premium_photo-1716488286931-79cef654e08c?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8Q2FzdCUyMGlyb258ZW58MHx8MHx8fDA%3D"
                }
            );
        }
    }
}
