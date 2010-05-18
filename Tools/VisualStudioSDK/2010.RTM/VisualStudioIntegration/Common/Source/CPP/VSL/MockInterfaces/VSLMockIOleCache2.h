/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECACHE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECACHE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleCache2NotImpl :
	public IOleCache2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCache2NotImpl)

public:

	typedef IOleCache2 Interface;

	STDMETHOD(UpdateCache)(
		/*[in]*/ LPDATAOBJECT /*pDataObject*/,
		/*[in]*/ DWORD /*grfUpdf*/,
		/*[in]*/ LPVOID /*pReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DiscardCache)(
		/*[in]*/ DWORD /*dwDiscardOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Cache)(
		/*[in,unique]*/ FORMATETC* /*pformatetc*/,
		/*[in]*/ DWORD /*advf*/,
		/*[out]*/ DWORD* /*pdwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Uncache)(
		/*[in]*/ DWORD /*dwConnection*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumCache)(
		/*[out]*/ IEnumSTATDATA** /*ppenumSTATDATA*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitCache)(
		/*[in,unique]*/ IDataObject* /*pDataObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetData)(
		/*[in,unique]*/ FORMATETC* /*pformatetc*/,
		/*[in,unique]*/ STGMEDIUM* /*pmedium*/,
		/*[in]*/ BOOL /*fRelease*/)VSL_STDMETHOD_NOTIMPL
};

class IOleCache2MockImpl :
	public IOleCache2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCache2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleCache2MockImpl)

	typedef IOleCache2 Interface;
	struct UpdateCacheValidValues
	{
		/*[in]*/ LPDATAOBJECT pDataObject;
		/*[in]*/ DWORD grfUpdf;
		/*[in]*/ LPVOID pReserved;
		HRESULT retValue;
		size_t pReserved_size_in_bytes;
	};

	STDMETHOD(UpdateCache)(
		/*[in]*/ LPDATAOBJECT pDataObject,
		/*[in]*/ DWORD grfUpdf,
		/*[in]*/ LPVOID pReserved)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateCache)

		VSL_CHECK_VALIDVALUE(pDataObject);

		VSL_CHECK_VALIDVALUE(grfUpdf);

		VSL_CHECK_VALIDVALUE_PVOID(pReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct DiscardCacheValidValues
	{
		/*[in]*/ DWORD dwDiscardOptions;
		HRESULT retValue;
	};

	STDMETHOD(DiscardCache)(
		/*[in]*/ DWORD dwDiscardOptions)
	{
		VSL_DEFINE_MOCK_METHOD(DiscardCache)

		VSL_CHECK_VALIDVALUE(dwDiscardOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct CacheValidValues
	{
		/*[in,unique]*/ FORMATETC* pformatetc;
		/*[in]*/ DWORD advf;
		/*[out]*/ DWORD* pdwConnection;
		HRESULT retValue;
	};

	STDMETHOD(Cache)(
		/*[in,unique]*/ FORMATETC* pformatetc,
		/*[in]*/ DWORD advf,
		/*[out]*/ DWORD* pdwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(Cache)

		VSL_CHECK_VALIDVALUE_POINTER(pformatetc);

		VSL_CHECK_VALIDVALUE(advf);

		VSL_SET_VALIDVALUE(pdwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct UncacheValidValues
	{
		/*[in]*/ DWORD dwConnection;
		HRESULT retValue;
	};

	STDMETHOD(Uncache)(
		/*[in]*/ DWORD dwConnection)
	{
		VSL_DEFINE_MOCK_METHOD(Uncache)

		VSL_CHECK_VALIDVALUE(dwConnection);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumCacheValidValues
	{
		/*[out]*/ IEnumSTATDATA** ppenumSTATDATA;
		HRESULT retValue;
	};

	STDMETHOD(EnumCache)(
		/*[out]*/ IEnumSTATDATA** ppenumSTATDATA)
	{
		VSL_DEFINE_MOCK_METHOD(EnumCache)

		VSL_SET_VALIDVALUE_INTERFACE(ppenumSTATDATA);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitCacheValidValues
	{
		/*[in,unique]*/ IDataObject* pDataObject;
		HRESULT retValue;
	};

	STDMETHOD(InitCache)(
		/*[in,unique]*/ IDataObject* pDataObject)
	{
		VSL_DEFINE_MOCK_METHOD(InitCache)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDataObject);

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
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECACHE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
