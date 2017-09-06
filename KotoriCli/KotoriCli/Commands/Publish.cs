using System;
using KotoriCli.Storages;
using KotoriCli.Outputs;
using KotoriCli.Tokens;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace KotoriCli.Commands
{
    public class Publish
    {
        public Result Run(PublishOptions opts, IOutput output, IStorage storage)
        {
            var options = opts as PublishOptions;

            output.Message("Scanning directory tree...");

            var storageResult = storage.GetAll(opts.Directory, Enums.FileType.Documents, true);

            if (storageResult.Code != Enums.ResultCode.Ok)
                return storageResult;
            
            output.Message($"{storageResult.InputFiles.Count(x => !x.IsDirectory && x.Code == Enums.ResultCode.Ok)} files found in {storageResult.InputFiles.Count(x => x.IsDirectory && x.Code == Enums.ResultCode.Ok)} directories.");

            var okFiles = storageResult.InputFiles.Where(x => !x.IsDirectory && x.Code == Enums.ResultCode.Ok);
            var invalidFiles = storageResult.InputFiles.Where(x => !x.IsDirectory && x.Code == Enums.ResultCode.Fail);
            var invalidDirectories = storageResult.InputFiles.Where(x => x.IsDirectory && x.Code == Enums.ResultCode.Fail);

            foreach(var d in invalidDirectories)
            {
                output.Error($"[FAILED DIR] {d}");
            }

            foreach (var f in invalidFiles)
            {
                output.Error($"[FAILED FILE] {f}");
            }

            output.Message("Processing documents...");

            var tasks = new List<Task>();

            foreach (var f in okFiles)
            {
                tasks.Add(new Task(() => ProcessFile(output, f)));
            }

            foreach (var t in tasks) 
                t.Start();

            Task.WaitAll(tasks.ToArray());

            return new Result(Enums.ResultCode.Ok);
        }

        private static Result ProcessFile(IOutput output, InputFile file)
        {            
            Thread.Sleep(150);

            var f = $"{file.Directory}/{file.Filename}";
            output.Message(f);
            return new Result(Enums.ResultCode.Ok);
        }
    }
}
