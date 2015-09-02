using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public unsafe class CurlyBracketsFixeds
    {
        public void TestFixed()
        {
            int x = 0;

            // Invalid
            fixed (int* p = null) { }
            fixed (int* p = null) { x = 2; }

            fixed (int* p = null)
            {
                x = 2; }

            fixed (int* p = null) {
                x = 2; 
            }

            fixed (int* p = null) {
                x = 2; }

            fixed (int* p = null) 
            { x = 2; 
            }

            fixed (int* p = null)
            { x = 2; }

            // Valid
            fixed (int* p = null)
            {
            }

            fixed (int* p = null)
            {
                x = 2; 
            }
        }
    }
}