using Microsoft.EntityFrameworkCore;
using WebUygulamaProje.Models;

namespace WebUygulamaProje.Utility
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<KitapTuru> KitapTurleri { get; set; }
        public DbSet<Kitap> Kitaplar{ get; set; }



    }
}
