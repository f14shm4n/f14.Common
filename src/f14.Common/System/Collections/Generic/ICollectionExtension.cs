namespace System.Collections.Generic
{
    /// <summary>
    /// Provides extensions methods for <see cref="ICollection{T}"/>.
    /// </summary>
    public static class ICollectionExtension
    {
        /// <summary>
        /// Determines whether the collection is empty or not.
        /// </summary>
        /// <typeparam name="T">The collection item type.</typeparam>
        /// <param name="collection">The source collection.</param>
        /// <returns>True - if empty; False - if not.</returns>
        public static bool IsEmpty<T>(this ICollection<T> collection) => collection?.Count == 0;

        /// <summary>
        /// Add items into collection.
        /// </summary>
        /// <typeparam name="T">The collection item type.</typeparam>
        /// <param name="collection">The source collection.</param>
        /// <param name="data">The items that should be added.</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> data)
        {
            ArgumentNullException.ThrowIfNull(collection);
            ArgumentNullException.ThrowIfNull(data);

            foreach (var i in data)
            {
                collection.Add(i);
            }
        }
    }
}
