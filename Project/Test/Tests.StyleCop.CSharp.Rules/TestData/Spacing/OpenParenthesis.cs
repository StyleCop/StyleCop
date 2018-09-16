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
            var x = from p in pc
                    group p by ((int)Math.Round(p.z / 10.0) * 10) - 10 into g
                    orderby g.Key ascending
                    select new NameCount { Name = g.Key.ToString(), Count = g.Count() };
        }

        public void TestForIssue133()
        {
            try
            {
                int i;
            }
            catch (Exception e) when
            (
                e is SomeException ||
                e is SomeOtherException
            )
            {
            }
        }

        public void TestForTupleDeconstruction()
        {
            var (firstName, lastName) = Person;
            var ( firstN, lastN) = Person; // Should throw violation.
        }
    }
}
