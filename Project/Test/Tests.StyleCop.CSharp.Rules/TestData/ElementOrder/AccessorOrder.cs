public class A
{
    // No violation
    public bool P1
    {
        get { return true; }
        set { }
    }

    // No violation
    public bool P2
    {
        get { return true; }
    }

    // No violation
    public bool P3
    {
        set { }
    }

    // No violation
    public bool P4
    {
        get { return true; }
        protected set { }
    }

    // Violation
    public bool P5
    {
        set { }
        get { return true; }
    }

    // Violation
    public bool P1
    {
        protected set { }
        get { return true; }
    }
}

public class E
{
    // No violation
    public event EventHandler E1
    {
        add { }
        remove { }
    }

    // No violation
    public event EventHandler E2
    {
        add { }
    }

    // No violation
    public event EventHandler E3
    {
        remove { }
    }

    // Violation
    public event EventHandler E4
    {
        remove { }
        add { }
    }
}