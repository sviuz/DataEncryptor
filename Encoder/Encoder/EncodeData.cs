using DataModels.Models;
using System.Linq;
using System.Security.Cryptography;

namespace EncryptorLOGIC.Encoder
{
    public static class EncodeData
    {
        public static void Encode(Model model, ushort secretKey)
        {
            model.Name = EncodeDecrypt(model.Name, secretKey);
            model.Description = EncodeDecrypt(model.Description, secretKey);
            model.SecretValue = EncodeDecrypt(model.SecretValue, secretKey);
        }

        public static string EncodeDecrypt(string str, ushort secretKey)
        {
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }

        public static char TopSecret(char character, ushort secretKey)
        {
            character = (char)(character ^ secretKey); //Производим XOR операцию
            return character;
        }

        
    }
}
