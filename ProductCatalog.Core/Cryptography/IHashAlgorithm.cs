namespace ProductCatalog.Core.Cryptography
{
    public interface IHashAlgorithm
    {
        string CalculateHash(string text);
    }
}
