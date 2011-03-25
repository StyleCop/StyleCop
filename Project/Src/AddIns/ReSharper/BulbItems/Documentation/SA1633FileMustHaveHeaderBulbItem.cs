// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1633FileMustHaveHeaderBulbItem.cs" company="StyleCop for ReSharper Development Team">
//   Copyright (c) StyleCop for ReSharper Development Team. All rights reserved.
// </copyright>
// <summary>
//   Defines the SA1633FileMustHaveHeaderBulbItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.BulbItems.Documentation
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.CodeCleanup.Rules;
    using StyleCop.ReSharper.Core;

    #endregion

    /// <summary>
    /// BulbItem for inserting the standard StyleCop File Header.
    /// </summary>
    public class SA1633FileMustHaveHeaderBulbItem : V5BulbItemImpl
    {
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            var file = Utils.GetCSharpFile(solution, textControl);
            new DocumentationRules().InsertFileHeader(file);
        }
    }
}