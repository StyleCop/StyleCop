using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsArrayInitialization
    {
        public void TestArrayInitialization()
        {
            // Invalid
            int[] a = new int[] 
            { 
                1 };

            int[] b = new int[] { 
                1 };

            int[] c = new int[] { 
                1 
            };

            int[] d = new int[] 
            { 
                1 };

            int[] e = new int[] 
            { 1 
            };

            int[] f = new int[] 
            { 1 };

            // Valid
            int[] x = new int[] { };
            int[] x = new int[] { 1 };

            int[] x = new int[] 
            { 
                1 
            };
        }
    }
}