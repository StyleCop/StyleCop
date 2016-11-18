using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsWhiles
    {
        public void TestWhile()
        {
            int x = 0;

            // Invalid whiles
            while (x == 0) { }
            while (x == 0) { x = 2; }

            while (x == 0)
            {
                x = 2; }

            while (x == 0) {
                x = 2; 
            }

            while (x == 0) {
                x = 2; }

            while (x == 0) 
            { x = 2; 
            }

            while (x == 0)
            { x = 2; }

            while (x == 0) x = 2;

            while (x == 0)
                x = 2;

            // Valid whiles
            while (x == 0)
            {
            }

            while (x == 0)
            {
                x = 2; 
            }

            // Invalid while stack
            while (true)
            while (true)
            while (true)
            {
                x = 2;
            }
        }
    }
}