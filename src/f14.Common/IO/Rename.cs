namespace f14.IO
{
    /// <summary>
    /// Provides methods to read and write data to file.
    /// </summary>
    public static partial class FileIO
    {
        /// <summary>
        /// Rename file.
        /// </summary>
        /// <param name="oldName">Old name.</param>
        /// <param name="newName">New name.</param>
        public static void RenameFile(string oldName, string newName)
        {
            CheckRenameRequirements(oldName, newName);
            File.Move(oldName, newName);
        }

        /// <summary>
        /// Rename folder.
        /// </summary>
        /// <param name="oldName">Old name.</param>
        /// <param name="newName">New name.</param>
        public static void RenameFolder(string oldName, string newName)
        {
            CheckRenameRequirements(oldName, newName);
            Directory.Move(oldName, newName);
        }

        #region Helpers

        /// <summary>
        /// Checking requirements for the rename operation.
        /// </summary>
        /// <param name="oldName">Old name.</param>
        /// <param name="newName">New name.</param>
        private static void CheckRenameRequirements(string oldName, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(newName))
            {
                throw new InvalidOperationException("Source name or Destination name cannot be empty.");
            }

            string? srcDir = Path.GetDirectoryName(oldName);
            string? destDir = Path.GetDirectoryName(newName);

            if (!string.Equals(srcDir, destDir, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("Source file folder and destination file folder must be the same.");
            }
        }

        #endregion
    }
}
