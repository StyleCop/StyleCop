#region Delegate Order

namespace ElementOrderNamespace1
{
    // Correct order
    public delegate void Delegate1();

    public enum Enum1
    {
    }
}

namespace ElementOrderNamespace2
{
    // Incorrect order
    public enum Enum1
    {
    }

    public delegate void Delegate1();
}

namespace ElementOrderNamespace3
{
    // Correct order
    public delegate void Delegate1();

    public interface Interface1
    {
    }
}

namespace ElementOrderNamespace4
{
    // Incorrect order
    public interface Interface1
    {
    }

    public delegate void Delegate1();
}

namespace ElementOrderNamespace5
{
    // Correct order
    public delegate void Delegate1();

    public struct Struct1
    {
    }
}

namespace ElementOrderNamespace6
{
    // Incorrect order
    public struct Struct1
    {
    }

    public delegate void Delegate1();
}

namespace ElementOrderNamespace7
{
    // Correct order
    public delegate void Delegate1();

    public class Class1
    {
    }
}

namespace ElementOrderNamespace8
{
    // Incorrect order
    public class Class1
    {
    }

    public delegate void Delegate1();
}

#endregion Delegate Order

#region Enum Order

namespace ElementOrderNamespace9
{
    // Correct order
    public enum Enum1
    {
    }

    public interface Interface1
    {
    }
}

namespace ElementOrderNamespace10
{
    // Incorrect order
    public interface Interface1
    {
    }

    public enum Enum1
    {
    }
}

namespace ElementOrderNamespace11
{
    // Correct order
    public enum Enum1
    {
    }

    public struct Struct1
    {
    }
}

namespace ElementOrderNamespace12
{
    // Incorrect order
    public struct Struct1
    {
    }

    public enum Enum1
    {
    }
}

namespace ElementOrderNamespace13
{
    // Correct order
    public enum Enum1
    {
    }

    public class Class1
    {
    }
}

namespace ElementOrderNamespace14
{
    // Incorrect order
    public class Class1
    {
    }

    public enum Enum1
    {
    }
}

#endregion Enum Order

#region Interface Order

namespace ElementOrderNamespace15
{
    // Correct order
    public interface Interface1
    {
    }

    public struct Struct1
    {
    }
}

namespace ElementOrderNamespace16
{
    // Incorrect order
    public struct Struct1
    {
    }

    public interface Interface1
    {
    }
}

namespace ElementOrderNamespace17
{
    // Correct order
    public interface Interface1
    {
    }

    public class Class1
    {
    }
}

namespace ElementOrderNamespace18
{
    // Incorrect order
    public class Class1
    {
    }

    public interface Interface1
    {
    }
}

#endregion Interface Order

#region Struct Order

namespace ElementOrderNamespace19
{
    // Correct order
    public struct Struct1
    {
    }

    public class Class1
    {
    }
}

namespace ElementOrderNamespace20
{
    // Incorrect order
    public class Class1
    {
    }

    public struct Struct1
    {
    }
}

#endregion Struct Order