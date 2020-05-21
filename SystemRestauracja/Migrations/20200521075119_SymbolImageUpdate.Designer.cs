﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SystemRestauracja.Data;

namespace SystemRestauracja.Migrations
{
    [DbContext(typeof(RestaurantDbContext))]
    [Migration("20200521075119_SymbolImageUpdate")]
    partial class SymbolImageUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SystemRestauracja.Data.Danie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CategoryId");

                    b.Property<decimal>("Cena");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("CzyUpublicznione");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Nazwa");

                    b.Property<string>("NormalizedNazwa");

                    b.Property<string>("OpisDania");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Dania");
                });

            modelBuilder.Entity("SystemRestauracja.Data.DanieDoZestawu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("DanieId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("Notatka");

                    b.Property<string>("UserId");

                    b.Property<Guid>("ZestawId");

                    b.HasKey("Id");

                    b.HasIndex("DanieId");

                    b.HasIndex("UserId");

                    b.HasIndex("ZestawId");

                    b.ToTable("DaniaDoZestawu");
                });

            modelBuilder.Entity("SystemRestauracja.Data.Kategoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<bool>("HasChildren");

                    b.Property<string>("Nazwa");

                    b.Property<string>("NormalizedName");

                    b.Property<Guid?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("SystemRestauracja.Data.Symbol", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Nazwa");

                    b.HasKey("Id");

                    b.ToTable("Symbole");
                });

            modelBuilder.Entity("SystemRestauracja.Data.SymbolDoDania", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<Guid>("DanieId");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<Guid>("SymbolId");

                    b.HasKey("Id");

                    b.HasIndex("DanieId");

                    b.HasIndex("SymbolId");

                    b.ToTable("SymboleDoDania");
                });

            modelBuilder.Entity("SystemRestauracja.Data.UserAccount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("IsActive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("StatusStolika");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SystemRestauracja.Data.Zamowienie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CenaSuma");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("NormalizedName");

                    b.Property<int>("StatusZamowienie");

                    b.Property<string>("ZamawiajacyId");

                    b.Property<int>("ZamowienieNr")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.HasIndex("ZamawiajacyId");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("SystemRestauracja.Data.Zestaw", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CenaZestawu");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("DeleteDate");

                    b.Property<string>("NormalizedName");

                    b.Property<int>("StatusZestawu");

                    b.Property<string>("ZamawiajacyId");

                    b.Property<Guid>("ZamowienieId");

                    b.HasKey("Id");

                    b.HasIndex("ZamawiajacyId");

                    b.HasIndex("ZamowienieId");

                    b.ToTable("Zestawy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SystemRestauracja.Data.UserAccount")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SystemRestauracja.Data.UserAccount")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SystemRestauracja.Data.UserAccount")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SystemRestauracja.Data.UserAccount")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemRestauracja.Data.Danie", b =>
                {
                    b.HasOne("SystemRestauracja.Data.Kategoria", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemRestauracja.Data.DanieDoZestawu", b =>
                {
                    b.HasOne("SystemRestauracja.Data.Danie", "Danie")
                        .WithMany()
                        .HasForeignKey("DanieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SystemRestauracja.Data.UserAccount", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("SystemRestauracja.Data.Zestaw", "Zestaw")
                        .WithMany()
                        .HasForeignKey("ZestawId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemRestauracja.Data.Kategoria", b =>
                {
                    b.HasOne("SystemRestauracja.Data.Kategoria", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("SystemRestauracja.Data.SymbolDoDania", b =>
                {
                    b.HasOne("SystemRestauracja.Data.Danie", "Danie")
                        .WithMany()
                        .HasForeignKey("DanieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SystemRestauracja.Data.Symbol", "Symbol")
                        .WithMany()
                        .HasForeignKey("SymbolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SystemRestauracja.Data.Zamowienie", b =>
                {
                    b.HasOne("SystemRestauracja.Data.UserAccount", "Zamawiajacy")
                        .WithMany()
                        .HasForeignKey("ZamawiajacyId");
                });

            modelBuilder.Entity("SystemRestauracja.Data.Zestaw", b =>
                {
                    b.HasOne("SystemRestauracja.Data.UserAccount", "Zamawiajacy")
                        .WithMany()
                        .HasForeignKey("ZamawiajacyId");

                    b.HasOne("SystemRestauracja.Data.Zamowienie", "Zamowienie")
                        .WithMany()
                        .HasForeignKey("ZamowienieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
