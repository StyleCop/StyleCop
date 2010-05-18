/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDATAOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDATAOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDataObjectNotImpl :
	public IDataObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDataObjectNotImpl)

public:

	typedef IDataObject Interface;

	STDMETHOD(GetData)(
		/*[in,unique]*/ FORMATETC* /*pformatetcIn*/,
		/*[out]*/ STGMEDIUM* /*pmedium*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDataHere)(
		/*[in,unique]*/ FORMATETC* /*pformatetc*/,
		/*[in,out]*/ STGMEDIUM* /*pmedium*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryGetData)(
		/*[in,unique]*/ FORMATETC* /*pformatetc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCanonicalFormatEtc)(
		/*[in,unique]*/ FORMATETC* /*pformatectIn*/,
		/*[out]*/ FORMATETC* /*pformatetcOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetData)(
		/*[in,unique]*/ FORMATETC* /*pformatetc*/,
		/*[in,unique]*/ STGMEDIUM* /*pmedium*/,
		/*[in]*/ BOOL /*fRelease*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumFormatEtc)(
		/*[in]*/ DWORD /*dwDirection*/,
		/*[out]*/ IEnumFORMATETC** /*ppenumFormatEtc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DAdvise)(
		/*[in]*/ FORMATETC* /*pformatetc*/,
		/*[in]*/ DWORD /*advf*/,
		/*[in,unique]*/ IAdviseSink* /*pAdvSink*/,
		/*[out]*/ DWORD* /*pdwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DUnadvise)(
		/*[in]*/ DWORD /*dwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumDAdvise)(
		/*[out]*/ IEnumSTATDATA** /*ppenumAdvise*/)VSL_STDMETHOD_NOTIMPL
};

class IDataObjectMockImpl :
	public IDataObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDataObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDataObjectMockImpl)

	typedef IDataObject Interface;
	struct GetDataValidValues
	{
		/*[in,unique]*/ FORMATETC* pformatetcIn;
		/*[out]*/ STGMEDIUM* pmedium;
		HRESULT retValue;
	};

	STDMETHOD(GetData)(
		/*[in,unique]*/ FORMATETC* pformatetcIn,
		/*[out]*/ STGMEDIUM* pmedium)
	{
		VSL_DEFINE_MOCK_METHOD(GetData)

		VSL_CHECK_VALIDVALUE_POINTER(pformatetcIn);

		VSL_SET_VALIDVALUE(pmedium);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDataHereValidValues
	{
		/*[in,unique]*/ FORMATETC* pformatetc;
		/*[in,out]*/ STGMEDIUM* pmedium;
		HRESULT retValue;
	};

	STDMETHOD(GetDataHere)(
		/*[in,unique]*/ FORMATETC* pformatetc,
		/*[in,out]*/ STGMEDIUM* pmedium)
	{
		VSL_DEFINE_MOCK_METHOD(GetDataHere)

		VSL_CHECK_VALIDVALUE_POINTER(pformatetc);

		VSL_SET_VALIDVALUE(pmedium);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryGetDataValidValues
	{
		/*[in,unique]*/ FORMATETC* pformatetc;
		HRESULT retValue;
	};

	STDMETHOD(QueryGetData)(
		/*[in,unique]*/ FORMATETC* pformatetc)
	{
		VSL_DEFINE_MOCK_METHOD(QueryGetData)

		VSL_CHECK_VALIDVALUE_POINTER(pformatetc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCanonicalFormatEtcValidValues
	{
		/*[in,unique]*/ FORMATETC* pformatectIn;
		/*[out]*/ FORMATETC* pformatetcOut;
		HRESULT retValue;
	};

	STDMETHOD(GetCanonicalFormatEtc)(
		/*[in,unique]*/ FORMATETC* pformatectIn,
		/*[out]*/ FORMATETC* pformatetcOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetCanonicalFormatEtc)

		VSL_CHECK_VALIDVALUE_POINTER(pformatectIn);

		VSL_SET_VALIDVALUE(pformatetcOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDataValidValues
	{
		/*[in,unique]*/ FORMATETC* pformatetc;
		/*[in,unique]*/ STGMEDIUM* pmedium;
		/*[in]*/ BOOL fRelease;
		HRESULT retValue;
	};

	STDMETHOD(SetData)(
		/*[in,unique]*/ FORMATETC* pformatetc,
		/*[in,unique]*/ STGMEDIUM* pmedium,
		/*[in]*/ BOOL fRelease)
	{
		VSL_DEFINE_MOCK_METHOD(SetData)

		VSL_CHECK_VALIDVALUE_POINTER(pformatetc);

		VSL_CHECK_VALIDVALUE_POINTER(pmedium);

		VSL_CHECK_VALIDVALUE(fRelease);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumFormatEtcValidValues
	{
		/*[in]*/ DWORD dwDirection;
		/*[out]*/ IEnumFORMATETC** ppenumFormatEtc;
		HRESULT retValue;
	};

	STDMETHOD(EnumFormatEtc)(
		/*[in]*/ DWORD dwDirection,
		/*[out]*/ IEnumFORMATETC** ppenumFormatEtc)
	{
		VSL_DEFINE_MOCK_METHOD(EnumFormatEtc)

		VSL_CHECK_VALIDVALUE(dwDirection);

		VSL_SET_VALIDVALUE_INTERFACE(ppenumFormatEtc);

		VSL_RETURN_VALIDVALUES();
	}
	struct DAdviseValidValues
	{
		/*[in]*/ FORMATETC* pformatetc;
		/*[in]*/ DWORD advf;
		/*[in,unique]*/ IAdviseSink* pAdvSink;
		/*[out]*/ DWORD* pdwConnection;
		HRESULT retValue;
	};

	STDMETHOD(DAdvise)(
		/*[in]*/ FORMATETC* pformatetc,
		/*[in]*/ DWORD advf,
		/*[in,unique]*/ IAdviseSink* pAdvSink,
		/*[out]*/ DWORD* pdwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(DAdvise)

		VSL_CHECK_VALIDVALUE_POINTER(pformatetc);

		VSL_CHECK_VALIDVALUE(advf);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAdvSink);

		VSL_SET_VALIDVALUE(pdwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct DUnadviseValidValues
	{
		/*[in]*/ DWORD dwConnection;
		HRESULT retValue;
	};

	STDMETHOD(DUnadvise)(
		/*[in]*/ DWORD dwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(DUnadvise)

		VSL_CHECK_VALIDVALUE(dwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumDAdviseValidValues
	{
		/*[out]*/ IEnumSTATDATA** ppenumAdvise;
		HRESULT retValue;
	};

	STDMETHOD(EnumDAdvise)(
		/*[out]*/ IEnumSTATDATA** ppenumAdvise)
	{
		VSL_DEFINE_MOCK_METHOD(EnumDAdvise)

		VSL_SET_VALIDVALUE_INTERFACE(ppenumAdvise);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDATAOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
