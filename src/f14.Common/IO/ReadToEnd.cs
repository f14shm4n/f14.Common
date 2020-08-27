using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace f14.IO
{
    /// <summary>
    /// Provides methods to read and write data to file.
    /// </summary>
    public static partial class FileIO
    {
        /// <summary>
        /// Reads all data in the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>The string value that represents the file content.</returns>
        public static string ReadToEnd(string filePath) => ReadToEnd(filePath, Encoding.UTF8, true, 1024, false);

        /// <summary>
        /// Reads all data in the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param> 
        /// <returns>The string value that represents the file content.</returns>
        public static string ReadToEnd(string filePath, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return ReadToEnd(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
        }

        /// <summary>
        /// Reads string data from the stream.
        /// </summary>
        /// <param name="stream">Input steam.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param>
        /// <returns>The string value that represents the stream content.</returns>
        public static string ReadToEnd(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            using var sr = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// Asynchronous reads all data in the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>The string value that represents the file content</returns>
        public static Task<string> ReadToEndAsync(string filePath) => ReadToEndAsync(filePath, Encoding.UTF8, true, 1024, false);

        /// <summary>
        /// Asynchronous reads all data in the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param>        
        /// <returns>The string value that represents the file content.</returns>
        public static async Task<string> ReadToEndAsync(string filePath, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return await ReadToEndAsync(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen).ConfigureAwait(false);
        }

        /// <summary>
        /// Asynchronous reads data from a stream.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param>        
        /// <returns>The string value that represents the file content.</returns>
        public static async Task<string> ReadToEndAsync(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            using var sw = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            return await sw.ReadToEndAsync().ConfigureAwait(false);
        }
    }
}
