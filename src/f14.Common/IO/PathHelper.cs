using System;
using System.IO;
using System.Linq;
using System.Text;

namespace f14.IO
{
    /// <summary>
    /// Provides helper methods for working with paths.
    /// </summary>
    public sealed class PathHelper
    {
        /// <summary>
        /// Cuts the path to the specified number of sections. Sections of the path, separated by backslash - '\'.
        /// </summary>
        /// <param name="path">The path string.</param>
        /// <param name="skip">Number of sections of the path for skipping, starting at the end of the path.</param>
        /// <returns>A new path line, a new path at the beginning and at the end does not contain a slash.</returns>
        public static string RemoveSections(string path, int skip) => RemoveSections(path, skip, false);

        /// <summary>
        /// Cuts the path to the specified number of sections. Sections of the path, separated by slash - '/'.
        /// </summary>
        /// <param name="path">The path string.</param>
        /// <param name="skip">Number of sections of the path for skipping, starting at the end of the path.</param>
        /// <returns>A new path line, a new path at the beginning and at the end does not contain a slash.</returns>
        public static string RemoveAltSections(string path, int skip) => RemoveSections(path, skip, true);

        /// <summary>
        /// Cuts the path to the specified number of sections.
        /// </summary>
        /// <param name="path">The path string.</param>
        /// <param name="skip">Number of sections of the path for skipping, starting at the end of the path.</param>
        /// <param name="useAltSeparatorChar">true - the <see cref="Path.AltDirectorySeparatorChar"/> will be used as directory separator char; false - <see cref="Path.DirectorySeparatorChar"/>.</param>
        /// <returns>A new path line, a new path at the beginning and at the end does not contain a slash.</returns>
        private static string RemoveSections(string path, int skip, bool useAltSeparatorChar)
        {
            path.ThrowIfNull(nameof(path));

            char separator;

            if (useAltSeparatorChar)
            {
                separator = Path.AltDirectorySeparatorChar;
                path = path.Replace(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            }
            else
            {
                separator = Path.DirectorySeparatorChar;
                path = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            StringBuilder sb = new StringBuilder();
            string[] parts = path
                .Split(separator)
                .Except(new string[] { " ", "" })
                .ToArray();

            for (int i = 0; i < parts.Length; i++)
            {
                var p = parts[i];

                if (string.IsNullOrWhiteSpace(p))
                    continue;

                if (i < parts.Length - skip)
                {
                    sb.Append(separator).Append(p);
                }
                else
                {
                    break;
                }
            }

            string result = sb.ToString();
            if (result.StartsWith(separator.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                result = result.Remove(0, 1);
            }

            return result;
        }
    }
}
