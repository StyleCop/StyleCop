using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsSwitches
    {
        public void TestSwitch()
        {
            int x = 0;

            // Invalid switches
            switch (x) { case 0: break; }

            switch (x)
            {
                case 0:
                    break; }

            switch (x) {
                case 0:
                    break;
            }

            switch (x) {
                case 0:
                    break; }
            
            switch (x)
            {
                case 0:
                    break; }

            switch (x)
            { case 0:
                break; 
            }

            switch (x)
            { case 0:
                break; }

            switch (x)
            { case 0: break; }

            // Valid switches
            switch (x)
            {
                case 0:
                    break;
            }
        }
    }
}