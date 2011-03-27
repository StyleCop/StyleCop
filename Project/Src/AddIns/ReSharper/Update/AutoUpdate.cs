// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoUpdate.cs" company="http://stylecop.codeplex.com">
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
//   Defines an Auto Update Document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Update
{
    #region Using Directives

    using System.Xml.Serialization;

    #endregion

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
}