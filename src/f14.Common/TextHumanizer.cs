using System.Net;
using System.Text.RegularExpressions;

namespace f14
{
    /// <summary>
    /// Provides methods for making the input text human readable for various types of text sources.
    /// </summary>
    public static partial class TextHumanizer
    {
        /// <summary>
        /// Replaces all unnecessary new line, caret return, multiple tabs, spaces and decode it uses <see cref="WebUtility.HtmlDecode(string)"/> for the specified text.
        /// </summary>
        /// <param name="raw">Raw text to humanize.</param>
        /// <returns>Human readable text.</returns>
        public static string HumanizeHtmlInner(string raw)
        {
            raw = NewLineRegex().Replace(raw, " ");
            raw = WhiteSpacesRegex().Replace(raw, " ");
            return WebUtility.HtmlDecode(raw);
        }

        [GeneratedRegex(@"(\r\n|\r|\n)")]
        private static partial Regex NewLineRegex();

        [GeneratedRegex(@"\s{2,}")]
        private static partial Regex WhiteSpacesRegex();
    }
}
