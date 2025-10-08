namespace System.Text
{
    /// <summary>
    /// Represents custom encoding provider which returns <see cref="Encoding.UTF8"/> for next encoding names included double quotes in the name of encoding: utf8, UTF8, utf-8, UTF-8.
    /// </summary>
    public class UTF8EncodingProvider : EncodingProvider
    {
        private static IEnumerable<string> EncodingNames
        {
            get
            {
                yield return "utf8";
                yield return "utf-8";
            }
        }

        /// <inheritdoc />
        public override Encoding? GetEncoding(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            var adjustedName = name.Trim('"');

            foreach (var encName in EncodingNames)
            {
                if (string.Equals(adjustedName, encName, StringComparison.OrdinalIgnoreCase))
                {
                    return Encoding.UTF8;
                }
            }

            return null;
        }

        /// <inheritdoc />
        public override Encoding? GetEncoding(int codepage) => null;
    }
}
