using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace f14
{
    /// <summary>
    /// Provides wrappers for hashing algorithms to calculate the hash value from given strings.
    /// </summary>
    public static class HashHelper
    {
        /// <summary>
        /// Computes the hash value uses <see cref="SHA512"/>.
        /// </summary>
        /// <param name="inputString">Source string.</param>
        /// <returns>Hash value.</returns>
        public static string GetSHA512HashString(string inputString)
        {
            using (var alg = SHA512.Create())
            {
                return GetHashString(alg, inputString);
            }
        }

        /// <summary>
        /// Computes the hash value uses <see cref="SHA384"/>.
        /// </summary>
        /// <param name="inputString">Source string.</param>
        /// <returns>Hash value.</returns>
        public static string GetSHA384HashString(string inputString)
        {
            using (var alg = SHA384.Create())
            {
                return GetHashString(alg, inputString);
            }
        }

        /// <summary>
        /// Computes the hash value uses <see cref="SHA256"/>.
        /// </summary>
        /// <param name="inputString">Source string.</param>
        /// <returns>Hash value.</returns>
        public static string GetSHA256HashString(string inputString)
        {
            using (var alg = SHA256.Create())
            {
                return GetHashString(alg, inputString);
            }
        }

        /// <summary>
        /// Computes the hash value uses <see cref="SHA1"/>.
        /// </summary>
        /// <param name="inputString">Source string.</param>
        /// <returns>Hash value.</returns>
        public static string GetSHA1HashString(string inputString)
        {
#pragma warning disable CA5350 // Не используйте слабые алгоритмы шифрования
            using (var alg = SHA1.Create())
#pragma warning restore CA5350 // Не используйте слабые алгоритмы шифрования
            {
                return GetHashString(alg, inputString);
            }
        }


        /// <summary>
        /// Computes the hash value uses <see cref="MD5"/>.
        /// </summary>
        /// <param name="inputString">Source string.</param>
        /// <returns>Hash value.</returns>
        public static string GetMD5HashString(string inputString)
        {
#pragma warning disable CA5351 // Не используйте взломанные алгоритмы шифрования
            using (var alg = MD5.Create())
#pragma warning restore CA5351 // Не используйте взломанные алгоритмы шифрования
            {
                return GetHashString(alg, inputString);
            }
        }

        /// <summary>
        /// Computes the hash value uses specified hash algorithm and input string.
        /// </summary>
        /// <param name="algorithm">Hash algorithm.</param>
        /// <param name="inputString">Source string.</param>
        /// <returns>Hash value.</returns>
        public static string GetHashString(HashAlgorithm algorithm, string inputString)
        {
            StringBuilder sb = new();
            foreach (byte b in GetHash(algorithm, inputString))
            {
                sb.Append(b.ToString("X2", CultureInfo.InvariantCulture));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Computes the hash value uses specified hash algorithm and input string.
        /// </summary>
        /// <param name="algorithm">Hash algorithm.</param>
        /// <param name="inputString">Source string.</param>
        /// <returns>Hash value as array of bytes.</returns>
        public static byte[] GetHash(HashAlgorithm algorithm, string inputString)
        {
            ArgumentNullException.ThrowIfNull(algorithm);
            ArgumentNullException.ThrowIfNull(inputString);
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
    }
}
