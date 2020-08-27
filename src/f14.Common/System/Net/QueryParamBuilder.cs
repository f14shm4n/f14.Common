using f14;
using System.Collections.Generic;
using System.Text;

namespace System.Net
{
    /// <summary>
    /// Provides the base class for a query param builders.
    /// </summary>
    public abstract class QueryParamBuilder
    {
        private readonly List<QueryParameter> _parameters = new List<QueryParameter>();
        private readonly PredicateComparer<QueryParameter> _comparer = new PredicateComparer<QueryParameter>((x, y) => x.Order.CompareTo(y.Order));

        /// <summary>
        /// Creates new instance of the builder.
        /// </summary>
        protected QueryParamBuilder()
        {
        }

        /// <summary>
        /// Gets the name and value separator.
        /// </summary>
        public abstract string NameValueSeparator { get; }

        /// <summary>
        /// Gets the query parameters separator.
        /// </summary>
        public abstract string ParametersSeparator { get; }

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
            StringBuilder sb = new StringBuilder();
            int i = 0;
            _parameters.Sort(_comparer);
            foreach (var p in _parameters)
            {
                sb.Append($"{p.Name}{NameValueSeparator}{(p.EncodeValue ? WebUtility.UrlEncode(p.Value) : p.Value)}");

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
