/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSPLITROOT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSPLITROOT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSplitRootNotImpl :
	public IVsSplitRoot
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSplitRootNotImpl)

public:

	typedef IVsSplitRoot Interface;

	STDMETHOD(GetRootSplitter)(
		/*[out]*/ IVsSplitter** /*ppPane*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWindowHandle)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPane)(
		/*[in]*/ PANETYPE /*paneType*/,
		/*[out]*/ IVsSplitPane** /*ppPane*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSplitRootMockImpl :
	public IVsSplitRoot,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSplitRootMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSplitRootMockImpl)

	typedef IVsSplitRoot Interface;
	struct GetRootSplitterValidValues
	{
		/*[out]*/ IVsSplitter** ppPane;
		HRESULT retValue;
	};

	STDMETHOD(GetRootSplitter)(
		/*[out]*/ IVsSplitter** ppPane)
	{
		VSL_DEFINE_MOCK_METHOD(GetRootSplitter)

		VSL_SET_VALIDVALUE_INTERFACE(ppPane);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWindowHandleValidValues
	{
		/*[out]*/ HWND* phwnd;
		HRESULT retValue;
	};

	STDMETHOD(GetWindowHandle)(
		/*[out]*/ HWND* phwnd)
	{
		VSL_DEFINE_MOCK_METHOD(GetWindowHandle)

		VSL_SET_VALIDVALUE(phwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPaneValidValues
	{
		/*[in]*/ PANETYPE paneType;
		/*[out]*/ IVsSplitPane** ppPane;
		HRESULT retValue;
	};

	STDMETHOD(GetPane)(
		/*[in]*/ PANETYPE paneType,
		/*[out]*/ IVsSplitPane** ppPane)
	{
		VSL_DEFINE_MOCK_METHOD(GetPane)

		VSL_CHECK_VALIDVALUE(paneType);

		VSL_SET_VALIDVALUE_INTERFACE(ppPane);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSPLITROOT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
