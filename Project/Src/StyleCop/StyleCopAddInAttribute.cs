// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopAddInAttribute.cs" company="https://github.com/StyleCop">
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
//   Attribute class for marking StyleCop add-in classes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Attribute class for marking StyleCop add-in classes.
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "The class is inherited by other attribute types.")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class StyleCopAddInAttribute : Attribute
    {
        #region Fields

        /// <summary>
        /// The id of the add-in xml file within the assembly resources.
        /// </summary>
        private readonly string addInXmlId;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopAddInAttribute class.
        /// </summary>
        public StyleCopAddInAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopAddInAttribute class.
        /// </summary>
        /// <param name="addInXmlId">
        /// The ID of the add-in xml file within the analyzer resource.
        /// </param>
        public StyleCopAddInAttribute(string addInXmlId)
        {
            Param.RequireValidString(addInXmlId, "addInXmlId");
            this.addInXmlId = addInXmlId;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the ID of the add-in xml file within the assembly resources.
        /// </summary>
        public string AddInXmlId
        {
            get
            {
                return this.addInXmlId;
            }
        }

        #endregion
    }
}