using DataModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EncryptorLOGIC.Services
{
    public interface IEncryptorService
    {
        Task<Model> GetDataByID(int id);
        Task<IEnumerable<Model>> GetAllData();
        Task AddData(Model model);
    }
}
