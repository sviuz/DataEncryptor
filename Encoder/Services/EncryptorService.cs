using AutoMapper;
using DataModels.Entities;
using DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncryptorLOGIC.Services
{
    public class EncryptorService : IEncryptorService
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly IMapper _mapper;

        public EncryptorService(DataBaseContext dataBaseContext, IMapper mapper)
        {
            _dataBaseContext = dataBaseContext;
            _mapper = mapper;
        }

        public Task AddData(Model model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model>> GetAllData()
        {
            throw new NotImplementedException();
        }

        public Task<Model> GetDataByID(int id)
        {
            throw new NotImplementedException();
        }

        private string EncryptData(string str, ushort secretKey)
        {
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }

        private char TopSecret(char character, ushort key)
        {
            character = (char)(character ^ key);
            return character;
        }
    }
}
