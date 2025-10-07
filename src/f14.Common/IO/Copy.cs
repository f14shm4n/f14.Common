namespace f14.IO
{
    /// <summary>
    /// Provides methods to read and write data to file.
    /// </summary>
    public static partial class FileIO
    {
        /// <summary>
        /// Copy directory. [From MSDN Samples]
        /// </summary>
        /// <param name="srcFolderPath">Path to source folder.</param>
        /// <param name="dstFolderPath">Path to destination folder.</param>
        /// <param name="overwriteFiles">Overwrite files if exists.</param>
        public static void CopyAll(string srcFolderPath, string dstFolderPath, bool overwriteFiles) => CopyAll(new DirectoryInfo(srcFolderPath), new DirectoryInfo(dstFolderPath), overwriteFiles);

        /// <summary>
        /// Copy directory. [From MSDN Samples]
        /// </summary>
        /// <param name="source">Source directory info.</param>
        /// <param name="target">Target directory info.</param>
        /// <param name="overwriteFiles">Overwrite files if exists.</param>
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target, bool overwriteFiles)
        {
            if (!source.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + source.FullName);
            }

            if (string.Equals(source.FullName, target.FullName, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Same locations.");
            }

            // Check if the target directory exists, if not, create it.
            if (!Directory.Exists(target.FullName))
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.EnumerateFiles())
            {
                string destPath = Path.Combine(target.ToString(), fi.Name);
                if (File.Exists(destPath) && !overwriteFiles)
                {
                    continue;
                }
                fi.CopyTo(destPath, overwriteFiles);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.EnumerateDirectories())
            {
                DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir, overwriteFiles);
            }
        }
    }
}
