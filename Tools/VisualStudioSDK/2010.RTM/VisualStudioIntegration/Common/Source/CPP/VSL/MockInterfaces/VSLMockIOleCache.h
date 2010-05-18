/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECACHE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECACHE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleCacheNotImpl :
	public IOleCache
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCacheNotImpl)

public:

	typedef IOleCache Interface;

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

class IOleCacheMockImpl :
	public IOleCache,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCacheMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleCacheMockImpl)

	typedef IOleCache Interface;
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

#endif // IOLECACHE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
