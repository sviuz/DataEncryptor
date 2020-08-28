using AutoMapper;
using DataModels.Entities;
using DataModels.Models;

namespace EncryptorLOGIC.Mappers
{
    public class MappingEntity :Profile
    {
        public MappingEntity()
        {
            CreateMap<Model, DataBaseModel>();
            CreateMap<DataBaseModel, Model>();
        }
    }
}
