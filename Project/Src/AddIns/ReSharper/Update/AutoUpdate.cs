//-----------------------------------------------------------------------
// <copyright file="AutoUpdate.cs">
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

namespace StyleCop.ReSharper.Update
{
    using System.Xml.Serialization;

    /// <summary>
    /// Defines an Auto Update Document.
    /// </summary>
    [XmlRoot("autoupdate")]
    public class AutoUpdate
    {
        /// <summary>
        /// Gets or sets the Version of the Document.
        /// </summary>
        [XmlElement(ElementName = "version")]
        public AutoUpdateVersion Version { get; set; }

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
    }
}