//-----------------------------------------------------------------------
// <copyright file="Property.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a property element.
    /// </summary>
    /// <subcategory>element</subcategory>
    [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", Justification = "The class describes a C# property.")]
    public sealed class Property : Element
    {
        #region Private Fields

        /// <summary>
        /// The return type for the property.
        /// </summary>
        private CodeUnitProperty<TypeToken> returnType;

        /// <summary>
        /// The get accessor for the property.
        /// </summary>
        private CodeUnitProperty<Accessor> get;

        /// <summary>
        /// The set accessor for the property.
        /// </summary>
        private CodeUnitProperty<Accessor> set;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the Property class.
        /// </summary>
        /// <param name="proxy">Proxy object for the property.</param>
        /// <param name="name">The name of the property.</param>
        /// <param name="attributes">The list of attributes attached to this element.</param>
        /// <param name="returnType">The property return type.</param>
        /// <param name="unsafeCode">Indicates whether the element resides within a block of unsafe code.</param>
        internal Property(CodeUnitProxy proxy, string name, ICollection<Attribute> attributes, TypeToken returnType, bool unsafeCode)
            : base(proxy, ElementType.Property, name, attributes, unsafeCode)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.AssertValidString(name, "name");
            Param.Ignore(attributes);
            Param.AssertNotNull(returnType, "returnType");
            Param.Ignore(unsafeCode);

            this.returnType.Value = returnType;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the return type for the property.
        /// </summary>
        public TypeToken ReturnType
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.returnType.Initialized)
                {
                    this.returnType.Value = this.FindFirstChild<TypeToken>();
                }

                return this.returnType.Value;
            }
        }

        /// <summary>
        /// Gets the get accessor for the property, if there is one.
        /// </summary>
        public Accessor GetAccessor
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.get.Initialized)
                {
                    this.get.Value = null;

                    for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
                    {
                        if (child.AccessorType == AccessorType.Get)
                        {
                            this.get.Value = child;
                        }
                    }
                }

                return this.get.Value;
            }
        }

        /// <summary>
        /// Gets the set accessor for the property, if there is one.
        /// </summary>
        public Accessor SetAccessor
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.set.Initialized)
                {
                    this.set.Value = null;

                    for (Accessor child = this.FindFirstChild<Accessor>(); child != null; child = child.FindNextSibling<Accessor>())
                    {
                        if (child.AccessorType == AccessorType.Set)
                        {
                            this.set.Value = child;
                        }
                    }
                }

                return this.set.Value;
            }
        }

        #endregion Public Properties

        #region Protected Override Properties

        /// <summary>
        /// Gets the collection of modifiers allowed on this element.
        /// </summary>
        protected override IEnumerable<string> AllowedModifiers
        {
            get
            {
                return CodeParser.PropertyModifiers;
            }
        }

        /// <summary>
        /// Gets the default access modifier for this type.
        /// </summary>
        protected override AccessModifierType DefaultAccessModifierType
        {
            get
            {
                string name = this.Name;

                // If this is an explicit interface member implementation and our access modifier
                // is currently set to private because we don't have one, then it should be public instead.
                if (name.IndexOf(".", StringComparison.Ordinal) > -1 && !name.StartsWith("this.", StringComparison.Ordinal))
                {
                    return AccessModifierType.Public;
                }

                return base.DefaultAccessModifierType;
            }
        }

        #endregion Protected Override Properties

        #region Protected Override Methods

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <returns>The name of the element.</returns>
        protected override string GetElementName()
        {
            // Get the return type.
            TypeToken r = this.FindFirstChild<TypeToken>();
            if (r != null)
            {
                // The next Token is the name.
                Token nameToken = r.FindNextSibling<Token>();
                if (nameToken != null)
                {
                    return nameToken.Text;
                }
            }

            throw new SyntaxException(this.Document, this.LineNumber);
        }

        /// <summary>
        /// Resets the contents of the class.
        /// </summary>
        protected override void Reset()
        {
            base.Reset();

            this.returnType.Reset();
            this.get.Reset();
            this.set.Reset();
        }

        #endregion Protected Override Methods
    }
}
