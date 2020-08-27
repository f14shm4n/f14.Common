using System.Diagnostics;

namespace System.Net
{
    /// <summary>
    /// Provides a query parameter.
    /// </summary>
    [DebuggerDisplay("{Name}: {Value}")]
    public class QueryParameter : IEquatable<QueryParameter>
    {
        /// <summary>
        /// Creates new instance of the parameter with default value for <see cref="EncodeValue"/> equal to 'true'.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        public QueryParameter(string name, string value) : this(name, value, true) { }

        /// <summary>
        /// Creates new instance of the parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <param name="encodeValue">Determines whether the parameter should be encoded with <see cref="WebUtility.UrlEncode(string)"/>.</param>
        public QueryParameter(string name, string value, bool encodeValue) : this(name, value, 0, encodeValue) { }

        /// <summary>
        /// Creates new instance of the parameter with default value for <see cref="EncodeValue"/> equal to 'true'.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <param name="order">Parameter order.</param>
        public QueryParameter(string name, string value, int order) : this(name, value, order, true) { }

        /// <summary>
        /// Creates new instance of the parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <param name="order">Parameter order.</param>
        /// <param name="encodeValue">Determines whether the parameter should be encoded with <see cref="WebUtility.UrlEncode(string)"/>.</param>
        public QueryParameter(string name, string value, int order, bool encodeValue)
        {
            Name = name;
            Value = value;
            Order = order;
            EncodeValue = encodeValue;
        }

        /// <summary>
        /// Gets the parameter order.
        /// </summary>
        public int Order { get; }

        /// <summary>
        /// Gets the parameter name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the parameter value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Determines whether the parameter should be encoded with <see cref="WebUtility.UrlEncode(string)"/>.
        /// </summary>
        public bool EncodeValue { get; }

        public bool Equals(QueryParameter other)
        {
            if (ReferenceEquals(this, other))
                return true;

            if (other == null)
                return false;

            return Name == other.Name && Value == other.Value && Order == other.Order && EncodeValue == other.EncodeValue;
        }

        public override bool Equals(object obj)
        {
            return Equals((obj as QueryParameter)!);
        }

        public override int GetHashCode()
        {
            return 0xF5F3198 ^ Name.GetHashCode(StringComparison.Ordinal) ^ Value.GetHashCode(StringComparison.Ordinal) ^ Order.GetHashCode() ^ EncodeValue.GetHashCode();
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
