namespace System.Collections
{
    /// <summary>
    /// Provides extensions methods for <see cref="ICollection"/>.
    /// </summary>
    public static class ICollectionExtension
    {
        /// <summary>
        /// Determines whether the collection is empty or not.
        /// </summary>
        /// <param name="collection">The source collection.</param>
        /// <returns>True - if empty; False - if not.</returns>
        public static bool IsEmpty(this ICollection collection) => collection?.Count == 0;
    }
}
