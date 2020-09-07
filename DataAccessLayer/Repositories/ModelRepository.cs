﻿using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class ModelRepository :IRepository<DataModel>
    {
        private DataContext _dataContext;

        public ModelRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void Create(DataModel item)
        {
            try
            {
                var newItem = new DataModel { Id = item.Id, Name = item.Name, Desc = item.Desc };
                _dataContext.Models.Add(newItem);
            }
            catch (System.Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public void Delete(int id)
        {
            var m = _dataContext.Models.Find(id);
            if (m!=null)
            {
                _dataContext.Models.Remove(m);
            }
        }

        public IEnumerable<DataModel> Get()
        {
            return _dataContext.Models.AsNoTracking().AsEnumerable();
        }

        public DataModel Get(int id)
        {
            return _dataContext.Models.Find(id);
        }

        public void Update(DataModel item)
        {
            _dataContext.Entry(item).State = EntityState.Modified;
        }
    }
}
