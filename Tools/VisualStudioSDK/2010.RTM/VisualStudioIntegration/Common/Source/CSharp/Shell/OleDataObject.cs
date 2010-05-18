//------------------------------------------------------------------------------
// <copyright file="VsToolboxService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

using Microsoft.VisualStudio.Shell.Ole2Bcl;
using System;
using WinForms = System.Windows.Forms;

using IOleDataObject = Microsoft.VisualStudio.OLE.Interop.IDataObject;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;
using IDataObject = System.Windows.Forms.IDataObject;

namespace Microsoft.VisualStudio.Shell
{
    /// <include file='doc\OleDataObject.uex' path='docs/doc[@for=OleDataObject]/*' />
    [CLSCompliant(false)]
    public class OleDataObject : WinForms.DataObject, IOleDataObject
    {
        private IOleDataObject oleData;

        /// <include file='doc\OleDataObject.uex' path='docs/doc[@for=OleDataObject.OleDataObject]/*' />
        public OleDataObject() 
        {
            oleData = (IOleDataObject)(new Ole2BclDataObject(this as IComDataObject));
        }

        /// <include file='doc\OleDataObject.uex' path='docs/doc[@for=OleDataObject.OleDataObject1]/*' />
        public OleDataObject(IDataObject winData) :
            base (winData)
        {
            this.oleData = winData as IOleDataObject;
            if (null == this.oleData)
                oleData = (IOleDataObject)(new Ole2BclDataObject(this as IComDataObject));
        }

        /// <include file='doc\OleDataObject.uex' path='docs/doc[@for=OleDataObject.OleDataObject2]/*' />
        public OleDataObject(IComDataObject comData) :
            base(comData)
        {
            oleData = comData as IOleDataObject;
            if (null == oleData)
                this.oleData = (IOleDataObject)(new Ole2BclDataObject(comData));
        }

        /// <include file='doc\OleDataObject.uex' path='docs/doc[@for=OleDataObject.OleDataObject3]/*' />
        public OleDataObject(IOleDataObject oleData) :
            base( (oleData is IComDataObject) ? (IComDataObject)oleData : (IComDataObject)(new Ole2BclDataObject(oleData)) )
        {
            this.oleData = oleData;
        }

        #region IOleDataObject Members

        int IOleDataObject.DAdvise(Microsoft.VisualStudio.OLE.Interop.FORMATETC[] pFormatetc, uint ADVF, Microsoft.VisualStudio.OLE.Interop.IAdviseSink pAdvSink, out uint pdwConnection)
        {
            return oleData.DAdvise(pFormatetc, ADVF, pAdvSink, out pdwConnection);
        }

        void IOleDataObject.DUnadvise(uint dwConnection)
        {
            oleData.DUnadvise(dwConnection);
        }

        int IOleDataObject.EnumDAdvise(out Microsoft.VisualStudio.OLE.Interop.IEnumSTATDATA ppenumAdvise)
        {
            return oleData.EnumDAdvise(out ppenumAdvise);
        }

        int IOleDataObject.EnumFormatEtc(uint dwDirection, out Microsoft.VisualStudio.OLE.Interop.IEnumFORMATETC ppenumFormatEtc)
        {
            return oleData.EnumFormatEtc(dwDirection, out ppenumFormatEtc);
        }

        int IOleDataObject.GetCanonicalFormatEtc(Microsoft.VisualStudio.OLE.Interop.FORMATETC[] pformatectIn, Microsoft.VisualStudio.OLE.Interop.FORMATETC[] pformatetcOut)
        {
            return oleData.GetCanonicalFormatEtc(pformatectIn, pformatetcOut);
        }

        void IOleDataObject.GetData(Microsoft.VisualStudio.OLE.Interop.FORMATETC[] pformatetcIn, Microsoft.VisualStudio.OLE.Interop.STGMEDIUM[] pRemoteMedium)
        {
            oleData.GetData(pformatetcIn, pRemoteMedium);
        }

        void IOleDataObject.GetDataHere(Microsoft.VisualStudio.OLE.Interop.FORMATETC[] pFormatetc, Microsoft.VisualStudio.OLE.Interop.STGMEDIUM[] pRemoteMedium)
        {
            oleData.GetDataHere(pFormatetc, pRemoteMedium);
        }

        int IOleDataObject.QueryGetData(Microsoft.VisualStudio.OLE.Interop.FORMATETC[] pFormatetc)
        {
            return oleData.QueryGetData(pFormatetc);
        }

        void IOleDataObject.SetData(Microsoft.VisualStudio.OLE.Interop.FORMATETC[] pFormatetc, Microsoft.VisualStudio.OLE.Interop.STGMEDIUM[] pmedium, int fRelease)
        {
            oleData.SetData(pFormatetc, pmedium, fRelease);
        }

        #endregion
    }
}
