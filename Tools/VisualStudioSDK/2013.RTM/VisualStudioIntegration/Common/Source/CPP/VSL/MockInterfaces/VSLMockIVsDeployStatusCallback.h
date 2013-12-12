/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEPLOYSTATUSCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEPLOYSTATUSCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDeployStatusCallbackNotImpl :
	public IVsDeployStatusCallback
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDeployStatusCallbackNotImpl)

public:

	typedef IVsDeployStatusCallback Interface;

	STDMETHOD(OnStartDeploy)(
		/*[in,out]*/ BOOL* /*pfContinue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnEndDeploy)(
		/*[in]*/ BOOL /*fSuccessful*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnQueryContinueDeploy)(
		/*[in,out]*/ BOOL* /*pfContinue*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDeployStatusCallbackMockImpl :
	public IVsDeployStatusCallback,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDeployStatusCallbackMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDeployStatusCallbackMockImpl)

	typedef IVsDeployStatusCallback Interface;
	struct OnStartDeployValidValues
	{
		/*[in,out]*/ BOOL* pfContinue;
		HRESULT retValue;
	};

	STDMETHOD(OnStartDeploy)(
		/*[in,out]*/ BOOL* pfContinue)
	{
		VSL_DEFINE_MOCK_METHOD(OnStartDeploy)

		VSL_SET_VALIDVALUE(pfContinue);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnEndDeployValidValues
	{
		/*[in]*/ BOOL fSuccessful;
		HRESULT retValue;
	};

	STDMETHOD(OnEndDeploy)(
		/*[in]*/ BOOL fSuccessful)
	{
		VSL_DEFINE_MOCK_METHOD(OnEndDeploy)

		VSL_CHECK_VALIDVALUE(fSuccessful);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnQueryContinueDeployValidValues
	{
		/*[in,out]*/ BOOL* pfContinue;
		HRESULT retValue;
	};

	STDMETHOD(OnQueryContinueDeploy)(
		/*[in,out]*/ BOOL* pfContinue)
	{
		VSL_DEFINE_MOCK_METHOD(OnQueryContinueDeploy)

		VSL_SET_VALIDVALUE(pfContinue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEPLOYSTATUSCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
