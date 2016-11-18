namespace CSharpAnalyzersTest.TestData.BuiltInTypes
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    class ShorthandForNullableTypes
    {
        private Nullable<DateTime> d2; // invalid

        private DateTime? d1; // valid

        private List<Nullable<DateTime>> dates; // invalid

        private List<DateTime?> dates2; // valid

        private Nullable<int> i1; // invalid

        private int? i2; // valid

        private IEnumerable<IEnumerable<Nullable<DateTime>>> nested2Levels; // invalid

        private IEnumerable<IEnumerable<DateTime?>> nested2Levels2; // valid

        private IEnumerable<IEnumerable<IEnumerable<Nullable<DateTime>>>> nested3Levels; // invalid

        private IEnumerable<IEnumerable<IEnumerable<DateTime?>>> nested3Levels2; // valid

        private IEnumerable<IEnumerable<Nullable<Rectangle>, float>> rectangles; // invalid

        private IEnumerable<IEnumerable<Rectangle?, float>> rectangles2; // valid

        private IEnumerable<IEnumerable<int, Nullable<Size>, string>> sizes; // invalid

        private IEnumerable<IEnumerable<int, Size?, string>> sizes2; // valid

        private IEnumerable<IEnumerable<int, double, Nullable<Tuple<int, int>>>> tuples; // invalid

        private IEnumerable<IEnumerable<int, double, Tuple<int, int>?>> tuples2; // valid

        private NullableX<int> nx1; // valid

        public Nullable<DateTime> this[int index] // invalid
        {
            get
            {
                return this.dates[index];
            }
        }

        public DateTime? this[int index, string dummy] // valid
        {
            get
            {
                return this.dates2[index];
            }
        }

        public long this[int index, Nullable<long> nullable] // invalid
        {
            get
            {
                return 0;
            }
        }

        public long this[int index, string dummy, long? nullable] // valid
        {
            get
            {
                return 0;
            }
        }

        public IEnumerable<Nullable<DateTime>> Dates // invalid
        {
            get
            {
                return this.dates;
            }
        }

        public IEnumerable<DateTime?> Dates2 // valid
        {
            get
            {
                return this.dates2;
            }
        }

        public ShorthandForNullableTypes(IEnumerable<Nullable<DateTime>> dates) // invalid
        {
            this.dates = new List<Nullable<DateTime>>(dates);
        }

        public ShorthandForNullableTypes(IEnumerable<DateTime?> dates2, string dummy) // valid
        {
            this.dates2 = new List<DateTime?>(dates2);
        }

        public void Method(
            Nullable<bool> b1, // invalid
            bool? b2) // valid
        {
            Nullable<bool> c1 = null; // invalid
            bool? c2 = null; // valid
        }

        public void Method2()
        {
            var a = typeof(Nullable<>); // valid
        }

        public Nullable<TimeSpan> Method3() // invalid
        {
            return null;
        }

        public TimeSpan? Method4() // valid
        {
            return null;
        }

        private class Inner : IExample<Nullable<int>> // invalid
        {
        }

        private class Inner2 : IExample<int?> // valid
        {
        }

        private class Inner : IExample<System.Nullable<int>> // invalid
        {
        }

        private class Inner : IExample<global::System.Nullable<int>> // invalid
        {
        }

        public static TPrimitiveType Nullable<TPrimitiveType>(this TPrimitiveType primitiveType, bool isNullable)
        {

        }
    }
}
