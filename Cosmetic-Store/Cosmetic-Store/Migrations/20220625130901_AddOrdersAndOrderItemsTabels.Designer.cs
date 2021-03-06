// <auto-generated />
using System;
using Cosmetic_Store.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cosmetic_Store.Migrations
{
    [DbContext(typeof(CosmeticDBContext))]
    [Migration("20220625130901_AddOrdersAndOrderItemsTabels")]
    partial class AddOrdersAndOrderItemsTabels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cosmetic_Store.Auth.Model.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "abcbe9c0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "896f21fc-7998-4206-92c5-35ae0c6c1b4a",
                            Email = "admin@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEDW1Wi+lxluc6E3rdMH6iD+kNvSB6ztEntheHP7jIp6odAk8D/tUT5SsMqrVKhR8EA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "abcze710",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "88137585-9fcc-4e21-8a22-b7561ca8fbd6",
                            Email = "editor@gmail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "editor@gmail.com",
                            NormalizedUserName = "editor",
                            PasswordHash = "AQAAAAEAACcQAAAAEETdvxc/BVf/6+n5Kiv30CW5ddOolQ9KWCRZJz29LBgyQYreajpEWzxs2i2m8STZVg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "editor"
                        });
                });

            modelBuilder.Entity("Cosmetic_Store.Models.Cart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Cosmetic_Store.Models.CartProduct", b =>
                {
                    b.Property<int>("CartID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CartID", "ProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartProducts");
                });

            modelBuilder.Entity("Cosmetic_Store.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Mascara is a makeup product that aims to lengthen, enhance, and define eyelashes.",
                            Logo = "/images/Mascara/Mascara.PNG",
                            Name = "Mascara"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Lipstick is makeup that makes your lips look darker, redder, or shinier.",
                            Logo = "/images/Lipstick/Lipstick.PNG",
                            Name = "Lipstick"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Face powder is a cosmetic product applied to the face to serve different functions, typically to beautify the face.",
                            Logo = "/images/Powder/Powder.PNG",
                            Name = "Powder"
                        },
                        new
                        {
                            CategoryId = 4,
                            Description = "Foundation is a liquid, cream, or powder makeup applied to the face and neck to create an even, uniform color to the complexion, cover flaws and, sometimes, to change the natural skin tone.",
                            Logo = "/images/Foundation/Foundation.PNG",
                            Name = "Foundation"
                        });
                });

            modelBuilder.Entity("Cosmetic_Store.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreditCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Timestamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Cosmetic_Store.Models.OrderItems", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Cosmetic_Store.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.",
                            ImageURL = "/images/Mascara/Essence.PNG",
                            Name = "Essence Mascara",
                            Price = 5.0
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "Defining, lengthening | Washable and waterproof versions | Skinny, low-profile brush with sparse, short bristles.",
                            ImageURL = "/images/Mascara/Maybelline.PNG",
                            Name = "Maybelline Mascara",
                            Price = 9.5
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Description = "Lengthening, lifting | Water-resistant | Tapered silicone brush with tiered bristles",
                            ImageURL = "/images/Mascara/Glossier.PNG",
                            Name = "Glossier Mascara",
                            Price = 16.0
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Description = "What glides on like butter, feels like a second skin and wont budge? Our Liquid Catsuit Matte Lipstick! Made with glammed out superpowers, it goes on glossy yet transforms into a high - pigmented matte finish with some serious staying power. Read our lips This color is going nowhere.",
                            ImageURL = "/images/Lipstick/MegaLastLiquid.PNG",
                            Name = "MegaLastLiquid Lipstick",
                            Price = 4.0
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 2,
                            Description = "This cult-classic lipstick is the perfect combination of high-impact color in a super-moisturizing formula.",
                            ImageURL = "/images/Lipstick/Maybelline.PNG",
                            Name = "Maybelline Lipstick",
                            Price = 5.0
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 2,
                            Description = "Satin lipstick gives a sheen like a cream lipstick but with the boldness of a matte.",
                            ImageURL = "/images/Lipstick/Satin.PNG",
                            Name = "Satin Lipstick",
                            Price = 3.0
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 3,
                            Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.",
                            ImageURL = "/images/Powder/ELF.PNG",
                            Name = "ELF Powder",
                            Price = 7.0
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 3,
                            Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.",
                            ImageURL = "/images/Powder/FitMe.PNG",
                            Name = "FitMe Powder",
                            Price = 10.0
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 3,
                            Description = "Volumizing, defining | Washable | Conic nylon brush with full, soft bristles.",
                            ImageURL = "/images/Powder/StayMatte.PNG",
                            Name = "StayMatte Powder",
                            Price = 15.0
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 4,
                            Description = "Up To 30 Hour Wear |Full Coverage Foundation | Light As Air Feel |Transfer Resistant |Seamless Matte Finish |Oil Free",
                            ImageURL = " /images/Foundation/Maybelline.PNG",
                            Name = "Maybelline Foundation",
                            Price = 20.0
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 4,
                            Description = "Achieve a matte finish that won’t fall flat with this air-light, longwearing liquid formula. Lightweight and creamy, foundation goes on smooth with a demi-matte finish that lasts up to 24 hours—hiding imperfections for a smooth, clear complexion.",
                            ImageURL = "/images/Foundation/LOreal.PNG",
                            Name = "LOreal Foundation",
                            Price = 13.0
                        },
                        new
                        {
                            ProductId = 12,
                            CategoryId = 4,
                            Description = "This M Perfect Cover BB Cream makes your skin tone clean and chic by concealing blemishes with excellent skin coverage it is a multi functional makeup cream with blocking UV rays, whitening and wrinkle care effects and simplifies makeup formalities its moisturized application with W/S texture makes sleek skin tone while supplying moisture and nutrition at the same time.",
                            ImageURL = "/images/Foundation/Missha.PNG",
                            Name = "Missha Foundation",
                            Price = 8.0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "ad376a8ff",
                            ConcurrencyStamp = "84d9d096-58d7-4d83-a123-18c0f40697b9",
                            Name = "Administrator",
                            NormalizedName = "Admin"
                        },
                        new
                        {
                            Id = "bd586a8ff",
                            ConcurrencyStamp = "861bd4f4-a521-4502-a066-240687a90c72",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        },
                        new
                        {
                            Id = "administrator",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "editor",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Editor",
                            NormalizedName = "EDITOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "permissions",
                            ClaimValue = "create",
                            RoleId = "administrator"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "permissions",
                            ClaimValue = "delete",
                            RoleId = "administrator"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "permissions",
                            ClaimValue = "update",
                            RoleId = "editor"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "abcbe9c0",
                            RoleId = "ad376a8ff"
                        },
                        new
                        {
                            UserId = "abcze710",
                            RoleId = "bd586a8ff"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Cosmetic_Store.Models.CartProduct", b =>
                {
                    b.HasOne("Cosmetic_Store.Models.Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cosmetic_Store.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Cosmetic_Store.Models.OrderItems", b =>
                {
                    b.HasOne("Cosmetic_Store.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cosmetic_Store.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Cosmetic_Store.Models.Product", b =>
                {
                    b.HasOne("Cosmetic_Store.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Cosmetic_Store.Auth.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Cosmetic_Store.Auth.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cosmetic_Store.Auth.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Cosmetic_Store.Auth.Model.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cosmetic_Store.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
