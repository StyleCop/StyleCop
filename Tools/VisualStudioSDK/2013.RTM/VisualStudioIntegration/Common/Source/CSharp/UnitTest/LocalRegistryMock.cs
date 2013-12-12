/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using Microsoft.VisualStudio.Shell.Interop;

namespace Microsoft.VsSDK.UnitTestLibrary
{
    [CLSCompliant(false)]
    public class LocalRegistryMock : ILocalRegistry, ILocalRegistry2, ILocalRegistry3
    {
        private Dictionary<Guid, object> objectsList;
        private string registryRoot;

        public LocalRegistryMock()
        {
            objectsList = new Dictionary<Guid, object>();
        }
        public void AddClass(Type classType, object instance)
        {
            if (objectsList.ContainsKey(classType.GUID))
            {
                objectsList.Remove(classType.GUID);
            }
            objectsList.Add(classType.GUID, instance);
        }
        public string RegistryRoot
        {
            get { return registryRoot; }
            set { registryRoot = value; }
        }

        public int CreateInstance(Guid clsid, object punkOuter, ref Guid riid, uint dwFlags, out IntPtr ppvObj)
        {
            ppvObj = IntPtr.Zero;
            if (!objectsList.ContainsKey(clsid))
            {
                return Microsoft.VisualStudio.VSConstants.E_NOINTERFACE;
            }
            object obj = objectsList[clsid];
            ppvObj = System.Runtime.InteropServices.Marshal.GetIUnknownForObject(obj);
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public int CreateManagedInstance(string codeBase, string assemblyName, string typeName, ref Guid riid, out IntPtr ppvObj)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public virtual int GetClassObjectOfClsid(ref Guid clsid, uint dwFlags, IntPtr lpReserved, ref Guid riid, out IntPtr ppvClassObject)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public int GetClassObjectOfClsid(ref Guid clsid, uint dwFlags, IntPtr lpReserved, ref Guid riid, IntPtr ppvClassObject)
        {
            return ((ILocalRegistry)this).GetClassObjectOfClsid(ref clsid, dwFlags, lpReserved, ref riid, out ppvClassObject);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public int GetClassObjectOfManagedClass(string codeBase, string assemblyName, string typeName, ref Guid riid, out IntPtr ppvClassObject)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        public int GetLocalRegistryRoot(out string pbstrRoot)
        {
            pbstrRoot = registryRoot;
            return Microsoft.VisualStudio.VSConstants.S_OK;
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public virtual int GetTypeLibOfClsid(Guid clsid, out Microsoft.VisualStudio.OLE.Interop.ITypeLib pptLib)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }
    }
}
