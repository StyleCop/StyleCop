//-----------------------------------------------------------------------
// <copyright file="GenericTypeToken.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.CSharp
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// Describes a generic type token.
    /// </summary>
    /// <subcategory>token</subcategory>
    [SuppressMessage("Microsoft.Maintainability", "CA1501:AvoidExcessiveInheritance", Justification = "C# syntax is deeply hierarchical")]
    public sealed class GenericTypeToken : TypeToken
    {
        #region Private Fields

        /// <summary>
        /// The types within the generic type.
        /// </summary>
        private ICollection<string> types;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the GenericTypeToken class.
        /// </summary>
        /// <param name="proxy">Proxy object for the statement.</param>
        /// <param name="location">The location of the generic in the code.</param>
        /// <param name="generated">True if the token is inside of a block of generated code.</param>
        internal GenericTypeToken(CodeUnitProxy proxy, CodeLocation location, bool generated)
            : base(proxy, location, generated)
        {
            Param.AssertGreaterThanOrEqualTo(proxy.Children.Count, 3, "childTokens");
            Param.AssertNotNull(location, "location");
            Param.Ignore(generated);

            this.IsGeneric = true;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the types within the generic type.
        /// </summary>
        public ICollection<string> GenericTypes
        {
            get
            {
                if (this.types == null)
                {
                    this.ExtractGenericTypes();
                }

                return this.types;
            }
        }

        #endregion Public Properties
        
        #region Private Methods

        /// <summary>
        /// Extracts the generic types from the type list and saves them.
        /// </summary>
        private void ExtractGenericTypes()
        {
            var genericTypes = new List<string>();
            var type = new StringBuilder();

            for (Token token = this.FindFirstChild<Token>(); token != null; token = token.FindNextSibling<Token>())
            {
                if (token.TokenType == TokenType.Comma)
                {
                    string trimmedType = CodeParser.TrimType(type.ToString());
                    if (!string.IsNullOrEmpty(trimmedType))
                    {
                        genericTypes.Add(trimmedType);
                    }

                    type.Remove(0, type.Length);
                }
                else
                {
                    type.Append(token.Text);
                }
            }

            if (type.Length > 0)
            {
                string trimmedType = CodeParser.TrimType(type.ToString());
                if (!string.IsNullOrEmpty(trimmedType))
                {
                    genericTypes.Add(trimmedType);
                }
            }

            this.types = genericTypes.ToArray();
        }

        #endregion Private Methods
    }
}
