/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSENHANCEDDATATIP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSENHANCEDDATATIP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsEnhancedDataTipNotImpl :
	public IVsEnhancedDataTip
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnhancedDataTipNotImpl)

public:

	typedef IVsEnhancedDataTip Interface;

	STDMETHOD(Show)(
		/*[in]*/ HWND /*hwndOwner*/,
		/*[in]*/ POINT* /*pptTopLeft*/,
		/*[in]*/ RECT* /*pHotRect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetExpression)(
		/*[in]*/ BSTR /*bstrExpression*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBaseWindowHandle)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsErrorTip)(
		/*[out]*/ BOOL* /*pbIsError*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsOpen)(
		/*[out]*/ BOOL* /*pbIsOpen*/)VSL_STDMETHOD_NOTIMPL
};

class IVsEnhancedDataTipMockImpl :
	public IVsEnhancedDataTip,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsEnhancedDataTipMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsEnhancedDataTipMockImpl)

	typedef IVsEnhancedDataTip Interface;
	struct ShowValidValues
	{
		/*[in]*/ HWND hwndOwner;
		/*[in]*/ POINT* pptTopLeft;
		/*[in]*/ RECT* pHotRect;
		HRESULT retValue;
	};

	STDMETHOD(Show)(
		/*[in]*/ HWND hwndOwner,
		/*[in]*/ POINT* pptTopLeft,
		/*[in]*/ RECT* pHotRect)
	{
		VSL_DEFINE_MOCK_METHOD(Show)

		VSL_CHECK_VALIDVALUE(hwndOwner);

		VSL_CHECK_VALIDVALUE_POINTER(pptTopLeft);

		VSL_CHECK_VALIDVALUE_POINTER(pHotRect);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetExpressionValidValues
	{
		/*[in]*/ BSTR bstrExpression;
		HRESULT retValue;
	};

	STDMETHOD(SetExpression)(
		/*[in]*/ BSTR bstrExpression)
	{
		VSL_DEFINE_MOCK_METHOD(SetExpression)

		VSL_CHECK_VALIDVALUE_BSTR(bstrExpression);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBaseWindowHandleValidValues
	{
		/*[out]*/ HWND* phwnd;
		HRESULT retValue;
	};

	STDMETHOD(GetBaseWindowHandle)(
		/*[out]*/ HWND* phwnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetBaseWindowHandle)

		VSL_SET_VALIDVALUE(phwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsErrorTipValidValues
	{
		/*[out]*/ BOOL* pbIsError;
		HRESULT retValue;
	};

	STDMETHOD(IsErrorTip)(
		/*[out]*/ BOOL* pbIsError)
	{
		VSL_DEFINE_MOCK_METHOD(IsErrorTip)

		VSL_SET_VALIDVALUE(pbIsError);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsOpenValidValues
	{
		/*[out]*/ BOOL* pbIsOpen;
		HRESULT retValue;
	};

	STDMETHOD(IsOpen)(
		/*[out]*/ BOOL* pbIsOpen)
	{
		VSL_DEFINE_MOCK_METHOD(IsOpen)

		VSL_SET_VALIDVALUE(pbIsOpen);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSENHANCEDDATATIP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
