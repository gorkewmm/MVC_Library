using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebUygulamaProje.Utility;

namespace WebUygulamaProje.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly UygulamaDbContext _context;
        internal DbSet<T> _dbSet; //dbset = _context.Set<KitapTurleri>()
        public Repository(UygulamaDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Ekle(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Sil(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void SilAralik(IEnumerable<T> entities)
        {
            //foreach (var item in entities)
            //{
            //    _dbSet.Remove(item);
            //}

            _dbSet.RemoveRange(entities);
        }
    }
}
