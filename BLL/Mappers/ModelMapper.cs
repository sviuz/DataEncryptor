using AutoMapper;
using BLL.DTO;
using BLL.DTO.ViewModels;
using DataAccessLayer.Entities;

namespace BLL.Mappers
{
    public class ModelMapper :Profile
    {
        public ModelMapper()
        {
            CreateMap<ModelDTO, DataModel>();
            CreateMap<DataModel, ModelDTO>();
            CreateMap<UserDTO, DataUser>();
            CreateMap<DataUser, UserDTO>();
        }
    }
}
