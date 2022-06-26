using Cosmetic_Store.Auth.Model;
using Cosmetic_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Cosmetic_Store.Data
{
    public class CosmeticDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }

        public CosmeticDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartProduct>().HasKey(CartProduct => new { CartProduct.CartID, CartProduct.ProductID });
            modelBuilder.Entity<OrderItems>().HasKey(OrderItems => new { OrderItems.OrderID, OrderItems.ProductID });


            modelBuilder.Entity<Category>().HasData(
              new Category { CategoryId = 1, Name = "Mascara", Description = "Mascara is a makeup product that aims to lengthen, enhance, and define eyelashes.", Logo = "/images/Mascara/Mascara.PNG" },
              new Category { CategoryId = 2, Name = "Lipstick", Description = "Lipstick is makeup that makes your lips look darker, redder, or shinier.", Logo = "/images/Lipstick/Lipstick.PNG" },
              new Category { CategoryId = 3, Name = "Powder", Description = "Face powder is a cosmetic product applied to the face to serve different functions, typically to beautify the face.", Logo = "/images/Powder/Powder.PNG" },
              new Category { CategoryId = 4, Name = "Foundation", Description = "Foundation is a liquid, cream, or powder makeup applied to the face and neck to create an even, uniform color to the complexion, cover flaws and, sometimes, to change the natural skin tone.", Logo = "/images/Foundation/Foundation.PNG" }
            );
            modelBuilder.Entity<Product>().HasData(
              new Product { ProductId = 1, CategoryId = 1, Name = "Essence Mascara", Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.", Price = 5.0f, ImageURL = "/images/Mascara/Essence.PNG" },
              new Product { ProductId = 2, CategoryId = 1, Name = "Maybelline Mascara", Description = "Defining, lengthening | Washable and waterproof versions | Skinny, low-profile brush with sparse, short bristles.", Price = 9.5f, ImageURL = "/images/Mascara/Maybelline.PNG" },
              new Product { ProductId = 3, CategoryId = 1, Name = "Glossier Mascara", Description = "Lengthening, lifting | Water-resistant | Tapered silicone brush with tiered bristles", Price = 16.0f, ImageURL = "/images/Mascara/Glossier.PNG" },

              new Product { ProductId = 4, CategoryId = 2, Name = "MegaLastLiquid Lipstick", Description = "What glides on like butter, feels like a second skin and wont budge? Our Liquid Catsuit Matte Lipstick! Made with glammed out superpowers, it goes on glossy yet transforms into a high - pigmented matte finish with some serious staying power. Read our lips This color is going nowhere.", Price = 4.0f, ImageURL = "/images/Lipstick/MegaLastLiquid.PNG" },
              new Product { ProductId = 5, CategoryId = 2, Name = "Maybelline Lipstick", Description = "This cult-classic lipstick is the perfect combination of high-impact color in a super-moisturizing formula.", Price = 5.0f, ImageURL = "/images/Lipstick/Maybelline.PNG" },
              new Product { ProductId = 6, CategoryId = 2, Name = "Satin Lipstick", Description = "Satin lipstick gives a sheen like a cream lipstick but with the boldness of a matte.", Price = 3.0f, ImageURL = "/images/Lipstick/Satin.PNG" },

              new Product { ProductId = 7, CategoryId = 3, Name = "ELF Powder", Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.", Price = 7.0f, ImageURL = "/images/Powder/ELF.PNG" },
              new Product { ProductId = 8, CategoryId = 3, Name = "FitMe Powder", Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.", Price = 10.0f, ImageURL = "/images/Powder/FitMe.PNG" },
              new Product { ProductId = 9, CategoryId = 3, Name = "StayMatte Powder", Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.", Price = 15.0f, ImageURL = "/images/Powder/StayMatte.PNG" },

              new Product { ProductId = 10, CategoryId = 4, Name = "Maybelline Foundation", Description = "Up To 30 Hour Wear |Full Coverage Foundation | Light As Air Feel |Transfer Resistant |Seamless Matte Finish |Oil Free", Price = 20.0f, ImageURL = " /images/Foundation/Maybelline.PNG" },
              new Product { ProductId = 11, CategoryId = 4, Name = "LOreal Foundation", Description = "Achieve a matte finish that won’t fall flat with this air-light, longwearing liquid formula. Lightweight and creamy, foundation goes on smooth with a demi-matte finish that lasts up to 24 hours—hiding imperfections for a smooth, clear complexion.", Price = 13.0f, ImageURL = "/images/Foundation/LOreal.PNG" },
              new Product { ProductId = 12, CategoryId = 4, Name = "Missha Foundation", Description = "This M Perfect Cover BB Cream makes your skin tone clean and chic by concealing blemishes with excellent skin coverage it is a multi functional makeup cream with blocking UV rays, whitening and wrinkle care effects and simplifies makeup formalities its moisturized application with W/S texture makes sleek skin tone while supplying moisture and nutrition at the same time.", Price = 8.0f, ImageURL = "/images/Foundation/Missha.PNG" }

            );

            // any unique string id
            const string ADMIN_ID = "abcbe9c0";
            const string ADMIN_ROLE_ID = "ad376a8ff";

            const string EDITOR_ID = "abcze710";
            const string EDITOR_ROLE_ID = "bd586a8ff";

            // create an Admin role
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Administrator",
                NormalizedName = "Admin"
            }, new IdentityRole
            {
                Id = EDITOR_ROLE_ID,
                Name = "Editor",
                NormalizedName = "EDITOR"
            });

            // create a User
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "@dmin123"),
                SecurityStamp = string.Empty
            },
            new ApplicationUser
            {
                Id = EDITOR_ID,
                UserName = "editor",
                NormalizedUserName = "editor",
                Email = "editor@gmail.com",
                NormalizedEmail = "editor@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Edit0r123"),
                SecurityStamp = string.Empty
            });

            // assign that user to the admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = EDITOR_ROLE_ID,
                UserId = EDITOR_ID
            });


            SeedRole(modelBuilder, "Administrator", "create", "delete");
            SeedRole(modelBuilder, "Editor", "update");
        }
        private int nextId = 1; // we need this to generate a unique id on our own
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions", // This matches what we did in Startup.cs
                ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }
    }
}

