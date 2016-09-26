namespace ConstructorInitializerSpanningMultipleLines
{
    using System;

    public abstract class ConstructorInitializerSpanningMultipleLines
    {
        public ConstructorInitializerSpanningMultipleLines(int minimum, int maximum, SomeClass something)
        {
            //...
        }

        public ConstructorInitializerSpanningMultipleLines(int minimum, int maximum)
            : this(
                minimum,
                maximum,
                new SomeClass(
                    () => Console.WriteLine("First action invoked"),
                    () => Console.WriteLine("Second action invoked"),
                    () => Console.WriteLine("Third action invoked")))
        {
        }
    }

    public class SomeClass
    {
        public SomeClass(Action firstAction, Action secondAction, Action thirdAction)
        {
        }
    }
}
