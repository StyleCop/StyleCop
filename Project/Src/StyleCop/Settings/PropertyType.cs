// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyType.cs" company="https://github.com/StyleCop">
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
//   The possible property types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// The possible property types.
    /// </summary>
    public enum PropertyType
    {
        /// <summary>
        /// A string value.
        /// </summary>
        String, 

        /// <summary>
        /// A boolean value.
        /// </summary>
        Boolean, 

        /// <summary>
        /// An integer value.
        /// </summary>
        Int, 

        /// <summary>
        /// A collection of values.
        /// </summary>
        Collection
    }
}