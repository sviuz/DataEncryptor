using DataAccessLayer.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<DataModel> Models { get; }
        void Save();
    }
}
