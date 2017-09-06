namespace KotoriCli.Outputs
{
    /// <summary>
    /// Output.
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Print message.
        /// </summary>
        /// <param name="message">Message.</param>
        void Message(string message);

        /// <summary>
        /// Print error.
        /// </summary>
        /// <returns>The error message.</returns>
        void Error(string error);

        /// <summary>
        /// Process the specified result.
        /// </summary>
        /// <param name="result">Result.</param>
        void Process(Tokens.Result result);
    }
}
