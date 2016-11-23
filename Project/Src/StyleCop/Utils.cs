// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="https://github.com/StyleCop">
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
// <summary>
//   This contains utility functions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// This contains utility functions.
    /// </summary>
    public sealed class Utils
    {
        #region Public Methods and Operators

        /// <summary>
        /// Checks for a valid UTF8 byte sequence. An implementation of http://www.ietf.org/rfc/rfc2279.txt?number=2279
        /// </summary>
        /// <param name="buffer">
        /// The buffer to check. 
        /// </param>
        /// <param name="length">
        /// The number of bytes to check. 
        /// </param>
        /// <returns>
        /// True if the bytes checked are UTF8; otherwise False. 
        /// </returns>
        public static bool DetectIfByteArrayIsUtf8(IList<byte> buffer, int length)
        {
            int currentIndex = 0;

            while (currentIndex < length)
            {
                byte currentByte = buffer[currentIndex];

                if (currentByte <= 0x7f)
                {
                    currentIndex++;
                    continue;
                }

                int codeLength;

                if (currentByte >= 0xc2 && currentByte <= 0xdf)
                {
                    // 0b110xxxxx: 2 bytes sequence 
                    codeLength = 2;
                }
                else if (currentByte >= 0xe0 && currentByte <= 0xef)
                {
                    // 0b1110xxxx: 3 bytes sequence 
                    codeLength = 3;
                }
                else if (currentByte >= 0xf0 && currentByte <= 0xf4)
                {
                    // 0b11110xxx: 4 bytes sequence 
                    codeLength = 4;
                }
                else
                {
                    // Invalid first byte
                    return false;
                }

                if (currentIndex + (codeLength - 1) >= length)
                {
                    // THis indicates a truncated string or invalid byte sequence so we should return false.
                    // As we may be passed just the first xx bytes of a UTF-8 file this could happen
                    // So if we've been all utf-8 ok up to now assume it'll all be good and return true
                    return true;
                }

                // Check continuation bytes: bit 7 should be set, bit 6 should be unset.
                for (int i = 1; i < codeLength; i++)
                {
                    if ((buffer[currentIndex + i] & 0xC0) != 0x80)
                    {
                        return false;
                    }
                }

                switch (codeLength)
                {
                    case 2:
                        {
                            // 2 bytes U+0080 - U+07FF 
                            int ch = ((buffer[currentIndex] & 0x1f) << 6) + (buffer[currentIndex + 1] & 0x3f);
                            if (ch < 0x0080)
                            {
                                return false;
                            }
                        }

                        break;
                    case 3:
                        {
                            // 3 bytes U+0800 - U+FFFF 
                            int ch = ((buffer[currentIndex] & 0x0f) << 12) + ((buffer[currentIndex + 1] & 0x3f) << 6) + (buffer[currentIndex + 2] & 0x3f);
                            if (ch < 0x0800)
                            {
                                return false;
                            }

                            // U+D800 - U+DFFF are invalid in UTF-8 
                            if ((ch >= 0xD800) && (ch <= 0xDFFF))
                            {
                                return false;
                            }
                        }

                        break;
                    case 4:
                        {
                            // 4 bytes sequence: U+10000 - U+10FFFF 
                            int ch = ((buffer[currentIndex] & 0x07) << 18) + ((buffer[currentIndex + 1] & 0x3f) << 12) + ((buffer[currentIndex + 2] & 0x3f) << 6)
                                     + (buffer[currentIndex + 3] & 0x3f);
                            if ((ch < 0x10000) || (ch > 0x10FFFF))
                            {
                                return false;
                            }
                        }

                        break;
                }

                currentIndex += codeLength;
            }

            return true;
        }

        /// <summary>
        /// Returns the specified Attribute for the assembly.
        /// </summary>
        /// <typeparam name="T">
        /// The attribute to return.
        /// </typeparam>
        /// <param name="assembly">
        /// The assembly to check.
        /// </param>
        /// <returns>
        /// The attribute required or null.
        /// </returns>
        public static T GetAssemblyAttribute<T>(Assembly assembly) where T : Attribute
        {
            if (assembly == null)
            {
                return null;
            }

            object[] attributes = assembly.GetCustomAttributes(typeof(T), true);

            if (attributes.Length == 0)
            {
                return null;
            }

            return (T)attributes[0];
        }

        /// <summary>
        /// Gets the full username.
        /// </summary>
        /// <returns>The username string.</returns>
        public static string GetDisplayUserName()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                StringBuilder userName = new StringBuilder(0x400);
                uint capacity = (uint)userName.Capacity;
                if (NativeMethods.GetUserNameEx(NativeMethods.EXTENDED_NAME_FORMAT.NameDisplay, userName, ref capacity) != 0)
                {
                    return userName.ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Detects the encoding used by the file at the path provided.
        /// </summary>
        /// <param name="path">
        /// A path to a file.
        /// </param>
        /// <returns>
        /// An Encoding of the file passed in.
        /// </returns>
        public static Encoding GetFileEncoding(string path)
        {
            Param.AssertNotNull(path, "path");

            // We check the first 4K.
            // If we get completely valid UTF-8 bytes in there with no BOM then we assume UTF-8 otherwise we return the Encoding.Default.
            const int BufferSize = 4096;
            Encoding encoding = Encoding.Default;

            byte[] buffer = new byte[BufferSize];
            FileStream file = File.OpenRead(path);
            int bytesRead = file.Read(buffer, 0, BufferSize);
            file.Close();

            if (bytesRead < 4)
            {
                return encoding;
            }

            if (buffer[0] == 0xff && buffer[1] == 0xfe && buffer[2] == 0 && buffer[3] == 0)
            {
                // 0000feff UTF32 Little Endian
                return Encoding.UTF32;
            }

            if (buffer[0] == 0xfe && buffer[1] == 0xff)
            {
                // 1201 unicodeFFFE Unicode (Big-Endian)
                return Encoding.BigEndianUnicode;
            }

            if (buffer[0] == 0xff && buffer[1] == 0xfe)
            {
                // 1200 utf-16 Unicode
                return Encoding.GetEncoding(1200);
            }

            if (buffer[0] == 0x2b && buffer[1] == 0x2f && buffer[2] == 0x76)
            {
                return Encoding.UTF7;
            }

            if (buffer[0] == 0xef && buffer[1] == 0xbb && buffer[2] == 0xbf)
            {
                return Encoding.UTF8;
            }

            if (buffer[0] == 0 && buffer[1] == 0 && buffer[2] == 0xfe && buffer[3] == 0xff)
            {
                // 0000feff UTF32 Big Endian
                return Encoding.GetEncoding(12001);
            }

            return DetectIfByteArrayIsUtf8(buffer, bytesRead) ? Encoding.UTF8 : encoding;
        }

        /// <summary>
        /// Determines whether the given file path matches any of the filter patterns.
        /// </summary>
        /// <param name="input">
        /// The string to match with the Regular Expressions.
        /// </param>
        /// <param name="patterns">
        /// The <see cref="Regex"/> patterns to match with.
        /// </param>
        /// <returns>
        /// Returns true if the file path name matches any of the patterns.
        /// </returns>
        public static bool InputMatchesRegExPattern(string input, IEnumerable<string> patterns)
        {
            Param.AssertNotNull(input, "input");
            Param.Ignore(patterns);

            return patterns != null && patterns.Any(pattern => Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase));
        }

        /// <summary>
        /// Creates an absolute path given a relative path and the root directory.
        /// </summary>
        /// <param name="rootFolder">
        /// The root directory.
        /// </param>
        /// <param name="relativePath">
        /// The relative path.
        /// </param>
        /// <returns>
        /// Returns the absolute path.
        /// </returns>
        public static string MakeAbsolutePath(string rootFolder, string relativePath)
        {
            Param.AssertValidString(rootFolder, "rootFolder");
            Param.AssertValidString(relativePath, "relativePath");

            // Make a copy of the root folder path.
            string absolutePath = rootFolder.Substring(0, rootFolder.Length);

            int index = 0;

            // Back up all directories specified in the relative path.
            while (true)
            {
                if (relativePath.Length - index < 3)
                {
                    break;
                }
                else if (relativePath[index] == '.' && relativePath[index + 1] == '\\')
                {
                    index += 2;
                }
                else if (relativePath[index] == '\\')
                {
                    index += 1;
                }
                else if (relativePath[index] == '.' && relativePath[index + 1] == '.' && relativePath[index + 2] == '\\')
                {
                    // Back up one folder.
                    index += 3;

                    // First, remove all backslashes from the end of the absolute path.
                    while (absolutePath.Length > 0 && absolutePath[absolutePath.Length - 1] == '\\')
                    {
                        absolutePath = absolutePath.Substring(0, absolutePath.Length - 1);
                    }

                    // Now cut off the last directory.
                    int lastSlashIndex = absolutePath.LastIndexOf("\\", StringComparison.Ordinal);
                    if (lastSlashIndex == -1)
                    {
                        // We've reached the end of the string. It's not possible to create 
                        // an absolute path.
                        return relativePath;
                    }

                    absolutePath = absolutePath.Substring(0, lastSlashIndex + 1);
                }
                else
                {
                    break;
                }
            }

            // Now add the remainder of the relative path onto the absolute path.
            return Path.Combine(absolutePath, relativePath.Substring(index, relativePath.Length - index));
        }

        /// <summary>
        /// Replaces any tokenized strings and returns the expanded result.
        /// </summary>
        /// <param name="value">
        /// The tokenized string to expand.
        /// </param>
        /// <param name="file">
        /// The file to use for replaceable info.
        /// </param>
        /// <returns>
        /// The expanded string.
        /// </returns>
        public static string ReplaceTokenVariables(string value, FileInfo file)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            DateTime nowDate = DateTime.Now.Date;

            DateTime creationTime = file.CreationTime;
            DateTime lastWriteTime = file.LastWriteTime;
            DateTime lastAccessTime = file.LastAccessTime;

            Dictionary<string, string> stringDictionary = new Dictionary<string, string>
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

        #endregion
    }
}