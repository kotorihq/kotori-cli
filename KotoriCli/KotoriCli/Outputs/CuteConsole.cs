using System;

namespace KotoriCli.Outputs
{
    /// <summary>
    /// Classic console output with some coloring.
    /// </summary>
    public class CuteConsole : IOutput
    {
        private static readonly object _output = new object();

        /// <summary>
        /// Show error message.
        /// </summary>
        /// <param name="error">Error message.</param>
        public void Error(string error)
        {
            PrintMessage(error, ConsoleColor.Red);
        }

        /// <summary>
        /// Show message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void ProgressMessage(string message)
        {
            PrintMessage(message);
        }

        /// <summary>
        /// Show message.
        /// </summary>
        /// <param name="message">Message.</param>
        public void Message(string message)
        {
            PrintMessage(message);
        }

        /// <summary>
        /// Process result token.
        /// </summary>
        /// <param name="result">Result token.</param>
        public void Process(Tokens.Result result)
        {
            if (string.IsNullOrEmpty(result.Message))
            {
                if (result.Code == Enums.ResultCode.Ok)
                {
                    PrintMessage("Ok!", ConsoleColor.Green);
                } 
                else if (result.Code == Enums.ResultCode.Fail)
                {
                    Error("Internal error.");
                }
            }
            else
            {
                if (result.Code == Enums.ResultCode.Ok)
                {
                    PrintMessage(result.Message, ConsoleColor.Green);
                }
                else if (result.Code == Enums.ResultCode.Fail)
                {
                    Error(result.Message);
                }
            }
        }

        private static void PrintMessage(string message, ConsoleColor? color = null)
        {
            if (color == null)
            {
                Console.WriteLine(message);
            }
            else
            {
                lock (_output)
                {
                    Console.ForegroundColor = color.Value;
                    Console.WriteLine(message);
                    Console.ResetColor();
                }
            }
        }
    }
}
