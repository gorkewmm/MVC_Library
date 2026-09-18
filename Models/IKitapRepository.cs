namespace WebUygulamaProje.Models
{
    public interface IKitapRepository : IRepository<Kitap>
    {
        void Guncelle(Kitap kitap);
        void Kaydet();
    }
}
