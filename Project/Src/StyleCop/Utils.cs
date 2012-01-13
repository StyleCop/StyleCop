// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This cotnains utility functions.
    /// </summary>
    public sealed class Utils
    {
        /// <summary>
        /// Gets the full username.
        /// </summary>
        /// <returns>The username string.</returns>
        public static string GetDisplayUserName()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var userName = new StringBuilder(0x400);
                var capacity = (uint)userName.Capacity;
                if (NativeMethods.GetUserNameEx(NativeMethods.EXTENDED_NAME_FORMAT.NameDisplay, userName, ref capacity) != 0)
                {
                    return userName.ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Replaces any tokenised strings and returns the expanded result.
        /// </summary>
        /// <param name="value">The tokenised string to expand.</param>
        /// <param name="file">The file to use for replaceable info.</param>
        /// <returns>The expanded string.</returns>
        public static string ReplaceTokenVariables(string value, FileInfo file)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            var nowDate = DateTime.Now.Date;

            var creationTime = file.CreationTime;
            var lastWriteTime = file.LastWriteTime;
            var lastAccessTime = file.LastAccessTime;

            var stringDictionary = new Dictionary<string, string>
                {
                    { "$USER_LOGIN$", Environment.UserName },
                    { "$USER_NAME$", GetDisplayUserName() },
                    { "$FILENAME$", file.Name },
                    { "$CURRENT_YEAR$", nowDate.ToString("yyyy") },
                    { "$CURRENT_MONTH$", nowDate.ToString("MM") },
                    { "$CURRENT_DAY$", nowDate.ToString("dd") },
                    { "$CURRENT_TIME$", nowDate.ToString("t") },
                    { "$CREATED_YEAR$", creationTime.ToString("yyyy") },
                    { "$CREATED_MONTH$", creationTime.ToString("MM") },
                    { "$CREATED_DAY$", creationTime.ToString("dd") },
                    { "$CREATED_TIME$", creationTime.ToString("t") },
                    { "$MODIFIED_YEAR$", lastWriteTime.ToString("yyyy") },
                    { "$MODIFIED_MONTH$", lastWriteTime.ToString("MM") },
                    { "$MODIFIED_DAY$", lastWriteTime.ToString("dd") },
                    { "$MODIFIED_TIME$", lastWriteTime.ToString("t") },
                    { "$ACCESSED_YEAR$", lastAccessTime.ToString("yyyy") },
                    { "$ACCESSED_MONTH$", lastAccessTime.ToString("MM") },
                    { "$ACCESSED_DAY$", lastAccessTime.ToString("dd") },
                    { "$ACCESSED_TIME$", lastAccessTime.ToString("t") },
                };

            return Environment.ExpandEnvironmentVariables(stringDictionary.Keys.Aggregate(value, (current, key) => current.Replace(key, stringDictionary[key])));
        }
    }
}
