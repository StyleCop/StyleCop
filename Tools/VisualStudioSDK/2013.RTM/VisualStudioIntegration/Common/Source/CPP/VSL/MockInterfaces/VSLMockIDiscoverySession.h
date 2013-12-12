/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDISCOVERYSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDISCOVERYSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DiscoveryService.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDiscoverySessionNotImpl :
	public IDiscoverySession
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoverySessionNotImpl)

public:

	typedef IDiscoverySession Interface;

	STDMETHOD(DiscoverUrl)(
		/*[in]*/ BSTR /*pbstrUrl*/,
		/*[out,retval]*/ IDiscoveryResult** /*pIDiscoveryResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DiscoverUrlAsync)(
		/*[in]*/ BSTR /*url*/,
		/*[in]*/ IDiscoverUrlCallBack* /*pDiscoverUrlCallBack*/,
		/*[out,retval]*/ int* /*cookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CancelDiscoverUrl)(
		/*[in]*/ int /*cookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDiscoverError)(
		/*[in]*/ int /*cookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateWebReference)(
		/*[in]*/ IUnknown* /*punkWebReferenceFolder*/,
		/*[in]*/ BSTR /*bstrUrl*/,
		/*[in]*/ BSTR /*bstrDestinationPath*/)VSL_STDMETHOD_NOTIMPL
};

class IDiscoverySessionMockImpl :
	public IDiscoverySession,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoverySessionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDiscoverySessionMockImpl)

	typedef IDiscoverySession Interface;
	struct DiscoverUrlValidValues
	{
		/*[in]*/ BSTR pbstrUrl;
		/*[out,retval]*/ IDiscoveryResult** pIDiscoveryResult;
		HRESULT retValue;
	};

	STDMETHOD(DiscoverUrl)(
		/*[in]*/ BSTR pbstrUrl,
		/*[out,retval]*/ IDiscoveryResult** pIDiscoveryResult)
	{
		VSL_DEFINE_MOCK_METHOD(DiscoverUrl)

		VSL_CHECK_VALIDVALUE_BSTR(pbstrUrl);

		VSL_SET_VALIDVALUE_INTERFACE(pIDiscoveryResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct DiscoverUrlAsyncValidValues
	{
		/*[in]*/ BSTR url;
		/*[in]*/ IDiscoverUrlCallBack* pDiscoverUrlCallBack;
		/*[out,retval]*/ int* cookie;
		HRESULT retValue;
	};

	STDMETHOD(DiscoverUrlAsync)(
		/*[in]*/ BSTR url,
		/*[in]*/ IDiscoverUrlCallBack* pDiscoverUrlCallBack,
		/*[out,retval]*/ int* cookie)
	{
		VSL_DEFINE_MOCK_METHOD(DiscoverUrlAsync)

		VSL_CHECK_VALIDVALUE_BSTR(url);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDiscoverUrlCallBack);

		VSL_SET_VALIDVALUE(cookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct CancelDiscoverUrlValidValues
	{
		/*[in]*/ int cookie;
		HRESULT retValue;
	};

	STDMETHOD(CancelDiscoverUrl)(
		/*[in]*/ int cookie)
	{
		VSL_DEFINE_MOCK_METHOD(CancelDiscoverUrl)

		VSL_CHECK_VALIDVALUE(cookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDiscoverErrorValidValues
	{
		/*[in]*/ int cookie;
		HRESULT retValue;
	};

	STDMETHOD(GetDiscoverError)(
		/*[in]*/ int cookie)
	{
		VSL_DEFINE_MOCK_METHOD(GetDiscoverError)

		VSL_CHECK_VALIDVALUE(cookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateWebReferenceValidValues
	{
		/*[in]*/ IUnknown* punkWebReferenceFolder;
		/*[in]*/ BSTR bstrUrl;
		/*[in]*/ BSTR bstrDestinationPath;
		HRESULT retValue;
	};

	STDMETHOD(UpdateWebReference)(
		/*[in]*/ IUnknown* punkWebReferenceFolder,
		/*[in]*/ BSTR bstrUrl,
		/*[in]*/ BSTR bstrDestinationPath)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateWebReference)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkWebReferenceFolder);

		VSL_CHECK_VALIDVALUE_BSTR(bstrUrl);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDestinationPath);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDISCOVERYSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
