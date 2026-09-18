using System.Collections;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace WebUygulamaProje.Models
{
    public interface IRepository<T>  where T: class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Ekle(T entity);
        void Sil(T entity);
        void SilAralik(IEnumerable<T> entities);
    }
}
