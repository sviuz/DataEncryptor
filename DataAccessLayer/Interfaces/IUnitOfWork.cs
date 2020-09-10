using DataAccessLayer.Entities;
using System;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IModelRepository<DataModel> Models { get; }

        IModelRepository<DataIdentityUser> Users { get; }

        void Save();
    }
}