using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApp
{
    public static class Helper
    {
        public static long RandomLong()
        {
            Random rand = new Random();
            long a = rand.Next();
            long b = rand.Next();
            return a * b;
        }

        public static byte[] Hash(string plaintext)
        {
            HashAlgorithm algorithm = SHA512.Create();
            return algorithm.ComputeHash(Encoding.ASCII.GetBytes(plaintext));
        }
    }

}
