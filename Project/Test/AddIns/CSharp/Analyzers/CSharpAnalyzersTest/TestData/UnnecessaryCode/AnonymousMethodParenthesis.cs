namespace UnnecessaryCheckedAndUnchecked
{
    public delegate void Delegate1(int x);
    public delegate void Delegate2();

    public class Class1
    {
        public void Method1(Delegate1 x, Delegate2 y)
        {
        }

        public void Method2()
        {
            // Valid since the second anonymous method has no parenthesis.
            this.Method1(delegate(int x) { }, delegate { });

            // Invalid since the second anoymous method uses parenthesis.
            this.Method2(delegate(int x) { }, delegate() { });
        }
    }

    public class Class2
    {
        public bool MethodName(Func<bool> predicate)
        {
            return predicate();
        }

        public bool MethodName(Func<int, bool> predicate)
        {
            return predicate(10);
        }

        private bool Test()
        {
            // This is valid as MethodName as 2 signatures on this class.
            return this.MethodName(delegate() { return true; });
        }
    }

    public class Class3
    {
        public bool MethodName(Func<bool> predicate)
        {
            return predicate();
        }

        public bool MethodName2(Func<int, bool> predicate)
        {
            return predicate(10);
        }

        private bool Test()
        {
            // This is invalid.
            return this.MethodName(delegate() { return true; });
        }
    }

    public class Class4
    { 
        private bool Test()
        {
            // This is valid.
            return MethodNameC(delegate() { return true; });
        }
    }
}