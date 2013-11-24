/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPONENTSELECTORPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPONENTSELECTORPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsComponentSelectorProviderNotImpl :
	public IVsComponentSelectorProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentSelectorProviderNotImpl)

public:

	typedef IVsComponentSelectorProvider Interface;

	STDMETHOD(GetComponentSelectorPage)(
		/*[in]*/ REFGUID /*rguidPage*/,
		/*[in,out]*/ VSPROPSHEETPAGE* /*pPage*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComponentSelectorProviderMockImpl :
	public IVsComponentSelectorProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentSelectorProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComponentSelectorProviderMockImpl)

	typedef IVsComponentSelectorProvider Interface;
	struct GetComponentSelectorPageValidValues
	{
		/*[in]*/ REFGUID rguidPage;
		/*[in,out]*/ VSPROPSHEETPAGE* pPage;
		HRESULT retValue;
	};

	STDMETHOD(GetComponentSelectorPage)(
		/*[in]*/ REFGUID rguidPage,
		/*[in,out]*/ VSPROPSHEETPAGE* pPage)
	{
		VSL_DEFINE_MOCK_METHOD(GetComponentSelectorPage)

		VSL_CHECK_VALIDVALUE(rguidPage);

		VSL_SET_VALIDVALUE(pPage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPONENTSELECTORPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
