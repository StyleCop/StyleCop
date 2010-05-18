/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOBJECTWITHSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOBJECTWITHSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IObjectWithSiteNotImpl :
	public IObjectWithSite
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IObjectWithSiteNotImpl)

public:

	typedef IObjectWithSite Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IUnknown* /*pUnkSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSite)(
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvSite*/)VSL_STDMETHOD_NOTIMPL
};

class IObjectWithSiteMockImpl :
	public IObjectWithSite,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IObjectWithSiteMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IObjectWithSiteMockImpl)

	typedef IObjectWithSite Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IUnknown* pUnkSite;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IUnknown* pUnkSite)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSiteValidValues
	{
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvSite;
		HRESULT retValue;
	};

	STDMETHOD(GetSite)(
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvSite)
	{
		VSL_DEFINE_MOCK_METHOD(GetSite)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvSite);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOBJECTWITHSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
