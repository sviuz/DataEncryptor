using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public static class Generator
    {
        public static string Generate()
        {
            string str = "";
            var range = new Random();
            for (int i = 0; i < range.Next(10, 40); i++)
            {
                str += addSymbol();
            }
            return str;
        }

        static char addSymbol()
        {
            Random rnd = new Random();
            string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!№;%:?*()_-+=^/?.,'\" ";
            char result = ' ';
            var array = Alphabet.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                result = array[rnd.Next(0, array.Length)];
            }
            return result;
        }
    }
}
