using DataAccessLayer.Entities;
using System;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<DataModel> Models { get; }
        void Save();
    }
}
