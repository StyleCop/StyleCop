namespace StyleCop.CSharpParserTest.TestData
{
    using System;

    public class AsType
    {
        public Type Method()
        {
            // Tests complex type tokens used with as.
            return categoryIds.ToArray(typeof(Guid?)) as Guid?[];
        }

        public void Method2()
        {
            // Tests the use of the nullable type operator with a generic type.
            Foo<short>? foo1 = new Foo<short>();

            // Tests the ability to create variables with complex names including generics.
            Type1.Type2.Type3 aa = null;
            Type1<int, string>.Type2.Type3 bb = null;
            Type1.Type2<int, string>.Type3 cc = null;
            Type1.Type2.Type3<int, string> dd = null;
            Type1<int, string>.Type2<int, string>.Type3 ee = null;
            Type1<int, string>.Type2.Type3<int, string> ff = null;
            Type1.Type2<int, string>.Type3<int, string> gg = null;
            Type1<int, string>.Type2<int, string>.Type3<int, string> hh = null;
        }
    }

    // The ability to create a fixed array using a hardcoded number or a const.
    internal unsafe struct MyStruct
    {
        private const int DATA_SIZE = 1024;

        private fixed byte data [DATA_SIZE];

        private fixed byte data2 [1024];
    }

    internal class Program
    {
        private static void Main()
        {
            // The number one formatted as string
            1.ToString();
        }
    }

    public class MyDictionary<TKey, TValue> : INotifyPropertyChanged, INotifyCollectionChanged, IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IDictionary
    {
        public MyDictionary(IDictionary<TKey, TValue> dictionary = null, IEqualityComparer<TKey> comparer = null)
        {
        }
    }

    public class BooleanExtensionMethods
    {
        public BooleanExtensionMethods()
        {
            7.ShouldBe(6);
            true.ShouldBe(true);
            false.ShouldBe(false);
        }
    }

    public class @__ClassNameStartingWithAt
    {
        public @__ClassNameStartingWithAt()
        {

        }

        ~@__ClassNameStartingWithAt()
        {

        }
    }
}