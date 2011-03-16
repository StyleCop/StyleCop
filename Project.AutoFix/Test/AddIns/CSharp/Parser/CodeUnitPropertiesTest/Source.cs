//-----------------------------------------------------------------------
// <copyright file="Source.cs">
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
namespace CodeUnitPropertiesTest
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StyleCop;
    using System.IO;

    internal class Source : SourceCode
    {
        private string source;
        private string sourceName;

        public Source(CodeProject project, SourceParser parser, string source, string sourceName)
            : base(project, parser)
        {
            Param.Ignore(project);
            Param.Ignore(parser);
            Param.AssertNotNull(source, "source");
            Param.AssertNotNull(sourceName, "sourceName");

            this.source = source;
            this.sourceName = sourceName;
        }

        public override string Name
        {
            get
            {
                return this.sourceName;
            }
        }

        public override string Path
        {
            get
            {
                return this.sourceName;
            }
        }

        public override string Type
        {
            get
            {
                return "cs";
            }
        }

        public override bool Exists
        {
            get
            {
                return true;
            }
        }

        public override DateTime TimeStamp
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override TextReader Read()
        {
            // Lazily load the actual source string.
            return new StringReader(this.source);
        }

        /// <summary>
        /// Writes the final document back to the source.
        /// </summary>
        /// <param name="document">The document to write.</param>
        /// <param name="exception">Returns an exception if the write operation fails.</param>
        /// <returns>Returns true if the document was written successfully; false otherwise.</returns>
        public override bool Write(ICodeDocument document, out Exception exception)
        {
            exception = new NotImplementedException();
            return false;
        }
    }
}
