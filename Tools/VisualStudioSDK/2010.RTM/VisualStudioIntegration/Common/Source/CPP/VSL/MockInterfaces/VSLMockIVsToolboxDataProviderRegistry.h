/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLBOXDATAPROVIDERREGISTRY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLBOXDATAPROVIDERREGISTRY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsToolboxDataProviderRegistryNotImpl :
	public IVsToolboxDataProviderRegistry
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxDataProviderRegistryNotImpl)

public:

	typedef IVsToolboxDataProviderRegistry Interface;

	STDMETHOD(RegisterDataProvider)(
		/*[in]*/ IVsToolboxDataProvider* /*pDP*/,
		/*[out,retval]*/ VSCOOKIE* /*pdwProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterDataProvider)(
		/*[in]*/ VSCOOKIE /*dwProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolboxDataProviderRegistryMockImpl :
	public IVsToolboxDataProviderRegistry,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolboxDataProviderRegistryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolboxDataProviderRegistryMockImpl)

	typedef IVsToolboxDataProviderRegistry Interface;
	struct RegisterDataProviderValidValues
	{
		/*[in]*/ IVsToolboxDataProvider* pDP;
		/*[out,retval]*/ VSCOOKIE* pdwProvider;
		HRESULT retValue;
	};

	STDMETHOD(RegisterDataProvider)(
		/*[in]*/ IVsToolboxDataProvider* pDP,
		/*[out,retval]*/ VSCOOKIE* pdwProvider)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterDataProvider)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDP);

		VSL_SET_VALIDVALUE(pdwProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterDataProviderValidValues
	{
		/*[in]*/ VSCOOKIE dwProvider;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterDataProvider)(
		/*[in]*/ VSCOOKIE dwProvider)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterDataProvider)

		VSL_CHECK_VALIDVALUE(dwProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLBOXDATAPROVIDERREGISTRY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
