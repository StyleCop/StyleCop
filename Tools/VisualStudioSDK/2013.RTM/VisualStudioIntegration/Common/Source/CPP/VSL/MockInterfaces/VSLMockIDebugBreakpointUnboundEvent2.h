/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGBREAKPOINTUNBOUNDEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGBREAKPOINTUNBOUNDEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugBreakpointUnboundEvent2NotImpl :
	public IDebugBreakpointUnboundEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBreakpointUnboundEvent2NotImpl)

public:

	typedef IDebugBreakpointUnboundEvent2 Interface;

	STDMETHOD(GetBreakpoint)(
		/*[out]*/ IDebugBoundBreakpoint2** /*ppBP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetReason)(
		/*[out]*/ BP_UNBOUND_REASON* /*pdwUnboundReason*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugBreakpointUnboundEvent2MockImpl :
	public IDebugBreakpointUnboundEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBreakpointUnboundEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugBreakpointUnboundEvent2MockImpl)

	typedef IDebugBreakpointUnboundEvent2 Interface;
	struct GetBreakpointValidValues
	{
		/*[out]*/ IDebugBoundBreakpoint2** ppBP;
		HRESULT retValue;
	};

	STDMETHOD(GetBreakpoint)(
		/*[out]*/ IDebugBoundBreakpoint2** ppBP)
	{
		VSL_DEFINE_MOCK_METHOD(GetBreakpoint)

		VSL_SET_VALIDVALUE_INTERFACE(ppBP);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetReasonValidValues
	{
		/*[out]*/ BP_UNBOUND_REASON* pdwUnboundReason;
		HRESULT retValue;
	};

	STDMETHOD(GetReason)(
		/*[out]*/ BP_UNBOUND_REASON* pdwUnboundReason)
	{
		VSL_DEFINE_MOCK_METHOD(GetReason)

		VSL_SET_VALIDVALUE(pdwUnboundReason);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGBREAKPOINTUNBOUNDEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
