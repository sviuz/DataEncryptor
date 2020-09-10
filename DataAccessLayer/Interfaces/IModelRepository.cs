using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IModelRepository<T> where T : class
    {
        IEnumerable<T> Get();

        T Get(int id);

        void Create(T item);

        void Update(T item);
    }
}