using System.Security.Cryptography;

namespace f14.Security
{
    /// <summary>
    /// Provides the AES algorithm encryptor.
    /// The code in the Encrypt and Decrypt methods from: 'https://msdn.microsoft.com/ru-ru/library/system.security.cryptography.aes(v=vs.110).aspx'.
    /// </summary>
    public sealed class AesEncryptor : ISymmetricEncryptor
    {
        ///<inheritdoc/>
        public byte[] Encrypt(string data, byte[] key)
        {
            byte[] encrypted;
            using (var aesAlg = Aes.Create())
            {
                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new())
                {
                    msEncrypt.Write(aesAlg.IV, 0, 16);

                    // Create a decryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor();
                    using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(data);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        ///<inheritdoc/>
        public string Decrypt(byte[] data, byte[] key)
        {
            // Declare the string used to hold
            // the decrypted text.
            string? plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new(data))
                {
                    byte[] IVBuf = new byte[16];
                    msDecrypt.Read(IVBuf, 0, 16);
                    aesAlg.IV = IVBuf;
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new(csDecrypt))
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
