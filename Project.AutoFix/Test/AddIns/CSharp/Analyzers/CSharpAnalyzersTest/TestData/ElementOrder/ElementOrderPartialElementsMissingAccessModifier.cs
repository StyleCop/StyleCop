namespace ElementOrderPartialElementsMissingAccessModifier
{
    // Violation
    partial interface Interface1
    {
    }

    protected partial interface Interface2
    {
    }

    partial interface Interface3
    {
    }

    // Violation
    partial struct Struct1
    {
    }

    protected internal partial struct Struct2
    {
    }

    partial struct Struct3
    {
    }

    partial class Class1
    {
    }

    protected partial class Class2
    {
    }

    // Violation
    partial class Class3
    {
    }
}