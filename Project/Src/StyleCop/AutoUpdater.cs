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
    /// THirir irg irg.
    /// </summary>
    public class AutoUpdater
    {
        /// <summary>
        /// Message box title.
        /// </summary>
        private const string MessageBoxTitle = "StyleCop";

#if DEBUG
        /// <summary>
        /// This is the URL of the xml file that contains the latest version number.
        /// </summary>
        private const string VersionUrl = "http://www.stylecop.com/updates/4.5/version.dev.xml";
#else
        /// <summary>
        /// This is the URL of the xml file that contains the latest version number.
        /// </summary>        
        private const string VersionUrl = "http://www.stylecop.com/updates/4.5/version.xml";
#endif

        /// <summary>
        /// Question text.
        /// </summary>
        private const string QuestionText =
          "StyleCop {0} is now available.\r\n\nStyleCop {1} is currently installed.\r\n\r\nOnce downloaded and installed you'll need to restart Visual Studio.\r\n\r\nDo you wish to download the latest version?";
        
        /// <summary>
        /// Checks to see if a newer version is available.
        /// </summary>
        public void CheckForUpdate()
        {
            var client = new WebClient();
            client.DownloadStringCompleted += this.DownloadStringCompleted;

            try
            {
                client.DownloadStringAsync(new Uri(VersionUrl));
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
                return MessageBox.Show(string.Format(QuestionText, newVersionNumber, currentVersionNumber), MessageBoxTitle, MessageBoxButtons.YesNo) == DialogResult.Yes;
            }

            MessageBox.Show(messageText, MessageBoxTitle, MessageBoxButtons.OK);

            return false;
        }

        /// <summary>
        /// This is called when the download of the version number is completed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The DownloadStringCompletedEventArgs.</param>
        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    return;
                }

                var autoUpdate = Serialization.CreateInstance<AutoUpdate>(e.Result);
                var currentVersionNumber = this.GetType().Assembly.GetName().Version;
                var newVersionNumber = autoUpdate.Version.CastAsSystemVersion();
                var newerPlugInAvailable = newVersionNumber.CompareTo(currentVersionNumber) > 0;

                if (newerPlugInAvailable && this.PromptUserForDownload(currentVersionNumber.ToString(), newVersionNumber.ToString(), autoUpdate.Message))
                {
                    // this will launch the default browser at the download url
                    Process.Start(autoUpdate.DownloadUrl);
                }
            }
            catch
            {
                // if anything at all goes wrong in here we just consume it and say nothing
                return;
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