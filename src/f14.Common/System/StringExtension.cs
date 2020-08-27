using System.Text;

namespace System
{
    /// <summary>
    /// String extensions methods.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Cuts the source string to the specified length, if the source string is shorter than the required length, 
        /// then the original string will be returned without any manipulation.
        /// </summary>
        /// <param name="source">String to truncate.</param>
        /// <param name="length">Required string length.</param>
        /// <returns>Truncated string.</returns>
        public static string Truncate(this string source, int length) => source.Length <= length ? source : source.Substring(0, length);

        /// <summary>
        /// Encodes the specified string to a base64 representation with <see cref="Encoding.UTF8"/>.
        /// </summary>
        /// <param name="source">String to encode.</param>
        /// <returns>Base64 string.</returns>
        public static string ToBase64(this string source) => source.ToBase64(Encoding.UTF8);

        /// <summary>
        /// Encodes the specified string to a base64 representation with specific <see cref="Encoding"/>.
        /// </summary>
        /// <param name="source">String to encode.</param>
        /// <param name="encoding">Encoding implementation.</param>
        /// <returns>Base64 string.</returns>
        public static string ToBase64(this string source, Encoding encoding)
        {
            byte[] arr = encoding.GetBytes(source);
            return Convert.ToBase64String(arr);
        }
    }
}
