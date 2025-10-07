namespace f14.IO
{
    /// <summary>
    /// Provides methods to read and write data to file.
    /// </summary>
    public static partial class FileIO
    {
        /// <summary>
        /// Writes string collection to the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="lines">Sring collection.</param>
        /// <returns>Task.</returns>
        public static async Task WriteLinesAsync(string filePath, IEnumerable<string> lines, CancellationToken cancellationToken = default)
        {
            using var st = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var sw = new StreamWriter(st);
            foreach (var line in lines)
            {
                await sw.WriteLineAsync(line).ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        /// Writes string data to the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="data">String data.</param>
        /// <returns>Task.</returns>
        public static async Task WriteStingAsync(string filePath, string data)
        {
            using var st = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var sw = new StreamWriter(st);
            await sw.WriteAsync(data).ConfigureAwait(false);
        }
    }
}
