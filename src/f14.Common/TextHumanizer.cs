using System.Net;
using System.Text.RegularExpressions;

namespace f14
{
    /// <summary>
    /// Provides methods for making the input text human readable for various types of text sources.
    /// </summary>
    public static class TextHumanizer
    {
        /// <summary>
        /// Replaces all unnecessary new line, caret return, multiple tabs, spaces and decode it uses <see cref="WebUtility.HtmlDecode(string)"/> for the specified text.
        /// </summary>
        /// <param name="raw">Raw text to humanize.</param>
        /// <returns>Human readable text.</returns>
        public static string HumanizeHtmlInner(string raw)
        {
            raw = Regex.Replace(raw, @"(\r\n|\r|\n)", " ");
            raw = Regex.Replace(raw, @"\s{2,}", " ");
            return WebUtility.HtmlDecode(raw);
        }
    }
}
