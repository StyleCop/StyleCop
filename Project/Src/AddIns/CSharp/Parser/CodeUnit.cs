//-----------------------------------------------------------------------
// <copyright file="CodeUnit.cs" company="Microsoft">
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
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.StyleCop.Collections;

    /// <summary>
    /// Delegate used for callbacks from the Next and Previous properties.
    /// </summary>
    /// <param name="codeUnit">The code unit to match against.</param>
    /// <returns>Returns true if the code unit is a match, false otherwise.</returns>
    public delegate bool CodeUnitMatchHandler(CodeUnit codeUnit);

    /// <summary>
    /// A basic code unit.
    /// </summary>
    public abstract class CodeUnit : ILinkNode<CodeUnit>, ICodeUnitReference
    {
        #region Internal Static Fields

        /// <summary>
        /// An empty array of code units.
        /// </summary>
        internal static readonly CodeUnit[] EmptyCodeUnitArray = new CodeUnit[] { };

        #endregion Internal Static Fields

        #region Private Fields

        /// <summary>
        /// The friendly name of the type.
        /// </summary>
        private string friendlyTypeName;

        /// <summary>
        /// The friendly name of the type, in plural form.
        /// </summary>
        private string friendlyPluralTypeName;

        /// <summary>
        /// The children beneath this code unit.
        /// </summary>
        private CodeUnitCollection children;

        /// <summary>
        /// The reference to the parent code unit.
        /// </summary>
        private ICodeUnitReference parentReference;

        /// <summary>
        /// The type of the code unit.
        /// </summary>
        private int fundamentalType;

        /// <summary>
        /// The linked list node.
        /// </summary>
        private LinkNode<CodeUnit> linkNode;

        /// <summary>
        /// Indicates whether the code unit lies within a block of generated code.
        /// </summary>
        private bool generated;

        #endregion Private Fields

        #region Internal Constructors

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="proxy">Proxy object for the code unit.</param>
        /// <param name="codeUnitType">The type of the code unit.</param>
        internal CodeUnit(CodeUnitProxy proxy, CodeUnitType codeUnitType)
            : this(proxy, (int)codeUnitType)
        {
            Param.Ignore(proxy, codeUnitType);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="proxy">Proxy object for the code unit.</param>
        /// <param name="fundamentalType">The type of the code unit.</param>
        internal CodeUnit(CodeUnitProxy proxy, int fundamentalType)
            : this(
            proxy, 
            fundamentalType, 
            proxy == null ? false : (proxy.Children == null ? false : (proxy.Children.First == null ? false : (proxy.Children.First.Generated || proxy.Children.Last.Generated))))
        {
            Param.Ignore(proxy, fundamentalType);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="proxy">Proxy object for the code unit.</param>
        /// <param name="codeUnitType">The type of the code unit.</param>
        /// <param name="generated">Indicates whether the item lies within a block of generated code.</param>
        internal CodeUnit(CodeUnitProxy proxy, CodeUnitType codeUnitType, bool generated)
            : this(proxy, (int)codeUnitType, generated)
        {
            Param.Ignore(proxy);
            Param.Ignore(codeUnitType);
            Param.Ignore(generated);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="proxy">Proxy object for the code unit.</param>
        /// <param name="fundamentalType">The type of the code unit.</param>
        /// <param name="generated">Indicates whether the item lies within a block of generated code.</param>
        internal CodeUnit(CodeUnitProxy proxy, int fundamentalType, bool generated)
        {
            Param.Ignore(proxy);
            Param.Ignore(fundamentalType);
            Param.Ignore(generated);

            this.linkNode = new LinkNode<CodeUnit>(this);

            // Fill in the values from the proxy of this code unit.
            if (proxy != null)
            {
                this.children = proxy.Children;
                proxy.Attach(this);
            }
            else
            {
                this.children = new CodeUnitCollection(this);
            }

            Debug.Assert(this.children != null, "The child collection must be set");

            this.fundamentalType = fundamentalType;
            Debug.Assert(System.Enum.IsDefined(typeof(CodeUnitType), this.CodeUnitType), "The type is invalid.");

            this.generated = generated;
        }

        #endregion Internal Constructors

        #region Public Properties

        /// <summary>
        /// Gets the collection of children beneath this code unit.
        /// </summary>
        public CodeUnitCollection Children
        {
            get
            {
                return this.children;
            }
        }

        /// <summary>
        /// Gets the parent of the code unit.
        /// </summary>
        public CodeUnit Parent
        {
            get
            {
                if (this.parentReference == null)
                {
                    return null;
                }

                return this.parentReference.Target;
            }
        }

        /// <summary>
        /// Gets the location of this code unit within the document.
        /// </summary>
        public virtual CodeLocation Location
        {
            get
            {
                if (this.children != null && this.children.Count > 0)
                {
                    return CodeUnit.JoinLocations(this.children.First, this.children.Last);
                }

                return CodeLocation.Empty;
            }
        }

        /// <summary>
        /// Gets the line number that this code unit appears on in the document.
        /// </summary>
        public virtual int LineNumber
        {
            get
            {
                if (this.children != null && this.children.Count > 0)
                {
                    return this.children.First.LineNumber;
                }

                return 0;
            }
        }

        /// <summary>
        /// Gets the friendly name of the code unit type, which can be used in user output.
        /// </summary>
        public string FriendlyTypeText
        {
            get
            {
                string text = this.GetFriendlyTypeText(null);
                if (text != null)
                {
                    return text;
                }

                text = this.GetFriendlyTypeText(this.GetType().Name);
                Debug.Assert(!string.IsNullOrEmpty(text), "The text should not be empty");

                return text;
            }
        }

        /// <summary>
        /// Gets the friendly name of the code unit type as a plural noun, which can be used in user output.
        /// </summary>
        public string FriendlyPluralTypeText
        {
            get
            {
                string text = this.GetFriendlyPluralTypeText(null);
                if (text != null)
                {
                    return text;
                }

                text = this.GetFriendlyPluralTypeText(this.GetType().Name);
                Debug.Assert(!string.IsNullOrEmpty(text), "The text should not be empty");

                return text;
            }
        }

        /// <summary>
        /// Gets the unmodified code unit type.
        /// </summary>
        public int FundamentalType
        {
            get
            {
                return this.fundamentalType;
            }
        }

        /// <summary>
        /// Gets the type of the code unit.
        /// </summary>
        public CodeUnitType CodeUnitType
        {
            get
            {
                return (CodeUnitType)(this.fundamentalType & (int)FundamentalTypeMasks.CodeUnit);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this is generated code.
        /// </summary>
        public bool Generated
        {
            get
            {
                return this.generated;
            }

            protected set
            {
                this.generated = value;
            }
        }

        /// <summary>
        /// Gets the back and forward links for the node.
        /// </summary>
        public LinkNode<CodeUnit> LinkNode
        {
            get 
            { 
                return this.linkNode; 
            }
        }

        #endregion Public Properties

        #region IReference Properties 

        /// <summary>
        /// Gets a reference which points back to this object.
        /// </summary>
        CodeUnit ICodeUnitReference.Target
        {
            get { return this; }
        }
        
        #endregion IReference Properties

        #region Internal Virtual Properties

        /// <summary>
        /// Gets or sets the parent reference.
        /// </summary>
        internal virtual ICodeUnitReference ParentReference
        {
            get
            {
                return this.parentReference;
            }

            set
            {
                Param.Ignore(value);

                if (value != this.parentReference)
                {
                    ////if (this.parentReference != null)
                    ////{
                    ////    this.parentReference.ReferenceChanged -= new EventHandler(this.ParentReferenceChanged);
                    ////}

                    this.parentReference = value;

                    ////if (value != null)
                    ////{
                    ////    value.ReferenceChanged += new EventHandler(this.ParentReferenceChanged);
                    ////}

                    ////this.OnParentChanged();
                }
            }
        }

        #endregion Internal Virtual Properties

        #region Internal Static Methods

        /// <summary>
        /// Joins the locations of the two code units.
        /// </summary>
        /// <param name="codeUnit1">The first code unit.</param>
        /// <param name="codeUnit2">The second code unit.</param>
        /// <returns>Returns the joined location.</returns>
        internal static CodeLocation JoinLocations(CodeUnit codeUnit1, CodeUnit codeUnit2)
        {
            Param.Ignore(codeUnit1, codeUnit2);

            if (codeUnit1 == null)
            {
                if (codeUnit2 == null)
                {
                    return CodeLocation.Empty;
                }

                return CodeLocation.Join(null, codeUnit2.Location);
            }
            else if (codeUnit2 == null)
            {
                return CodeLocation.Join(codeUnit1.Location, null);
            }
            else
            {
                return CodeLocation.Join(codeUnit1.Location, codeUnit2.Location);
            }
        }

        /// <summary>
        /// Joins the locations of the two code units.
        /// </summary>
        /// <param name="codeUnit1">The first code unit.</param>
        /// <param name="location2">The second location.</param>
        /// <returns>Returns the joined location.</returns>
        internal static CodeLocation JoinLocations(CodeUnit codeUnit1, CodeLocation location2)
        {
            Param.Ignore(codeUnit1, location2);

            if (codeUnit1 == null)
            {
                if (location2 == null)
                {
                    return CodeLocation.Empty;
                }

                return location2;
            }
            else if (location2 == null)
            {
                return CodeLocation.Join(codeUnit1.Location, null);
            }
            else
            {
                return CodeLocation.Join(codeUnit1.Location, location2);
            }
        }

        /// <summary>
        /// Joins the locations of the two code units.
        /// </summary>
        /// <param name="location1">The first code unit.</param>
        /// <param name="codeUnit2">The second code unit.</param>
        /// <returns>Returns the joined location.</returns>
        internal static CodeLocation JoinLocations(CodeLocation location1, CodeUnit codeUnit2)
        {
            Param.Ignore(location1, codeUnit2);
            return JoinLocations(codeUnit2, location1);
        }

        #endregion Internal Static Methods

        #region Internal Methods

        /// <summary>
        /// Gets the friendly name of the code unit type, which can be used in user output.
        /// </summary>
        /// <param name="typeName">The name of the type.</param>
        /// <returns>Returns the friendly name text.</returns>
        internal string GetFriendlyTypeText(string typeName)
        {
            Param.Ignore(typeName);

            if (this.friendlyTypeName == null && typeName != null)
            {
                this.friendlyTypeName = TypeNames.ResourceManager.GetString(typeName, TypeNames.Culture);
            }

            return this.friendlyTypeName;
        }

        /// <summary>
        /// Gets the friendly name of the code unit type as a plural noun, which can be used in user output.
        /// </summary>
        /// <param name="typeName">The name of the type.</param>
        /// <returns>Returns the plural friendly name text.</returns>
        internal string GetFriendlyPluralTypeText(string typeName)
        {
            Param.Ignore(typeName);

            if (this.friendlyPluralTypeName == null && typeName != null)
            {
                this.friendlyPluralTypeName = TypeNames.ResourceManager.GetString(typeName + "Plural", TypeNames.Culture);
            }

            return this.friendlyPluralTypeName;
        }

        /// <summary>
        /// Validates that the token's parent code unit references has been set.
        /// </summary>
        [Conditional("DEBUG")]
        internal void ValidateCodeUnitReference()
        {
            if ((this.parentReference == null || this.parentReference.Target == null) && !(this is DocumentRoot))
            {
                Debug.Fail("Parent code unit reference has not been set for token. DocumentRoot is the only code unit type which is allowed to have a null parent.");
            }
        }

        /// <summary>
        /// Detaches the code unit from the code unit collection that contains it.
        /// </summary>
        internal void Detach()
        {
            if (this.parentReference != null && this.parentReference.Target != null)
            {
                this.parentReference.Target.Children.Remove(this);
            }

            this.parentReference = null;
        }

        #endregion Internal Methods

        #region Protected Virtual Methods

        /////// <summary>
        /////// Called when the parent of the element changes.
        /////// </summary>
        ////protected virtual void OnParentChanged()
        ////{
        ////}

        /// <summary>
        /// Collects the variables declared by the code unit.
        /// </summary>
        protected virtual void CollectVariables()
        {
        }

        #endregion Protected Virtual Methods

        #region Protected Override Methods

        /////// <summary>
        /////// Gets the collection of children beneath this code unit.
        /////// </summary>
        /////// <returns>Returns the child collection.</returns>
        ////protected override ICollection<CodeUnit> GetChildCodeUnits()
        ////{
        ////    return new CollectionAdapter<CodeUnit, CodePart>(this.children, delegate(CodeUnit c) { return c; });
        ////}

        /////// <summary>
        /////// Gets the parent of this code unit.
        /////// </summary>
        /////// <returns>Returns the parent.</returns>
        ////protected override CodePart GetParentCodePart()
        ////{
        ////    return this.Parent;
        ////}

        #endregion Protected Override Methods

        #region Protected Methods

        /// <summary>
        /// Iterates through the tokens in the element declaration and extracts the parameters, if any.
        /// </summary>
        /// <param name="startToken">The first token to begin searching for the parameter list.</param>
        /// <param name="parameterListEndBracket">The type of the end bracket.</param>
        /// <returns>Returns the parameters.</returns>
        protected IList<Parameter> CollectFormalParameters(Token startToken, TokenType parameterListEndBracket)
        {
            Param.Ignore(startToken);
            Param.Ignore(parameterListEndBracket);

            if (startToken == null)
            {
                return Parameter.EmptyParameterArray;
            }

            var list = new List<Parameter>();
            for (CodeUnit codeUnit = startToken; codeUnit != null; codeUnit = codeUnit.FindNextSibling<CodeUnit>())
            {
                // If we hit the closing bracket before we've seen a parameter list, then quit.
                if (codeUnit.Is(parameterListEndBracket))
                {
                    break;
                }

                if (codeUnit.CodeUnitType == CodeUnitType.ParameterList)
                {
                    // We've found the parameter list. Add each child parameter then quit.
                    for (Parameter parameter = codeUnit.FindFirstChild<Parameter>(); parameter != null; parameter = parameter.FindNextSibling<Parameter>())
                    {
                        list.Add(parameter);
                    }

                    break;
                }
            }

            return list.ToArray();
        }

        #endregion Protected Methods

        #region Private Methods

        /////// <summary>
        /////// Called when the parent reference changes.
        /////// </summary>
        /////// <param name="sender">The event sender.</param>
        /////// <param name="e">The event arguments.</param>
        ////private void ParentReferenceChanged(object sender, EventArgs e)
        ////{
        ////    Param.Ignore(sender, e);
        ////    this.OnParentChanged();
        ////}

        #endregion Private Methods
    }
}
