using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemRestauracja.Models;

namespace SystemRestauracja.Data
{
    public class RestaurantDbContext : IdentityDbContext<UserAccount>
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Kategoria> Kategorie { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<Zestaw> Zestawy { get; set; }
        public DbSet<Danie> Dania { get; set; }
        public DbSet<DanieDoZestawu> DaniaDoZestawu { get; set; }
        public DbSet<Symbol> Symbole { get; set; }
        public DbSet<SymbolDoDania> SymboleDoDania { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Zestaw>()
                .Property(f => f.ZestawNr)
                .ValueGeneratedOnAdd();
            builder.Entity<Zestaw>()
                .Property(f => f.ZestawNr)
                .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            builder.Entity<Zamowienie>()
                .Property(f => f.ZamowienieNr)
                .ValueGeneratedOnAdd();
            builder.Entity<Zamowienie>()
                .Property(f => f.ZamowienieNr)
                .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
            

            base.OnModelCreating(builder);
        }
    }
}
