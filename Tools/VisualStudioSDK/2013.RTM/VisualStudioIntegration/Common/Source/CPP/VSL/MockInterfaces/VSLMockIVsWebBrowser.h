/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsbrowse.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebBrowserNotImpl :
	public IVsWebBrowser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebBrowserNotImpl)

public:

	typedef IVsWebBrowser Interface;

	STDMETHOD(Navigate)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ LPCOLESTR /*lpszURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NavigateEx)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ LPCOLESTR /*lpszURL*/,
		/*[in]*/ VARIANT* /*pvarTargetFrame*/,
		/*[in]*/ VARIANT* /*pvarPostData*/,
		/*[in]*/ VARIANT* /*pvarHeaders*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Stop)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Refresh)(
		/*[in]*/ VSWBREFRESHTYPE /*dwRefreshType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentInfo)(
		/*[in]*/ VSWBDOCINFOINDEX /*dwInfoIndex*/,
		/*[out]*/ VARIANT* /*pvarInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebBrowserMockImpl :
	public IVsWebBrowser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebBrowserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebBrowserMockImpl)

	typedef IVsWebBrowser Interface;
	struct NavigateValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ LPCOLESTR lpszURL;
		HRESULT retValue;
	};

	STDMETHOD(Navigate)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ LPCOLESTR lpszURL)
	{
		VSL_DEFINE_MOCK_METHOD(Navigate)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct NavigateExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ LPCOLESTR lpszURL;
		/*[in]*/ VARIANT* pvarTargetFrame;
		/*[in]*/ VARIANT* pvarPostData;
		/*[in]*/ VARIANT* pvarHeaders;
		HRESULT retValue;
	};

	STDMETHOD(NavigateEx)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ LPCOLESTR lpszURL,
		/*[in]*/ VARIANT* pvarTargetFrame,
		/*[in]*/ VARIANT* pvarPostData,
		/*[in]*/ VARIANT* pvarHeaders)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszURL);

		VSL_CHECK_VALIDVALUE_POINTER(pvarTargetFrame);

		VSL_CHECK_VALIDVALUE_POINTER(pvarPostData);

		VSL_CHECK_VALIDVALUE_POINTER(pvarHeaders);

		VSL_RETURN_VALIDVALUES();
	}
	struct StopValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Stop)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Stop)

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshValidValues
	{
		/*[in]*/ VSWBREFRESHTYPE dwRefreshType;
		HRESULT retValue;
	};

	STDMETHOD(Refresh)(
		/*[in]*/ VSWBREFRESHTYPE dwRefreshType)
	{
		VSL_DEFINE_MOCK_METHOD(Refresh)

		VSL_CHECK_VALIDVALUE(dwRefreshType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentInfoValidValues
	{
		/*[in]*/ VSWBDOCINFOINDEX dwInfoIndex;
		/*[out]*/ VARIANT* pvarInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentInfo)(
		/*[in]*/ VSWBDOCINFOINDEX dwInfoIndex,
		/*[out]*/ VARIANT* pvarInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentInfo)

		VSL_CHECK_VALIDVALUE(dwInfoIndex);

		VSL_SET_VALIDVALUE_VARIANT(pvarInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
