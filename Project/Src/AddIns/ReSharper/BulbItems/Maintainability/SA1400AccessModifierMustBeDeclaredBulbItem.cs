// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SA1400AccessModifierMustBeDeclaredBulbItem.cs" company="http://stylecop.codeplex.com">
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
//   The s a 1400 access modifier must be declared bulb item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.BulbItems.Maintainability
{
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Psi.CSharp;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Psi.Tree;
    using JetBrains.TextControl;

    using StyleCop.ReSharper.BulbItems.Framework;
    using StyleCop.ReSharper.Core;

    /// <summary>
    /// The s a 1400 access modifier must be declared bulb item.
    /// </summary>
    internal class SA1400AccessModifierMustBeDeclaredBulbItem : V5BulbItemImpl
    {
        /// <summary>
        /// Gets or sets Modifier.
        /// </summary>
        public string Modifier { get; set; }

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
            // See also ModifiersUtil.SetAccessRights
            ITreeNode element = Utils.GetElementAtCaret(solution, textControl);
            var modifiersListOwner = element.GetContainingNode<IModifiersListOwner>();
            if (modifiersListOwner != null)
            {
                if (modifiersListOwner.ModifiersList == null)
                {
                    modifiersListOwner.SetModifiersList(GetModifierList(modifiersListOwner));
                }
                else
                {
                    modifiersListOwner.ModifiersList.AddModifier(GetModifier(modifiersListOwner));
                }
            }
        }

        private IModifiersList GetModifierList(ITreeNode declaration)
        {
            return
                ((IMethodDeclaration)
                 CSharpElementFactory.GetInstance(declaration)
                     .CreateTypeMemberDeclaration(this.Modifier + " void Foo(){}")).ModifiersList;
        }

        private ITokenNode GetModifier(ITreeNode declaration)
        {
            return GetModifierList(declaration).Modifiers[0];
        }
    }
}