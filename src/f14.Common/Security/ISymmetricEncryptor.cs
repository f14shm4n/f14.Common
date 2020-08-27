namespace f14.Security
{
    /// <summary>
    /// The base interface for data encryptor using symmetric algorithm.
    /// </summary>
    public interface ISymmetricEncryptor
    {
        /// <summary>
        /// Encrypts the string data with the given key.
        /// </summary>
        /// <param name="data">The string data.</param>
        /// <param name="key">The secret key.</param>
        /// <returns>The encrypted byte array.</returns>
        byte[] Encrypt(string data, byte[] key);

        /// <summary>
        /// Dercypts the byte array to the string using the given key.
        /// </summary>
        /// <param name="data">The byte array data.</param>
        /// <param name="key">The secret key.</param>
        /// <returns>The decrypted string data.</returns>
        string Decrypt(byte[] data, byte[] key);
    }
}
