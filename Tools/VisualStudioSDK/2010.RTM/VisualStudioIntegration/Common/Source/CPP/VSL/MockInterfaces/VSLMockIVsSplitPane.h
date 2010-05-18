/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSPLITPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSPLITPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSplitPaneNotImpl :
	public IVsSplitPane
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSplitPaneNotImpl)

public:

	typedef IVsSplitPane Interface;

	STDMETHOD(SetParentSplitter)(
		/*[in]*/ IVsSplitter* /*pSplitter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParentSplitter)(
		/*[out]*/ IVsSplitter** /*ppSplitter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFocus)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPosition)(
		/*[in]*/ long /*iLeft*/,
		/*[in]*/ long /*iTop*/,
		/*[in]*/ long /*iRight*/,
		/*[in]*/ long /*iBottom*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPosition)(
		/*[out]*/ long* /*piLeft*/,
		/*[out]*/ long* /*piTop*/,
		/*[out]*/ long* /*piRight*/,
		/*[out]*/ long* /*piBottom*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizeExtents)(
		/*[out]*/ long* /*piMinHorz*/,
		/*[out]*/ long* /*piMaxHorz*/,
		/*[out]*/ long* /*piMinVert*/,
		/*[out]*/ long* /*piMaxVert*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetParentWindow)(
		/*[out]*/ HWND* /*phwndParent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPaneFlags)(
		/*[out]*/ DWORD* /*pdwPaneFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClosePane)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyPane)(
		/*[in]*/ SPLITNOTIFYCODE /*iCode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DetachPane)()VSL_STDMETHOD_NOTIMPL
};

class IVsSplitPaneMockImpl :
	public IVsSplitPane,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSplitPaneMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSplitPaneMockImpl)

	typedef IVsSplitPane Interface;
	struct SetParentSplitterValidValues
	{
		/*[in]*/ IVsSplitter* pSplitter;
		HRESULT retValue;
	};

	STDMETHOD(SetParentSplitter)(
		/*[in]*/ IVsSplitter* pSplitter)
	{
		VSL_DEFINE_MOCK_METHOD(SetParentSplitter)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSplitter);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParentSplitterValidValues
	{
		/*[out]*/ IVsSplitter** ppSplitter;
		HRESULT retValue;
	};

	STDMETHOD(GetParentSplitter)(
		/*[out]*/ IVsSplitter** ppSplitter)
	{
		VSL_DEFINE_MOCK_METHOD(GetParentSplitter)

		VSL_SET_VALIDVALUE_INTERFACE(ppSplitter);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFocusValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetFocus)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetFocus)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPositionValidValues
	{
		/*[in]*/ long iLeft;
		/*[in]*/ long iTop;
		/*[in]*/ long iRight;
		/*[in]*/ long iBottom;
		HRESULT retValue;
	};

	STDMETHOD(SetPosition)(
		/*[in]*/ long iLeft,
		/*[in]*/ long iTop,
		/*[in]*/ long iRight,
		/*[in]*/ long iBottom)
	{
		VSL_DEFINE_MOCK_METHOD(SetPosition)

		VSL_CHECK_VALIDVALUE(iLeft);

		VSL_CHECK_VALIDVALUE(iTop);

		VSL_CHECK_VALIDVALUE(iRight);

		VSL_CHECK_VALIDVALUE(iBottom);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPositionValidValues
	{
		/*[out]*/ long* piLeft;
		/*[out]*/ long* piTop;
		/*[out]*/ long* piRight;
		/*[out]*/ long* piBottom;
		HRESULT retValue;
	};

	STDMETHOD(GetPosition)(
		/*[out]*/ long* piLeft,
		/*[out]*/ long* piTop,
		/*[out]*/ long* piRight,
		/*[out]*/ long* piBottom)
	{
		VSL_DEFINE_MOCK_METHOD(GetPosition)

		VSL_SET_VALIDVALUE(piLeft);

		VSL_SET_VALIDVALUE(piTop);

		VSL_SET_VALIDVALUE(piRight);

		VSL_SET_VALIDVALUE(piBottom);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeExtentsValidValues
	{
		/*[out]*/ long* piMinHorz;
		/*[out]*/ long* piMaxHorz;
		/*[out]*/ long* piMinVert;
		/*[out]*/ long* piMaxVert;
		HRESULT retValue;
	};

	STDMETHOD(GetSizeExtents)(
		/*[out]*/ long* piMinHorz,
		/*[out]*/ long* piMaxHorz,
		/*[out]*/ long* piMinVert,
		/*[out]*/ long* piMaxVert)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizeExtents)

		VSL_SET_VALIDVALUE(piMinHorz);

		VSL_SET_VALIDVALUE(piMaxHorz);

		VSL_SET_VALIDVALUE(piMinVert);

		VSL_SET_VALIDVALUE(piMaxVert);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetParentWindowValidValues
	{
		/*[out]*/ HWND* phwndParent;
		HRESULT retValue;
	};

	STDMETHOD(GetParentWindow)(
		/*[out]*/ HWND* phwndParent)
	{
		VSL_DEFINE_MOCK_METHOD(GetParentWindow)

		VSL_SET_VALIDVALUE(phwndParent);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPaneFlagsValidValues
	{
		/*[out]*/ DWORD* pdwPaneFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetPaneFlags)(
		/*[out]*/ DWORD* pdwPaneFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetPaneFlags)

		VSL_SET_VALIDVALUE(pdwPaneFlags);

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
	struct NotifyPaneValidValues
	{
		/*[in]*/ SPLITNOTIFYCODE iCode;
		HRESULT retValue;
	};

	STDMETHOD(NotifyPane)(
		/*[in]*/ SPLITNOTIFYCODE iCode)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyPane)

		VSL_CHECK_VALIDVALUE(iCode);

		VSL_RETURN_VALIDVALUES();
	}
	struct DetachPaneValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DetachPane)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DetachPane)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSPLITPANE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
