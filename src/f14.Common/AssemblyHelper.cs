using System.Reflection;

namespace f14
{
    /// <summary>
    /// Helpers methods for assemblies.
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Returns an array with resources names from assembly that contains the given type.
        /// </summary>
        /// <param name="assemblyType">Assembly type.</param>
        /// <returns>Array with resource names.</returns>
        public static string[] GetAssemblyResourceNames(Type assemblyType) => assemblyType.GetTypeInfo().Assembly.GetManifestResourceNames();

        /// <summary>
        /// Gets location for executing assembly.
        /// </summary>
        /// <returns>Path to executing assembly.</returns>
        public static string? GetExeLocation() => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
