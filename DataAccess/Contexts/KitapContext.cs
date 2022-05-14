using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class KitapContext:DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;database=OdevKitap; Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitap>()
                .HasOne(kitap => kitap.Kategori)
                .WithMany(kategori => kategori.Kitaplar)
                .HasForeignKey(kitap => kitap.KategoriId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
