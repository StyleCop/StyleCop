/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSWITCHTOOLWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSWITCHTOOLWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSwitchToolWindowNotImpl :
	public IVsSwitchToolWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSwitchToolWindowNotImpl)

public:

	typedef IVsSwitchToolWindow Interface;

	STDMETHOD(QueryToolWindow)(
		/*[in]*/ REFGUID /*guidToolWindow*/,
		/*[out]*/ GUID* /*guidToolSwitch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSwitchedPane)(
		/*[in]*/ REFGUID /*guidToolSwitch*/,
		/*[in]*/ IVsWindowFrame* /*pFrame*/,
		/*[out]*/ IVsWindowPane** /*pPane*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSwitchToolWindowMockImpl :
	public IVsSwitchToolWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSwitchToolWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSwitchToolWindowMockImpl)

	typedef IVsSwitchToolWindow Interface;
	struct QueryToolWindowValidValues
	{
		/*[in]*/ REFGUID guidToolWindow;
		/*[out]*/ GUID* guidToolSwitch;
		HRESULT retValue;
	};

	STDMETHOD(QueryToolWindow)(
		/*[in]*/ REFGUID guidToolWindow,
		/*[out]*/ GUID* guidToolSwitch)
	{
		VSL_DEFINE_MOCK_METHOD(QueryToolWindow)

		VSL_CHECK_VALIDVALUE(guidToolWindow);

		VSL_SET_VALIDVALUE(guidToolSwitch);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSwitchedPaneValidValues
	{
		/*[in]*/ REFGUID guidToolSwitch;
		/*[in]*/ IVsWindowFrame* pFrame;
		/*[out]*/ IVsWindowPane** pPane;
		HRESULT retValue;
	};

	STDMETHOD(GetSwitchedPane)(
		/*[in]*/ REFGUID guidToolSwitch,
		/*[in]*/ IVsWindowFrame* pFrame,
		/*[out]*/ IVsWindowPane** pPane)
	{
		VSL_DEFINE_MOCK_METHOD(GetSwitchedPane)

		VSL_CHECK_VALIDVALUE(guidToolSwitch);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFrame);

		VSL_SET_VALIDVALUE_INTERFACE(pPane);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSWITCHTOOLWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
