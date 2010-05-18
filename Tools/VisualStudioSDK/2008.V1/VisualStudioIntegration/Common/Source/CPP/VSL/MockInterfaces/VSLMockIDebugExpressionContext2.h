/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGEXPRESSIONCONTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGEXPRESSIONCONTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugExpressionContext2NotImpl :
	public IDebugExpressionContext2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugExpressionContext2NotImpl)

public:

	typedef IDebugExpressionContext2 Interface;

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseText)(
		/*[in]*/ LPCOLESTR /*pszCode*/,
		/*[in]*/ PARSEFLAGS /*dwFlags*/,
		/*[in]*/ UINT /*nRadix*/,
		/*[out]*/ IDebugExpression2** /*ppExpr*/,
		/*[out]*/ BSTR* /*pbstrError*/,
		/*[out]*/ UINT* /*pichError*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugExpressionContext2MockImpl :
	public IDebugExpressionContext2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugExpressionContext2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugExpressionContext2MockImpl)

	typedef IDebugExpressionContext2 Interface;
	struct GetNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseTextValidValues
	{
		/*[in]*/ LPCOLESTR pszCode;
		/*[in]*/ PARSEFLAGS dwFlags;
		/*[in]*/ UINT nRadix;
		/*[out]*/ IDebugExpression2** ppExpr;
		/*[out]*/ BSTR* pbstrError;
		/*[out]*/ UINT* pichError;
		HRESULT retValue;
	};

	STDMETHOD(ParseText)(
		/*[in]*/ LPCOLESTR pszCode,
		/*[in]*/ PARSEFLAGS dwFlags,
		/*[in]*/ UINT nRadix,
		/*[out]*/ IDebugExpression2** ppExpr,
		/*[out]*/ BSTR* pbstrError,
		/*[out]*/ UINT* pichError)
	{
		VSL_DEFINE_MOCK_METHOD(ParseText)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCode);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(nRadix);

		VSL_SET_VALIDVALUE_INTERFACE(ppExpr);

		VSL_SET_VALIDVALUE_BSTR(pbstrError);

		VSL_SET_VALIDVALUE(pichError);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGEXPRESSIONCONTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
