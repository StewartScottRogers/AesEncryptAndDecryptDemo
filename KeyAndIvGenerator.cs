using System;
using System.Security.Cryptography;

namespace AesEncryptAndDecryptDemo
{
    public static class KeyAndIvGenerator
    {
        private const int Key256ByteLength = 32;
        private const int Iv016ByteLength = 16;

        public static (byte[] Key, byte[] Iv) CreateRngKeyAndIv()
        {
            byte[] key = new byte[Key256ByteLength];
            byte[] iv = new byte[Iv016ByteLength];

            using RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();

            rngCryptoServiceProvider.GetBytes(key);
            rngCryptoServiceProvider.GetBytes(iv);

            return (key, iv);
        }

        public static (byte[] Key, byte[] Iv) CreateRandomKeyAndIv()
        {
            byte[] key = new byte[Key256ByteLength];
            byte[] iv = new byte[Iv016ByteLength];

            new Random().NextBytes(key);
            new Random().NextBytes(iv);

            return (key, iv);
        }

        public static (byte[] Key, byte[] Iv) CreateKeyAndIv(string password)
        {
            byte[] key = new byte[Key256ByteLength];
            byte[] iv = new byte[Iv016ByteLength];

            new Random().NextBytes(key);

            return (key, iv);
        }
    }
}

