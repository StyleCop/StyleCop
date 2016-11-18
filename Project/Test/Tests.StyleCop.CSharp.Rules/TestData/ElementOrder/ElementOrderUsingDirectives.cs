// The following should throw violations because they are outside of the namespace.
using System;
using Thread = System.Threading.Thread;

namespace ElementOrderUsingDirectivesNamespace1
{
    // The following should not throw violations as they are inside of a namespace.
    using System.Diagnostics;
    using ThreadException = System.Threading.ThreadAbortException;
}

namespace ElementOrderUsingDirectivesNamespace2
{
    // The following should not throw violations as they are inside of a namespace.
    using System.Globalization;
    using ThreadException2 = System.Threading.ThreadInterruptedException;
}