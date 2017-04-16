namespace CSharpParserTest.TestData
{
    public class NullConditionExpressions
    {
        public void TestObjectNotNull()
        {
            List<string> list = new List<string>();
            var variable = list?.FirstOrDefault();
        }

        public object TestArrayNotNull1()
        {
            Module[] modules = Assembly.GetExecutingAssembly().GetModules();
            Contract.Assume(modules?.Length > 0);
            var result = modules?[0];
            return modules?[0];
        }

        public object TestArrayNotNull2()
        {
            int index = 0;
            Module[] modules = Assembly.GetExecutingAssembly().GetModules();
            Contract.Assume(modules?.Length > 0);
            var result = modules?[index];
            return modules?[index];
        }

        public void TestMethodReturnIsNotNull()
        {
            string company = AssemblyInfo.Attribute()?.Company;

            var posts = new List<string>() { "abc", "123" };
            posts.First()?.Replace('a', 'z');
        }

        public void SplitNullConditionOperator()
        {
            foo?.Bar();

            foo?
              .Bar();

            foo? // comment
              .Bar();

            foo?[index];

            foo?
              [index];

            foo? // comment
              [index];

            var list = new List<string>();
            var length = list.FirstOrDefault()?
                             .Length;
        }

        internal class myclass
        {
            private bool? singleBitValue;

            private bool? foo(object obj)
            {
                this.singleBitValue = obj as bool?;
                this.singleBitValue = obj as bool? ?? false;
                return true ? true : false;
            }
        }

        public class MyTest
        {
            public object Invoke()
            {
                return null;
            }
        }

        public class Class2
        {
            public void Test()
            {
                bool y = true;
                MyTest z = new MyTest();
                MyTest w = new MyTest();

                var x = y ? z?.Invoke() : w?.Invoke();
            }
        }

        public class ThrowTest
        {
            public string Name { get; }

            public ThrowTest(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
