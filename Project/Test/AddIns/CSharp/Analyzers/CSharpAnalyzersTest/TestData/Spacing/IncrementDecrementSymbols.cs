using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    internal class IncrementDecrementSymbols
    {
        private int Method(int x)
        {
            x ++;
            ++ x;
            x --;
            -- x;
            return x;
        }

        private void Method()
        {
            int x = 0;
            this.Method(x ++);
            this.Method(++ x);
            this.Method(x --);
            this.Method(-- x);
        }

        private int Method(int x)
        {
            x++;
            ++x;
            x--;
            --x;
            return x;
        }

        private void Method()
        {
            int x = 0;
            this.Method(x++);
            this.Method(++x);
            this.Method(x--);
            this.Method(--x);
        }
    }
}
