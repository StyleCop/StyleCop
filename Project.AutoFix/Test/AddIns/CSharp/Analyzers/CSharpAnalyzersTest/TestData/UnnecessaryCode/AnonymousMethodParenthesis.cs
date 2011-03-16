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
}