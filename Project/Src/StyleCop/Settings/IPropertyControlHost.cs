// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyControlHost.cs" company="https://github.com/StyleCop">
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
//   Interface which must be implemented by a host of the <see cref="PropertyControl" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    /// <summary>
    /// Interface which must be implemented by a host of the <see cref="PropertyControl"/>.
    /// </summary>
    internal interface IPropertyControlHost
    {
        #region Public Methods and Operators

        /// <summary>
        /// Called to cancel the host.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Called when the combined dirty status of the pages changes.
        /// </summary>
        /// <param name="isDirty">
        /// True if any of the pages are dirty, false if not.
        /// </param>
        void Dirty(bool isDirty);

        #endregion
    }
}