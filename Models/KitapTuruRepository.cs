using WebUygulamaProje.Utility;

namespace WebUygulamaProje.Models
{
    public class KitapTuruRepository : Repository<KitapTuru>, IKitapTuruRepository
    {
        public KitapTuruRepository(UygulamaDbContext context) : base(context)
        {
        }

        public void Guncelle(KitapTuru kitapTuru)
        {
            _context.Update(kitapTuru);
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }
    }
}
