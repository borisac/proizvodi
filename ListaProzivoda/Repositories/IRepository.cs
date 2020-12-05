using System.Collections.Generic;

namespace ListaProzivoda.Repositories
{
    public interface IRepository<T> 
    {

        List<T> GetAll();
        T GetById(int id);
        void Create(T p);
        void Edit(T p);
        void Delete(int id);
        void SaveChanges();
        
    }
}
