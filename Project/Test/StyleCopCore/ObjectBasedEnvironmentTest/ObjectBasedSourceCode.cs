using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.StyleCop;
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
    }
}
