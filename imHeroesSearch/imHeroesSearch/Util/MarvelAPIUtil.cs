using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace imHeroesSearch.Util
{
    public class MarvelAPIUtil
    {
        public static string GetHash(string time, string publicKey, string privateKey)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(time + privateKey + publicKey);
            var generator = MD5.Create();
            byte[] bytesHash = generator.ComputeHash(bytes);
            return BitConverter.ToString(bytesHash).ToLower().Replace("-", String.Empty);
        }
    }
}