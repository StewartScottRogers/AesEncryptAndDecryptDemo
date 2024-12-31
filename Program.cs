using System;

namespace AesEncryptAndDecryptDemo
{
    static class Program
    {
        static void Main(string[] args)
        {
            (byte[] Key, byte[] Iv) keyAndIv
                = KeyAndIvGenerator.CreateKeyAndIv("01234567890123456789012345678901");

            string plainText = "Hello, World!";
            Console.WriteLine("Plain Text: " + plainText);
            Console.WriteLine();

            // Encrypt
            (byte[] CypherBytes, byte[] IvBytes) encryptPacket
                = AesEncryption.Encrypt(plainText, keyAndIv.Iv, keyAndIv.Key);
            Console.WriteLine("Cipher Bytes: " + BitConverter.ToString(encryptPacket.CypherBytes));
            Console.WriteLine();

            string cipherText = Convert.ToBase64String(encryptPacket.CypherBytes);
            Console.WriteLine("Cipher Base64: " + cipherText);
            Console.WriteLine();

            // Decrypt
            string decryptedText = AesEncryption.Decrypt(encryptPacket.CypherBytes, encryptPacket.IvBytes, keyAndIv.Key);
            Console.WriteLine("Decrypted Text: " + decryptedText);

            Console.WriteLine();
        }
    }
}