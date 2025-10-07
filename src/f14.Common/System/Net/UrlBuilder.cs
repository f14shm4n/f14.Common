using System.Text;

namespace System.Net
{
    /// <summary>
    /// Represents the URL builder that provides basic workflow.
    /// </summary>
    public class UrlBuilder(string baseAddress)
    {
        private readonly UrlQueryBuilder _queryBuilder = new();

        /// <summary>
        /// Adds new query parameter.
        /// </summary>
        /// <param name="parameter">Query parameter.</param>
        public void AddQueryParam(QueryParameter parameter) => _queryBuilder.AddParam(parameter);

        /// <summary>
        /// Sets the query parameter. This method is overriding existing parameter.
        /// </summary>
        /// <param name="parameter">Query parameter.</param>
        public void SetQueryParam(QueryParameter parameter) => _queryBuilder.SetParam(parameter);

        /// <summary>
        /// Gets the base address.
        /// </summary>
        public string BaseAddress { get; } = baseAddress;

        /// <summary>
        /// Builds new <see cref="Uri"/>.
        /// </summary>
        /// <returns><see cref="Uri"/>.</returns>
        public virtual Uri Build()
        {
            StringBuilder sb = new();
            sb.Append(BaseAddress);

            if (!BaseAddress.EndsWith('?'))
            {
                sb.Append('?');
            }

            sb.Append(_queryBuilder.Build());

            return new Uri(sb.ToString());
        }
    }
}
