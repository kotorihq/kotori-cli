using System;

namespace KotoriCli
{
    /// <summary>
    /// Global enums.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// File types. 
        /// </summary>
        public enum FileType
        {
            /// <summary>
            /// Documents - typically Markdowns.
            /// </summary>
            Documents = 10
        }

        /// <summary>
        /// Result codes.   
        /// </summary>
        public enum ResultCode
        {
            /// <summary>
            /// Everything's ok.
            /// </summary>
            Ok = 0,
            /// <summary>
            /// Something bad happened.
            /// </summary>
            Fail = 1
        }
    }
}
