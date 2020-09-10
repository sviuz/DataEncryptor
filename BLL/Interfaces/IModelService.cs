using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IModelService
    {
        IEnumerable<ModelDTO> GetAll();

        ModelDTO Get(int id);

        void Create(ModelDTO model);

        void Update(ModelDTO model);
    }
}