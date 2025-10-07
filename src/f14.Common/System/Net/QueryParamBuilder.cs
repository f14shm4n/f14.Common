using System.Text;

namespace System.Net
{
    /// <summary>
    /// Provides the class for a query param builders.
    /// </summary>
    /// <remarks>
    /// Creates new instance of the builder.
    /// </remarks>
    public class QueryParamBuilder(string nameValueSeparator, string parametersSeparator)
    {
        private readonly List<QueryParameter> _parameters = [];

        /// <summary>
        /// Gets the name and value separator.
        /// </summary>
        public string NameValueSeparator { get; } = nameValueSeparator;

        /// <summary>
        /// Gets the query parameters separator.
        /// </summary>
        public string ParametersSeparator { get; } = parametersSeparator;

        /// <summary>
        /// Adds new query parameter.
        /// </summary>
        /// <param name="parameter">Query parameter.</param>
        public void AddParam(QueryParameter parameter)
        {
            _parameters.Add(parameter);
        }

        /// <summary>
        /// Sets the query parameter. This method is overriding existing parameter.
        /// </summary>
        /// <param name="parameter">Query parameter.</param>
        public void SetParam(QueryParameter parameter)
        {
            _parameters.RemoveAll(p => p.Name == parameter.Name);
            _parameters.Add(parameter);
        }

        /// <summary>
        /// Builds the query param string.
        /// </summary>
        /// <returns>String.</returns>
        public virtual string Build()
        {
            StringBuilder sb = new();
            int i = 0;
            _parameters.Sort(QueryParameter.Comparer);
            foreach (var p in _parameters)
            {
                sb.Append(p.Name).Append(NameValueSeparator).Append(p.EncodeValue ? WebUtility.UrlEncode(p.Value) : p.Value);
                if ((i + 1) < _parameters.Count)
                {
                    sb.Append(ParametersSeparator);
                }
                i++;
            }

            return sb.ToString();
        }
    }
}
