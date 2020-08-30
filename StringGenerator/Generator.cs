using System;
using System.Collections.Generic;
using System.Text;

namespace StringGenerator
{
    public static class Generator
    {
        public static string Generate()
        {
            string str = "";
            var range = new Random();
            for (int i = 0; i < range.Next(10, 40); i++)
            {
                str += setSymbol();
            }
            return str;
        }

        static char setSymbol()
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
