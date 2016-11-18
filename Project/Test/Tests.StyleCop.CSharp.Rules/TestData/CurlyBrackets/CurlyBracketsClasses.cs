using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsClasses
    {
        // Invalid classes
        public class InvalidClass1 { }
        public class InvalidClass2 { private int field; }

        public class InvalidClass3 {
            private int field; }

        public class InvalidClass4 {
            private int field; 
        }

        public class InvalidClass5 
        {
            private int field; }

        public class InvalidClass6
        { private int field; 
        }

        public class InvalidClass7
        { private int field; }

        // Valid classes
        public class ValidClass1
        {
        }

        public class ValidClass2
        { 
            private int field; 
        }
    }
}