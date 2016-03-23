// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderUsingsBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   BulbItem - OrderUsingsBulbItem : Qualifies all usings, the orders them, groups them and removes duplicates.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper1000.BulbItems.Ordering
{
    using JetBrains.DataFlow;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper1000.BulbItems.Framework;
    using StyleCop.ReSharper1000.CodeCleanup.Rules;
    using StyleCop.ReSharper1000.Core;
    using StyleCop.ReSharper1000.ShellComponents;

    /// <summary>
    /// BulbItem - OrderUsingsBulbItem : Qualifies all usings, the orders them, groups them and removes duplicates.
    /// </summary>
    public class OrderUsingsBulbItem : V5BulbItemImpl
    {
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
            ICSharpFile file = Utils.GetCSharpFile(solution, textControl);

            Lifetimes.Using(
                lifetime =>
                    {
                        StyleCopApi api = solution.GetComponent<StyleCopApiPool>().GetInstance(lifetime);

                        Settings settings = api.Settings.GetSettings(file.GetSourceFile().ToProjectFile());

                        // Fixes SA1208, SA1209, SA1210, SA1211
                        OrderingRules.ExecuteAll(file, settings);
                    });
        }
    }
}