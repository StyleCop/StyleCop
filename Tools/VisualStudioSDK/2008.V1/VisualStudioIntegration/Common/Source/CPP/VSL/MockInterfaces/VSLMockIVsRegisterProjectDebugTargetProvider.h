/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSREGISTERPROJECTDEBUGTARGETPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSREGISTERPROJECTDEBUGTARGETPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsRegisterProjectDebugTargetProviderNotImpl :
	public IVsRegisterProjectDebugTargetProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterProjectDebugTargetProviderNotImpl)

public:

	typedef IVsRegisterProjectDebugTargetProvider Interface;

	STDMETHOD(AddDebugTargetProvider)(
		/*[in]*/ IVsProjectDebugTargetProvider* /*pNewDbgTrgtProvider*/,
		/*[out]*/ IVsProjectDebugTargetProvider** /*ppNextDbgTrgtProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveDebugTargetProvider)(
		/*[in]*/ IVsProjectDebugTargetProvider* /*pDbgTrgtProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRegisterProjectDebugTargetProviderMockImpl :
	public IVsRegisterProjectDebugTargetProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterProjectDebugTargetProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRegisterProjectDebugTargetProviderMockImpl)

	typedef IVsRegisterProjectDebugTargetProvider Interface;
	struct AddDebugTargetProviderValidValues
	{
		/*[in]*/ IVsProjectDebugTargetProvider* pNewDbgTrgtProvider;
		/*[out]*/ IVsProjectDebugTargetProvider** ppNextDbgTrgtProvider;
		HRESULT retValue;
	};

	STDMETHOD(AddDebugTargetProvider)(
		/*[in]*/ IVsProjectDebugTargetProvider* pNewDbgTrgtProvider,
		/*[out]*/ IVsProjectDebugTargetProvider** ppNextDbgTrgtProvider)
	{
		VSL_DEFINE_MOCK_METHOD(AddDebugTargetProvider)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNewDbgTrgtProvider);

		VSL_SET_VALIDVALUE_INTERFACE(ppNextDbgTrgtProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveDebugTargetProviderValidValues
	{
		/*[in]*/ IVsProjectDebugTargetProvider* pDbgTrgtProvider;
		HRESULT retValue;
	};

	STDMETHOD(RemoveDebugTargetProvider)(
		/*[in]*/ IVsProjectDebugTargetProvider* pDbgTrgtProvider)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveDebugTargetProvider)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDbgTrgtProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSREGISTERPROJECTDEBUGTARGETPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
