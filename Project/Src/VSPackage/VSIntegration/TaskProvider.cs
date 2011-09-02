//-----------------------------------------------------------------------
// <copyright file="TaskProvider.cs">
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
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.Shell;

    using StyleCop.Diagnostics;

    /// <summary>
    /// Implementation of <see cref="T:Microsoft.VisualStudio.Shell.ErrorListProvider"/> .
    /// </summary>
    internal class TaskProvider : ErrorListProvider, ITaskProvider
    {
        #region Private Fields

        /// <summary>
        /// The system service provider.
        /// </summary>
        private IServiceProvider serviceProvider;

        #endregion Private Fields

        #region Constructor(s)

        /// <summary>
        /// Initializes a new instance of the TaskProvider class.
        /// </summary>
        /// <param name="serviceProvider">System service provider.</param>
        public TaskProvider(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");

            this.ProviderGuid = new Guid("{E7AB8757-980C-401c-9CE1-8D78584131F6}");
            this.ProviderName = "StyleCop";
            this.serviceProvider = serviceProvider;
        }

        #endregion Constructor(s)

        #region ITaskProvider Members

        /// <summary>
        /// Adds a list of violations to the task provider.
        /// </summary>
        /// <param name="violations">The list of violations to add.</param>
        public void AddResults(List<ViolationInfo> violations)
        {
            Param.AssertNotNull(violations, "violations");
            StyleCopTrace.In(violations);

            this.SuspendRefresh();

            foreach (ViolationInfo violation in violations)
            {
                this.AddResult(violation);
            }
            
            this.ResumeRefresh();

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Clears the list of violations from the task provider.
        /// </summary>
        public void Clear()
        {
            this.Tasks.Clear();
            this.Refresh();
        }

        #endregion
        
        #region Private Methods

        /// <summary>
        /// Adds a single violation to the task provider.
        /// </summary>
        /// <param name="violation">The violation to add.</param>
        private void AddResult(ViolationInfo violation)
        {
            Param.AssertNotNull(violation, "violation");

            Task task = new ViolationTask(this.serviceProvider, violation);
            this.Tasks.Add(task);
        }
        
        #endregion Private Methods
    }
}