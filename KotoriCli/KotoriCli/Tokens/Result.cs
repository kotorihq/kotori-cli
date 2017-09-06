namespace KotoriCli.Tokens
{
    /// <summary>
    /// Generic result.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        public Enums.ResultCode Code { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.Result"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="message">Message.</param>
        public Result(Enums.ResultCode code, string message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.Result"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        public Result(Enums.ResultCode code)
        {
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:KotoriCli.Tokens.Result"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        public Result()
        {
        }
    }
}
