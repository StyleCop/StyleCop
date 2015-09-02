using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsConstructors
    {
        // Invalid constructors
        public CurlyBracketsConstructors() { }
        public CurlyBracketsConstructors(int a) { int x; }

        public CurlyBracketsConstructors(bool a) {
            int x; }

        public CurlyBracketsConstructors(short a) {
            int x; 
        }

        public CurlyBracketsConstructors(long a)
        {
            int x; }

        public CurlyBracketsConstructors(long a)
        { int x; 
        }

        public CurlyBracketsConstructors(float a)
        { int x; }

        // Valid constructors
        public CurlyBracketsConstructors(double a)
        {
        }

        public CurlyBracketsConstructors(string a)
        {
            int x; 
        }
    }
}