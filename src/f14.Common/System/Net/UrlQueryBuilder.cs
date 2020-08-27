namespace System.Net
{
    /// <summary>
    /// Provides URL query builder.
    /// </summary>
    public sealed class UrlQueryBuilder : QueryParamBuilder
    {
        public override string NameValueSeparator => "=";

        public override string ParametersSeparator => "&";
    }
}
