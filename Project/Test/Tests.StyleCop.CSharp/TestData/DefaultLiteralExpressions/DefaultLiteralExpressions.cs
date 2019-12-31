using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.StyleCop.CSharp.TestData.DefaultLiteralExpressions
{
    public class DefaultLiteralExpressions
    {
        public DefaultLiteralExpressions()
        {
            int id = default(int);

            int[] idArray = default(int[]);

            int? csharp6NullableId = default(int?);

            int? nullableId = default;
        }
    }
}
