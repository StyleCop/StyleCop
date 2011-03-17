using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    class OpenParenthesis
    {
        public void M(Action a)
        {
            M(a: () => Console.WriteLine());
        }

        public void Method1()
        {
            this.Foo1(param: (object)null);
            this.Foo2(param: (int x) => { return x * x; });
            this.Foo3(param: () => { });
        }

        public void Foo1(object param)
        {
        }

        private void Foo2(Func<int, int> param)
        {
        }

        private void Foo3(Action param)
        {
        }
   }
}
