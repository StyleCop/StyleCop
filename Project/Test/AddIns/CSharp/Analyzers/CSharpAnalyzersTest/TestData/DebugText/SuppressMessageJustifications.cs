namespace SuppressMessageJustifications
{
    using System.Diagnostics.CodeAnalysis;

    #region Valid Justifications

    [SuppressMessage("x", "y", Justification = "This is the justification")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
    public class Class1
    {
        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public int field1;

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public Class1()
        {
        }

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public delegate int Delegate1();

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public event EventHandler Event1;

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public enum Enum1
        {
        }

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public int this[int x]
        {
            get { return 1; }
        }

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public int Property1
        {
            get { return 1; }
        }

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public void Method1()
        {
        }

        [SuppressMessage("x", "y", Justification = "This is the justification")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "This is the justification")]
        public struct Struct1
        {
        }
    }

    #endregion Valid Justifications

    #region Invalid Justifications

    [SuppressMessage("x", "y")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
    [SuppressMessage("x", "y", Justification = "")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
    [System . Diagnostics . 
        CodeAnalysis
        . SuppressMessage("x", "y")]
    public class Class2
    {
        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public int field1;

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public Class2()
        {
        }

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public delegate int Delegate1();

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public event EventHandler Event1;

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public enum Enum1
        {
        }

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public int this[int x]
        {
            get { return 1; }
        }

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public int Property1
        {
            get { return 1; }
        }

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public void Method1()
        {
        }

        [SuppressMessage("x", "y")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y")]
        [SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("x", "y", Justification = "")]
        [System.Diagnostics.
            CodeAnalysis
            .SuppressMessage("x", "y")]
        public struct Struct1
        {
        }
    }

    #endregion Valid Justifications
}