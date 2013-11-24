/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPONENTENUMERATORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPONENTENUMERATORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "compsvcspkg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsComponentEnumeratorFactoryNotImpl :
	public IVsComponentEnumeratorFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentEnumeratorFactoryNotImpl)

public:

	typedef IVsComponentEnumeratorFactory Interface;

	STDMETHOD(GetComponents)(
		/*[in]*/ BSTR /*bstrMachineName*/,
		/*[in]*/ LONG /*lEnumType*/,
		/*[in]*/ BOOL /*bForceRefresh*/,
		/*[out]*/ IEnumComponents** /*pEnumerator*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComponentEnumeratorFactoryMockImpl :
	public IVsComponentEnumeratorFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentEnumeratorFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComponentEnumeratorFactoryMockImpl)

	typedef IVsComponentEnumeratorFactory Interface;
	struct GetComponentsValidValues
	{
		/*[in]*/ BSTR bstrMachineName;
		/*[in]*/ LONG lEnumType;
		/*[in]*/ BOOL bForceRefresh;
		/*[out]*/ IEnumComponents** pEnumerator;
		HRESULT retValue;
	};

	STDMETHOD(GetComponents)(
		/*[in]*/ BSTR bstrMachineName,
		/*[in]*/ LONG lEnumType,
		/*[in]*/ BOOL bForceRefresh,
		/*[out]*/ IEnumComponents** pEnumerator)
	{
		VSL_DEFINE_MOCK_METHOD(GetComponents)

		VSL_CHECK_VALIDVALUE_BSTR(bstrMachineName);

		VSL_CHECK_VALIDVALUE(lEnumType);

		VSL_CHECK_VALIDVALUE(bForceRefresh);

		VSL_SET_VALIDVALUE_INTERFACE(pEnumerator);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPONENTENUMERATORFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
