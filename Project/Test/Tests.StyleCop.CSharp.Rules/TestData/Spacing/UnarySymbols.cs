using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    class UnarySymbols
    {
        public void Method1()
        {
            bool boolVar = false;
            if ( !boolVar) // invalid
            {
            }

            Debug.Assert(!someCondition, "Some text"); // valid
            Debug.Assert( !someCondition, "Some text"); // invalid
            
            //valid
            Debug.Assert(
            !someCondition,
            "Some text");
        }
    }
}
