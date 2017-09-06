using KotoriCli.Tokens;

namespace KotoriCli.Storages
{
    /// <summary>
    /// Storage.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Gets all files.
        /// </summary>
        /// <returns>The collection of input files.</returns>
        /// <param name="path">Path.</param>
        /// <param name="path">Path.</param>
        /// <param name="recursive">If set to <c>true</c> recursive.</param>
        InputFilesResult GetAll(string path, Enums.FileType fileType, bool recursive);
    }
}
