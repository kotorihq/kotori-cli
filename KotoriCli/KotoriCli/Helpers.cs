using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace KotoriCli
{
    /// <summary>
    /// Various helper methods.
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Get extesions for a given file type.
        /// </summary>
        /// <returns>List of extensions (incl. dot char).</returns>
        /// <param name="fileType">File type.</param>
        public static IEnumerable<string> ToExtensions(this Enums.FileType fileType)
        {
            switch (fileType)
            {
                case Enums.FileType.Documents:
                    return new []
                    {
                        ".md"
                    };

                default:
                    throw new System.NotImplementedException("This conversion is not supported.");
            }
        }

        /// <summary>
        /// Convert to path without base path.
        /// </summary>
        /// <returns>The part path.</returns>
        /// <param name="fullPath">Full path.</param>
        /// <param name="basePath">Base path.</param>
        public static string ToPartPath(this string fullPath, string basePath)
        {
            var pathParts = fullPath.Split(new [] { Path.DirectorySeparatorChar });
            var basePathParts = basePath.Split(new[] { Path.DirectorySeparatorChar });
            var idx = 0;
            var r = string.Empty;

            foreach(var part in pathParts)
            {
                if (idx >= basePathParts.Length)
                    r += part + (idx < pathParts.Length - 1 ? Path.DirectorySeparatorChar.ToString() : string.Empty);

                idx++;
            }

            return r;
        }

        public static readonly string ProductVersion = GetProductVersion();

        private static string GetProductVersion()
        {
            var attr = typeof(Helpers)
                .GetTypeInfo()
                .Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            return attr?.InformationalVersion;
        }
    }
}
