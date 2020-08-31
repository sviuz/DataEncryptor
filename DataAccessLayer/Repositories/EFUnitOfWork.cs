using BLL.DTO;
using DataAccessLayer.Contexts;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IRepository<ModelDTO> Models
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
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
