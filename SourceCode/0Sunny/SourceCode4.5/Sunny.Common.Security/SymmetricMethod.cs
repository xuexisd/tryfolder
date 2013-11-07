using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sunny.Common.Security
{
    public class SymmetricMethod
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainText">原始文本</param>
        /// <param name="KeyStr"></param>
        /// <param name="IVStr"></param>
        /// <returns></returns>
        public static string EncryptString_Aes(string plainText, string KeyStr, string IVStr)
        {
            byte[] Key = Encoding.UTF8.GetBytes(KeyStr.Replace("a", "e").Replace("A", "E").Replace("b", "n").Replace("B", "N").Replace("c", "r").Replace("C", "R").Replace("v", "y").Replace("V", "Y").Replace("g", "9").Replace("G", "9").Replace("o", "0").Replace("O", "0").Replace("1", "I").Replace("5", "S"));
            byte[] IV = Encoding.UTF8.GetBytes(IVStr.Replace("a", "e").Replace("A", "E").Replace("b", "n").Replace("B", "N").Replace("c", "r").Replace("C", "R").Replace("v", "y").Replace("V", "Y").Replace("g", "9").Replace("G", "9").Replace("o", "0").Replace("O", "0").Replace("1", "I").Replace("5", "S"));
            // Check arguments.
            //if (plainText == null || plainText.Length <= 0)
            //    throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            byte[] encrypted;
            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);

        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="cipherText">密码文本</param>
        /// <param name="KeyStr"></param>
        /// <param name="IVStr"></param>
        /// <returns></returns>
        public static string DecryptString_Aes(string cipherText, string KeyStr, string IVStr)
        {
            byte[] Key = Encoding.UTF8.GetBytes(KeyStr.Replace("a", "e").Replace("A", "E").Replace("b", "n").Replace("B", "N").Replace("c", "r").Replace("C", "R").Replace("v", "y").Replace("V", "Y").Replace("g", "9").Replace("G", "9").Replace("o", "0").Replace("O", "0").Replace("1", "I").Replace("5", "S"));
            byte[] IV = Encoding.UTF8.GetBytes(IVStr.Replace("a", "e").Replace("A", "E").Replace("b", "n").Replace("B", "N").Replace("c", "r").Replace("C", "R").Replace("v", "y").Replace("V", "Y").Replace("g", "9").Replace("G", "9").Replace("o", "0").Replace("O", "0").Replace("1", "I").Replace("5", "S"));
            // Check arguments.
            //if (cipherText == null || cipherText.Length <= 0)
            //    throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesManaged object
            // with the specified key and IV.
            using (AesManaged aesAlg = new AesManaged())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }
    }
}
