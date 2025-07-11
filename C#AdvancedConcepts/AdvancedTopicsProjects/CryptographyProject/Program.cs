﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
internal class Program
{
    static void Main(string[] args)
    {
        #region Hashing Encryption
        //using (var sha265 = SHA256.Create())
        //{
        //    byte[] data = sha265.ComputeHash(Encoding.UTF8.GetBytes("Esam"));
        //    Console.WriteLine(BitConverter.ToString(data).Replace("-", ""));

        //}
        #endregion

        #region Symmetric Encryption
        //string encryptedString = SymmetricEncrypt("Fady", "1234567891234567");
        //Console.WriteLine(encryptedString); 
        //Console.WriteLine(SymmetricDecrypt(encryptedString, "1234567891234567"));
        #endregion

        #region ASymmetric Encryption

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            string publicKey = rsa.ToXmlString(false);

            string privateKey = rsa.ToXmlString(true);

            string originalMessage = "Hello, this is a secret message!";

            string encryptedMessage = ASymmetricEncrypt(originalMessage, publicKey);

            string decryptedMessage = ASymmetricDecrypt(encryptedMessage, privateKey);


            // Display the results
            Console.WriteLine($"\n\nPublic Key:\n {publicKey}");
            Console.WriteLine($"\n\nPrivate Key:\n {privateKey}");
            Console.WriteLine($"\nOriginal Message:\n {originalMessage}");
            Console.WriteLine($"\nEncrypted Message:\n {encryptedMessage}");
            Console.WriteLine($"\nDecrypted Message:\n {decryptedMessage}");
        }
        #endregion
        
        Console.ReadKey();
    }


    // ASymmetric Encryption
    static string ASymmetricEncrypt(string plainText, string publicKey)
    {
        try
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKey);


                byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), false);
                return Convert.ToBase64String(encryptedData);
            }
        }
        catch (CryptographicException ex)
        {
            Console.WriteLine($"Encryption error: {ex.Message}");
            throw; // Rethrow the exception to be caught in the Main method
        }
    }

    // ASymmetric Encryption
    static string ASymmetricDecrypt(string cipherText, string privateKey)
    {
        try
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKey);


                byte[] encryptedData = Convert.FromBase64String(cipherText);
                byte[] decryptedData = rsa.Decrypt(encryptedData, false);


                return Encoding.UTF8.GetString(decryptedData);
            }
        }
        catch (CryptographicException ex)
        {
            Console.WriteLine($"Decryption error: {ex.Message}");
            throw; // Rethrow the exception to be caught in the Main method
        }
    }





    // Symmetric Encryption
    static string SymmetricEncrypt(string plainText, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            // Set the key and IV for AES encryption
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[aesAlg.BlockSize / 8];


            // Create an encryptor
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);


            // Encrypt the data
            using (var msEncrypt = new System.IO.MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }


                // Return the encrypted data as a Base64-encoded string
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }
    // Symmetric Encryption
    static string SymmetricDecrypt(string cipherText, string key)
    {
        using (Aes aesAlg = Aes.Create())
        {
            // Set the key and IV for AES decryption
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.IV = new byte[aesAlg.BlockSize / 8];


            // Create a decryptor
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);


            // Decrypt the data
            using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
            {
                // Read the decrypted data from the StreamReader
                return srDecrypt.ReadToEnd();
            }
        }
    }
}

