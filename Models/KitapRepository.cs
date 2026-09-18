using WebUygulamaProje.Utility;

namespace WebUygulamaProje.Models
{
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        public KitapRepository(UygulamaDbContext context) : base(context)
        {
            
        }

        public void Guncelle(Kitap kitap)
        {
            _context.Update(kitap);  
        }

        public void Kaydet()
        {
            _context.SaveChanges();
        }
    }
}
