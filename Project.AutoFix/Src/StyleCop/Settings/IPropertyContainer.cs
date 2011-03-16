//-----------------------------------------------------------------------
// <copyright file="IPropertyContainer.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Contains a collection of properties.
    /// </summary>
    public interface IPropertyContainer
    {
        /// <summary>
        /// Gets the collection of property descriptors.
        /// </summary>
        PropertyDescriptorCollection PropertyDescriptors
        {
            get;
        }
    }
}
