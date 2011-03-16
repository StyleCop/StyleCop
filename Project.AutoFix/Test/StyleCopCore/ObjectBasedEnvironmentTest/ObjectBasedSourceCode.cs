//-----------------------------------------------------------------------
// <copyright file="ObjectBasedSourceCode.cs">
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StyleCop;
using System.IO;

namespace StreamBasedEnvironmentTest
{
    internal class ObjectBasedSourceCode : SourceCode
    {
        private int index;

        public ObjectBasedSourceCode(CodeProject project, SourceParser parser, int index) 
            : base(project, parser)
        {
            Param.Ignore(project);
            Param.Ignore(parser);
            Param.AssertValueBetween(index, 0, StaticSource.Sources.Length - 1, "Out of range.");

            this.index = index;
        }

        public override string Name
        {
            get 
            {
                return "StaticSource#" + this.index; 
            }
        }

        public override string Path
        {
            get 
            {
                return this.index.ToString(); 
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
            return new StringReader(StaticSource.Sources[this.index]);
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
