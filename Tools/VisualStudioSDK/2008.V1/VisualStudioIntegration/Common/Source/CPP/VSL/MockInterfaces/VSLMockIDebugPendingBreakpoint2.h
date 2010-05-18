/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPENDINGBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPENDINGBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugPendingBreakpoint2NotImpl :
	public IDebugPendingBreakpoint2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPendingBreakpoint2NotImpl)

public:

	typedef IDebugPendingBreakpoint2 Interface;

	STDMETHOD(CanBind)(
		/*[out]*/ IEnumDebugErrorBreakpoints2** /*ppErrorEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Bind)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetState)(
		/*[out]*/ PENDING_BP_STATE_INFO* /*pState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBreakpointRequest)(
		/*[out]*/ IDebugBreakpointRequest2** /*ppBPRequest*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Virtualize)(
		/*[in]*/ BOOL /*fVirtualize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Enable)(
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCondition)(
		/*[in]*/ BP_CONDITION /*bpCondition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPassCount)(
		/*[in]*/ BP_PASSCOUNT /*bpPassCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumBoundBreakpoints)(
		/*[out]*/ IEnumDebugBoundBreakpoints2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumErrorBreakpoints)(
		/*[in]*/ BP_ERROR_TYPE /*bpErrorType*/,
		/*[out]*/ IEnumDebugErrorBreakpoints2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Delete)()VSL_STDMETHOD_NOTIMPL
};

class IDebugPendingBreakpoint2MockImpl :
	public IDebugPendingBreakpoint2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPendingBreakpoint2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugPendingBreakpoint2MockImpl)

	typedef IDebugPendingBreakpoint2 Interface;
	struct CanBindValidValues
	{
		/*[out]*/ IEnumDebugErrorBreakpoints2** ppErrorEnum;
		HRESULT retValue;
	};

	STDMETHOD(CanBind)(
		/*[out]*/ IEnumDebugErrorBreakpoints2** ppErrorEnum)
	{
		VSL_DEFINE_MOCK_METHOD(CanBind)

		VSL_SET_VALIDVALUE_INTERFACE(ppErrorEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct BindValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Bind)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Bind)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStateValidValues
	{
		/*[out]*/ PENDING_BP_STATE_INFO* pState;
		HRESULT retValue;
	};

	STDMETHOD(GetState)(
		/*[out]*/ PENDING_BP_STATE_INFO* pState)
	{
		VSL_DEFINE_MOCK_METHOD(GetState)

		VSL_SET_VALIDVALUE(pState);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBreakpointRequestValidValues
	{
		/*[out]*/ IDebugBreakpointRequest2** ppBPRequest;
		HRESULT retValue;
	};

	STDMETHOD(GetBreakpointRequest)(
		/*[out]*/ IDebugBreakpointRequest2** ppBPRequest)
	{
		VSL_DEFINE_MOCK_METHOD(GetBreakpointRequest)

		VSL_SET_VALIDVALUE_INTERFACE(ppBPRequest);

		VSL_RETURN_VALIDVALUES();
	}
	struct VirtualizeValidValues
	{
		/*[in]*/ BOOL fVirtualize;
		HRESULT retValue;
	};

	STDMETHOD(Virtualize)(
		/*[in]*/ BOOL fVirtualize)
	{
		VSL_DEFINE_MOCK_METHOD(Virtualize)

		VSL_CHECK_VALIDVALUE(fVirtualize);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableValidValues
	{
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(Enable)(
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(Enable)

		VSL_CHECK_VALIDVALUE(fEnable);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetConditionValidValues
	{
		/*[in]*/ BP_CONDITION bpCondition;
		HRESULT retValue;
	};

	STDMETHOD(SetCondition)(
		/*[in]*/ BP_CONDITION bpCondition)
	{
		VSL_DEFINE_MOCK_METHOD(SetCondition)

		VSL_CHECK_VALIDVALUE(bpCondition);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPassCountValidValues
	{
		/*[in]*/ BP_PASSCOUNT bpPassCount;
		HRESULT retValue;
	};

	STDMETHOD(SetPassCount)(
		/*[in]*/ BP_PASSCOUNT bpPassCount)
	{
		VSL_DEFINE_MOCK_METHOD(SetPassCount)

		VSL_CHECK_VALIDVALUE(bpPassCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumBoundBreakpointsValidValues
	{
		/*[out]*/ IEnumDebugBoundBreakpoints2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumBoundBreakpoints)(
		/*[out]*/ IEnumDebugBoundBreakpoints2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumBoundBreakpoints)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumErrorBreakpointsValidValues
	{
		/*[in]*/ BP_ERROR_TYPE bpErrorType;
		/*[out]*/ IEnumDebugErrorBreakpoints2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumErrorBreakpoints)(
		/*[in]*/ BP_ERROR_TYPE bpErrorType,
		/*[out]*/ IEnumDebugErrorBreakpoints2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumErrorBreakpoints)

		VSL_CHECK_VALIDVALUE(bpErrorType);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Delete)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Delete)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPENDINGBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
