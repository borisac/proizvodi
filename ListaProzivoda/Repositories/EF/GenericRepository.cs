using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ListaProzivoda.Repositories.EF
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private DbSet<T> dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();//context.Proizvods            _
        }

        public virtual List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Create(T p)
        {
            dbSet.Add(p);
            
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
        }

        public virtual void Edit(T p)
        {
            _context.Entry(p).State = EntityState.Modified;
            
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}