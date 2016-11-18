//-----------------------------------------------------------------------
// <copyright file="ITaskProvider.cs">
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
namespace StyleCop.VisualStudio
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// Interface for the TaskProvider class.
    /// </summary>
    internal interface ITaskProvider : IVsTaskProvider, IVsTaskProvider3
    {
        /// <summary>
        /// Adds a list of violations to the task provider.
        /// </summary>
        /// <param name="violations">The list of violations to add.</param>
        void AddResults(List<ViolationInfo> violations);

        /// <summary>
        /// Clears the list of violations from the task provider.
        /// </summary>
        void Clear();

        /// <summary>
        /// Shows the task list.
        /// </summary>
        void Show();

        /// <summary>
        /// Activates the Error List window and makes it visible.
        /// </summary>
        void BringToFront();
        
        /// <summary>
        /// Refreshes the task list UI.
        /// </summary>
        void Refresh();
    }
}