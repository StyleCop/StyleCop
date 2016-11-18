using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsBlocks
    {
        public void TestBlocks()
        {
            // Invalid blocks
            { }
            { int a; }

            {
                int b; }

            { int d; 
            }
            
            { int e; }

            // Valid blocks
            {
            }

            {
                int f; 
            }
        }
    }

    /// <summary>
    /// The following class uses lambda expressions with valid curly bracket placement.
    /// No violations should be thrown.
    /// </summary>
    public class ValidBlocks
    {
        public void Method1()
        {
            // A lambda expression containing a block statement can be spread across
            // multiple lines like this.
            Comparison<ItemData> comparison = (item1, item2) =>
            {
                return string.Compare(item1.Name, item2.Name, StringComparison.Ordinal);
            };

            Array.Sort<ItemData>(unsortedData, comparison);
        }

        public void Method2()
        {
            // A block statement is allowed to be all on a single line when it is part of 
            // a lambda expression.
            Array.Sort<ItemData>(unsortedData, (item1, item2) => { return string.Compare(item1.Name, item2.Name, StringComparison.Ordinal); });
        }
    }
}