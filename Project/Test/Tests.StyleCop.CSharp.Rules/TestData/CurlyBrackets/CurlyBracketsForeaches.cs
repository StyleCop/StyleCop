using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsForeaches
    {
        public void TestForeach()
        {
            int x = 0;
            int[] array = { 1, 2 };

            // Invalid foreaches
            foreach (int y in array) { }
            foreach (int y in array) { x = 2; }

            foreach (int y in array)
            {
                x = 2; }

            foreach (int y in array) {
                x = 2; 
            }

            foreach (int y in array) {
                x = 2; }

            foreach (int y in array) 
            { x = 2; 
            }

            foreach (int y in array)
            { x = 2; }

            foreach (int y in array) x = 2;

            foreach (int y in array)
                x = 2;

            // Valid foreachs
            foreach (int y in array)
            {
            }

            foreach (int y in array)
            {
                x = 2;
            }

            // Invalid foreach stack
            foreach (int aa in array)
            foreach (int bb in array)
            foreach (int cc in array)
            {
                x = 2;
            }
        }
    }
}