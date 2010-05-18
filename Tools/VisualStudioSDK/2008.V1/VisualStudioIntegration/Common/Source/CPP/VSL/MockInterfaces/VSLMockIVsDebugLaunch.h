/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEBUGLAUNCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEBUGLAUNCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDebugLaunchNotImpl :
	public IVsDebugLaunch
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebugLaunchNotImpl)

public:

	typedef IVsDebugLaunch Interface;

	STDMETHOD(DebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS /*grfLaunch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryDebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS /*grfLaunch*/,
		/*[out]*/ BOOL* /*pfCanLaunch*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDebugLaunchMockImpl :
	public IVsDebugLaunch,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebugLaunchMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDebugLaunchMockImpl)

	typedef IVsDebugLaunch Interface;
	struct DebugLaunchValidValues
	{
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch;
		HRESULT retValue;
	};

	STDMETHOD(DebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch)
	{
		VSL_DEFINE_MOCK_METHOD(DebugLaunch)

		VSL_CHECK_VALIDVALUE(grfLaunch);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryDebugLaunchValidValues
	{
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch;
		/*[out]*/ BOOL* pfCanLaunch;
		HRESULT retValue;
	};

	STDMETHOD(QueryDebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch,
		/*[out]*/ BOOL* pfCanLaunch)
	{
		VSL_DEFINE_MOCK_METHOD(QueryDebugLaunch)

		VSL_CHECK_VALIDVALUE(grfLaunch);

		VSL_SET_VALIDVALUE(pfCanLaunch);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEBUGLAUNCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
