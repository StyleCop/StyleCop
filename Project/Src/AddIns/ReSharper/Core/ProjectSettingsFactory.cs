//-----------------------------------------------------------------------
// <copyright file="">
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
//-----------------------------------------------------------------------

namespace StyleCop.ReSharper.Core
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security;
    using System.Xml;

    using StyleCop;

    using StyleCop.ReSharper.Diagnostics;

    #endregion

    public class ProjectSettingsFactory
    {
        private readonly static Dictionary<string, Settings> Cache = new Dictionary<string, Settings>();

        public StyleCopCore StyleCopCore { get; set; }

        public Settings Create(string settingsFilePath, bool readOnly)
        {
            StyleCopTrace.In(settingsFilePath);

            string cacheKey = string.Format("{0}::{1}", settingsFilePath, readOnly);

            Settings result;

            if (Cache.TryGetValue(cacheKey, out result))
            {
                StyleCopTrace.Out();

                return result;   
            }

            try
            {
                // Determine whether the file exists.
                if (File.Exists(settingsFilePath))
                {
                    // Load the settings document.
                    var document = new XmlDocument();
                    document.Load(settingsFilePath);

                    // Get the last write time for the time.
                    DateTime writeTime = File.GetLastWriteTime(settingsFilePath);

                    // Create the settings container.
                    var settings = readOnly ? new Settings(this.StyleCopCore, settingsFilePath, document, writeTime)
                                            : new WritableSettings(this.StyleCopCore, settingsFilePath, document, writeTime);

                    StyleCopTrace.Out();

                    Cache[cacheKey] = settings;

                    return settings;
                }

                StyleCopTrace.Out();

                // The file does not exist.
                return null;

            }
            catch (IOException)
            {
                StyleCopTrace.Out();

                return null;
            }
            catch (SecurityException)
            {
                StyleCopTrace.Out();

                return null;
            }
            catch (UnauthorizedAccessException)
            {
                StyleCopTrace.Out();

                return null;
            }
            catch (XmlException)
            {
                StyleCopTrace.Out();

                return null;
            }
        }
    }
}