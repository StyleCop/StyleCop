/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGBOUNDBREAKPOINT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGBOUNDBREAKPOINT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugBoundBreakpoint3NotImpl :
	public IDebugBoundBreakpoint3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBoundBreakpoint3NotImpl)

public:

	typedef IDebugBoundBreakpoint3 Interface;

	STDMETHOD(SetTracepoint)(
		/*[in]*/ LPCOLESTR /*bpBstrTracepoint*/,
		/*[in]*/ BP_FLAGS /*bpFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugBoundBreakpoint3MockImpl :
	public IDebugBoundBreakpoint3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBoundBreakpoint3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugBoundBreakpoint3MockImpl)

	typedef IDebugBoundBreakpoint3 Interface;
	struct SetTracepointValidValues
	{
		/*[in]*/ LPCOLESTR bpBstrTracepoint;
		/*[in]*/ BP_FLAGS bpFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetTracepoint)(
		/*[in]*/ LPCOLESTR bpBstrTracepoint,
		/*[in]*/ BP_FLAGS bpFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetTracepoint)

		VSL_CHECK_VALIDVALUE_STRINGW(bpBstrTracepoint);

		VSL_CHECK_VALIDVALUE(bpFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGBOUNDBREAKPOINT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
