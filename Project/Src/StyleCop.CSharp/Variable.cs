// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Variable.cs" company="https://github.com/StyleCop">
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
//   Describes a field, variable or constant.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes a field, variable or constant.
    /// </summary>
    /// <subcategory>other</subcategory>
    public class Variable : ICodePart
    {
        #region Fields

        /// <summary>
        /// Indicates whether the variable is located within a block of generated code.
        /// </summary>
        private readonly bool generated;

        /// <summary>
        /// The location of the variable.
        /// </summary>
        private readonly CodeLocation location;

        /// <summary>
        /// The variable modifiers, if any.
        /// </summary>
        private readonly VariableModifiers modifiers;

        /// <summary>
        /// The variable name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The parent of the variable.
        /// </summary>
        private readonly Reference<ICodePart> parent;

        /// <summary>
        /// The variable type.
        /// </summary>
        private readonly TypeToken type;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the Variable class.
        /// </summary>
        /// <param name="type">
        /// The type of the variable.
        /// </param>
        /// <param name="name">
        /// The name of the variable.
        /// </param>
        /// <param name="modifiers">
        /// Modifiers applied to this variable.
        /// </param>
        /// <param name="location">
        /// The location of the variable.
        /// </param>
        /// <param name="parent">
        /// The parent code part.
        /// </param>
        /// <param name="generated">
        /// Indicates whether the variable is located within a block of generated code.
        /// </param>
        internal Variable(TypeToken type, string name, VariableModifiers modifiers, CodeLocation location, Reference<ICodePart> parent, bool generated)
        {
            Param.Ignore(type);
            Param.AssertValidString(name, "name");
            Param.Ignore(modifiers);
            Param.AssertNotNull(location, "location");
            Param.AssertNotNull(parent, "parent");
            Param.Ignore(generated);

            this.type = type;
            this.name = CodeLexer.DecodeEscapedText(name, true);
            this.modifiers = modifiers;
            this.location = location;
            this.parent = parent;
            this.generated = generated;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the type of this code part.
        /// </summary>
        public CodePartType CodePartType
        {
            get
            {
                return CodePartType.Variable;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the variable is located within a block of generated code.
        /// </summary>
        public bool Generated
        {
            get
            {
                return this.generated;
            }
        }

        /// <summary>
        /// Gets the line number on which this variable appears.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this.location.LineNumber;
            }
        }

        /// <summary>
        /// Gets the location of the variable.
        /// </summary>
        public CodeLocation Location
        {
            get
            {
                return this.location;
            }
        }

        /// <summary>
        /// Gets the modifiers applied to this variable.
        /// </summary>
        public VariableModifiers Modifiers
        {
            get
            {
                return this.modifiers;
            }
        }

        /// <summary>
        /// Gets the variable name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the parent of the variable.
        /// </summary>
        public ICodePart Parent
        {
            get
            {
                return this.parent.Target;
            }
        }

        /// <summary>
        /// Gets the variable type.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "API has already been published and should not be changed.")]
        public TypeToken Type
        {
            get
            {
                return this.type;
            }
        }

        #endregion
    }
}