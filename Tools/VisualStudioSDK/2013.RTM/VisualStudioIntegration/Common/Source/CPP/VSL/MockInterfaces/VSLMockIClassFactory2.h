/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICLASSFACTORY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICLASSFACTORY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IClassFactory2NotImpl :
	public IClassFactory2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClassFactory2NotImpl)

public:

	typedef IClassFactory2 Interface;

	STDMETHOD(GetLicInfo)(
		/*[out]*/ LICINFO* /*pLicInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RequestLicKey)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[out]*/ BSTR* /*pBstrKey*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateInstanceLic)(
		/*[in]*/ IUnknown* /*pUnkOuter*/,
		/*[in]*/ IUnknown* /*pUnkReserved*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ BSTR /*bstrKey*/,
		/*[out,iid_is(riid)]*/ PVOID* /*ppvObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateInstance)(
		/*[in,unique]*/ IUnknown* /*pUnkOuter*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockServer)(
		/*[in]*/ BOOL /*fLock*/)VSL_STDMETHOD_NOTIMPL
};

class IClassFactory2MockImpl :
	public IClassFactory2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClassFactory2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IClassFactory2MockImpl)

	typedef IClassFactory2 Interface;
	struct GetLicInfoValidValues
	{
		/*[out]*/ LICINFO* pLicInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetLicInfo)(
		/*[out]*/ LICINFO* pLicInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetLicInfo)

		VSL_SET_VALIDVALUE(pLicInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct RequestLicKeyValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[out]*/ BSTR* pBstrKey;
		HRESULT retValue;
	};

	STDMETHOD(RequestLicKey)(
		/*[in]*/ DWORD dwReserved,
		/*[out]*/ BSTR* pBstrKey)
	{
		VSL_DEFINE_MOCK_METHOD(RequestLicKey)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_SET_VALIDVALUE_BSTR(pBstrKey);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateInstanceLicValidValues
	{
		/*[in]*/ IUnknown* pUnkOuter;
		/*[in]*/ IUnknown* pUnkReserved;
		/*[in]*/ REFIID riid;
		/*[in]*/ BSTR bstrKey;
		/*[out,iid_is(riid)]*/ PVOID* ppvObj;
		HRESULT retValue;
	};

	STDMETHOD(CreateInstanceLic)(
		/*[in]*/ IUnknown* pUnkOuter,
		/*[in]*/ IUnknown* pUnkReserved,
		/*[in]*/ REFIID riid,
		/*[in]*/ BSTR bstrKey,
		/*[out,iid_is(riid)]*/ PVOID* ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(CreateInstanceLic)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkOuter);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkReserved);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_BSTR(bstrKey);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateInstanceValidValues
	{
		/*[in,unique]*/ IUnknown* pUnkOuter;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvObject;
		HRESULT retValue;
	};

	STDMETHOD(CreateInstance)(
		/*[in,unique]*/ IUnknown* pUnkOuter,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvObject)
	{
		VSL_DEFINE_MOCK_METHOD(CreateInstance)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkOuter);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockServerValidValues
	{
		/*[in]*/ BOOL fLock;
		HRESULT retValue;
	};

	STDMETHOD(LockServer)(
		/*[in]*/ BOOL fLock)
	{
		VSL_DEFINE_MOCK_METHOD(LockServer)

		VSL_CHECK_VALIDVALUE(fLock);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICLASSFACTORY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
