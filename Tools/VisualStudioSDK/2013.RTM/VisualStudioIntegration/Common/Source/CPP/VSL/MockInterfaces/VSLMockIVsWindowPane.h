/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWINDOWPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWINDOWPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWindowPaneNotImpl :
	public IVsWindowPane
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowPaneNotImpl)

public:

	typedef IVsWindowPane Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreatePaneWindow)(
		/*[in]*/ HWND /*hwndParent*/,
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[in]*/ int /*cx*/,
		/*[in]*/ int /*cy*/,
		/*[out]*/ HWND* /*hwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultSize)(
		/*[out]*/ SIZE* /*psize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClosePane)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadViewState)(
		/*[in]*/ IStream* /*pstream*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveViewState)(
		/*[in]*/ IStream* /*pstream*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG /*lpmsg*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWindowPaneMockImpl :
	public IVsWindowPane,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowPaneMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWindowPaneMockImpl)

	typedef IVsWindowPane Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IServiceProvider* pSP;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* pSP)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreatePaneWindowValidValues
	{
		/*[in]*/ HWND hwndParent;
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[in]*/ int cx;
		/*[in]*/ int cy;
		/*[out]*/ HWND* hwnd;
		HRESULT retValue;
	};

	STDMETHOD(CreatePaneWindow)(
		/*[in]*/ HWND hwndParent,
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[in]*/ int cx,
		/*[in]*/ int cy,
		/*[out]*/ HWND* hwnd)
	{
		VSL_DEFINE_MOCK_METHOD(CreatePaneWindow)

		VSL_CHECK_VALIDVALUE(hwndParent);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(cx);

		VSL_CHECK_VALIDVALUE(cy);

		VSL_SET_VALIDVALUE(hwnd);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultSizeValidValues
	{
		/*[out]*/ SIZE* psize;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultSize)(
		/*[out]*/ SIZE* psize)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultSize)

		VSL_SET_VALIDVALUE(psize);

		VSL_RETURN_VALIDVALUES();
	}
	struct ClosePaneValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ClosePane)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ClosePane)

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadViewStateValidValues
	{
		/*[in]*/ IStream* pstream;
		HRESULT retValue;
	};

	STDMETHOD(LoadViewState)(
		/*[in]*/ IStream* pstream)
	{
		VSL_DEFINE_MOCK_METHOD(LoadViewState)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pstream);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveViewStateValidValues
	{
		/*[in]*/ IStream* pstream;
		HRESULT retValue;
	};

	STDMETHOD(SaveViewState)(
		/*[in]*/ IStream* pstream)
	{
		VSL_DEFINE_MOCK_METHOD(SaveViewState)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pstream);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateAcceleratorValidValues
	{
		/*[in]*/ LPMSG lpmsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG lpmsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelerator)

		VSL_CHECK_VALIDVALUE(lpmsg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWINDOWPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
