namespace CSharpParserTest.TestData
{

    /// <summary>
    /// The test class for issue #8.
    /// </summary>
    public class Test1
    {
        /// <summary>
        /// The rect struct2.
        /// </summary>
        public struct Rect2
        {
            public float x, y, w, h;
        }

        public class TestClass
        {
            /// <summary>
            /// The track position. 
            /// </summary>
            public Rect2 TrackPosition = new Rect2();

            /// <summary>
            /// Initializes a new instance of the <see cref="TestClass"/> class.
            /// </summary>
            public TestClass()
            {
            }
        }

        public void TestGroupKeyword(int group, bool hidden)
        {
            if ((int)42.0f == (int)group)
            {
            }
        }

        public void TestGroupKeyword2(TestClass group, bool hidden)
        {
            if ((int)42.0f == (int)group.TrackPosition.y)
            {
            }
        }

        public void TestWhereKeyword(int where, bool hidden)
        {
            if ((int)42.0f == (int)where)
            {
            }
        }

        public void TestWhereKeyword2(TestClass where, bool hidden)
        {
            if ((int)42.0f == (int)where.TrackPosition.y)
            {
            }
        }

        public void TestSelectKeyword(int select, bool hidden)
        {
            if ((int)42.0f == (int)select)
            {
            }
        }

        public void TestSelectKeyword2(TestClass select, bool hidden)
        {
            if ((int)42.0f == (int)select.TrackPosition.y)
            {
            }
        }

        public void TestIntoKeyword(int into, bool hidden)
        {
            if ((int)42.0f == (int)into)
            {
            }
        }

        public void TestIntoKeyword2(TestClass into, bool hidden)
        {
            if ((int)42.0f == (int)into.TrackPosition.y)
            {
            }
        }

        public void TestOrdeyByKeyword(int orderby, bool hidden)
        {
            if ((int)42.0f == (int)orderby)
            {
            }
        }

        public void TestOrdeyByKeyword2(TestClass orderby, bool hidden)
        {
            if ((int)42.0f == (int)orderby.TrackPosition.y)
            {
            }
        }

        public void TestJoinKeyword(int join, bool hidden)
        {
            if ((int)42.0f == (int)join)
            {
            }
        }

        public void TestJoinKeyword2(TestClass join, bool hidden)
        {
            if ((int)42.0f == (int)join.TrackPosition.y)
            {
            }
        }

        public void TestLetKeyword(int let, bool hidden)
        {
            if ((int)42.0f == (int)let)
            {
            }
        }

        public void TestLetKeyword2(TestClass let, bool hidden)
        {
            if ((int)42.0f == (int)let.TrackPosition.y)
            {
            }
        }

        public void TestEqualsKeyword(int equals, bool hidden)
        {
            if ((int)42.0f == (int)equals)
            {
            }
        }

        public void TestEqualsKeyword2(TestClass equals, bool hidden)
        {
            if ((int)42.0f == (int)equals.TrackPosition.y)
            {
            }
        }

        public void TestByKeyword(int by, bool hidden)
        {
            if ((int)42.0f == (int)by)
            {
            }
        }

        public void TestByKeyword2(TestClass by, bool hidden)
        {
            if ((int)42.0f == (int)by.TrackPosition.y)
            {
            }
        }

        public void TestOnKeyword(int on, bool hidden)
        {
            if ((int)42.0f == (int)on)
            {
            }
        }

        public void TestOnKeyword2(TestClass on, bool hidden)
        {
            if ((int)42.0f == (int)on.TrackPosition.y)
            {
            }
        }
    }
}

 
