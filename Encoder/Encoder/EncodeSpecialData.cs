using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EncryptorLOGIC.Encoder
{
    public static class EncodeSpecialData
    {
        public static string EncodeTopSecret(string str)
        {
            ushort secretKey = 0x0088;
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }

        private static char TopSecret(char character, ushort key)
        {
            character = (char)(character ^ key); //Производим XOR операцию
            return character;
        }

        public static string DecodeTopSecret(string str)
        {
            ushort secretKey = 0x0088;
            var ch = str.ToArray(); //преобразуем строку в символы
            string newStr = "";      //переменная которая будет содержать зашифрованную строку
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);  //производим шифрование каждого отдельного элемента и сохраняем его в строку
            return newStr;
        }
    }
}
