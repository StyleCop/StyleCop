using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace CSharpAnalyzersTest.TestData.Documentation
{
    /// <summary>
    /// Some class header.
    /// </summary>
    public class DocumentationExternDllImports
    {
        // Does not require a header.
        [DllImport("kernel32.dll")]
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Does not require a header.
        [DllImportAttribute("kernel32.dll")]
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Does not require a header.
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Does not require a header.
        [System.Runtime.InteropServices.DllImportAttribute("kernel32.dll")]
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Does not require a header.
        [SomeOtherAttribute1]
        [SomeOtherAttribute2, DllImport("kernel32.dll")]
        [SomeOtherAttribute3]
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Does require a header because it is public.
        [DllImport("kernel32.dll")]
        public static extern Boolean FreeLibrary(IntPtr lib);

        // Does require a header because it is not static.
        [DllImport("kernel32.dll")]
        internal extern Boolean FreeLibrary(IntPtr lib);

        // Does require a header because it is not extern.
        [DllImport("kernel32.dll")]
        internal static Boolean FreeLibrary(IntPtr lib);

        // Does require a header because it does not contain a DllImport attribute.
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Does require a header because it does not contain a DllImport attribute.
        [DllImpor3t("kernel32.dll")]
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Requires a header and has a valid header.
        /// <summary>
        /// Some header.
        /// </summary>
        /// <param name="lib">Some parameter data..</param>
        /// <returns>Some return value.</returns>
        [DllImpor3t("kernel32.dll")]
        internal static extern Boolean FreeLibrary(IntPtr lib);

        // Does not require a header, but still has a valid header.
        /// <summary>
        /// Some header.
        /// </summary>
        /// <param name="lib">Some parameter data..</param>
        /// <returns>Some return value.</returns>
        [DllImpor3t("kernel32.dll")]
        internal static extern Boolean FreeLibrary(IntPtr lib);
    }
}
