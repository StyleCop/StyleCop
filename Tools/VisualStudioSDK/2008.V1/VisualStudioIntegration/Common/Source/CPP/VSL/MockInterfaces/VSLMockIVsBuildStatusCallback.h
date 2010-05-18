/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBUILDSTATUSCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBUILDSTATUSCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsBuildStatusCallbackNotImpl :
	public IVsBuildStatusCallback
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildStatusCallbackNotImpl)

public:

	typedef IVsBuildStatusCallback Interface;

	STDMETHOD(BuildBegin)(
		/*[in,out]*/ BOOL* /*pfContinue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BuildEnd)(
		/*[in]*/ BOOL /*fSuccess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Tick)(
		/*[in,out]*/ BOOL* /*pfContinue*/)VSL_STDMETHOD_NOTIMPL
};

class IVsBuildStatusCallbackMockImpl :
	public IVsBuildStatusCallback,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildStatusCallbackMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsBuildStatusCallbackMockImpl)

	typedef IVsBuildStatusCallback Interface;
	struct BuildBeginValidValues
	{
		/*[in,out]*/ BOOL* pfContinue;
		HRESULT retValue;
	};

	STDMETHOD(BuildBegin)(
		/*[in,out]*/ BOOL* pfContinue)
	{
		VSL_DEFINE_MOCK_METHOD(BuildBegin)

		VSL_SET_VALIDVALUE(pfContinue);

		VSL_RETURN_VALIDVALUES();
	}
	struct BuildEndValidValues
	{
		/*[in]*/ BOOL fSuccess;
		HRESULT retValue;
	};

	STDMETHOD(BuildEnd)(
		/*[in]*/ BOOL fSuccess)
	{
		VSL_DEFINE_MOCK_METHOD(BuildEnd)

		VSL_CHECK_VALIDVALUE(fSuccess);

		VSL_RETURN_VALIDVALUES();
	}
	struct TickValidValues
	{
		/*[in,out]*/ BOOL* pfContinue;
		HRESULT retValue;
	};

	STDMETHOD(Tick)(
		/*[in,out]*/ BOOL* pfContinue)
	{
		VSL_DEFINE_MOCK_METHOD(Tick)

		VSL_SET_VALIDVALUE(pfContinue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBUILDSTATUSCALLBACK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
