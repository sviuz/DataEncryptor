using AutoMapper;
using BLL.DTO;
using DataAccessLayer.Entities;

namespace BLL.Mappers
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<ModelDTO, DataModel>();
            CreateMap<DataModel, ModelDTO>();
        }
    }
}
