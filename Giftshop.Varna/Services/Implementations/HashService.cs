using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Giftshop.Varna.Services
{
    public class HashService : IHashService
    {
        private readonly HashAlgorithm algorithm;

        public HashService(HashAlgorithm algorithm)
        {
            this.algorithm = algorithm;
        }

        public bool ComapareWithPlain(string hashText, string plainText)
        {
            var computedHash = ComputeHash(plainText);

            return CompareWithHash(hashText, computedHash);
        }

        public bool CompareWithHash(string left, string right)
        {
            return string.Equals(left, right);
        }

        public string ComputeHash(string plainText)
        {
            var hash = algorithm.ComputeHash(System.Text.Encoding.UTF8.GetBytes(plainText));
            return ToHex(hash);
        }

        public void Dispose()
        {
            algorithm?.Dispose();
        }

        public static string ToHex(byte[] bytes)
        {
            return BitConverter.ToString(bytes)
                .Replace("-", "")
                .ToLower();
        }
    }
}
