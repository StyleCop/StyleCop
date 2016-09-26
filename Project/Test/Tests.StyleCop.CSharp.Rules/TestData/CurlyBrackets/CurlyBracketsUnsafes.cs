using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsUnsafes
    {
        public void TestUnsafes()
        {
            int x = 0;

            // Invalid
            unsafe { }
            unsafe { x = 2; }

            unsafe
            {
                x = 2; }

            unsafe {
                x = 2; 
            }

            unsafe {
                x = 2; }

            unsafe 
            { x = 2; 
            }

            unsafe
            { x = 2; }

            // Valid
            unsafe
            {
            }

            unsafe
            {
                x = 2; 
            }
        }
    }
}