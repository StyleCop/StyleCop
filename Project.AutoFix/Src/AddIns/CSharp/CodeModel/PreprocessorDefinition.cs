//-----------------------------------------------------------------------
// <copyright file="PreprocessorDefinition.cs">
//   MS-PL
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
    using System;

    /// <summary>
    /// Represents one flag defined at the preprocessor level.
    /// </summary>
    public class PreprocessorDefinition
    {
        /// <summary>
        /// Initializes a new instance of the PreprocessorDefinition class.
        /// </summary>
        /// <param name="name">The preprocessor flag name.</param>
        /// <param name="value">The optional value of the preprocessor flag.</param>
        public PreprocessorDefinition(string name, object value)
        {
            Param.RequireValidString(name, "name");
            Param.Ignore(value);

            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets the name of the flag.
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the value of the flag.
        /// </summary>
        public object Value
        {
            get;
            private set;
        }
    }
}
