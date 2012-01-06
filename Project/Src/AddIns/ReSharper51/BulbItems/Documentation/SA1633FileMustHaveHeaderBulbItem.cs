// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1633FileMustHaveHeaderBulbItem.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <summary>
//   Defines the SA1633FileMustHaveHeaderBulbItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper51.BulbItems.Documentation
{
    #region Using Directives

    using JetBrains.ProjectModel;
    using JetBrains.TextControl;

    using StyleCop.ReSharper51.BulbItems.Framework;
    using StyleCop.ReSharper51.CodeCleanup.Rules;
    using StyleCop.ReSharper51.Core;

    #endregion

    /// <summary>
    /// BulbItem for inserting the standard StyleCop File Header.
    /// </summary>
    public class SA1633FileMustHaveHeaderBulbItem : V5BulbItemImpl
    {
        #region Public Methods

        /// <summary>
        /// The execute transaction inner.
        /// </summary>
        /// <param name="solution">
        /// The solution.
        /// </param>
        /// <param name="textControl">
        /// The text control.
        /// </param>
        public override void ExecuteTransactionInner(ISolution solution, ITextControl textControl)
        {
            var file = Utils.GetCSharpFile(solution, textControl);
            new DocumentationRules().InsertFileHeader(file);
        }

        #endregion
    }
}