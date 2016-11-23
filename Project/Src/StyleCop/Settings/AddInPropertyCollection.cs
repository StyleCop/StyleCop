// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddInPropertyCollection.cs" company="https://github.com/StyleCop">
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
//   A set of properties for a StyleCop add-in.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// A set of properties for a StyleCop add-in.
    /// </summary>
    public class AddInPropertyCollection : PropertyCollection
    {
        #region Fields

        /// <summary>
        /// The analyzer or parser add-in.
        /// </summary>
        private readonly StyleCopAddIn addIn;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the AddInPropertyCollection class.
        /// </summary>
        /// <param name="addIn">
        /// An analyzer or parser add-in.
        /// </param>
        internal AddInPropertyCollection(StyleCopAddIn addIn)
        {
            Param.AssertNotNull(addIn, "addIn");
            this.addIn = addIn;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the StyleCop add-in.
        /// </summary>
        public StyleCopAddIn AddIn
        {
            get
            {
                return this.addIn;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Clones the contents of the collection.
        /// </summary>
        /// <returns>Returns the cloned collection.</returns>
        public override PropertyCollection Clone()
        {
            AddInPropertyCollection clone = new AddInPropertyCollection(this.addIn);
            foreach (PropertyValue item in this.Properties)
            {
                clone.Add(item.Clone());
            }

            return clone;
        }

        #endregion
    }
}