using System;
using ProductCatalog.Core.Cryptography;

namespace ProductCatalog.Core.Cryptography
{
    public abstract class HashAlgorithm : IHashAlgorithm
    {
        public string CalculateHash(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (text.Length == 0)
            {
                throw new ArgumentException("Length must be > 0.", nameof(text));
            }

            return CalculateHashInternal(text);
        }

        protected abstract string CalculateHashInternal(string text);
    }
}
