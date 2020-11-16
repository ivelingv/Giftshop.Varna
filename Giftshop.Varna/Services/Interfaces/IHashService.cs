using System;

namespace Giftshop.Varna.Services
{
    public interface IHashService : IDisposable
    {
        string ComputeHash(string plainText);

        bool ComapareWithPlain(string hashText, string plainText);

        bool CompareWithHash(string left, string right);
    }
}