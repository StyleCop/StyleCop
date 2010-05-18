/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IWEBAPPLICATIONCTXSVC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IWEBAPPLICATIONCTXSVC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "Webapplicationctx.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IWebApplicationCtxSvcNotImpl :
	public IWebApplicationCtxSvc
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IWebApplicationCtxSvcNotImpl)

public:

	typedef IWebApplicationCtxSvc Interface;

	STDMETHOD(GetItemContext)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ IServiceProvider** /*ppServiceProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IWebApplicationCtxSvcMockImpl :
	public IWebApplicationCtxSvc,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IWebApplicationCtxSvcMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IWebApplicationCtxSvcMockImpl)

	typedef IWebApplicationCtxSvc Interface;
	struct GetItemContextValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ IServiceProvider** ppServiceProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetItemContext)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ IServiceProvider** ppServiceProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemContext)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppServiceProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IWEBAPPLICATIONCTXSVC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
