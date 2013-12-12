/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBSERVICEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBSERVICEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWebServiceProviderNotImpl :
	public IVsWebServiceProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceProviderNotImpl)

public:

	typedef IVsWebServiceProvider Interface;

	STDMETHOD(WebServices)(
		/*[out,retval]*/ IEnumWebServices** /*ppIEnumWebServices*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWebService)(
		/*[in]*/ LPCOLESTR /*pszUrl*/,
		/*[out,retval]*/ IVsWebService** /*ppIVsWebService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartServer)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseWebServiceProviderEvents)(
		/*[in]*/ IVsWebServiceProviderEvents* /*pEvents*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseWebServiceProviderEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnsureServerRunning)(
		/*[out,retval]*/ BSTR* /*pbstrUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ApplicationUrl)(
		/*[out,retval]*/ BSTR* /*pbstrUrl*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebServiceProviderMockImpl :
	public IVsWebServiceProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebServiceProviderMockImpl)

	typedef IVsWebServiceProvider Interface;
	struct WebServicesValidValues
	{
		/*[out,retval]*/ IEnumWebServices** ppIEnumWebServices;
		HRESULT retValue;
	};

	STDMETHOD(WebServices)(
		/*[out,retval]*/ IEnumWebServices** ppIEnumWebServices)
	{
		VSL_DEFINE_MOCK_METHOD(WebServices)

		VSL_SET_VALIDVALUE_INTERFACE(ppIEnumWebServices);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWebServiceValidValues
	{
		/*[in]*/ LPCOLESTR pszUrl;
		/*[out,retval]*/ IVsWebService** ppIVsWebService;
		HRESULT retValue;
	};

	STDMETHOD(GetWebService)(
		/*[in]*/ LPCOLESTR pszUrl,
		/*[out,retval]*/ IVsWebService** ppIVsWebService)
	{
		VSL_DEFINE_MOCK_METHOD(GetWebService)

		VSL_CHECK_VALIDVALUE_STRINGW(pszUrl);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsWebService);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartServerValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StartServer)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StartServer)

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseWebServiceProviderEventsValidValues
	{
		/*[in]*/ IVsWebServiceProviderEvents* pEvents;
		/*[out,retval]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseWebServiceProviderEvents)(
		/*[in]*/ IVsWebServiceProviderEvents* pEvents,
		/*[out,retval]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseWebServiceProviderEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEvents);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseWebServiceProviderEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseWebServiceProviderEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseWebServiceProviderEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnsureServerRunningValidValues
	{
		/*[out,retval]*/ BSTR* pbstrUrl;
		HRESULT retValue;
	};

	STDMETHOD(EnsureServerRunning)(
		/*[out,retval]*/ BSTR* pbstrUrl)
	{
		VSL_DEFINE_MOCK_METHOD(EnsureServerRunning)

		VSL_SET_VALIDVALUE_BSTR(pbstrUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct ApplicationUrlValidValues
	{
		/*[out,retval]*/ BSTR* pbstrUrl;
		HRESULT retValue;
	};

	STDMETHOD(ApplicationUrl)(
		/*[out,retval]*/ BSTR* pbstrUrl)
	{
		VSL_DEFINE_MOCK_METHOD(ApplicationUrl)

		VSL_SET_VALIDVALUE_BSTR(pbstrUrl);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBSERVICEPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
