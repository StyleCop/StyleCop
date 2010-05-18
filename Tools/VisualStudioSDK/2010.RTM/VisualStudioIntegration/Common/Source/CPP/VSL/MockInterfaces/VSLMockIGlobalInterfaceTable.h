/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IGLOBALINTERFACETABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IGLOBALINTERFACETABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IGlobalInterfaceTableNotImpl :
	public IGlobalInterfaceTable
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IGlobalInterfaceTableNotImpl)

public:

	typedef IGlobalInterfaceTable Interface;

	STDMETHOD(RegisterInterfaceInGlobal)(
		/*[in]*/ IUnknown* /*pUnk*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ DWORD* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevokeInterfaceFromGlobal)(
		/*[in]*/ DWORD /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInterfaceFromGlobal)(
		/*[in]*/ DWORD /*dwCookie*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppv*/)VSL_STDMETHOD_NOTIMPL
};

class IGlobalInterfaceTableMockImpl :
	public IGlobalInterfaceTable,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IGlobalInterfaceTableMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IGlobalInterfaceTableMockImpl)

	typedef IGlobalInterfaceTable Interface;
	struct RegisterInterfaceInGlobalValidValues
	{
		/*[in]*/ IUnknown* pUnk;
		/*[in]*/ REFIID riid;
		/*[out]*/ DWORD* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterInterfaceInGlobal)(
		/*[in]*/ IUnknown* pUnk,
		/*[in]*/ REFIID riid,
		/*[out]*/ DWORD* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterInterfaceInGlobal)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnk);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevokeInterfaceFromGlobalValidValues
	{
		/*[in]*/ DWORD dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RevokeInterfaceFromGlobal)(
		/*[in]*/ DWORD dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RevokeInterfaceFromGlobal)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInterfaceFromGlobalValidValues
	{
		/*[in]*/ DWORD dwCookie;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppv;
		HRESULT retValue;
	};

	STDMETHOD(GetInterfaceFromGlobal)(
		/*[in]*/ DWORD dwCookie,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppv)
	{
		VSL_DEFINE_MOCK_METHOD(GetInterfaceFromGlobal)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppv);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IGLOBALINTERFACETABLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
