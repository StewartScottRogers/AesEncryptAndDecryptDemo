using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesEncryptAndDecryptDemo
{
    public class AesEncryption
    {
        public static (byte[] CypherBytes, byte[] IvBytes) Encrypt(string plainText, byte[] iv, byte[] key)
        {
            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;

            using ICryptoTransform cryptoTransform = aes.CreateEncryptor();
            using MemoryStream outputMemoryStream = new MemoryStream();
            using CryptoStream cryptoStream = new CryptoStream(outputMemoryStream, cryptoTransform, CryptoStreamMode.Write);

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            // DRAGONS-BE-HERE: Call Dispose() or the outputMemoryStream will not be completely written.
            cryptoStream.Dispose();

            return (outputMemoryStream.ToArray(), iv);
        }

        public static string Decrypt(byte[] cipherText, byte[] iv, byte[] key)
        {
            using Aes aes = Aes.Create();

            aes.Key = key;
            aes.IV = iv;

            using ICryptoTransform cryptoTransform = aes.CreateDecryptor();
            using MemoryStream inputMemoryStream = new MemoryStream(cipherText);
            using CryptoStream cryptoStream = new CryptoStream(inputMemoryStream, cryptoTransform, CryptoStreamMode.Read);
            using MemoryStream outputMemoryStream = new MemoryStream();

            cryptoStream.CopyTo(outputMemoryStream);

            return Encoding.UTF8.GetString(outputMemoryStream.ToArray());
        }
    }
}