/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleWindowNotImpl :
	public IOleWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleWindowNotImpl)

public:

	typedef IOleWindow Interface;

	STDMETHOD(GetWindow)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ContextSensitiveHelp)(
		/*[in]*/ BOOL /*fEnterMode*/)VSL_STDMETHOD_NOTIMPL
};

class IOleWindowMockImpl :
	public IOleWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleWindowMockImpl)

	typedef IOleWindow Interface;
	struct GetWindowValidValues
	{
		/*[out]*/ HWND* phwnd;
		HRESULT retValue;
	};

	STDMETHOD(GetWindow)(
		/*[out]*/ HWND* phwnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetWindow)

		VSL_SET_VALIDVALUE(phwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct ContextSensitiveHelpValidValues
	{
		/*[in]*/ BOOL fEnterMode;
		HRESULT retValue;
	};

	STDMETHOD(ContextSensitiveHelp)(
		/*[in]*/ BOOL fEnterMode)
	{
		VSL_DEFINE_MOCK_METHOD(ContextSensitiveHelp)

		VSL_CHECK_VALIDVALUE(fEnterMode);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLEWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
