/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccProvider.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccProviderNotImpl :
	public IVsSccProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProviderNotImpl)

public:

	typedef IVsSccProvider Interface;

	STDMETHOD(SetActive)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetInactive)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AnyItemsUnderSourceControl)(
		/*[out]*/ BOOL* /*pfResult*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccProviderMockImpl :
	public IVsSccProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccProviderMockImpl)

	typedef IVsSccProvider Interface;
	struct SetActiveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetActive)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetActive)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetInactiveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetInactive)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetInactive)

		VSL_RETURN_VALIDVALUES();
	}
	struct AnyItemsUnderSourceControlValidValues
	{
		/*[out]*/ BOOL* pfResult;
		HRESULT retValue;
	};

	STDMETHOD(AnyItemsUnderSourceControl)(
		/*[out]*/ BOOL* pfResult)
	{
		VSL_DEFINE_MOCK_METHOD(AnyItemsUnderSourceControl)

		VSL_SET_VALIDVALUE(pfResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
