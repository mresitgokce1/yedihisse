using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace yedihisse.Shared.Utilities.Encrytpions
{
    public class PasswordEncryption
    {
        public static string CreateHashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyHashPassword(string oldHashBytes, string newPassword)
        {
            byte[] newHashBytes = Convert.FromBase64String(oldHashBytes);
            byte[] salt = new byte[16];
            Array.Copy(newHashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(newPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
                if (newHashBytes[i + 16] != hash[i])
                    return false;

            return true;
        }
    }
}
