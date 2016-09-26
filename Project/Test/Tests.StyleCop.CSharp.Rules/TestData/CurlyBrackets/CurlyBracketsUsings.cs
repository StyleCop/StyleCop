using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsUsings
    {
        public void TestUsings()
        {
            int x;

            // Invalid usings
            using (Form y = new Form()) { }
            using (Form y = new Form()) { x = 2; }

            using (Form y = new Form()) 
            { 
                x = 2; }

            using (Form y = new Form()) {
                x = 2; 
            }

            using (Form y = new Form()) {
                x = 2; }

            using (Form y = new Form()) 
            { x = 2; 
            }

            using (Form y = new Form()) 
            { x = 2; }

            // Valid usings
            using (Form y = new Form()) 
            { 
            }

            using (Form y = new Form()) 
            { 
                x = 2; 
            }

            // Invalid using -- Missing the curly brackets
            using (Form y = new Form())
                x = 2;

            // Valid stacked usings
            using (Form aa = new Form())
            using (Form bb = new Form())
            using (Form cc = new Form())
            {
                x = 2;
            }

            // Valid nexted usings
            using (Form aa = new Form())
            {
                using (Form bb = new Form())
                {
                    using (Form cc = new Form())
                    {
                        x = 2;
                    }
                }
            }

            // Valid mix of stacked and nested usings.
            using (Form aa = new Form())
            {
                using (Form bb = new Form())
                using (Form cc = new Form())
                {
                    x = 2;
                }
            }

            // Invalid stack with no brackets:
            using (Form aa = new Form())
            using (Form bb = new Form())
            using (Form cc = new Form())
                x = 2;

            // Invalid stack with body in the middle:
            using (Form aa = new Form())
            x = 2;
            using (Form bb = new Form())
            using (Form cc = new Form())
            {
                x = 2;
            }

            // Invalid stack with if in the middle
            using (Form aa = new Form())
            if (true)
            using (Form bb = new Form())
            using (Form cc = new Form())
            {
                x = 2;
            }

            // Invalid stack with valid if
            using (Form aa = new Form())
            if (true)
            {
                using (Form bb = new Form())
                using (Form cc = new Form())
                {
                    x = 2;
                }
            }
        }
    }
}