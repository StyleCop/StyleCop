using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsCheckeds
    {
        public void TestChecked()
        {
            int x = 0;

            // Invalid
            checked { }
            checked { x = 2; }

            checked
            {
                x = 2; }

            checked {
                x = 2; 
            }

            checked {
                x = 2; }

            checked 
            { x = 2; 
            }

            checked
            { x = 2; }

            // Valid
            checked
            {
            }

            checked
            {
                x = 2; 
            }
        }
    }
}