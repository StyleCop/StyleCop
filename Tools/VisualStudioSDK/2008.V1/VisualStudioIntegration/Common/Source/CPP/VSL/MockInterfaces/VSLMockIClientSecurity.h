/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICLIENTSECURITY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICLIENTSECURITY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IClientSecurityNotImpl :
	public IClientSecurity
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClientSecurityNotImpl)

public:

	typedef IClientSecurity Interface;

	STDMETHOD(QueryBlanket)(
		/*[in]*/ IUnknown* /*pProxy*/,
		/*[out]*/ DWORD* /*pAuthnSvc*/,
		/*[out]*/ DWORD* /*pAuthzSvc*/,
		/*[out]*/ OLECHAR** /*pServerPrincName*/,
		/*[out]*/ DWORD* /*pAuthnLevel*/,
		/*[out]*/ DWORD* /*pImpLevel*/,
		/*[out]*/ void** /*pAuthInfo*/,
		/*[out]*/ DWORD* /*pCapabilites*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBlanket)(
		/*[in]*/ IUnknown* /*pProxy*/,
		/*[in]*/ DWORD /*dwAuthnSvc*/,
		/*[in]*/ DWORD /*dwAuthzSvc*/,
		/*[in]*/ OLECHAR* /*pServerPrincName*/,
		/*[in]*/ DWORD /*dwAuthnLevel*/,
		/*[in]*/ DWORD /*dwImpLevel*/,
		/*[in]*/ void* /*pAuthInfo*/,
		/*[in]*/ DWORD /*dwCapabilities*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CopyProxy)(
		/*[in]*/ IUnknown* /*pProxy*/,
		/*[out]*/ IUnknown** /*ppCopy*/)VSL_STDMETHOD_NOTIMPL
};

class IClientSecurityMockImpl :
	public IClientSecurity,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClientSecurityMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IClientSecurityMockImpl)

	typedef IClientSecurity Interface;
	struct QueryBlanketValidValues
	{
		/*[in]*/ IUnknown* pProxy;
		/*[out]*/ DWORD* pAuthnSvc;
		/*[out]*/ DWORD* pAuthzSvc;
		/*[out]*/ OLECHAR** pServerPrincName;
		/*[out]*/ DWORD* pAuthnLevel;
		/*[out]*/ DWORD* pImpLevel;
		/*[out]*/ void** pAuthInfo;
		/*[out]*/ DWORD* pCapabilites;
		HRESULT retValue;
	};

	STDMETHOD(QueryBlanket)(
		/*[in]*/ IUnknown* pProxy,
		/*[out]*/ DWORD* pAuthnSvc,
		/*[out]*/ DWORD* pAuthzSvc,
		/*[out]*/ OLECHAR** pServerPrincName,
		/*[out]*/ DWORD* pAuthnLevel,
		/*[out]*/ DWORD* pImpLevel,
		/*[out]*/ void** pAuthInfo,
		/*[out]*/ DWORD* pCapabilites)
	{
		VSL_DEFINE_MOCK_METHOD(QueryBlanket)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProxy);

		VSL_SET_VALIDVALUE(pAuthnSvc);

		VSL_SET_VALIDVALUE(pAuthzSvc);

		VSL_SET_VALIDVALUE(pServerPrincName);

		VSL_SET_VALIDVALUE(pAuthnLevel);

		VSL_SET_VALIDVALUE(pImpLevel);

		VSL_SET_VALIDVALUE(pAuthInfo);

		VSL_SET_VALIDVALUE(pCapabilites);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBlanketValidValues
	{
		/*[in]*/ IUnknown* pProxy;
		/*[in]*/ DWORD dwAuthnSvc;
		/*[in]*/ DWORD dwAuthzSvc;
		/*[in]*/ OLECHAR* pServerPrincName;
		/*[in]*/ DWORD dwAuthnLevel;
		/*[in]*/ DWORD dwImpLevel;
		/*[in]*/ void* pAuthInfo;
		/*[in]*/ DWORD dwCapabilities;
		HRESULT retValue;
		size_t pAuthInfo_size_in_bytes;
	};

	STDMETHOD(SetBlanket)(
		/*[in]*/ IUnknown* pProxy,
		/*[in]*/ DWORD dwAuthnSvc,
		/*[in]*/ DWORD dwAuthzSvc,
		/*[in]*/ OLECHAR* pServerPrincName,
		/*[in]*/ DWORD dwAuthnLevel,
		/*[in]*/ DWORD dwImpLevel,
		/*[in]*/ void* pAuthInfo,
		/*[in]*/ DWORD dwCapabilities)
	{
		VSL_DEFINE_MOCK_METHOD(SetBlanket)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProxy);

		VSL_CHECK_VALIDVALUE(dwAuthnSvc);

		VSL_CHECK_VALIDVALUE(dwAuthzSvc);

		VSL_CHECK_VALIDVALUE_STRINGW(pServerPrincName);

		VSL_CHECK_VALIDVALUE(dwAuthnLevel);

		VSL_CHECK_VALIDVALUE(dwImpLevel);

		VSL_CHECK_VALIDVALUE_PVOID(pAuthInfo);

		VSL_CHECK_VALIDVALUE(dwCapabilities);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyProxyValidValues
	{
		/*[in]*/ IUnknown* pProxy;
		/*[out]*/ IUnknown** ppCopy;
		HRESULT retValue;
	};

	STDMETHOD(CopyProxy)(
		/*[in]*/ IUnknown* pProxy,
		/*[out]*/ IUnknown** ppCopy)
	{
		VSL_DEFINE_MOCK_METHOD(CopyProxy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProxy);

		VSL_SET_VALIDVALUE_INTERFACE(ppCopy);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICLIENTSECURITY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
