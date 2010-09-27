using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.BuiltInTypes
{
    class ShorthandForNullableTypes
    {
        private DateTime? d1; // valid

        private Nullable<DateTime> d2; //invalid

        private Nullable<int> i1; // invalid

        private int? i2; // valid
    }
}
