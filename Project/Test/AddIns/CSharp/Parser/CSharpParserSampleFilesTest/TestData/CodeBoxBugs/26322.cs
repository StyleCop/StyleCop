using System;

interface IMyInterface
{
    event EventHandler MyEvent;
}

public class MyClass : IMyInterface
{
    event EventHandler IMyInterface.MyEvent
    {
        add { }
        remove { }
    }
}

class X
{
    static void Main()
    { }
}
