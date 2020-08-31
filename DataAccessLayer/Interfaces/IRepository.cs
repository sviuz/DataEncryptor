using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
