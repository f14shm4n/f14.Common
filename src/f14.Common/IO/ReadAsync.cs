using System.Runtime.CompilerServices;
using System.Text;

namespace f14.IO
{
    /// <summary>
    /// Provides methods to read and write data to file.
    /// </summary>
    public static partial class FileIO
    {
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
            {
                yield return line;
            }
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
            while ((line = await reader.ReadLineAsync(cancellationToken: cancellationToken).ConfigureAwait(false)) != null)
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
