using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsQueries
    {
        public void ValidQueryNoBlankLineBeforeInto()
        {
            var input = Enumerable.Repeat(new { a = "Foo", b = "Bar" }, 23);
            var a = from e in input
                where e.a != null
                group e by new
                {
                    e.a
                }
                into eventGroups
                select new
                {
                    Result = eventGroups.Count()
                };
        }

        public void ValidQueryNoBlankLineBeforeEquals()
        {
            var leftStream = Enumerable.Repeat(new { a = "Foo", b = "Bar" }, 23);
            var rightStream = Enumerable.Repeat(new { a = "Foo", b = "Bar" }, 23);

            var a = from left in leftStream
                join right in rightStream
                on
                new
                {
                    left.a,
                    left.b
                }
                equals
                new
                {
                    right.a,
                    right.b
                }
                select new
                {
                    a = "BAZ!"
                };
        }
    }
}