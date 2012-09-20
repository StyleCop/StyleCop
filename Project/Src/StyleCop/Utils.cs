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
    using System.Reflection;
    using System.Text;

    using Microsoft.Win32;

    /// <summary>
    /// This contains utility functions.
    /// </summary>
    public sealed class Utils
    {
        /// <summary>
        /// Retrieves a RegistryKey value for the registry for the current user.
        /// </summary>
        /// <param name="key">The sub key to open.</param>
        /// <returns>The value of the RegistryKey.</returns>
        public static object RetrieveFromRegistry(string key)
        {
            const string SubKey = @"SOFTWARE\CodePlex\StyleCop";

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(SubKey);
            return registryKey == null ? null : registryKey.GetValue(key);
        }

        /// <summary>
        /// Gets the StyleCop install location from the registry. This RegistryKey is created by StyleCop during install.
        /// </summary>
        /// <returns>
        /// Returns the RegistryKey value or null if not found.
        /// </returns>
        public static string InstallDirFromRegistry()
        {
            const string SubKey = @"SOFTWARE\CodePlex\StyleCop";
            const string Key = "InstallDir";

            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(SubKey);
            return registryKey == null ? null : registryKey.GetValue(Key) as string;
        }

        /// <summary>
        /// Sets a RegistryKey value in the registry for the current user.
        /// </summary>
        /// <param name="key">
        /// The sub key to create.
        /// </param>
        /// <param name="value">
        /// The value to use.
        /// </param>
        /// <param name="valueKind">
        /// The type of RegistryKey value to set.
        /// </param>
        public static void SetRegistry(string key, object value, RegistryValueKind valueKind)
        {
            const string SubKey = @"SOFTWARE\CodePlex\StyleCop";

            var registryKey = Registry.CurrentUser.CreateSubKey(SubKey);
            if (registryKey != null)
            {
                registryKey.SetValue(key, value, valueKind);
            }
        }

        /// <summary>
        /// Returns the specified Attribute for the assembly.
        /// </summary>
        /// <typeparam name="T">The attribute to return.</typeparam>
        /// <param name="assembly">The assembly to check.</param>
        /// <returns>The attribute required or null.</returns>
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
        /// Replaces any tokenized strings and returns the expanded result.
        /// </summary>
        /// <param name="value">The tokenized string to expand.</param>
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

        /// <summary>
        /// Detects the encoding used by the file at the path provided.
        /// </summary>
        /// <param name="path">A path to a file.</param>
        /// <returns>An Encoding of the file passed in.</returns>
        public static Encoding GetFileEncoding(string path)
        {
            Param.AssertNotNull(path, "path");
            
            // We check the first 4K.
            // If we get completely valid UTF-8 bytes in there with no BOM then we assume UTF-8 otherwise we return the Encoding.Default.
            const int BufferSize = 4096;
            var encoding = Encoding.Default;

            var buffer = new byte[BufferSize];
            var file = File.OpenRead(path);
            var bytesRead = file.Read(buffer, 0, BufferSize);
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
        /// Checks for a valid UTF8 byte sequence. An implementation of http://www.ietf.org/rfc/rfc2279.txt?number=2279
        /// </summary>
        /// <param name="buffer"> The buffer to check. </param>
        /// <param name="length"> The number of bytes to check. </param>
        /// <returns> True if the bytes checked are UTF8; otherwise False. </returns>
        public static bool DetectIfByteArrayIsUtf8(IList<byte> buffer, int length)
        {
            var currentIndex = 0;

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
                for (var i = 1; i < codeLength; i++)
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
                            var ch = ((buffer[currentIndex] & 0x1f) << 6) + (buffer[currentIndex + 1] & 0x3f);
                            if (ch < 0x0080)
                            {
                                return false;
                            }
                        }

                        break;
                    case 3:
                        {
                            // 3 bytes U+0800 - U+FFFF 
                            var ch = ((buffer[currentIndex] & 0x0f) << 12) + ((buffer[currentIndex + 1] & 0x3f) << 6) + (buffer[currentIndex + 2] & 0x3f);
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
                            var ch = ((buffer[currentIndex] & 0x07) << 18) + ((buffer[currentIndex + 1] & 0x3f) << 12) + ((buffer[currentIndex + 2] & 0x3f) << 6) + (buffer[currentIndex + 3] & 0x3f);
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
    }
}
