using System;
using System.Security.Cryptography;
using System.Text;
using ProductCatalog.Core.Cryptography;

namespace ProductCatalog.Core.Helpers
{
    public static class PasswordHelper
    {
        public static string GenerateSalt(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be > 0.", nameof(length));
            }

            using var cryptoService = new RNGCryptoServiceProvider();
            var saltBytes = new byte[length];
            cryptoService.GetNonZeroBytes(saltBytes);
            return Encoding.Unicode.GetString(saltBytes);
        }

        public static string ComputeHash(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentNullException(nameof(salt));
            }

            var hashAlgorithm = new Sha512Hash();
            return hashAlgorithm.CalculateHash(password + salt);
        }

        public static string Generate(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be > 0.", nameof(length));
            }

            var randomString = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Trim();
            return length <= randomString.Length ? randomString[..length] : randomString;
        }
    }
}
