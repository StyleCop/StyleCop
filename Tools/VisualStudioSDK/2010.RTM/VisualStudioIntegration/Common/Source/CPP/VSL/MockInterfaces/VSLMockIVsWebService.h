/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsWebServices.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebServiceNotImpl :
	public IVsWebService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceNotImpl)

public:

	typedef IVsWebService Interface;

	STDMETHOD(Url)(
		/*[out,retval]*/ BSTR* /*bstrUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AppRelativeUrl)(
		/*[out,retval]*/ BSTR* /*bstrAppUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProvider)(
		/*[out,retval]*/ IVsWebServiceProvider** /*ppIVsWebServiceProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseWebServiceEvents)(
		/*[in]*/ IVsWebServiceEvents* /*pEvents*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseWebServiceEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebServiceMockImpl :
	public IVsWebService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebServiceMockImpl)

	typedef IVsWebService Interface;
	struct UrlValidValues
	{
		/*[out,retval]*/ BSTR* bstrUrl;
		HRESULT retValue;
	};

	STDMETHOD(Url)(
		/*[out,retval]*/ BSTR* bstrUrl)
	{
		VSL_DEFINE_MOCK_METHOD(Url)

		VSL_SET_VALIDVALUE_BSTR(bstrUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct AppRelativeUrlValidValues
	{
		/*[out,retval]*/ BSTR* bstrAppUrl;
		HRESULT retValue;
	};

	STDMETHOD(AppRelativeUrl)(
		/*[out,retval]*/ BSTR* bstrAppUrl)
	{
		VSL_DEFINE_MOCK_METHOD(AppRelativeUrl)

		VSL_SET_VALIDVALUE_BSTR(bstrAppUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderValidValues
	{
		/*[out,retval]*/ IVsWebServiceProvider** ppIVsWebServiceProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetProvider)(
		/*[out,retval]*/ IVsWebServiceProvider** ppIVsWebServiceProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetProvider)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsWebServiceProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseWebServiceEventsValidValues
	{
		/*[in]*/ IVsWebServiceEvents* pEvents;
		/*[out,retval]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseWebServiceEvents)(
		/*[in]*/ IVsWebServiceEvents* pEvents,
		/*[out,retval]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseWebServiceEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEvents);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseWebServiceEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseWebServiceEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseWebServiceEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
