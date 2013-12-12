/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBSERVICEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBSERVICEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWebServiceEventsNotImpl :
	public IVsWebServiceEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceEventsNotImpl)

public:

	typedef IVsWebServiceEvents Interface;

	STDMETHOD(OnRemoved)(
		/*[in]*/ LPCOLESTR /*pszOldURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRenamed)(
		/*[in]*/ LPCOLESTR /*pszOldURL*/,
		/*[in]*/ LPCOLESTR /*pszNewURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnChanged)(
		/*[in]*/ IVsWebService* /*pIVsWebReference*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebServiceEventsMockImpl :
	public IVsWebServiceEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebServiceEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebServiceEventsMockImpl)

	typedef IVsWebServiceEvents Interface;
	struct OnRemovedValidValues
	{
		/*[in]*/ LPCOLESTR pszOldURL;
		HRESULT retValue;
	};

	STDMETHOD(OnRemoved)(
		/*[in]*/ LPCOLESTR pszOldURL)
	{
		VSL_DEFINE_MOCK_METHOD(OnRemoved)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOldURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRenamedValidValues
	{
		/*[in]*/ LPCOLESTR pszOldURL;
		/*[in]*/ LPCOLESTR pszNewURL;
		HRESULT retValue;
	};

	STDMETHOD(OnRenamed)(
		/*[in]*/ LPCOLESTR pszOldURL,
		/*[in]*/ LPCOLESTR pszNewURL)
	{
		VSL_DEFINE_MOCK_METHOD(OnRenamed)

		VSL_CHECK_VALIDVALUE_STRINGW(pszOldURL);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNewURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnChangedValidValues
	{
		/*[in]*/ IVsWebService* pIVsWebReference;
		HRESULT retValue;
	};

	STDMETHOD(OnChanged)(
		/*[in]*/ IVsWebService* pIVsWebReference)
	{
		VSL_DEFINE_MOCK_METHOD(OnChanged)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsWebReference);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBSERVICEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
