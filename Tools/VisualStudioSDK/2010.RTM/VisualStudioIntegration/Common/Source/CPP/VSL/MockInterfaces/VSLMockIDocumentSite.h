/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDOCUMENTSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDOCUMENTSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDocumentSiteNotImpl :
	public IDocumentSite
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDocumentSiteNotImpl)

public:

	typedef IDocumentSite Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSite)(
		/*[out]*/ IServiceProvider** /*ppSite*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompiler)(
		/*[in]*/ REFIID /*iid*/,
		/*[out]*/ void** /*ppvObj*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ActivateObject)(
		/*[in]*/ ACTFLAG /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsObjectShowable)()VSL_STDMETHOD_NOTIMPL
};

class IDocumentSiteMockImpl :
	public IDocumentSite,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDocumentSiteMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDocumentSiteMockImpl)

	typedef IDocumentSite Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IServiceProvider* pSite;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* pSite)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSiteValidValues
	{
		/*[out]*/ IServiceProvider** ppSite;
		HRESULT retValue;
	};

	STDMETHOD(GetSite)(
		/*[out]*/ IServiceProvider** ppSite)
	{
		VSL_DEFINE_MOCK_METHOD(GetSite)

		VSL_SET_VALIDVALUE_INTERFACE(ppSite);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompilerValidValues
	{
		/*[in]*/ REFIID iid;
		/*[out]*/ void** ppvObj;
		HRESULT retValue;
	};

	STDMETHOD(GetCompiler)(
		/*[in]*/ REFIID iid,
		/*[out]*/ void** ppvObj)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompiler)

		VSL_CHECK_VALIDVALUE(iid);

		VSL_SET_VALIDVALUE(ppvObj);

		VSL_RETURN_VALIDVALUES();
	}
	struct ActivateObjectValidValues
	{
		/*[in]*/ ACTFLAG dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(ActivateObject)(
		/*[in]*/ ACTFLAG dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(ActivateObject)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsObjectShowableValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsObjectShowable)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsObjectShowable)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDOCUMENTSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
