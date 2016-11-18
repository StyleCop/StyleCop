using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsConstructors
    {
        // Invalid interfaces
        public interface InvalidInterface1 { }
        public interface InvalidInterface2 { void Method(); }

        public interface InvalidInterface3 {
            void Method(); }

        public interface InvalidInterface4 {
            void Method(); 
        }

        public interface InvalidInterface5 
        {
            void Method(); }

        public interface InvalidInterface6
        { void Method(); 
        }

        public interface InvalidInterface7
        { void Method(); }

        // Valid interfacees
        public interface ValidInterface1
        {
        }

        public interface ValidInterface2
        { 
            void Method(); 
        }
    }
}