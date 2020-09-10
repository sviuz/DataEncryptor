using AutoMapper;
using BLL.DTO;
using DataAccessLayer.Entities;

namespace BLL.Mappers
{
    public class ModelMapper : Profile
    {
        public ModelMapper()
        {
            CreateMap<ModelDTO, DataModel>();
            CreateMap<DataModel, ModelDTO>();
        }
    }
}