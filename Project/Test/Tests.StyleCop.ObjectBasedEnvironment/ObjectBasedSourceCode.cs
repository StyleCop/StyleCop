// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectBasedSourceCode.cs" company="https://github.com/StyleCop">
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
//   The object based source code.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ObjectBasedEnvironmentTest
{
    using System;
    using System.IO;

    using StyleCop;

    /// <summary>
    /// The object based source code.
    /// </summary>
    internal class ObjectBasedSourceCode : SourceCode
    {
        #region Constants and Fields

        private int index;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectBasedSourceCode"/> class.
        /// </summary>
        /// <param name="project">
        /// The project.
        /// </param>
        /// <param name="parser">
        /// The parser.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        public ObjectBasedSourceCode(CodeProject project, SourceParser parser, int index)
            : base(project, parser)
        {
            Param.Ignore(project);
            Param.Ignore(parser);
            Param.AssertValueBetween(index, 0, StaticSource.Sources.Length - 1, "Out of range.");

            this.index = index;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether Exists.
        /// </summary>
        public override bool Exists
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets Name.
        /// </summary>
        public override string Name
        {
            get
            {
                return "StaticSource#" + this.index;
            }
        }

        /// <summary>
        /// Gets Path.
        /// </summary>
        public override string Path
        {
            get
            {
                return this.index.ToString();
            }
        }

        /// <summary>
        /// Gets TimeStamp.
        /// </summary>
        public override DateTime TimeStamp
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets Type.
        /// </summary>
        public override string Type
        {
            get
            {
                return "cs";
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The read.
        /// </summary>
        /// <returns>
        /// The StringReader with the source required.
        /// </returns>
        public override TextReader Read()
        {
            // Lazily load the actual source string.
            return new StringReader(StaticSource.Sources[this.index]);
        }

        #endregion
    }
}