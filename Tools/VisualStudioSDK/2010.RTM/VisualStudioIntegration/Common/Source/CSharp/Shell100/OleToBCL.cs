//------------------------------------------------------------------------------
// <copyright file="VsToolboxService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;

using OleInterop = Microsoft.VisualStudio.OLE.Interop;
using BclComTypes = System.Runtime.InteropServices.ComTypes;

using IOleAdviseSink = Microsoft.VisualStudio.OLE.Interop.IAdviseSink;
using IBclAdviseSink = System.Runtime.InteropServices.ComTypes.IAdviseSink;

namespace Microsoft.VisualStudio.Shell.Ole2Bcl
{
    internal sealed class StructConverter
    {
        // Private constructor to avoid creation of instances of this class
        private StructConverter() { }

        ///////////////////////////////////////////////////////////////////////////////////
        // FORMATETC
        static internal OleInterop.FORMATETC BclFormatETC2Ole(ref BclComTypes.FORMATETC bclFormat)
        {
            OleInterop.FORMATETC oleFormat;
            oleFormat.cfFormat = (ushort)bclFormat.cfFormat;
            oleFormat.dwAspect = (uint)bclFormat.dwAspect;
            oleFormat.lindex = bclFormat.lindex;
            oleFormat.ptd = bclFormat.ptd;
            oleFormat.tymed = (uint)bclFormat.tymed;
            return oleFormat;
        }
        static internal BclComTypes.FORMATETC OleFormatETC2Bcl(ref OleInterop.FORMATETC oleFormat)
        {
            BclComTypes.FORMATETC bclFormat;
            bclFormat.cfFormat = (short)oleFormat.cfFormat;
            bclFormat.dwAspect = (BclComTypes.DVASPECT)oleFormat.dwAspect;
            bclFormat.lindex = oleFormat.lindex;
            bclFormat.ptd = oleFormat.ptd;
            bclFormat.tymed = (BclComTypes.TYMED)oleFormat.tymed;
            return bclFormat;
        }
        //                                                                       FORMATETC
        ///////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        // STGMEDIUM
        static internal OleInterop.STGMEDIUM BclSTGMEDIUM2Ole(ref BclComTypes.STGMEDIUM bclMedium)
        {
            OleInterop.STGMEDIUM oleMedium;
            oleMedium.pUnkForRelease = bclMedium.pUnkForRelease;
            oleMedium.tymed = (uint)bclMedium.tymed;
            oleMedium.unionmember = bclMedium.unionmember;
            return oleMedium;
        }
        static internal BclComTypes.STGMEDIUM OleSTGMEDIUM2Bcl(ref OleInterop.STGMEDIUM oleMedium)
        {
            BclComTypes.STGMEDIUM bclMedium;
            bclMedium.pUnkForRelease = oleMedium.pUnkForRelease;
            bclMedium.tymed = (BclComTypes.TYMED)oleMedium.tymed;
            bclMedium.unionmember = oleMedium.unionmember;
            return bclMedium;
        }
        //                                                                      STGMEDIUM
        ///////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////
        // STATDATA
        static internal OleInterop.STATDATA BclSTATDATA2Ole(ref BclComTypes.STATDATA bclData)
        {
            OleInterop.STATDATA oleData;
            if (null == bclData.advSink)
            {
                oleData.pAdvSink = null;
            }
            else
            {
                oleData.pAdvSink = bclData.advSink as OleInterop.IAdviseSink;
                if (null == oleData.pAdvSink)
                    oleData.pAdvSink = (new AdviseSink(bclData.advSink));
            }
            oleData.ADVF = (uint)bclData.advf;
            oleData.dwConnection = (uint)bclData.connection;
            oleData.FORMATETC = BclFormatETC2Ole(ref bclData.formatetc);
            return oleData;
        }
        static internal BclComTypes.STATDATA OleSTATDATA2Bcl(ref OleInterop.STATDATA oleData)
        {
            BclComTypes.STATDATA bclData;
            if (null == oleData.pAdvSink)
            {
                bclData.advSink = null;
            }
            else
            {
                bclData.advSink = oleData.pAdvSink as BclComTypes.IAdviseSink;
                if (null == bclData.advSink)
                    bclData.advSink = (BclComTypes.IAdviseSink)(new AdviseSink(oleData.pAdvSink));
            }
            bclData.advf = (BclComTypes.ADVF)oleData.ADVF;
            bclData.connection = (int)oleData.dwConnection;
            bclData.formatetc = OleFormatETC2Bcl(ref oleData.FORMATETC);
            return bclData;
        }
        //                                                                        STATDATA
        ///////////////////////////////////////////////////////////////////////////////////
    }

    internal sealed class AdviseSink : IOleAdviseSink, IBclAdviseSink
    {
        private IOleAdviseSink oleSink;
        private IBclAdviseSink bclSink;

        // This class in a converter and it doesn't make sense to build it
        // without an interface to convert, so we make the default constructor
        // private to avoid that the compiler build a public one for us.
        private AdviseSink()
        {
        }

        internal AdviseSink(IOleAdviseSink oleSink)
        {
            if (null == oleSink)
                throw new ArgumentNullException("Microsoft.VisualStudio.OLE.Interop.IAdviseSink");
            this.oleSink = oleSink;
            this.bclSink = oleSink as IBclAdviseSink;
        }

        internal AdviseSink(IBclAdviseSink bclSink)
        {
            if (null == bclSink)
                throw new ArgumentNullException("System.Runtime.InteropServices.ComTypes.IAdviseSink");
            this.oleSink = bclSink as IOleAdviseSink;
            this.bclSink = bclSink;
        }

        //////////////////////////////////////////////////////////////
        // OnClose
        //
        void IOleAdviseSink.OnClose()
        {
            if (null != oleSink)
            {
                oleSink.OnClose();
            }
            else
            {
                bclSink.OnClose();
            }
        }
        void IBclAdviseSink.OnClose()
        {
            ((IOleAdviseSink)this).OnClose();
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // OnDataChange
        //
        void IOleAdviseSink.OnDataChange(OleInterop.FORMATETC[] pFormatetc, OleInterop.STGMEDIUM[] pStgmed)
        {
            if (null != oleSink)
            {
                oleSink.OnDataChange(pFormatetc, pStgmed);
            }
            else
            {
                // In order to call the version of this interface defined in the BCL
                // each array must contain exactly one object.
                if ((null == pFormatetc) || (null == pStgmed))
                    throw new ArgumentNullException("");
                if ((1 != pFormatetc.Length) || (1 != pStgmed.Length))
                    throw new InvalidOperationException();

                // Convert the parameters
                BclComTypes.FORMATETC bclFormat = StructConverter.OleFormatETC2Bcl(ref pFormatetc[0]);
                BclComTypes.STGMEDIUM bclMedium = StructConverter.OleSTGMEDIUM2Bcl(ref pStgmed[0]);

                // Now we can call the method on the BCL interface
                bclSink.OnDataChange(ref bclFormat, ref bclMedium);

                // Now we have to copy the parameters back into the original structures.
                pFormatetc[0] = StructConverter.BclFormatETC2Ole(ref bclFormat);
                pStgmed[0] = StructConverter.BclSTGMEDIUM2Ole(ref bclMedium);
            }
        }
        void IBclAdviseSink.OnDataChange(ref BclComTypes.FORMATETC format, ref BclComTypes.STGMEDIUM stgmedium)
        {
            if (null != bclSink)
            {
                bclSink.OnDataChange(ref format, ref stgmedium);
            }
            else
            {
                // As in the previous case we have to copy the parameters.
                OleInterop.FORMATETC[] pFormatetc = new OleInterop.FORMATETC[1];
                pFormatetc[0] = StructConverter.BclFormatETC2Ole(ref format);

                OleInterop.STGMEDIUM[] pStgmed = new OleInterop.STGMEDIUM[1];
                pStgmed[0] = StructConverter.BclSTGMEDIUM2Ole(ref stgmedium);

                // Call the original interface.
                oleSink.OnDataChange(pFormatetc, pStgmed);
            }
        }
        //
        //////////////////////////////////////////////////////////////

        void IOleAdviseSink.OnRename(OleInterop.IMoniker pmk)
        {
            if (null != oleSink)
            {
                oleSink.OnRename(pmk);
            }
            else
            {
                // TODO: Use the IMoniker converter when ready.
                bclSink.OnRename(null);
            }
        }
        void IBclAdviseSink.OnRename(BclComTypes.IMoniker moniker)
        {
            if (null != bclSink)
            {
                bclSink.OnRename(moniker);
            }
            else
            {
                // TODO: Use the IMoniker converter when ready.
                oleSink.OnRename(null);
            }
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // OnSave
        //
        void IOleAdviseSink.OnSave()
        {
            if (null != oleSink)
            {
                oleSink.OnSave();
            }
            else
            {
                bclSink.OnSave();
            }
        }
        void IBclAdviseSink.OnSave()
        {
            ((IOleAdviseSink)this).OnSave();
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // OnViewChange
        //
        void IOleAdviseSink.OnViewChange(uint aspect, int index)
        {
            if (null != oleSink)
            {
                oleSink.OnViewChange(aspect, index);
            }
            else
            {
                bclSink.OnViewChange((int)aspect, index);
            }
        }
        void IBclAdviseSink.OnViewChange(int aspect, int index)
        {
            ((IOleAdviseSink)this).OnViewChange((uint)aspect, index);
        }
        //
        //////////////////////////////////////////////////////////////

    }

    internal sealed class EnumSTATDATA : OleInterop.IEnumSTATDATA, BclComTypes.IEnumSTATDATA
    {
        private OleInterop.IEnumSTATDATA oleEnum;
        private BclComTypes.IEnumSTATDATA bclEnum;

        private EnumSTATDATA() { }

        internal EnumSTATDATA(OleInterop.IEnumSTATDATA oleEnum)
        {
            if (null == oleEnum)
                throw new ArgumentNullException("Microsoft.VisualStudio.OLE.Interop.IEnumSTATDATA");
            this.oleEnum = oleEnum;
            this.bclEnum = oleEnum as BclComTypes.IEnumSTATDATA;
        }

        internal EnumSTATDATA(BclComTypes.IEnumSTATDATA bclEnum)
        {
            if (null == bclEnum)
                throw new ArgumentNullException("System.Runtime.InteropServices.ComTypes.IEnumSTATDATA");
            this.oleEnum = bclEnum as OleInterop.IEnumSTATDATA;
            this.bclEnum = bclEnum;
        }

        //////////////////////////////////////////////////////////////
        // Clone
        void OleInterop.IEnumSTATDATA.Clone(out OleInterop.IEnumSTATDATA ppEnum)
        {
            ppEnum = null;
            if (null != oleEnum)
            {
                oleEnum.Clone(out ppEnum);
            }
            else
            {
                BclComTypes.IEnumSTATDATA bclCloned;
                bclEnum.Clone(out bclCloned);
                ppEnum = bclCloned as OleInterop.IEnumSTATDATA;
                if (null == ppEnum)
                    ppEnum = (OleInterop.IEnumSTATDATA)(new EnumSTATDATA(bclCloned));
            }
        }
        void BclComTypes.IEnumSTATDATA.Clone(out BclComTypes.IEnumSTATDATA newEnum)
        {
            newEnum = null;
            if (null != bclEnum)
            {
                bclEnum.Clone(out newEnum);
            }
            else
            {
                OleInterop.IEnumSTATDATA oleCloned;
                oleEnum.Clone(out oleCloned);
                newEnum = oleCloned as BclComTypes.IEnumSTATDATA;
                if (null == newEnum)
                    newEnum = (BclComTypes.IEnumSTATDATA)(new EnumSTATDATA(oleCloned));
            }
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // Next
        int OleInterop.IEnumSTATDATA.Next(uint celt, OleInterop.STATDATA[] rgelt, out uint pceltFetched)
        {
            pceltFetched = 0;
            if (null != oleEnum)
            {
                return oleEnum.Next(celt, rgelt, out pceltFetched);
            }

            BclComTypes.STATDATA[] bclStat = new BclComTypes.STATDATA[celt];
            int[] fetched = { (int)pceltFetched };
            int hr = bclEnum.Next((int)celt, bclStat, fetched);
            if (NativeMethods.Failed(hr))
                return hr;
            pceltFetched = (uint)fetched[0];
            for (int i = 0; i < pceltFetched; i++)
            {
                rgelt[i] = StructConverter.BclSTATDATA2Ole(ref bclStat[i]);
            }
            return hr;
        }
        int BclComTypes.IEnumSTATDATA.Next(int celt, BclComTypes.STATDATA[] rgelt, int[] pceltFetched)
        {
            if (null != bclEnum)
            {
                return bclEnum.Next(celt, rgelt, pceltFetched);
            }

            OleInterop.STATDATA[] oleStat = new OleInterop.STATDATA[celt];
            uint fetched;
            int hr = oleEnum.Next((uint)celt, oleStat, out fetched);
            if (NativeMethods.Failed(hr))
                return hr;
            if (null != pceltFetched)
                pceltFetched[0] = (int)fetched;
            for (int i = 0; i < fetched; i++)
            {
                rgelt[i] = StructConverter.OleSTATDATA2Bcl(ref oleStat[i]);
            }
            return hr;
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // Reset
        int OleInterop.IEnumSTATDATA.Reset()
        {
            if (null != oleEnum)
                return oleEnum.Reset();
            return bclEnum.Reset();
        }
        int BclComTypes.IEnumSTATDATA.Reset()
        {
            if (null != bclEnum)
                return bclEnum.Reset();
            return oleEnum.Reset();
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // Skip
        int OleInterop.IEnumSTATDATA.Skip(uint celt)
        {
            if (null != oleEnum)
                return oleEnum.Skip(celt);
            return bclEnum.Skip((int)celt);
        }
        int BclComTypes.IEnumSTATDATA.Skip(int celt)
        {
            if (null != bclEnum)
                return bclEnum.Skip(celt);
            return oleEnum.Skip((uint)celt);
        }
        //
        //////////////////////////////////////////////////////////////
    }

    internal sealed class EnumFORMATETC : OleInterop.IEnumFORMATETC, BclComTypes.IEnumFORMATETC
    {
        private OleInterop.IEnumFORMATETC oleEnum;
        private BclComTypes.IEnumFORMATETC bclEnum;

        private EnumFORMATETC() { }

        internal EnumFORMATETC(OleInterop.IEnumFORMATETC oleEnum)
        {
            if (null == oleEnum)
                throw new ArgumentNullException("Microsoft.VisualStudio.OLE.Interop.IEnumFORMATETC");
            this.oleEnum = oleEnum;
            this.bclEnum = oleEnum as BclComTypes.IEnumFORMATETC;
        }

        internal EnumFORMATETC(BclComTypes.IEnumFORMATETC bclEnum)
        {
            if (null == bclEnum)
                throw new ArgumentNullException("System.Runtime.InteropServices.ComTypes.IEnumFORMATETC");
            this.oleEnum = bclEnum as OleInterop.IEnumFORMATETC;
            this.bclEnum = bclEnum;
        }

        //////////////////////////////////////////////////////////////
        // Clone
        void OleInterop.IEnumFORMATETC.Clone(out OleInterop.IEnumFORMATETC ppEnum)
        {
            ppEnum = null;
            if (null != oleEnum)
            {
                oleEnum.Clone(out ppEnum);
            }
            else
            {
                BclComTypes.IEnumFORMATETC bclCloned;
                bclEnum.Clone(out bclCloned);
                ppEnum = bclCloned as OleInterop.IEnumFORMATETC;
                if (null == ppEnum)
                    ppEnum = (OleInterop.IEnumFORMATETC)(new EnumFORMATETC(bclCloned));
            }
        }
        void BclComTypes.IEnumFORMATETC.Clone(out BclComTypes.IEnumFORMATETC newEnum)
        {
            newEnum = null;
            if (null != bclEnum)
            {
                bclEnum.Clone(out newEnum);
            }
            else
            {
                OleInterop.IEnumFORMATETC oleCloned;
                oleEnum.Clone(out oleCloned);
                newEnum = oleCloned as BclComTypes.IEnumFORMATETC;
                if (null == newEnum)
                    newEnum = (BclComTypes.IEnumFORMATETC)(new EnumFORMATETC(oleCloned));
            }
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // Next
        int OleInterop.IEnumFORMATETC.Next(uint celt, OleInterop.FORMATETC[] rgelt, uint[] pceltFetched)
        {
            if (null != oleEnum)
            {
                return oleEnum.Next(celt, rgelt, pceltFetched);
            }

            BclComTypes.FORMATETC[] bclStat = new BclComTypes.FORMATETC[celt];
            int[] fetched = new int[1];
            int hr = bclEnum.Next((int)celt, bclStat, fetched);
            if (NativeMethods.Failed(hr))
                return hr;
            if (null != pceltFetched)
                pceltFetched[0] = (uint)fetched[0];
            for (int i = 0; i < fetched[0]; i++)
            {
                rgelt[i] = StructConverter.BclFormatETC2Ole(ref bclStat[i]);
            }
            return hr;
        }
        int BclComTypes.IEnumFORMATETC.Next(int celt, BclComTypes.FORMATETC[] rgelt, int[] pceltFetched)
        {
            if (null != bclEnum)
            {
                return bclEnum.Next(celt, rgelt, pceltFetched);
            }

            OleInterop.FORMATETC[] oleStat = new OleInterop.FORMATETC[celt];
            uint[] fetched = new uint[1];
            int hr = oleEnum.Next((uint)celt, oleStat, fetched);
            if (NativeMethods.Failed(hr))
                return hr;
            if (null != pceltFetched)
                pceltFetched[0] = (int)fetched[0];
            for (uint i = 0; i < fetched[0]; i++)
            {
                rgelt[i] = StructConverter.OleFormatETC2Bcl(ref oleStat[i]);
            }
            return hr;
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // Reset
        int OleInterop.IEnumFORMATETC.Reset()
        {
            if (null != oleEnum)
                return oleEnum.Reset();
            return bclEnum.Reset();
        }
        int BclComTypes.IEnumFORMATETC.Reset()
        {
            if (null != bclEnum)
                return bclEnum.Reset();
            return oleEnum.Reset();
        }
        //
        //////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////
        // Skip
        int OleInterop.IEnumFORMATETC.Skip(uint celt)
        {
            if (null != oleEnum)
                return oleEnum.Skip(celt);
            return bclEnum.Skip((int)celt);
        }
        int BclComTypes.IEnumFORMATETC.Skip(int celt)
        {
            if (null != bclEnum)
                return bclEnum.Skip(celt);
            return oleEnum.Skip((uint)celt);
        }
        //
        //////////////////////////////////////////////////////////////
    }

    internal sealed class Ole2BclDataObject : OleInterop.IDataObject, BclComTypes.IDataObject
    {
        private OleInterop.IDataObject oleData;
        private BclComTypes.IDataObject bclData;

        // Private default constructor: it is not allow to build instances of this class without
        // providing an interface to convert.
        private Ole2BclDataObject() { }

        internal Ole2BclDataObject(OleInterop.IDataObject oleData)
        {
            if (null == oleData)
                throw new ArgumentNullException("Microsoft.VisualStudio.OLE.Interop.IDataObject");
            this.oleData = oleData;
            //this.bclData = oleData as BclComTypes.IDataObject;
            this.bclData = null;
        }

        internal Ole2BclDataObject(BclComTypes.IDataObject bclData)
        {
            if (null == bclData)
                throw new ArgumentNullException("System.Runtime.InteropServices.ComTypes.IDataObject");
            //this.oleData = bclData as OleInterop.IDataObject;
            this.oleData = null;
            this.bclData = bclData;
        }

        #region OleInterop.IDataObject Members

        int OleInterop.IDataObject.DAdvise(OleInterop.FORMATETC[] pFormatetc, uint ADVF, OleInterop.IAdviseSink pAdvSink, out uint pdwConnection)
        {
            if (null != oleData)
                return oleData.DAdvise(pFormatetc, ADVF, pAdvSink, out pdwConnection);

            // We have to call the method in the BCL version of the interface, so we need to
            // convert the parameters to the other type of structure.

            // As first make sure that the array contains exactly one element.
            if ((null == pFormatetc) || (pFormatetc.Length != 1))
                throw new ArgumentException();

            // Now convert the patameters
            BclComTypes.FORMATETC bclFormat = StructConverter.OleFormatETC2Bcl(ref pFormatetc[0]);
            BclComTypes.IAdviseSink bclSink = pAdvSink as BclComTypes.IAdviseSink;
            if (null == bclSink)
                bclSink = new AdviseSink(pAdvSink);

            int connection;
            int hr = bclData.DAdvise(ref bclFormat, (BclComTypes.ADVF)(ADVF), bclSink, out connection);
            pdwConnection = (uint)connection;
            return hr;
        }

        void OleInterop.IDataObject.DUnadvise(uint dwConnection)
        {
            if (null != oleData)
                oleData.DUnadvise(dwConnection);
            else
                bclData.DUnadvise((int)dwConnection);
        }

        int OleInterop.IDataObject.EnumDAdvise(out OleInterop.IEnumSTATDATA ppenumAdvise)
        {
            if (null != oleData)
                return oleData.EnumDAdvise(out ppenumAdvise);

            // Call the BCL version of the method
            BclComTypes.IEnumSTATDATA bclEnum;
            int hr = bclData.EnumDAdvise(out bclEnum);
            NativeMethods.ThrowOnFailure(hr);
            if (null == bclEnum)
            {
                ppenumAdvise = null;
            }
            else
            {
                ppenumAdvise = bclEnum as OleInterop.IEnumSTATDATA;
                if (null == ppenumAdvise)
                    ppenumAdvise = (OleInterop.IEnumSTATDATA)(new EnumSTATDATA(bclEnum));
            }
            return hr;
        }

        int OleInterop.IDataObject.EnumFormatEtc(uint dwDirection, out OleInterop.IEnumFORMATETC ppenumFormatEtc)
        {
            if (null != oleData)
                return oleData.EnumFormatEtc(dwDirection, out ppenumFormatEtc);

            BclComTypes.IEnumFORMATETC bclEnum = bclData.EnumFormatEtc((BclComTypes.DATADIR)dwDirection);
            if (null == bclEnum)
            {
                ppenumFormatEtc = null;
            }
            else
            {
                ppenumFormatEtc = bclEnum as OleInterop.IEnumFORMATETC;
                if (null == ppenumFormatEtc)
                    ppenumFormatEtc = (OleInterop.IEnumFORMATETC)(new EnumFORMATETC(bclEnum));
            }
            return NativeMethods.S_OK;
        }

        int OleInterop.IDataObject.GetCanonicalFormatEtc(OleInterop.FORMATETC[] pformatectIn, OleInterop.FORMATETC[] pformatetcOut)
        {
            if (null != oleData)
                return oleData.GetCanonicalFormatEtc(pformatectIn, pformatetcOut);

            // Check that the arrays are not null and with only one element.
            if ((null == pformatectIn) || (pformatectIn.Length != 1) ||
                 (null == pformatetcOut) || (pformatetcOut.Length != 1))
                throw new ArgumentException();

            BclComTypes.FORMATETC bclFormatIn = StructConverter.OleFormatETC2Bcl(ref pformatectIn[0]);
            BclComTypes.FORMATETC bclFormatOut;
            int hr = bclData.GetCanonicalFormatEtc(ref bclFormatIn, out bclFormatOut);
            NativeMethods.ThrowOnFailure(hr);
            pformatetcOut[0] = StructConverter.BclFormatETC2Ole(ref bclFormatOut);
            return hr;
        }

        void OleInterop.IDataObject.GetData(OleInterop.FORMATETC[] pformatetcIn, OleInterop.STGMEDIUM[] pRemoteMedium)
        {
            if (null != oleData)
            {
                oleData.GetData(pformatetcIn, pRemoteMedium);
                return;
            }

            // Check that the arrays are not null and with only one element.
            if ((null == pformatetcIn) || (pformatetcIn.Length != 1) ||
                 (null == pRemoteMedium) || (pRemoteMedium.Length != 1))
                throw new ArgumentException();

            // Call the method on the BCL interface
            BclComTypes.FORMATETC bclFormat = StructConverter.OleFormatETC2Bcl(ref pformatetcIn[0]);
            BclComTypes.STGMEDIUM bclMedium;
            bclData.GetData(ref bclFormat, out bclMedium);
            pRemoteMedium[0] = StructConverter.BclSTGMEDIUM2Ole(ref bclMedium);
        }

        void OleInterop.IDataObject.GetDataHere(OleInterop.FORMATETC[] pFormatetc, OleInterop.STGMEDIUM[] pRemoteMedium)
        {
            if (null != oleData)
            {
                oleData.GetDataHere(pFormatetc, pRemoteMedium);
                return;
            }

            // Check that the arrays are not null and with only one element.
            if ((null == pFormatetc) || (pFormatetc.Length != 1) ||
                 (null == pRemoteMedium) || (pRemoteMedium.Length != 1))
                throw new ArgumentException();

            // Call the method on the BCL interface
            BclComTypes.FORMATETC bclFormat = StructConverter.OleFormatETC2Bcl(ref pFormatetc[0]);
            BclComTypes.STGMEDIUM bclMedium = StructConverter.OleSTGMEDIUM2Bcl(ref pRemoteMedium[0]);
            bclData.GetDataHere(ref bclFormat, ref bclMedium);
            pRemoteMedium[0] = StructConverter.BclSTGMEDIUM2Ole(ref bclMedium);
        }

        int OleInterop.IDataObject.QueryGetData(OleInterop.FORMATETC[] pFormatetc)
        {
            if (null != oleData)
                return oleData.QueryGetData(pFormatetc);

            if ((null == pFormatetc) || (1 != pFormatetc.Length))
                throw new ArgumentException();

            BclComTypes.FORMATETC bclFormat = StructConverter.OleFormatETC2Bcl(ref pFormatetc[0]);
            return bclData.QueryGetData(ref bclFormat);
        }

        void OleInterop.IDataObject.SetData(OleInterop.FORMATETC[] pFormatetc, OleInterop.STGMEDIUM[] pmedium, int fRelease)
        {
            if (null != oleData)
            {
                oleData.SetData(pFormatetc, pmedium, fRelease);
                return;
            }

            if ((null == pFormatetc) || (1 != pFormatetc.Length) ||
                (null == pmedium) || (1 != pmedium.Length))
                throw new ArgumentException();

            BclComTypes.FORMATETC bclFormat = StructConverter.OleFormatETC2Bcl(ref pFormatetc[0]);
            BclComTypes.STGMEDIUM bclMedium = StructConverter.OleSTGMEDIUM2Bcl(ref pmedium[0]);
            bclData.SetData(ref bclFormat, ref bclMedium, (fRelease == 0) ? false : true);
        }

        #endregion

        #region IDataObject Members

        int BclComTypes.IDataObject.DAdvise(ref BclComTypes.FORMATETC pFormatetc, BclComTypes.ADVF advf, BclComTypes.IAdviseSink adviseSink, out int connection)
        {
            if (null != bclData)
                return bclData.DAdvise(ref pFormatetc, advf, adviseSink, out connection);

            OleInterop.FORMATETC[] oleFormat = new OleInterop.FORMATETC[1];
            oleFormat[0] = StructConverter.BclFormatETC2Ole(ref pFormatetc);
            uint result;
            OleInterop.IAdviseSink oleSink = adviseSink as OleInterop.IAdviseSink;
            if (null == oleSink)
                oleSink = (OleInterop.IAdviseSink)(new AdviseSink(adviseSink));
            int hr = oleData.DAdvise(oleFormat, (uint)advf, oleSink, out result);
            NativeMethods.ThrowOnFailure(hr);
            connection = (int)result;
            return hr;
        }

        void BclComTypes.IDataObject.DUnadvise(int connection)
        {
            if (bclData != null)
                bclData.DUnadvise(connection);
            else
                oleData.DUnadvise((uint)connection);
        }

        int BclComTypes.IDataObject.EnumDAdvise(out BclComTypes.IEnumSTATDATA enumAdvise)
        {
            if (null != bclData)
                return bclData.EnumDAdvise(out enumAdvise);

            OleInterop.IEnumSTATDATA oleEnum;
            int hr = oleData.EnumDAdvise(out oleEnum);
            NativeMethods.ThrowOnFailure(hr);
            if (null == oleEnum)
            {
                enumAdvise = null;
            }
            else
            {
                enumAdvise = oleEnum as BclComTypes.IEnumSTATDATA;
                if (null == enumAdvise)
                    enumAdvise = (BclComTypes.IEnumSTATDATA)(new EnumSTATDATA(oleEnum));
            }
            return hr;
        }

        BclComTypes.IEnumFORMATETC BclComTypes.IDataObject.EnumFormatEtc(BclComTypes.DATADIR direction)
        {
            if (bclData != null)
                return bclData.EnumFormatEtc(direction);

            OleInterop.IEnumFORMATETC oleEnum;
            NativeMethods.ThrowOnFailure(oleData.EnumFormatEtc((uint)direction, out oleEnum));
            if (null == oleEnum)
                return null;
            BclComTypes.IEnumFORMATETC bclEnum = oleEnum as BclComTypes.IEnumFORMATETC;
            if (null == bclEnum)
                bclEnum = (BclComTypes.IEnumFORMATETC)(new EnumFORMATETC(oleEnum));
            return bclEnum;
        }

        int BclComTypes.IDataObject.GetCanonicalFormatEtc(ref BclComTypes.FORMATETC formatIn, out BclComTypes.FORMATETC formatOut)
        {
            if (null != bclData)
                return bclData.GetCanonicalFormatEtc(ref formatIn, out formatOut);

            OleInterop.FORMATETC[] oleFormatIn = new OleInterop.FORMATETC[1];
            OleInterop.FORMATETC[] oleFormatOut = new OleInterop.FORMATETC[1];
            oleFormatIn[0] = StructConverter.BclFormatETC2Ole(ref formatIn);
            int hr = oleData.GetCanonicalFormatEtc(oleFormatIn, oleFormatOut);
            NativeMethods.ThrowOnFailure(hr);
            formatOut = StructConverter.OleFormatETC2Bcl(ref oleFormatOut[0]);
            return hr;
        }

        void BclComTypes.IDataObject.GetData(ref BclComTypes.FORMATETC format, out BclComTypes.STGMEDIUM medium)
        {
            if (null != bclData)
            {
                bclData.GetData(ref format, out medium);
                return;
            }

            OleInterop.FORMATETC[] oleFormat = new OleInterop.FORMATETC[1];
            oleFormat[0] = StructConverter.BclFormatETC2Ole(ref format);
            OleInterop.STGMEDIUM[] oleMedium = new OleInterop.STGMEDIUM[1];
            oleData.GetData(oleFormat, oleMedium);
            medium = StructConverter.OleSTGMEDIUM2Bcl(ref oleMedium[0]);
        }

        void BclComTypes.IDataObject.GetDataHere(ref BclComTypes.FORMATETC format, ref BclComTypes.STGMEDIUM medium)
        {
            if (null != bclData)
            {
                bclData.GetDataHere(ref format, ref medium);
                return;
            }

            OleInterop.FORMATETC[] oleFormat = new OleInterop.FORMATETC[1];
            oleFormat[0] = StructConverter.BclFormatETC2Ole(ref format);
            OleInterop.STGMEDIUM[] oleMedium = new OleInterop.STGMEDIUM[1];
            oleMedium[0] = StructConverter.BclSTGMEDIUM2Ole(ref medium);
            oleData.GetDataHere(oleFormat, oleMedium);
            medium = StructConverter.OleSTGMEDIUM2Bcl(ref oleMedium[0]);
        }

        int BclComTypes.IDataObject.QueryGetData(ref BclComTypes.FORMATETC format)
        {
            if (null != bclData)
                return bclData.QueryGetData(ref format);

            OleInterop.FORMATETC[] oleFormat = new OleInterop.FORMATETC[1];
            oleFormat[0] = StructConverter.BclFormatETC2Ole(ref format);
            return oleData.QueryGetData(oleFormat);
        }

        void BclComTypes.IDataObject.SetData(ref BclComTypes.FORMATETC formatIn, ref BclComTypes.STGMEDIUM medium, bool release)
        {
            if (null != bclData)
            {
                bclData.SetData(ref formatIn, ref medium, release);
                return;
            }

            OleInterop.FORMATETC[] oleFormat = new OleInterop.FORMATETC[1];
            oleFormat[0] = StructConverter.BclFormatETC2Ole(ref formatIn);
            OleInterop.STGMEDIUM[] oleMedium = new OleInterop.STGMEDIUM[1];
            oleMedium[0] = StructConverter.BclSTGMEDIUM2Ole(ref medium);
            oleData.SetData(oleFormat, oleMedium, release ? 1 : 0);
        }

        #endregion
    }
}
