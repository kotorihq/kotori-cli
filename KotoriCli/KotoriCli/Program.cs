using CommandLine;
using KotoriCli.Commands;
using KotoriCli.Outputs;

namespace KotoriCli
{
    class Program
    {
        static int Main(string[] args)
        {
            args = new[]
            {
                "publish",
                "/Users/frohikey/Projects/Kotori.Suric8",
                "-k",
                "aa"
            };

            IOutput output = new CuteConsole();

            return Parser.Default.ParseArguments<PublishOptions, StatusOptions>(args).MapResult(
                (PublishOptions opts) => Publish(opts, output),    
                (StatusOptions opts) => Status(opts, output), 
                errs => 1);
        }

        static int Publish(PublishOptions opts, IOutput output)
        {
            var ds = new Storages.DiskStorage();
            var r = new Publish().Run(opts, output, ds);
            output.Process(r);
            return (int)r.Code;
        }

        static int Status(StatusOptions opts, IOutput output)
        {
            output.Error("Not implemented.");

            return 1;
        }
    }
}
