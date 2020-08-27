using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic
{
    /// <summary>
    /// Provides extesions methods for <see cref="IDictionary{TKey, TValue}"/>.
    /// </summary>
    public static class IDictionaryExtensions
    {
        /// <summary>
        /// Wrapper for <see cref="IDictionary{TKey, TValue}.TryGetValue(TKey, out TValue)"/>.
        /// </summary>
        /// <typeparam name="K">Key type.</typeparam>
        /// <typeparam name="V">Value type.</typeparam>
        /// <param name="src">Source collection.</param>
        /// <param name="key">Key.</param>
        /// <returns>The value.</returns>
        public static V GetValueOrDefault<K, V>(this IDictionary<K, V> src, [NotNull, DisallowNull] K key)
        {
            src.TryGetValue(key, out V v);
            return v;
        }
    }
}
