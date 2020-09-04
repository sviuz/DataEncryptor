using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper _mapper;

        public ModelService(IUnitOfWork uow, IMapper mapper)
        {
            database = uow;
            _mapper = mapper;
        }

        public void Create(ModelDTO model)
        {
            var newModel = _mapper.Map<DataModel>(model);
            database.Models.Create(newModel);
        }

        public void Delete(ModelDTO model)
        {
            throw new NotImplementedException();
        }

        public ModelDTO Get(int id)
        {
            var model = _mapper.Map<ModelDTO>(database.Models.Get(id));
            return model;
        }

        public IEnumerable<ModelDTO> GetAll()
        {
            var models = _mapper.Map<IEnumerable<ModelDTO>>(database.Models.Get());
            return models;
        }

    }
}
