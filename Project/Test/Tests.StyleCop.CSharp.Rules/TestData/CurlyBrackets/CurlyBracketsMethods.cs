using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsMethods
    {
        // Invalid methods
        public void InvalidMethod1() { }
        public void InvalidMethod2() { int x; }

        public void InvalidMethod3()
        {
            int x; }

        public void InvalidMethod4() {
            int x; 
        }

        public void InvalidMethod5()
        {
            int x; }

        public void InvalidMethod6()
        { int x; 
        }

        public void InvalidMethod7()
        { int x; }

        // Valid methods
        public void ValidMethod1()
        {
        }

        public void ValidMethod2()
        {
            int x; 
        }
    }
}