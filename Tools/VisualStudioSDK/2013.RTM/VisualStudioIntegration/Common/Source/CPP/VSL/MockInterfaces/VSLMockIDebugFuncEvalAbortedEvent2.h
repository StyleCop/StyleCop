/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGFUNCEVALABORTEDEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGFUNCEVALABORTEDEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugFuncEvalAbortedEvent2NotImpl :
	public IDebugFuncEvalAbortedEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugFuncEvalAbortedEvent2NotImpl)

public:

	typedef IDebugFuncEvalAbortedEvent2 Interface;

	STDMETHOD(GetAbortResult)(
		/*[out]*/ FUNC_EVAL_ABORT_RESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFunctionName)(
		/*[out]*/ BSTR* /*pbstrFunctionName*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugFuncEvalAbortedEvent2MockImpl :
	public IDebugFuncEvalAbortedEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugFuncEvalAbortedEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugFuncEvalAbortedEvent2MockImpl)

	typedef IDebugFuncEvalAbortedEvent2 Interface;
	struct GetAbortResultValidValues
	{
		/*[out]*/ FUNC_EVAL_ABORT_RESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(GetAbortResult)(
		/*[out]*/ FUNC_EVAL_ABORT_RESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(GetAbortResult)

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFunctionNameValidValues
	{
		/*[out]*/ BSTR* pbstrFunctionName;
		HRESULT retValue;
	};

	STDMETHOD(GetFunctionName)(
		/*[out]*/ BSTR* pbstrFunctionName)
	{
		VSL_DEFINE_MOCK_METHOD(GetFunctionName)

		VSL_SET_VALIDVALUE_BSTR(pbstrFunctionName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGFUNCEVALABORTEDEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
