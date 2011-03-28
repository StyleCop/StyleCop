// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoUpdateVersion.cs" company="http://stylecop.codeplex.com">
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
//   Represents an Auto Update Version Document.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Update
{
    #region Using Directives

    using System;
    using System.Xml.Serialization;

    #endregion

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
}