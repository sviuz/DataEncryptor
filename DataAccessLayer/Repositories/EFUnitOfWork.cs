using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;

namespace DataAccessLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DataContext _dataContext;
        private ModelRepository _modelRepository;

        public EFUnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IRepository<DataModel> Models
        {
            get
            {
                if (_modelRepository == null)
                {
                    _modelRepository= new ModelRepository(_dataContext);
                }
                return _modelRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            try
            {
               _dataContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _dataContext.SaveChanges();
            }
        }
    }
}
