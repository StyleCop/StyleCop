/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXPANSIONFUNCTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXPANSIONFUNCTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsExpansionFunctionNotImpl :
	public IVsExpansionFunction
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionFunctionNotImpl)

public:

	typedef IVsExpansionFunction Interface;

	STDMETHOD(GetFunctionType)(
		/*[out]*/ ExpansionFunctionType* /*pFuncType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListCount)(
		/*[out]*/ long* /*iCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetListText)(
		/*[in]*/ long /*iIndex*/,
		/*[out]*/ BSTR* /*pbstrText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultValue)(
		/*[out]*/ BSTR* /*bstrValue*/,
		/*[out]*/ BOOL* /*fHasDefaultValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FieldChanged)(
		/*[in]*/ BSTR /*bstrField*/,
		/*[out]*/ BOOL* /*fRequeryFunction*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentValue)(
		/*[out]*/ BSTR* /*bstrValue*/,
		/*[out]*/ BOOL* /*fHasCurrentValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseFunction)()VSL_STDMETHOD_NOTIMPL
};

class IVsExpansionFunctionMockImpl :
	public IVsExpansionFunction,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionFunctionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExpansionFunctionMockImpl)

	typedef IVsExpansionFunction Interface;
	struct GetFunctionTypeValidValues
	{
		/*[out]*/ ExpansionFunctionType* pFuncType;
		HRESULT retValue;
	};

	STDMETHOD(GetFunctionType)(
		/*[out]*/ ExpansionFunctionType* pFuncType)
	{
		VSL_DEFINE_MOCK_METHOD(GetFunctionType)

		VSL_SET_VALIDVALUE(pFuncType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListCountValidValues
	{
		/*[out]*/ long* iCount;
		HRESULT retValue;
	};

	STDMETHOD(GetListCount)(
		/*[out]*/ long* iCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetListCount)

		VSL_SET_VALIDVALUE(iCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetListTextValidValues
	{
		/*[in]*/ long iIndex;
		/*[out]*/ BSTR* pbstrText;
		HRESULT retValue;
	};

	STDMETHOD(GetListText)(
		/*[in]*/ long iIndex,
		/*[out]*/ BSTR* pbstrText)
	{
		VSL_DEFINE_MOCK_METHOD(GetListText)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_BSTR(pbstrText);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultValueValidValues
	{
		/*[out]*/ BSTR* bstrValue;
		/*[out]*/ BOOL* fHasDefaultValue;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultValue)(
		/*[out]*/ BSTR* bstrValue,
		/*[out]*/ BOOL* fHasDefaultValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultValue)

		VSL_SET_VALIDVALUE_BSTR(bstrValue);

		VSL_SET_VALIDVALUE(fHasDefaultValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct FieldChangedValidValues
	{
		/*[in]*/ BSTR bstrField;
		/*[out]*/ BOOL* fRequeryFunction;
		HRESULT retValue;
	};

	STDMETHOD(FieldChanged)(
		/*[in]*/ BSTR bstrField,
		/*[out]*/ BOOL* fRequeryFunction)
	{
		VSL_DEFINE_MOCK_METHOD(FieldChanged)

		VSL_CHECK_VALIDVALUE_BSTR(bstrField);

		VSL_SET_VALIDVALUE(fRequeryFunction);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentValueValidValues
	{
		/*[out]*/ BSTR* bstrValue;
		/*[out]*/ BOOL* fHasCurrentValue;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentValue)(
		/*[out]*/ BSTR* bstrValue,
		/*[out]*/ BOOL* fHasCurrentValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentValue)

		VSL_SET_VALIDVALUE_BSTR(bstrValue);

		VSL_SET_VALIDVALUE(fHasCurrentValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseFunctionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ReleaseFunction)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ReleaseFunction)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXPANSIONFUNCTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
