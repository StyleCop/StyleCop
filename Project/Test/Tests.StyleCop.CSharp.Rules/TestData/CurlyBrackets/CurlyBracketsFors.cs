using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsFors
    {
        public void TestFor()
        {
            int x = 0;

            // Invalid fors
            for (;;) { }
            for (;;) { x = 2; }

            for (;;)
            {
                x = 2; }

            for (;;) {
                x = 2; 
            }

            for (;;) {
                x = 2; }

            for (;;) 
            { x = 2; 
            }

            for (;;)
            { x = 2; }

            for (;;) x = 2;

            for (;;)
                x = 2;

            // Valid fors
            for (;;)
            {
            }

            for (;;)
            {
                x = 2;
            }

            // Invalid for stack
            for(;;)
            for(;;)
            for(;;)
            {
                x = 2;
            }
        }
    }
}