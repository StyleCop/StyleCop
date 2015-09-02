namespace Foo
{
    using System.Runtime.InteropServices;
    using System.ComponentModel;
    using System.Diagnostics;
    using System;
    using System.Threading;
    using System.IO;
    using System.ServiceProcess;
    using System.Reflection;
    using System.Security;
    using System.Security.Permissions;
    using System.Globalization;

    internal abstract class Foo
    {

        #region Windows Form Designer generated code
        [ComVisible(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public unsafe void ServiceMainCallback(int argCount, IntPtr argPointer)
        {
            fixed (NativeMethods.SERVICE_STATUS* pStatus = &status)
            {
                string[] args = null;

                if (argCount > 0)
                {
                    char** argsAsPtr = (char**)argPointer.ToPointer();
                }
            }
        }

        #endregion
    }
}

