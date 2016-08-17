using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsUncheckeds
    {
        public void TestUnchecked()
        {
            int x = 0;

            // Invalid
            unchecked { }
            unchecked { x = 2; }

            unchecked
            {
                x = 2; }

            unchecked {
                x = 2; 
            }

            unchecked {
                x = 2; }

            unchecked 
            { x = 2; 
            }

            unchecked
            { x = 2; }

            // Valid
            unchecked
            {
            }

            unchecked
            {
                x = 2; 
            }
        }
    }
}