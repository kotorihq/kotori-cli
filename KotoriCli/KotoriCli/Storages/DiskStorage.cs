using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KotoriCli.Tokens;

namespace KotoriCli.Storages
{
    /// <summary>
    /// Disk storage.
    /// </summary>
    public class DiskStorage : IStorage
    {
        /// <summary>
        /// Gets all files.
        /// </summary>
        /// <returns>The collection of files..</returns>
        /// <param name="path">Path.</param>
        /// <param name="recursive">If set to <c>true</c> recursive.</param>
        public InputFilesResult GetAll(string path, Enums.FileType fileType, bool recursive)
        {
            var di = new DirectoryInfo(path);

            if (!di.Exists)
            {
                return new InputFilesResult(Enums.ResultCode.Fail, $"Input directory {path} does not exist.");
            }

            var extensions = fileType.ToExtensions();
            var files = WalkDirectoryTree(di, extensions, recursive);

            return new InputFilesResult(Enums.ResultCode.Ok, files);
        }

        static List<InputFile> WalkDirectoryTree(DirectoryInfo root, IEnumerable<string> extensions, bool recursive)
        {
            var processedFiles = new List<InputFile>();
            IEnumerable<FileInfo> files = null;

            try
            {
                var rawFiles = root.GetFiles();
                files = rawFiles.Where(f => extensions.Any(ex => f.Extension.Equals(ex, StringComparison.OrdinalIgnoreCase)));
                processedFiles.Add(new InputFile(root.FullName, Enums.ResultCode.Ok));
            }
            catch (UnauthorizedAccessException)
            {
                processedFiles.Add(new InputFile(root.FullName, Enums.ResultCode.Fail));
            }
            catch (DirectoryNotFoundException)
            {
                processedFiles.Add(new InputFile(root.FullName, Enums.ResultCode.Fail));
            }

            if (files != null)
            {
                foreach (FileInfo fi in files)
                {
                    processedFiles.Add(new InputFile(root.FullName, fi.FullName, Enums.ResultCode.Ok));
                }

                if (recursive)
                {
                    var subDirs = root.GetDirectories();

                    foreach (var dirInfo in subDirs)
                    {
                        processedFiles.AddRange(WalkDirectoryTree(dirInfo, extensions, recursive));
                    }
                }
            }

            return processedFiles;
        }
    }
}
