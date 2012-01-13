//-----------------------------------------------------------------------
// <copyright file="AutoUpdater.cs">
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

namespace StyleCop
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Serialization;

    #endregion

    /// <summary>
    /// Provides auto-update feature.
    /// </summary>
    public class AutoUpdater
    {
#if DEBUG
        /// <summary>
        /// This is the URL of the xml file that contains the latest version number.
        /// </summary>
        private const string VersionUrl = "http://www.stylecop.com/updates/4.7/version.dev.xml";
#else
        /// <summary>
        /// This is the URL of the xml file that contains the latest version number.
        /// </summary>        
        private const string VersionUrl = "http://www.stylecop.com/updates/4.7/version.xml";
#endif

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private StyleCopCore core;

        /// <summary>
        /// Initializes a new instance of the AutoUpdater class.
        /// </summary>
        /// <param name="core">The StyleCop core instance.</param>
        public AutoUpdater(StyleCopCore core)
        {
            Param.RequireNotNull(core, "core");

            this.core = core;
        }

        /// <summary>
        /// Checks to see if a newer version is available.
        /// </summary>
        public void CheckForUpdate()
        {
            // Request the version number update info and take a maximum of 5 seconds before giving up.
            // It used to be async but sometimes this took even longer to return.
            var client = new StyleCopWebClient { Timeout = 5000 };

            try
            {
                this.ProcessResponse(client.DownloadString(new Uri(VersionUrl)));
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Prompt user for download.
        /// </summary>
        /// <param name="currentVersionNumber">
        /// The current version number.
        /// </param>
        /// <param name="newVersionNumber">
        /// The new version number.
        /// </param>
        /// <param name="messageText">
        /// The message text.
        /// </param>
        /// <returns>
        /// The prompt user for download.
        /// </returns>
        private bool PromptUserForDownload(string currentVersionNumber, string newVersionNumber, string messageText)
        {
            if (string.IsNullOrEmpty(messageText))
            {
                messageText = string.Empty;
            }
            else
            {
                messageText += "." + Environment.NewLine;
            }

            if (this.core.DisplayUI)
            {
                // display dialog asking whether to perform auto-update
                DialogResult result = AlertDialog.Show(
                    this.core,
                    null,
                    string.Format(Strings.AutoUpdateQuestion, messageText, newVersionNumber, currentVersionNumber),
                    Strings.Title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                return result == DialogResult.Yes;
            }

            // send notification to the output for non-UI environment
            AlertDialog.Show(
                this.core,
                null,
                string.Format(Strings.AutoUpdateInformation, messageText, newVersionNumber, currentVersionNumber),
                Strings.Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return false;
        }
        
        /// <summary>
        /// Processes the response from the version number checker.
        /// </summary>
        /// <param name="response">The string of the response.</param>
        private void ProcessResponse(string response)
        {
            if (string.IsNullOrEmpty(response))
            {
                return;
            }

            var autoUpdate = Serialization.CreateInstance<AutoUpdate>(response);
            var currentVersionNumber = this.GetType().Assembly.GetName().Version;
            var newVersionNumber = autoUpdate.Version.CastAsSystemVersion();
            var newerPlugInAvailable = newVersionNumber.CompareTo(currentVersionNumber) > 0;

            if (newerPlugInAvailable && this.PromptUserForDownload(currentVersionNumber.ToString(), newVersionNumber.ToString(), autoUpdate.Message))
            {
                // this will launch the default browser at the download url
                Process.Start(autoUpdate.DownloadUrl);
            }
        }

        /// <summary>
        /// Represents an Auto Update Version Document.
        /// </summary>
        [XmlRoot("version")]
        public class AutoUpdateVersion
        {
            #region Properties

            /// <summary>
            /// Gets or sets the build number.
            /// </summary>
            [XmlElement(ElementName = "build")]
            public int Build { get; set; }

            /// <summary>
            /// Gets or sets the major number.
            /// </summary>
            [XmlElement(ElementName = "major")]
            public int Major { get; set; }

            /// <summary>
            /// Gets or sets the minor number.
            /// </summary>
            [XmlElement(ElementName = "minor")]
            public int Minor { get; set; }

            /// <summary>
            /// Gets or sets revision number.
            /// </summary>
            [XmlElement(ElementName = "revision")]
            public int Revision { get; set; }

            #endregion

            #region Public Methods

            /// <summary>
            /// Converts the document to an assembly version type.
            /// </summary>
            /// <returns>
            /// The Version as a System.Version instance.
            /// </returns>
            public Version CastAsSystemVersion()
            {
                return new Version(this.Major, this.Minor, this.Build, this.Revision);
            }

            #endregion
        }

        /// <summary>
        /// Defines an Auto Update Document.
        /// </summary>
        [XmlRoot("autoupdate")]
        public class AutoUpdate
        {
            #region Properties

            /// <summary>
            /// Gets or sets the Url to download an update.
            /// </summary>
            [XmlElement(ElementName = "downloadurl")]
            public string DownloadUrl { get; set; }

            /// <summary>
            /// Gets or sets a service announcement message.
            /// </summary>
            [XmlElement(ElementName = "message")]
            public string Message { get; set; }

            /// <summary>
            /// Gets or sets the Version of the Document.
            /// </summary>
            [XmlElement(ElementName = "version")]
            public AutoUpdateVersion Version { get; set; }

            #endregion
        }

        /// <summary>
        /// Utility that allows you to retrieve and create mock data from XML files containing serialized type instances.
        /// </summary>
        internal static class Serialization
        {
            #region Public Methods

            /// <summary>
            /// Deserializes a Type.
            /// </summary>
            /// <typeparam name="T">
            /// Type to deserialize.
            /// </typeparam>
            /// <param name="serializedType">
            /// Serialized version of the type.
            /// </param>
            /// <returns>
            /// DeSerialized version of the type.
            /// </returns>
            public static T CreateInstance<T>(string serializedType) where T : new()
            {
                var serializer = new XmlSerializer(typeof(T));
                var stream = new StringReader(serializedType);
                XmlReader xmlReader = new XmlTextReader(stream);

                var customType = (T)serializer.Deserialize(xmlReader);

                return customType;
            }

            #endregion
        }
    }
}