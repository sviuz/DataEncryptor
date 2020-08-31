using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IModelService
    {
        IEnumerable<ModelDTO> GetAll();
        ModelDTO Get(int id);
        void Create(ModelDTO model);
        void Update(ModelDTO model);
        void Delete(ModelDTO model);
    }
}
