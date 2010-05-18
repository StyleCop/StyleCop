namespace DebugAssertMessages
{
    using System.Diagnostics;

    #region Valid Asserts

    public class Class1
    {
        public void Method1()
        {
            Debug.Assert(true, "Message");
            Debug.Assert(true, "Message", "DetailedMessage");
            System.Diagnostics.Debug.Assert(true, "Message");
            System.Diagnostics.Debug.Assert(true, "Message", "DetailedMessage");
            Debug.Assert(true, 1);
            Debug.Assert(true, 1, "DetailedMessage");
            System.Diagnostics.Debug.Assert(true, 1);
            System.Diagnostics.Debug.Assert(true, 1, "DetailedMessage");

            Debug.Fail(1);
            Debug.Fail(1, "DetailedMessage");
            System.Diagnostics.Debug.Fail(1);
            System.Diagnostics.Debug.Fail(1, "DetailedMessage");
        }
    }

    #endregion Valid Asserts

    #region Invalid Asserts

    public class Class2
    {
        public void Method1()
        {
            Debug.Assert(true);
            Debug.Assert(true, "");
            Debug.Assert(true, @"");
            System.Diagnostics.Debug.Assert(true);
            System.Diagnostics.Debug.Assert(true, "");
            System.Diagnostics.Debug.Assert(true, @"");

            Debug.Fail();
            Debug.Fail("");
            Debug.Fail(@"");
            System.Diagnostics.Debug.Fail();
            System.Diagnostics.Debug.Fail("");
            System.Diagnostics.Debug.Fail(@"");
        }
    }

    #endregion Invalid Asserts
}