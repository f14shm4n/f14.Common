namespace System
{
    /// <summary>
    /// Provides an extensions methods for the <see cref="object"/> type.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Throws the <see cref="ArgumentNullException"/> if the current object is null.
        /// </summary>
        /// <typeparam name="T">Type of the current object.</typeparam>
        /// <param name="current">Current object.</param>
        /// <param name="paramName">The parameter name which means that the current object passed as parameter.</param>
        public static void ThrowIfNull<T>(this T current, string paramName)
        {
            if (current == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
