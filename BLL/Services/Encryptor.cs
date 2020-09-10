using System;
using System.Linq;

namespace BLL.Services
{
    public static class Encryptor
    {
        public static string EncodeOrDecrypt(string str)
        {
            ushort[] keys = new ushort[10] { 0x0088, 0x0011, 0x0022, 0x0033, 0x0044, 0x0055, 0x0066, 0x0077, 0x0000, 0x0099 };
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            Random rnd = new Random();
            var secretKey = keys[rnd.Next(0, keys.Length)];
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