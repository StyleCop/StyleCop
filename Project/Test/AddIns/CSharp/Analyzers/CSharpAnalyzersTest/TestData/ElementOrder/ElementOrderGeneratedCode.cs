namespace ElementOrderGeneratedCode1
{
    // Things in the correct order:
    public delegate void Delegate1();
    internal delegate void Delegate2();
    internal protected delegate void Delegate3();
    protected delegate void Delegate4();
    private delegate void Delegate5();

    public enum Enum1 { }
    internal enum Enum2 { }
    internal protected enum Enum3 { }
    protected enum Enum4 { }
    private enum Enum5 { }

    public interface Interface1 { }
    internal interface Interface2 { }
    internal protected interface Interface3 { }
    protected interface Interface4 { }
    private interface Interface5 { }

    public struct Struct1 { }
    internal struct Struct2 { }
    internal protected struct Struct3 { }
    protected struct Struct4 { }
    private struct Struct5 { }

    public class Class1 { }
    internal class Class2 { }
    internal protected class Class3 { }
    protected class Class4 { }
    private class Class5 { }
}

namespace ElementOrderGeneratedCode2
{
    // Things in incorrect order:
    private class Class6 { }
    protected class Class7 { }
    internal protected class Class8 { }
    internal class Class9 { }
    public class Class10 { }

    private struct Struct6 { }
    protected struct Struct7 { }
    internal protected struct Struct8 { }
    internal struct Struct9 { }
    public struct Struct10 { }

    private interface Interface6 { }
    protected interface Interface7 { }
    internal protected interface Interface8 { }
    internal interface Interface9 { }
    public interface Interface10 { }

    private enum Enum6 { }
    protected enum Enum7 { }
    internal protected enum Enum8 { }
    internal enum Enum9 { }
    public enum Enum10 { }

    private delegate void Delegate6();
    protected delegate void Delegate7();
    internal protected delegate void Delegate8();
    internal delegate void Delegate9();
    public delegate void Delegate10();
}

#region Whatever whatever generated code
namespace GeneratedCodeElementOrder3
{
    // Things in the correct order:
    public delegate void Delegate11();
    internal delegate void Delegate12();
    internal protected delegate void Delegate13();
    protected delegate void Delegate14();
    private delegate void Delegate15();

    public enum Enum11 { }
    internal enum Enum12 { }
    internal protected enum Enum13 { }
    protected enum Enum14 { }
    private enum Enum15 { }

    public interface Interface11 { }
    internal interface Interface12 { }
    internal protected interface Interface13 { }
    protected interface Interface14 { }
    private interface Interface15 { }

    public struct Struct11 { }
    internal struct Struct12 { }
    internal protected struct Struct13 { }
    protected struct Struct14 { }
    private struct Struct15 { }

    public class Class11 { }
    internal class Class12 { }
    internal protected class Class13 { }
    protected class Class14 { }
    private class Class15 { }
}

namespace GeneratedCodeElementOrder4
{
    // Things in incorrect order:
    private class Class16 { }
    protected class Class17 { }
    internal protected class Class18 { }
    internal class Class19 { }
    public class Class20 { }

    private struct Struct16 { }
    protected struct Struct17 { }
    internal protected struct Struct18 { }
    internal struct Struct19 { }
    public struct Struct20 { }

    private interface Interface16 { }
    protected interface Interface17 { }
    internal protected interface Interface18 { }
    internal interface Interface19 { }
    public interface Interface20 { }

    private enum Enum16 { }
    protected enum Enum17 { }
    internal protected enum Enum18 { }
    internal enum Enum19 { }
    public enum Enum20 { }

    private delegate void Delegate16();
    protected delegate void Delegate17();
    internal protected delegate void Delegate18();
    internal delegate void Delegate19();
    public delegate void Delegate20();
}
#endregion

namespace GeneratedCodeElementOrder5
{
    // Things in the correct order:
    public delegate void Delegate21();
    internal delegate void Delegate22();
    internal protected delegate void Delegate23();
    protected delegate void Delegate24();
    private delegate void Delegate25();

    public enum Enum21 { }
    internal enum Enum22 { }
    internal protected enum Enum23 { }
    protected enum Enum24 { }
    private enum Enum25 { }

    public interface Interface21 { }
    internal interface Interface22 { }
    internal protected interface Interface23 { }
    protected interface Interface24 { }
    private interface Interface25 { }

    public struct Struct21 { }
    internal struct Struct22 { }
    internal protected struct Struct23 { }
    protected struct Struct24 { }
    private struct Struct25 { }

    public class Class21 { }
    internal class Class22 { }
    internal protected class Class23 { }
    protected class Class24 { }
    private class Class25 { }
}

namespace GeneratedCodeElementOrder6
{
    // Things in incorrect order:
    private class Class26 { }
    protected class Class27 { }
    internal protected class Class28 { }
    internal class Class29 { }
    public class Class30 { }

    private struct Struct26 { }
    protected struct Struct27 { }
    internal protected struct Struct28 { }
    internal struct Struct29 { }
    public struct Struct30 { }

    private interface Interface26 { }
    protected interface Interface27 { }
    internal protected interface Interface28 { }
    internal interface Interface29 { }
    public interface Interface30 { }

    private enum Enum26 { }
    protected enum Enum27 { }
    internal protected enum Enum28 { }
    internal enum Enum29 { }
    public enum Enum30 { }

    private delegate void Delegate26();
    protected delegate void Delegate27();
    internal protected delegate void Delegate28();
    internal delegate void Delegate29();
    public delegate void Delegate30();
}

namespace GeneratedCodeElementOrder7
{
    // Things in incorrect order:
    #region Whatever generated code
    private class Class16 { }
    #endregion
    public class Class20 { }

    protected struct Struct17 { }
    #region Whatever generated code
    internal protected struct Struct18 { }
    #endregion 

    private interface Interface16 { }
    #region Whatever generated code
    internal protected interface Interface18 { }
    internal interface Interface19 { }
    #endregion

    #region Whatever generated code
    private enum Enum16 { }
    protected enum Enum17 { }
    #endregion Whatever generated code
    public enum Enum20 { }

    #region Whatever generated code
    protected delegate void Delegate17();
    #endregion
    internal delegate void Delegate19();
    public delegate void Delegate20();
}
