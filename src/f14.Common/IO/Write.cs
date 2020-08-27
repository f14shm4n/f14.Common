using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
        /// <param name="data">Sring collection.</param>
        public static void WriteLines(string filePath, IEnumerable<string> data)
        {
            using var st = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var sw = new StreamWriter(st);
            foreach (var s in data)
            {
                sw.WriteLine(s);
            }
        }

        /// <summary>
        /// Writes string collection to the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="data">Sring collection.</param>
        /// <returns>Task.</returns>
        public static async Task WriteLinesAsync(string filePath, IEnumerable<string> data)
        {
            using var st = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var sw = new StreamWriter(st);
            foreach (var s in data)
            {
                await sw.WriteLineAsync(s).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Writes string data to the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="data">String data.</param>
        public static void WriteData(string filePath, string data)
        {
            using var st = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var sw = new StreamWriter(st);
            sw.Write(data);
        }

        /// <summary>
        /// Writes string data to the file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <param name="data">String data.</param>
        /// <returns>Task.</returns>
        public static async Task WriteDataAsync(string filePath, string data)
        {
            using var st = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            using var sw = new StreamWriter(st);
            await sw.WriteAsync(data).ConfigureAwait(false);
        }
    }
}
