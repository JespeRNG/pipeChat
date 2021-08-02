using System;
using System.Security.Cryptography;
using System.Text;

namespace Chat.DAL
{
    public class PasswordProcessing
    {
        public string GenerateSalt()
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[6];
            random.GetNonZeroBytes(salt);
            return Convert.ToBase64String(salt);
        }
        public string GetHashCode(string pass, string salt)
        {
            return Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(pass + salt)));
        }
    }
}