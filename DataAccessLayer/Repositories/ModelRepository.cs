using BLL.DTO;
using DataAccessLayer.Contexts;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessLayer.Repositories
{
    public class ModelRepository :IRepository<ModelDTO>
    {
        private DataContext _dataContext;

        public ModelRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }


        public void Create(ModelDTO item)
        {
            _dataContext.Models.Add(item);
        }

        public void Delete(int id)
        {
            var m = _dataContext.Models.Find(id);
            if (m!=null)
            {
                _dataContext.Models.Remove(m);
            }
        }

        public IEnumerable<ModelDTO> Get()
        {
            return _dataContext.Models;
        }

        public ModelDTO Get(int id)
        {
            return _dataContext.Models.Find(id);
        }

        public void Update(ModelDTO item)
        {
            _dataContext.Entry(item).State = EntityState.Modified;
        }
    }
}
