using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<ModelDTO> Models { get; }
        void Save();
    }
}
