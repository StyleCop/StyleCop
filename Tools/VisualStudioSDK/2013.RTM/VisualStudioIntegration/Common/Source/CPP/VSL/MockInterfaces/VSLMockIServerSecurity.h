/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISERVERSECURITY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISERVERSECURITY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IServerSecurityNotImpl :
	public IServerSecurity
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IServerSecurityNotImpl)

public:

	typedef IServerSecurity Interface;

	STDMETHOD(QueryBlanket)(
		/*[out]*/ DWORD* /*pAuthnSvc*/,
		/*[out]*/ DWORD* /*pAuthzSvc*/,
		/*[out]*/ OLECHAR** /*pServerPrincName*/,
		/*[out]*/ DWORD* /*pAuthnLevel*/,
		/*[out]*/ DWORD* /*pImpLevel*/,
		/*[out]*/ void** /*pPrivs*/,
		/*[in,out]*/ DWORD* /*pCapabilities*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ImpersonateClient)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevertToSelf)()VSL_STDMETHOD_NOTIMPL

	virtual BOOL STDMETHODCALLTYPE IsImpersonating(){ return BOOL(); }
};

class IServerSecurityMockImpl :
	public IServerSecurity,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IServerSecurityMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IServerSecurityMockImpl)

	typedef IServerSecurity Interface;
	struct QueryBlanketValidValues
	{
		/*[out]*/ DWORD* pAuthnSvc;
		/*[out]*/ DWORD* pAuthzSvc;
		/*[out]*/ OLECHAR** pServerPrincName;
		/*[out]*/ DWORD* pAuthnLevel;
		/*[out]*/ DWORD* pImpLevel;
		/*[out]*/ void** pPrivs;
		/*[in,out]*/ DWORD* pCapabilities;
		HRESULT retValue;
	};

	STDMETHOD(QueryBlanket)(
		/*[out]*/ DWORD* pAuthnSvc,
		/*[out]*/ DWORD* pAuthzSvc,
		/*[out]*/ OLECHAR** pServerPrincName,
		/*[out]*/ DWORD* pAuthnLevel,
		/*[out]*/ DWORD* pImpLevel,
		/*[out]*/ void** pPrivs,
		/*[in,out]*/ DWORD* pCapabilities)
	{
		VSL_DEFINE_MOCK_METHOD(QueryBlanket)

		VSL_SET_VALIDVALUE(pAuthnSvc);

		VSL_SET_VALIDVALUE(pAuthzSvc);

		VSL_SET_VALIDVALUE(pServerPrincName);

		VSL_SET_VALIDVALUE(pAuthnLevel);

		VSL_SET_VALIDVALUE(pImpLevel);

		VSL_SET_VALIDVALUE(pPrivs);

		VSL_SET_VALIDVALUE(pCapabilities);

		VSL_RETURN_VALIDVALUES();
	}
	struct ImpersonateClientValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ImpersonateClient)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ImpersonateClient)

		VSL_RETURN_VALIDVALUES();
	}
	struct RevertToSelfValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RevertToSelf)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RevertToSelf)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsImpersonatingValidValues
	{
		BOOL retValue;
	};

	virtual BOOL _stdcall IsImpersonating()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsImpersonating)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISERVERSECURITY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
