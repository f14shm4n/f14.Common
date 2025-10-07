namespace System.Net
{
    /// <summary>
    /// Provides URL query builder.
    /// </summary>
    public sealed class UrlQueryBuilder : QueryParamBuilder
    {
        public UrlQueryBuilder() : base("=", "&")
        {
        }
    }
}
