using System.Collections.Generic;

namespace KotoriCli.Tokens
{
    /// <summary>
    /// Input files result.
    /// </summary>
    public class InputFilesResult : Result
    {
        /// <summary>
        /// Gets or sets the input files.
        /// </summary>
        /// <value>The collection of input files.</value>
        public IEnumerable<InputFile> InputFiles { get; set; } = new List<InputFile>();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.InputFilesResult"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="inputFiles">Input files.</param>
        public InputFilesResult(Enums.ResultCode code, IEnumerable<InputFile> inputFiles) : base(code)
        {
            InputFiles = inputFiles;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.InputFilesResult"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="message">Message.</param>
        public InputFilesResult(Enums.ResultCode code, string message) : base(code, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.InputFilesResult"/> class.
        /// </summary>
        public InputFilesResult()
        {
        }
    }
}
