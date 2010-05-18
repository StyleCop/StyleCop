/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGEXPRESSION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGEXPRESSION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugExpression2NotImpl :
	public IDebugExpression2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugExpression2NotImpl)

public:

	typedef IDebugExpression2 Interface;

	STDMETHOD(EvaluateAsync)(
		/*[in]*/ EVALFLAGS /*dwFlags*/,
		/*[in]*/ IDebugEventCallback2* /*pExprCallback*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Abort)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EvaluateSync)(
		/*[in]*/ EVALFLAGS /*dwFlags*/,
		/*[in]*/ DWORD /*dwTimeout*/,
		/*[in]*/ IDebugEventCallback2* /*pExprCallback*/,
		/*[out]*/ IDebugProperty2** /*ppResult*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugExpression2MockImpl :
	public IDebugExpression2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugExpression2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugExpression2MockImpl)

	typedef IDebugExpression2 Interface;
	struct EvaluateAsyncValidValues
	{
		/*[in]*/ EVALFLAGS dwFlags;
		/*[in]*/ IDebugEventCallback2* pExprCallback;
		HRESULT retValue;
	};

	STDMETHOD(EvaluateAsync)(
		/*[in]*/ EVALFLAGS dwFlags,
		/*[in]*/ IDebugEventCallback2* pExprCallback)
	{
		VSL_DEFINE_MOCK_METHOD(EvaluateAsync)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pExprCallback);

		VSL_RETURN_VALIDVALUES();
	}
	struct AbortValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Abort)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Abort)

		VSL_RETURN_VALIDVALUES();
	}
	struct EvaluateSyncValidValues
	{
		/*[in]*/ EVALFLAGS dwFlags;
		/*[in]*/ DWORD dwTimeout;
		/*[in]*/ IDebugEventCallback2* pExprCallback;
		/*[out]*/ IDebugProperty2** ppResult;
		HRESULT retValue;
	};

	STDMETHOD(EvaluateSync)(
		/*[in]*/ EVALFLAGS dwFlags,
		/*[in]*/ DWORD dwTimeout,
		/*[in]*/ IDebugEventCallback2* pExprCallback,
		/*[out]*/ IDebugProperty2** ppResult)
	{
		VSL_DEFINE_MOCK_METHOD(EvaluateSync)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pExprCallback);

		VSL_SET_VALIDVALUE_INTERFACE(ppResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGEXPRESSION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
