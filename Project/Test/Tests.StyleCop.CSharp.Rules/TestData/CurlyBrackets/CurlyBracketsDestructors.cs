using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsDestructors
    {
        // Invalid destructors
        ~CurlyBracketsDestructors() { }
        ~CurlyBracketsDestructors() { int x; }

        ~CurlyBracketsDestructors() {
            int x; }

        ~CurlyBracketsDestructors() {
            int x; 
        }

        ~CurlyBracketsDestructors()
        {
            int x; }

        ~CurlyBracketsDestructors()
        { int x; 
        }

        ~CurlyBracketsDestructors()
        { int x; }

        // Valid destructors
        ~CurlyBracketsDestructors()
        {
        }

        ~CurlyBracketsDestructors()
        {
            int x; 
        }
    }
}