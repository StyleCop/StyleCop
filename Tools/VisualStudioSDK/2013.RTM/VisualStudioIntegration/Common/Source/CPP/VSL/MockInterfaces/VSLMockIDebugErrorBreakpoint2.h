/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGERRORBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGERRORBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugErrorBreakpoint2NotImpl :
	public IDebugErrorBreakpoint2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugErrorBreakpoint2NotImpl)

public:

	typedef IDebugErrorBreakpoint2 Interface;

	STDMETHOD(GetPendingBreakpoint)(
		/*[out]*/ IDebugPendingBreakpoint2** /*ppPendingBreakpoint*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBreakpointResolution)(
		/*[out]*/ IDebugErrorBreakpointResolution2** /*ppErrorResolution*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugErrorBreakpoint2MockImpl :
	public IDebugErrorBreakpoint2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugErrorBreakpoint2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugErrorBreakpoint2MockImpl)

	typedef IDebugErrorBreakpoint2 Interface;
	struct GetPendingBreakpointValidValues
	{
		/*[out]*/ IDebugPendingBreakpoint2** ppPendingBreakpoint;
		HRESULT retValue;
	};

	STDMETHOD(GetPendingBreakpoint)(
		/*[out]*/ IDebugPendingBreakpoint2** ppPendingBreakpoint)
	{
		VSL_DEFINE_MOCK_METHOD(GetPendingBreakpoint)

		VSL_SET_VALIDVALUE_INTERFACE(ppPendingBreakpoint);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBreakpointResolutionValidValues
	{
		/*[out]*/ IDebugErrorBreakpointResolution2** ppErrorResolution;
		HRESULT retValue;
	};

	STDMETHOD(GetBreakpointResolution)(
		/*[out]*/ IDebugErrorBreakpointResolution2** ppErrorResolution)
	{
		VSL_DEFINE_MOCK_METHOD(GetBreakpointResolution)

		VSL_SET_VALIDVALUE_INTERFACE(ppErrorResolution);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGERRORBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
