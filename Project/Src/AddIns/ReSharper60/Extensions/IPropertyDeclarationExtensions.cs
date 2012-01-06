// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyDeclarationExtensions.cs" company="http://stylecop.codeplex.com">
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
//   I property declaration extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JetBrains.ReSharper.Psi.CSharp.Tree
{
    /// <summary>
    /// I property declaration extensions.
    /// </summary>
    public static class IPropertyDeclarationExtensions
    {
        #region Public Methods

        /// <summary>
        /// Gets an IAccessor for the Getter.
        /// </summary>
        /// <param name="propertyDeclaration">
        /// The property declaration.
        /// </param>
        /// <returns>
        /// An IAccessor for the getter.
        /// </returns>
        public static IAccessor Getter(this IPropertyDeclaration propertyDeclaration)
        {
            foreach (var declaration in propertyDeclaration.AccessorDeclarations)
            {
                var accessor = (IAccessor)declaration.DeclaredElement;

                if (accessor != null && accessor.Kind == AccessorKind.GETTER)
                {
                    return accessor;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns an IAccessor for the Setter.
        /// </summary>
        /// <param name="propertyDeclaration">
        /// The property declaration.
        /// </param>
        /// <returns>
        /// An IAccessor for the setter.
        /// </returns>
        public static IAccessor Setter(this IPropertyDeclaration propertyDeclaration)
        {
            foreach (var declaration in propertyDeclaration.AccessorDeclarations)
            {
                var accessor = (IAccessor)declaration.DeclaredElement;

                if (accessor != null && accessor.Kind == AccessorKind.SETTER)
                {
                    return accessor;
                }
            }

            return null;
        }

        #endregion
    }
}