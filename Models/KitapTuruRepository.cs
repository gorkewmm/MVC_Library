using WebUygulamaProje.Utility;

namespace WebUygulamaProje.Models
{
    public class KitapTuruRepository : Repository<KitapTuru>, IKitapTuruRepository
    {
        private UygulamaDbContext _context;
        public KitapTuruRepository(UygulamaDbContext context) : base(context)
        {
            _context = context;
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
