/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IURLMON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IURLMON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IUrlMonNotImpl :
	public IUrlMon
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUrlMonNotImpl)

public:

	typedef IUrlMon Interface;

	STDMETHOD(AsyncGetClassBits)(
		/*[in]*/ REFCLSID /*rclsid*/,
		/*[in,unique]*/ LPCWSTR /*pszTYPE*/,
		/*[in,unique]*/ LPCWSTR /*pszExt*/,
		/*[in]*/ DWORD /*dwFileVersionMS*/,
		/*[in]*/ DWORD /*dwFileVersionLS*/,
		/*[in,unique]*/ LPCWSTR /*pszCodeBase*/,
		/*[in]*/ IBindCtx* /*pbc*/,
		/*[in]*/ DWORD /*dwClassContext*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ DWORD /*flags*/)VSL_STDMETHOD_NOTIMPL
};

class IUrlMonMockImpl :
	public IUrlMon,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUrlMonMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IUrlMonMockImpl)

	typedef IUrlMon Interface;
	struct AsyncGetClassBitsValidValues
	{
		/*[in]*/ REFCLSID rclsid;
		/*[in,unique]*/ LPCWSTR pszTYPE;
		/*[in,unique]*/ LPCWSTR pszExt;
		/*[in]*/ DWORD dwFileVersionMS;
		/*[in]*/ DWORD dwFileVersionLS;
		/*[in,unique]*/ LPCWSTR pszCodeBase;
		/*[in]*/ IBindCtx* pbc;
		/*[in]*/ DWORD dwClassContext;
		/*[in]*/ REFIID riid;
		/*[in]*/ DWORD flags;
		HRESULT retValue;
	};

	STDMETHOD(AsyncGetClassBits)(
		/*[in]*/ REFCLSID rclsid,
		/*[in,unique]*/ LPCWSTR pszTYPE,
		/*[in,unique]*/ LPCWSTR pszExt,
		/*[in]*/ DWORD dwFileVersionMS,
		/*[in]*/ DWORD dwFileVersionLS,
		/*[in,unique]*/ LPCWSTR pszCodeBase,
		/*[in]*/ IBindCtx* pbc,
		/*[in]*/ DWORD dwClassContext,
		/*[in]*/ REFIID riid,
		/*[in]*/ DWORD flags)
	{
		VSL_DEFINE_MOCK_METHOD(AsyncGetClassBits)

		VSL_CHECK_VALIDVALUE(rclsid);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTYPE);

		VSL_CHECK_VALIDVALUE_STRINGW(pszExt);

		VSL_CHECK_VALIDVALUE(dwFileVersionMS);

		VSL_CHECK_VALIDVALUE(dwFileVersionLS);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCodeBase);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pbc);

		VSL_CHECK_VALIDVALUE(dwClassContext);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(flags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IURLMON_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
