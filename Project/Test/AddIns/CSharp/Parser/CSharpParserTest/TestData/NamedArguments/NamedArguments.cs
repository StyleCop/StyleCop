namespace ConsoleApplication1
{
    using System;

    public class NamedArguments
    {
        public NamedArguments()
        {
        }

        public NamedArguments(int x, int y = 2, string z = "hello")
        {
        }

        public int Method1(int x, int y = 5, int z = 7)
        {
            return 0;
        }

        public void CallMethod1()
        {
            Method1(1, 2, 3);
            Method1(1, 2);
            Method1(1);

            Method1(1, z: 3);
            Method1(1, 2, z: 3);
            Method1(x: 1, z: 3);
            Method1(x: 1, y: 2, z: 3);
            Method1(x: 1, y: 2);
            Method1(z: 3, x: 1);
            Method1(z: 3, x: 1, y: 2);
            Method1(y: 2, z: 3, x: 1);

            Method1(x: 1, y: 2, z: 3);

            Method1(x
                :
                1,
                y
                :
                2,
                z
                :
                3);
        }

        public int Method2(int x = 0, int y = -1)
        {
            return 0;
        }

        public enum EnumValues : int
        {
            EnumValue1 = 0,
            EnumValue2 = 1
        }

        public void CallMethod2()
        {
            Method2(x: Method1(x: 1, z: 3), y: Method1(1, y: 4, z: 3));

            Method2(x: Method1(x: 1, z: Method2()), y: Method1(1, y: Method2(x: (int)EnumValues.EnumValue1), z: 3));

            Method2(Method1(x: 1, z: 3), Method1(1, y: 4, z: 3));
        }

        public int Method3(int x, string y = "hello", DateTime z = new DateTime(), object a = null, bool b = true)
        {
            return 0;
        }

        public void Method4(int x, NamedArguments y = null)
        {
        }

        public void Method5(bool x, DateTime y = default(DateTime), NamedArguments z = default(NamedArguments))
        {
        }

        public void Method6<T>(T y = default(T))
        {
        }

        public void Method7(out bool x, ref int y)
        {
            x = true;
        }

        public void CallMethod7()
        {
            bool x = true;
            int y = 1;
            Method7(x: out x, y: ref y);
        }

        public int this[int x = 0, string y = "hi", DateTime z = default(DateTime)]
        {
            get { return 2; }
        }
    }

    public class CallIndexer
    {
        public void CallIndexerMethod()
        {
            NamedArguments args = new NamedArguments();
            int val = args[y: +23, z: DateTime.Now, x: -1223];
        }
    }
}