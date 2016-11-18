namespace ElementOrderPartialElementsMissingAccessModifier
{
    protected partial interface Interface1
    {
    }

    // Violation
    partial interface Interface2
    {
    }

    protected internal partial struct Struct1
    {
    }

    // Violation
    partial struct Struct2
    {
    }

    protected partial class Class1
    {
    }

    // Violation
    partial class Class2
    {
    }
}