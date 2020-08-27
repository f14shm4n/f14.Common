using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace f14.IO
{
    /// <summary>
    /// Provides methods to read and write data to file.
    /// </summary>
    public static partial class FileIO
    {
        /// <summary>
        /// Consecutively reads lines from a file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>The <see cref="IEnumerable{String}"/> that represents a file content.</returns>
        public static IEnumerable<string> ReadLines(string filePath) => ReadLines(filePath, Encoding.UTF8, true, 1024, false);

        /// <summary>
        /// Consecutively reads lines from a file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param>  
        /// <returns>The <see cref="IEnumerable{String}"/> that represents a file content.</returns>
        public static IEnumerable<string> ReadLines(string filePath, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            return ReadLines(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
        }

        /// <summary>
        /// Consecutively reads lines from a stream. This method does not load whole file into memory.
        /// </summary>
        /// <param name="stream">Input steam.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param>
        /// <returns>Array of strings.</returns>
        public static IEnumerable<string> ReadLines(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen)
        {
            using var sr = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                yield return line;
            }
        }

        /// <summary>
        /// Asynchronous and consecutively reads lines from a file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>Asynchronous enumerable stream.</returns>
        public static IAsyncEnumerable<string> ReadLinesAsync(string filePath) => ReadLinesAsync(filePath, default);

        /// <summary>
        /// Asynchronous and consecutively reads lines from a file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="cancellationToken">The cancellation token, to be able to stop read operation.</param>
        /// <returns>Asynchronous enumerable stream.</returns>
        public static IAsyncEnumerable<string> ReadLinesAsync(string filePath, CancellationToken cancellationToken) => ReadLinesAsync(filePath, Encoding.UTF8, true, 1024, false, cancellationToken);

        /// <summary>
        /// Asynchronous and consecutively reads lines from a file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param>        
        /// <param name="cancellationToken">The cancellation token, to be able to stop read operation.</param>
        /// <returns>Asynchronous enumerable stream.</returns>
        public static async IAsyncEnumerable<string> ReadLinesAsync(string filePath, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            await foreach (var line in ReadLinesAsync(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen, cancellationToken))
                yield return line;
        }

        /// <summary>
        /// Asynchronous and consecutively reads lines from a stream.
        /// </summary>
        /// <param name="stream">Input steam.</param>
        /// <param name="encoding">Data encoding.</param>
        /// <param name="detectEncodingFromByteOrderMarks">Detect byte order marks.</param>
        /// <param name="bufferSize">Buffer size.</param>
        /// <param name="leaveOpen">Leave stream open after read.</param>        
        /// <param name="cancellationToken">The cancellation token, to be able to stop read operation.</param>
        /// <returns>Asynchronous enumerable stream.</returns>
        public static async IAsyncEnumerable<string> ReadLinesAsync(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            using var reader = new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            string? line;
            while ((line = await reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                yield return line;

                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
            }
        }
    }
}
