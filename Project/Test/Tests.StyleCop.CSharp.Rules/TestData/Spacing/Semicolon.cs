using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    class Semicolon
    {
        public void ValidMethod1()
        {
            for (var start = 0; start <= 20; ++start)
            {
                for (var count = 0; count < 12; ++count)
                {
                    if (count == 6)
                    {
                        goto NOMATCH;
                    }
                }

                // Got through the whole pattern. We have a match.
                return;

                /* no match found at start. */
                NOMATCH:
                ;
            }
        }
        
        public void InValidMethod1()
        {
            for (var start = 0; start <= 20; ++start)
            {
                for (var count = 0; count < 12; ++count)
                {
                    if (count == 6)
                    {
                        goto NOMATCH;
                    }
                }

                ;

                // Got through the whole pattern. We have a match.
                return;

                /* no match found at start. */
                NOMATCH:
                ;
            }
        }
    }
}
