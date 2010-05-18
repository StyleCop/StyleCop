/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGBOUNDBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGBOUNDBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugBoundBreakpoint2NotImpl :
	public IDebugBoundBreakpoint2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBoundBreakpoint2NotImpl)

public:

	typedef IDebugBoundBreakpoint2 Interface;

	STDMETHOD(GetPendingBreakpoint)(
		/*[out]*/ IDebugPendingBreakpoint2** /*ppPendingBreakpoint*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetState)(
		/*[out]*/ BP_STATE* /*pState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHitCount)(
		/*[out]*/ DWORD* /*pdwHitCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBreakpointResolution)(
		/*[out]*/ IDebugBreakpointResolution2** /*ppBPResolution*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Enable)(
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHitCount)(
		/*[in]*/ DWORD /*dwHitCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCondition)(
		/*[in]*/ BP_CONDITION /*bpCondition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPassCount)(
		/*[in]*/ BP_PASSCOUNT /*bpPassCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Delete)()VSL_STDMETHOD_NOTIMPL
};

class IDebugBoundBreakpoint2MockImpl :
	public IDebugBoundBreakpoint2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBoundBreakpoint2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugBoundBreakpoint2MockImpl)

	typedef IDebugBoundBreakpoint2 Interface;
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
	struct GetStateValidValues
	{
		/*[out]*/ BP_STATE* pState;
		HRESULT retValue;
	};

	STDMETHOD(GetState)(
		/*[out]*/ BP_STATE* pState)
	{
		VSL_DEFINE_MOCK_METHOD(GetState)

		VSL_SET_VALIDVALUE(pState);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHitCountValidValues
	{
		/*[out]*/ DWORD* pdwHitCount;
		HRESULT retValue;
	};

	STDMETHOD(GetHitCount)(
		/*[out]*/ DWORD* pdwHitCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetHitCount)

		VSL_SET_VALIDVALUE(pdwHitCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBreakpointResolutionValidValues
	{
		/*[out]*/ IDebugBreakpointResolution2** ppBPResolution;
		HRESULT retValue;
	};

	STDMETHOD(GetBreakpointResolution)(
		/*[out]*/ IDebugBreakpointResolution2** ppBPResolution)
	{
		VSL_DEFINE_MOCK_METHOD(GetBreakpointResolution)

		VSL_SET_VALIDVALUE_INTERFACE(ppBPResolution);

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
	struct SetHitCountValidValues
	{
		/*[in]*/ DWORD dwHitCount;
		HRESULT retValue;
	};

	STDMETHOD(SetHitCount)(
		/*[in]*/ DWORD dwHitCount)
	{
		VSL_DEFINE_MOCK_METHOD(SetHitCount)

		VSL_CHECK_VALIDVALUE(dwHitCount);

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

#endif // IDEBUGBOUNDBREAKPOINT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
