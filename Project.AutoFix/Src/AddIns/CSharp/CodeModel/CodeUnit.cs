//-----------------------------------------------------------------------
// <copyright file="CodeUnit.cs">
//     MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop.CSharp.CodeModel
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using StyleCop.CSharp.CodeModel.Collections;

    /// <summary>
    /// Delegate used for callbacks from the Next and Previous properties.
    /// </summary>
    /// <param name="codeUnit">The code unit to match against.</param>
    /// <returns>Returns true if the code unit is a match, false otherwise.</returns>
    public delegate bool CodeUnitMatchHandler(CodeUnit codeUnit);

    /// <summary>
    /// A basic code unit.
    /// </summary>
    public abstract class CodeUnit : ILinkNode<CodeUnit>
    {
        #region Internal Constants

        /// <summary>
        /// An empty array of variables.
        /// </summary>
        internal static readonly VariableCollection EmptyVariableCollection = new VariableCollection();

        #endregion Internal Constants

        #region Internal Static Fields

        /// <summary>
        /// An empty array of code units.
        /// </summary>
        internal static readonly CodeUnit[] EmptyCodeUnitArray = new CodeUnit[] { };

        #endregion Internal Static Fields

        #region Private Static Fields

        /// <summary>
        /// Stores the friendly type names for all element types.
        /// </summary>
        private static ConcurrentDictionary<int, string> friendlyTypeNames = new ConcurrentDictionary<int, string>();

        /// <summary>
        /// Stores the pluralized friendly type names for all element types.
        /// </summary>
        private static ConcurrentDictionary<int, string> friendlyPluralTypeNames = new ConcurrentDictionary<int, string>();

        #endregion Private Static Fields

        #region Private Fields

        /// <summary>
        /// The proxy for this code unit.
        /// </summary>
        private CodeUnitProxy proxy;

        /// <summary>
        /// The reference to the parent code unit.
        /// </summary>
        private CodeUnitProxy parentReference;

        /// <summary>
        /// The type of the code unit.
        /// </summary>
        private int fundamentalType;

        /// <summary>
        /// The current edit version.
        /// </summary>
        private uint editVersion;

        /// <summary>
        /// The linked list node.
        /// </summary>
        private LinkNode<CodeUnit> linkNode;

        /// <summary>
        /// Indicates whether the code unit contains generated code.
        /// </summary>
        private CodeUnitProperty<bool> generated;

        /// <summary>
        /// The location of the item within the code.
        /// </summary>
        private CodeUnitProperty<CodeLocation> location;

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
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(codeUnitType);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="proxy">Proxy object for the code unit.</param>
        /// <param name="fundamentalType">The type of the code unit.</param>
        internal CodeUnit(CodeUnitProxy proxy, int fundamentalType)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(fundamentalType);

            this.linkNode = new LinkNode<CodeUnit>(this);

            this.fundamentalType = fundamentalType;
            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(CodeUnitType), this.CodeUnitType), "The type is invalid.");

            this.proxy = proxy;
            this.proxy.Attach(this);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="proxy">Proxy object for the code unit.</param>
        /// <param name="fundamentalType">The type of the code unit.</param>
        /// <param name="location">The location of the code unit.</param>
        internal CodeUnit(CodeUnitProxy proxy, int fundamentalType, CodeLocation location)
        {
            Param.AssertNotNull(proxy, "proxy");
            Param.Ignore(fundamentalType);
            Param.Ignore(location);

            this.linkNode = new LinkNode<CodeUnit>(this);

            this.fundamentalType = fundamentalType;
            CsLanguageService.Debug.Assert(System.Enum.IsDefined(typeof(CodeUnitType), this.CodeUnitType), "The type is invalid.");

            this.location.Value = location;

            this.proxy = proxy;
            this.proxy.Attach(this);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="codeUnitType">The type of the code unit.</param>
        internal CodeUnit(CsDocument document, CodeUnitType codeUnitType)
            : this(document, (int)codeUnitType)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(codeUnitType);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="fundamentalType">The type of the code unit.</param>
        internal CodeUnit(CsDocument document, int fundamentalType)
            : this(new CodeUnitProxy(document), fundamentalType)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(fundamentalType);
        }

        /// <summary>
        /// Initializes a new instance of the CodeUnit class.
        /// </summary>
        /// <param name="document">The parent document.</param>
        /// <param name="fundamentalType">The type of the code unit.</param>
        /// <param name="location">The location of the code unit.</param>
        internal CodeUnit(CsDocument document, int fundamentalType, CodeLocation location)
            : this(new CodeUnitProxy(document), fundamentalType)
        {
            Param.AssertNotNull(document, "document");
            Param.Ignore(fundamentalType);
            Param.Ignore(location);

            this.location.Value = location;
        }

        #endregion Internal Constructors

        #region Public Virtual Properties

        /// <summary>
        /// Gets a value indicating whether this is generated code.
        /// </summary>
        public virtual bool Generated
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.generated.Initialized)
                {
                    if (this.Children.Count == 0)
                    {
                        this.generated.Value = this.Parent.Generated;
                    }
                    else 
                    {
                        this.generated.Value = this.Children.First.Generated;
                    }
                }

                return this.generated.Value;
            }

            internal set
            {
                Param.Ignore(value);
                this.generated.Value = value;
            }
        }

        /// <summary>
        /// Gets the location of this code unit within the document.
        /// </summary>
        public virtual CodeLocation Location
        {
            get
            {
                this.ValidateEditVersion();

                if (!this.location.Initialized)
                {
                    if (!this.AttachedToDocument)
                    {
                        this.location.Value = CodeLocation.Empty;
                    }
                    else
                    {
                        // If the item has child lexical elements, its location is the join of the first and last child lexical elements.
                        LexicalElement first = null;
                        LexicalElement last = null;
                        if (this.Children.Count > 0)
                        {
                            first = this.FindFirstLexicalElement();
                            last = this.FindLastLexicalElement();
                        }

                        if (first != null && last != null)
                        {
                            this.location.Value = CodeLocation.Join(first.Location, last.Location);
                        }
                        else
                        {
                            // The item has no children. In that case, find the previous lexical element, and this item comes just after it.
                            LexicalElement previous = this.FindPreviousLexicalElement();
                            if (previous != null)
                            {
                                int index = previous.Location.EndPoint.Index + previous.Text.Length;

                                if (previous.Is(LexicalElementType.EndOfLine))
                                {
                                    this.location.Value = new CodeLocation(index, index, 0, 0, previous.LineNumber + 1, previous.LineNumber + 1);
                                }
                                else
                                {
                                    int indexOnLine = previous.Location.EndPoint.IndexOnLine + previous.Text.Length;
                                    this.location.Value = new CodeLocation(index, index, indexOnLine, indexOnLine, previous.LineNumber, previous.LineNumber);
                                }
                            }
                            else
                            {
                                // The item has no previous lexical elements. It is sitting at the very first index within the document.
                                this.location.Value = CodeLocation.Empty;
                            }
                        }
                    }
                }

                return this.location.Value;
            }

            internal set
            {
                Param.AssertNotNull(value, "CodeLocation");
                this.location.Value = value;
            }
        }

        /// <summary>
        /// Gets the line number that this code unit appears on in the document.
        /// </summary>
        public virtual int LineNumber
        {
            get
            {
                return this.Location.StartPoint.LineNumber;
            }
        }

        /// <summary>
        /// Gets the parent document.
        /// </summary>
        public virtual CsDocument Document
        {
            get
            {
                return this.proxy.Document;
            }
        }

        /// <summary>
        /// Gets the variables defined within this code unit.
        /// </summary>
        public virtual VariableCollection Variables
        {
            get
            {
                return CodeUnit.EmptyVariableCollection;
            }
        }

        #endregion Public Virtual Properties

        #region Public Properties

        /// <summary>
        /// Gets the collection of children beneath this code unit.
        /// </summary>
        public CodeUnitCollection Children
        {
            get
            {
                CsLanguageService.Debug.Assert(this.proxy != null, "Proxy has not been set.");
                return this.proxy.Children;
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
        /// Gets the back and forward links for the node.
        /// </summary>
        public LinkNode<CodeUnit> LinkNode
        {
            get 
            { 
                return this.linkNode; 
            }
        }

        /// <summary>
        /// Gets a value indicating whether the item has been inserted into a document.
        /// </summary>
        public bool AttachedToDocument
        {
            get
            {
                CodeUnit c = this;
                while (c != null)
                {
                    if (c.Is(ElementType.Document))
                    {
                        return true;
                    }

                    c = c.Parent;
                }

                return false;
            }
        }

        #endregion Public Properties

        #region Internal Virtual Properties

        /// <summary>
        /// Gets or sets the parent reference.
        /// </summary>
        internal virtual CodeUnitProxy ParentReference
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
                    this.parentReference = value;
                }
            }
        }

        #endregion Internal Virtual Properties

        #region Internal Properties

        /// <summary>
        /// Gets the proxy that was used to create this CodeUnit.
        /// </summary>
        internal CodeUnitProxy ThisProxy
        {
            get
            {
                return this.proxy;
            }
        }

        /// <summary>
        /// Gets or sets the edit version of the code unit.
        /// </summary>
        internal uint EditVersion
        {
            get
            {
                return this.editVersion;
            }

            set
            {
                Param.Ignore(value);
                this.editVersion = value;
            }
        }

        /// <summary>
        /// Gets the generated property.
        /// </summary>
        internal CodeUnitProperty<bool> GeneratedProperty
        {
            get
            {
                return this.generated;
            }
        }

        /// <summary>
        /// Gets the location property.
        /// </summary>
        internal CodeUnitProperty<CodeLocation> LocationProperty
        {
            get
            {
                return this.location;
            }
        }

        #endregion Internal Properties

        #region Protected Properties

        /// <summary>
        /// Gets the friendly name of the code unit type, which can be used in user output.
        /// </summary>
        protected string FriendlyTypeTextBase
        {
            get
            {
                string value = null;
                if (!friendlyTypeNames.TryGetValue(this.fundamentalType, out value))
                {
                    value = TypeNames.ResourceManager.GetString(this.GetType().Name, TypeNames.Culture);
                    friendlyTypeNames.AddOrUpdate(this.fundamentalType, value, (elementType, originalValue) => originalValue);
                }

                return value;
            }
        }

        /// <summary>
        /// Gets the pluralized friendly name of the code unit type, which can be used in user output.
        /// </summary>
        protected string FriendlyPluralTypeTextBase
        {
            get
            {
                string value = null;
                if (!friendlyPluralTypeNames.TryGetValue(this.fundamentalType, out value))
                {
                    value = TypeNames.ResourceManager.GetString(this.GetType().Name + "Plural", TypeNames.Culture);
                    friendlyPluralTypeNames.AddOrUpdate(this.fundamentalType, value, (elementType, originalValue) => originalValue);
                }

                return value;
            }
        }

        #endregion Protected Properties

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
        /// Validates that the token's parent code unit references has been set.
        /// </summary>
        [Conditional("DEBUG")]
        internal void ValidateCodeUnitReference()
        {
            if ((this.parentReference == null || this.parentReference.Target == null) && !(this is CsDocument))
            {
                CsLanguageService.Debug.Fail("Parent code unit reference has not been set for token. CsDocument is the only code unit type which is allowed to have a null parent.");
            }
        }

        /// <summary>
        /// Detaches the code unit from the code unit collection that contains it.
        /// </summary>
        internal void Detach()
        {
            if (this.parentReference != null)
            {
                this.parentReference.Children.Remove(this);
            }

            this.parentReference = null;
        }

        #endregion Internal Methods

        #region Protected Virtual Methods

        /// <summary>
        /// Resets all properties within the code unit.
        /// </summary>
        protected virtual void Reset()
        {
            this.editVersion = this.Document.EditVersion;
            this.generated.Reset();
        }

        #endregion Protected Virtual Methods

        #region Protected Methods

        /// <summary>
        /// Verifies that the code unit is up to date with the latest edit version of the document.
        /// </summary>
        protected void ValidateEditVersion()
        {
            if (this.editVersion != this.proxy.Document.EditVersion)
            {
                this.Reset();
            }
        }

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
            for (CodeUnit codeUnit = startToken; codeUnit != null; codeUnit = codeUnit.FindNextSibling())
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

            return list.AsReadOnly();
        }

        #endregion Protected Methods
    }
}
