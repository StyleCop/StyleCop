/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINSERTIONUI_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINSERTIONUI_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsInsertionUINotImpl :
	public IVsInsertionUI
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsInsertionUINotImpl)

public:

	typedef IVsInsertionUI Interface;

	STDMETHOD(GetWindowHandle)(
		/*[out]*/ HWND* /*hwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Hide)()VSL_STDMETHOD_NOTIMPL
};

class IVsInsertionUIMockImpl :
	public IVsInsertionUI,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsInsertionUIMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsInsertionUIMockImpl)

	typedef IVsInsertionUI Interface;
	struct GetWindowHandleValidValues
	{
		/*[out]*/ HWND* hwnd;
		HRESULT retValue;
	};

	STDMETHOD(GetWindowHandle)(
		/*[out]*/ HWND* hwnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetWindowHandle)

		VSL_SET_VALIDVALUE(hwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct HideValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Hide)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Hide)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINSERTIONUI_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
