using System;
using System.Collections.Generic;
using System.Text;
using Projeto.CrosssCutting.Cryptography.Contracts;
using System.Security.Cryptography;

namespace Projeto.CrosssCutting.Cryptography.Services
{
    public class MD5Service : IMD5Service
    {
        public string Encryptar(string value)
        {
            var md5 = new MD5CryptoServiceProvider();

            //encriptar o valo recebido..
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            //converter a variavel hash de byte[] para string hexadecimal..
            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("X2"); //X2 -> hexadecimal
            }

            return result;
        }
    }
}
