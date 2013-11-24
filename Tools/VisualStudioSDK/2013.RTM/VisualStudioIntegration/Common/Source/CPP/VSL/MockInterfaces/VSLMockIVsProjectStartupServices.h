/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTSTARTUPSERVICES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTSTARTUPSERVICES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectStartupServicesNotImpl :
	public IVsProjectStartupServices
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectStartupServicesNotImpl)

public:

	typedef IVsProjectStartupServices Interface;

	STDMETHOD(AddStartupService)(
		/*[in]*/ REFGUID /*guidService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveStartupService)(
		/*[in]*/ REFGUID /*guidService*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStartupServiceEnum)(
		/*[out]*/ IEnumProjectStartupServices** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectStartupServicesMockImpl :
	public IVsProjectStartupServices,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectStartupServicesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectStartupServicesMockImpl)

	typedef IVsProjectStartupServices Interface;
	struct AddStartupServiceValidValues
	{
		/*[in]*/ REFGUID guidService;
		HRESULT retValue;
	};

	STDMETHOD(AddStartupService)(
		/*[in]*/ REFGUID guidService)
	{
		VSL_DEFINE_MOCK_METHOD(AddStartupService)

		VSL_CHECK_VALIDVALUE(guidService);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveStartupServiceValidValues
	{
		/*[in]*/ REFGUID guidService;
		HRESULT retValue;
	};

	STDMETHOD(RemoveStartupService)(
		/*[in]*/ REFGUID guidService)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveStartupService)

		VSL_CHECK_VALIDVALUE(guidService);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStartupServiceEnumValidValues
	{
		/*[out]*/ IEnumProjectStartupServices** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(GetStartupServiceEnum)(
		/*[out]*/ IEnumProjectStartupServices** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(GetStartupServiceEnum)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTSTARTUPSERVICES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
