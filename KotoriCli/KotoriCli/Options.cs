using CommandLine;

namespace KotoriCli
{
    /// <summary>
    /// Base options.
    /// </summary>
    public interface IOptions
    {
    }

    /// <summary>
    /// Options which required key.
    /// </summary>
    public interface IDirectoryKeyOptions
    {
        [Option('k', "key", SetName = "key", HelpText = "Auth key.", Required = true)]
        string Key { get; set; }

        [Value(0, MetaName = "directory", HelpText = "Directory to be processed.", Required = true)]
        string Directory { get; set; }
    }

    /// <summary>
    /// Publish options.
    /// </summary>
    [Verb("publish", HelpText = "Publish project.")]
    public class PublishOptions : IOptions, IDirectoryKeyOptions
    {
        public string Directory { get; set; }
        public string Key { get; set; }
    }

    /// <summary>
    /// Status options.
    /// </summary>
    [Verb("status", HelpText = "Publish project.")]
    public class StatusOptions : IOptions, IDirectoryKeyOptions
    {
        public string Directory { get; set; }
        public string Key { get; set; }
    }
}
