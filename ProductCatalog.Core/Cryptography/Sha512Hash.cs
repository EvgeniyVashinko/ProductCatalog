using System.Security.Cryptography;
using System.Text;

namespace ProductCatalog.Core.Cryptography
{
    public sealed class Sha512Hash : HashAlgorithm
    {
        protected override string CalculateHashInternal(string text)
        {
            var bytes = Encoding.Unicode.GetBytes(text);
            using var sha512 = SHA512.Create();
            var hashed = sha512.ComputeHash(bytes);
            return Encoding.Unicode.GetString(hashed);
        }
    }
}
