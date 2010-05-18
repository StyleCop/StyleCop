/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGENGINEPROGRAM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGENGINEPROGRAM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugEngineProgram2NotImpl :
	public IDebugEngineProgram2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngineProgram2NotImpl)

public:

	typedef IDebugEngineProgram2 Interface;

	STDMETHOD(Stop)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WatchForThreadStep)(
		/*[in]*/ IDebugProgram2* /*pOriginatingProgram*/,
		/*[in]*/ DWORD /*dwTid*/,
		/*[in]*/ BOOL /*fWatch*/,
		/*[in]*/ DWORD /*dwFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WatchForExpressionEvaluationOnThread)(
		/*[in]*/ IDebugProgram2* /*pOriginatingProgram*/,
		/*[in]*/ DWORD /*dwTid*/,
		/*[in]*/ DWORD /*dwEvalFlags*/,
		/*[in]*/ IDebugEventCallback2* /*pExprCallback*/,
		/*[in]*/ BOOL /*fWatch*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugEngineProgram2MockImpl :
	public IDebugEngineProgram2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngineProgram2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugEngineProgram2MockImpl)

	typedef IDebugEngineProgram2 Interface;
	struct StopValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Stop)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Stop)

		VSL_RETURN_VALIDVALUES();
	}
	struct WatchForThreadStepValidValues
	{
		/*[in]*/ IDebugProgram2* pOriginatingProgram;
		/*[in]*/ DWORD dwTid;
		/*[in]*/ BOOL fWatch;
		/*[in]*/ DWORD dwFrame;
		HRESULT retValue;
	};

	STDMETHOD(WatchForThreadStep)(
		/*[in]*/ IDebugProgram2* pOriginatingProgram,
		/*[in]*/ DWORD dwTid,
		/*[in]*/ BOOL fWatch,
		/*[in]*/ DWORD dwFrame)
	{
		VSL_DEFINE_MOCK_METHOD(WatchForThreadStep)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOriginatingProgram);

		VSL_CHECK_VALIDVALUE(dwTid);

		VSL_CHECK_VALIDVALUE(fWatch);

		VSL_CHECK_VALIDVALUE(dwFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct WatchForExpressionEvaluationOnThreadValidValues
	{
		/*[in]*/ IDebugProgram2* pOriginatingProgram;
		/*[in]*/ DWORD dwTid;
		/*[in]*/ DWORD dwEvalFlags;
		/*[in]*/ IDebugEventCallback2* pExprCallback;
		/*[in]*/ BOOL fWatch;
		HRESULT retValue;
	};

	STDMETHOD(WatchForExpressionEvaluationOnThread)(
		/*[in]*/ IDebugProgram2* pOriginatingProgram,
		/*[in]*/ DWORD dwTid,
		/*[in]*/ DWORD dwEvalFlags,
		/*[in]*/ IDebugEventCallback2* pExprCallback,
		/*[in]*/ BOOL fWatch)
	{
		VSL_DEFINE_MOCK_METHOD(WatchForExpressionEvaluationOnThread)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pOriginatingProgram);

		VSL_CHECK_VALIDVALUE(dwTid);

		VSL_CHECK_VALIDVALUE(dwEvalFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pExprCallback);

		VSL_CHECK_VALIDVALUE(fWatch);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGENGINEPROGRAM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
