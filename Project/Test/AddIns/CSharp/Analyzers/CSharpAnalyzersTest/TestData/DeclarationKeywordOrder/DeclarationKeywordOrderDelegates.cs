using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class DeclarationKeywordOrderDelegates
    {
        // Valid delegates
        delegate void ValidDelegate1();

        public delegate void ValidDelegate2();

        internal delegate void ValidDelegate3();

        protected delegate void ValidDelegate4();

        protected internal delegate void ValidDelegate5();

        private delegate void ValidDelegate6();

        // Invalid delegates
        internal protected delegate void InvalidDelegate1();
    }
}
