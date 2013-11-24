/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBSERVICEPROVIDEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBSERVICEPROVIDEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWebServiceProviderEventsNotImpl :
	public IVsWebServiceProviderEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceProviderEventsNotImpl)

public:

	typedef IVsWebServiceProviderEvents Interface;

	STDMETHOD(OnAdded)(
		/*[in]*/ IVsWebService* /*pIVsWebReference*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRemoved)(
		/*[in]*/ LPCOLESTR /*pszURL*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebServiceProviderEventsMockImpl :
	public IVsWebServiceProviderEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceProviderEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebServiceProviderEventsMockImpl)

	typedef IVsWebServiceProviderEvents Interface;
	struct OnAddedValidValues
	{
		/*[in]*/ IVsWebService* pIVsWebReference;
		HRESULT retValue;
	};

	STDMETHOD(OnAdded)(
		/*[in]*/ IVsWebService* pIVsWebReference)
	{
		VSL_DEFINE_MOCK_METHOD(OnAdded)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsWebReference);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRemovedValidValues
	{
		/*[in]*/ LPCOLESTR pszURL;
		HRESULT retValue;
	};

	STDMETHOD(OnRemoved)(
		/*[in]*/ LPCOLESTR pszURL)
	{
		VSL_DEFINE_MOCK_METHOD(OnRemoved)

		VSL_CHECK_VALIDVALUE_STRINGW(pszURL);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBSERVICEPROVIDEREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
