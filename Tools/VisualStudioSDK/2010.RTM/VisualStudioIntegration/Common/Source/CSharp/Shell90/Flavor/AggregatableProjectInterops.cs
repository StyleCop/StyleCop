/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

namespace Microsoft.VisualStudio.Shell.Flavor
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.OLE.Interop;

    // We need to define a corrected version of the IA for this interface so that IUnknown pointers are passed
    // as "IntPtr" instead of "object". This ensures that we get the actual IUnknown pointer and not a wrapped
    // managed proxy pointer.
    [ComImport]
    [Guid("ffb2e715-7312-4b93-83d7-d37bcc561c90")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [CLSCompliant(false)]
    public interface IVsAggregatableProjectCorrected
    {
        [PreserveSig]
        int SetInnerProject(IntPtr punkInnerIUnknown);
        [PreserveSig]
        int InitializeForOuter([MarshalAs(UnmanagedType.LPWStr)]string pszFilename, 
                               [MarshalAs(UnmanagedType.LPWStr)]string pszLocation, 
                               [MarshalAs(UnmanagedType.LPWStr)]string pszName, 
                               uint grfCreateFlags, ref Guid iidProject, out IntPtr ppvProject, out int pfCanceled);
        [PreserveSig]
        int OnAggregationComplete();
        [PreserveSig]
        int GetAggregateProjectTypeGuids([MarshalAs(UnmanagedType.BStr)]out string pbstrProjTypeGuids);
        [PreserveSig]
        int SetAggregateProjectTypeGuids([MarshalAs(UnmanagedType.LPWStr)]string lpstrProjTypeGuids);
    }

    // We need to define a corrected version of the IA for this interface so that IUnknown pointers are passed
    // as "IntPtr" instead of "object". This ensures that we get the actual IUnknown pointer and not a wrapped
    // managed proxy pointer.
    [ComImport()]
    [Guid("6d5140d3-7436-11ce-8034-00aa006009fa")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [CLSCompliant(false)]
    public interface ILocalRegistryCorrected
    {
        [PreserveSig]
        int CreateInstance(Guid clsid, IntPtr punkOuterIUnknown, ref Guid riid, uint dwFlags, out IntPtr ppvObj);
        [PreserveSig]
        int GetClassObjectOfClsid(ref Guid clsid, uint dwFlags, IntPtr lpReserved, ref Guid riid, out IntPtr ppvClassObject);
        [PreserveSig]
        int GetTypeLibOfClsid(Guid clsid, out ITypeLib pptLib);
    }

    // We need to define a corrected version of the IA for this interface so that IUnknown pointers are passed
    // as "IntPtr" instead of "object". This ensures that we get the actual IUnknown pointer and not a wrapped
    // managed proxy pointer.
    [ComImport]
    [Guid("44569501-2ad0-4966-9bac-12b799a1ced6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVsAggregatableProjectFactoryCorrected
    {
        [PreserveSig]
        int GetAggregateProjectType([MarshalAs(UnmanagedType.LPWStr)]string fileName, [MarshalAs(UnmanagedType.BStr)]out string projectTypeGuid);
        [PreserveSig]
        int PreCreateForOuter(IntPtr outerProjectIUnknown, out IntPtr projectIUnknown);
    }

    [ComImport]
    [Guid("D6CEA324-8E81-4e0e-91DE-E5D7394A45CE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IVsProjectAggregator2
    {
        #region IVsProjectAggregator2 Members

        [PreserveSig]
        int SetInner(IntPtr innerIUnknown);
        [PreserveSig]
        int SetMyProject(IntPtr projectIUnknown);

        #endregion
    }
}
