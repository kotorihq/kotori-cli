using System.IO;

namespace KotoriCli.Tokens
{
    /// <summary>
    /// Input file.
    /// </summary>
    public class InputFile
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <value>The directory.</value>
        public string Directory { get; }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>The filename.</value>
        public string Filename { get; }

        /// <summary>
        /// Gets the result code.
        /// </summary>
        /// <value>The result code.</value>
        public Enums.ResultCode Code { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:KotoriCli.Tokens.InputFile"/> is directory.
        /// </summary>
        /// <value><c>true</c> if is directory; otherwise, <c>false</c>.</value>
        public bool IsDirectory { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.InputFile"/> class.
        /// </summary>
        public InputFile(string directory, Enums.ResultCode code)
        {
            IsDirectory = true;
            Directory = directory;
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.InputFile"/> class.
        /// </summary>
        /// <param name="basePath">Base path.</param>
        /// <param name="fullPath">Full path.</param>
        /// <param name="code">Result code.</param>
        public InputFile(string basePath, string fullPath, Enums.ResultCode code)
        {
            var dir = Path.GetDirectoryName(fullPath);
            var file = Path.GetFileName(fullPath);

            Directory = dir.ToPartPath(basePath);
            Filename = file;
            Code = code;
            Id = Path.Combine(Directory, Filename);

            IsDirectory = false;
        }
    }
}
