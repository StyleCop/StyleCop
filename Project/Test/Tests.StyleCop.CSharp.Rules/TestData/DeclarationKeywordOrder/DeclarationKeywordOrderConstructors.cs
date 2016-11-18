using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class DeclarationKeywordOrderConstructors
    {
        // Valid constructors
        DeclarationKeywordOrderConstructors(DateTime x)
        {
        }

        public DeclarationKeywordOrderConstructors(object x)
        {
        }

        internal DeclarationKeywordOrderConstructors(int x)
        {
        }

        protected DeclarationKeywordOrderConstructors(bool x)
        {
        }

        protected internal DeclarationKeywordOrderConstructors(short x)
        {
        }

        private DeclarationKeywordOrderConstructors(long x)
        {
        }

        extern DeclarationKeywordOrderConstructors(string[][] x);

        public extern DeclarationKeywordOrderConstructors(float x);

        internal extern DeclarationKeywordOrderConstructors(double x);

        protected extern DeclarationKeywordOrderConstructors(string x);

        protected internal extern DeclarationKeywordOrderConstructors(byte x);

        private extern DeclarationKeywordOrderConstructors(char x);

        static DeclarationKeywordOrderConstructors(int[] x)
        {
        }

        static extern DeclarationKeywordOrderConstructors(short[] x);

        // Invalid constructors
        extern static DeclarationKeywordOrderConstructors(long[] x);

        internal protected DeclarationKeywordOrderConstructors(float[] x)
        {
        }

        extern public DeclarationKeywordOrderConstructors(string[] x);

        extern internal DeclarationKeywordOrderConstructors(char[] x);

        extern protected DeclarationKeywordOrderConstructors(byte[] x);

        extern protected internal DeclarationKeywordOrderConstructors(DateTime x);

        extern internal protected DeclarationKeywordOrderConstructors(Array x);

        internal protected extern DeclarationKeywordOrderConstructors(double[] x);

        internal extern protected DeclarationKeywordOrderConstructors(double[][] x);

        protected extern internal DeclarationKeywordOrderConstructors(object[] x);

        extern private DeclarationKeywordOrderConstructors(object[][] x);
    }
}
