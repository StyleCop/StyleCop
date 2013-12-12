/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROFFERSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROFFERSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "proffserv.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IProfferServiceNotImpl :
	public IProfferService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProfferServiceNotImpl)

public:

	typedef IProfferService Interface;

	STDMETHOD(ProfferService)(
		/*[in]*/ REFGUID /*rguidService*/,
		/*[in]*/ IServiceProvider* /*psp*/,
		/*[out]*/ DWORD* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RevokeService)(
		/*[in]*/ DWORD /*dwCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IProfferServiceMockImpl :
	public IProfferService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProfferServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProfferServiceMockImpl)

	typedef IProfferService Interface;
	struct ProfferServiceValidValues
	{
		/*[in]*/ REFGUID rguidService;
		/*[in]*/ IServiceProvider* psp;
		/*[out]*/ DWORD* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(ProfferService)(
		/*[in]*/ REFGUID rguidService,
		/*[in]*/ IServiceProvider* psp,
		/*[out]*/ DWORD* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(ProfferService)

		VSL_CHECK_VALIDVALUE(rguidService);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(psp);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevokeServiceValidValues
	{
		/*[in]*/ DWORD dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RevokeService)(
		/*[in]*/ DWORD dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RevokeService)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROFFERSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
