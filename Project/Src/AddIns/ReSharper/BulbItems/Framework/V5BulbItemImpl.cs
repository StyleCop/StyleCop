// --------------------------------------------------------------------------------------------------------------------
// <copyright file="V5BulbItemImpl.cs" company="http://stylecop.codeplex.com">
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
//   BulbItem Implementation for ReSharper 5.0 style build items.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.BulbItems.Framework
{
    using System;

    using JetBrains.Application;
    using JetBrains.DocumentManagers.impl;
    using JetBrains.DocumentModel;
    using JetBrains.DocumentModel.Transactions;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Bulbs;
    using JetBrains.ReSharper.Psi;
    using JetBrains.TextControl;

    /// <summary>
    /// BulbItem Implementation for ReSharper build items.
    /// </summary>
    public abstract class V5BulbItemImpl : BulbItemImpl
    {
        /// <summary>
        /// Gets or sets the description of the BulbItem.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the document range to be used by the BulbItem.
        /// </summary>
        /// <value>
        /// The document range.
        /// </value>
        public DocumentRange DocumentRange { get; set; }

        /// <summary>
        /// Gets the text to display in the Quick Fix bulb item.
        /// </summary>
        public override string Text
        {
            get
            {
                return this.Description;
            }
        }

        /// <summary>
        /// Actual implementation of Quick Fix should happen within an overridden instance of this method.
        /// </summary>
        /// <param name="solution">
        /// Current Solution.
        /// </param>
        /// <param name="textControl">
        /// Current Text Control.
        /// </param>
        public abstract void ExecuteTransactionInner(ISolution solution, ITextControl textControl);

        /// <summary>
        /// Performs the QuickFix, ensures the file is both writable and creates a transaction.
        /// </summary>
        /// <param name="solution">
        /// Current Solution.
        /// </param>
        /// <param name="progress">
        /// Progress Indicator for the fix.
        /// </param>
        /// <returns>
        /// The execute transaction.
        /// </returns>
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, JetBrains.Application.Progress.IProgressIndicator progress)
        {
            return delegate(ITextControl textControl)
                {
                    solution.GetComponent<DocumentManagerOperations>().SaveAllDocuments();

                    using (solution.GetComponent<DocumentTransactionManager>().CreateTransactionCookie(JetBrains.Util.DefaultAction.Commit, "action name"))
                    {
                        var services = solution.GetPsiServices();
                        services.Transactions.Execute(
                            "Code cleanup",
                            () => services.Locks.ExecuteWithWriteLock(() => { ExecuteTransactionInner(solution, textControl); }));
                    }
                };
        }
    }
}