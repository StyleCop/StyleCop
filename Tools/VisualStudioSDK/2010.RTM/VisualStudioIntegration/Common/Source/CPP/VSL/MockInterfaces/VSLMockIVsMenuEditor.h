/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMENUEDITOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMENUEDITOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMenuEditorNotImpl :
	public IVsMenuEditor
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMenuEditorNotImpl)

public:

	typedef IVsMenuEditor Interface;

	STDMETHOD(AddMenuItem)(
		/*[in]*/ IVsMenuItem* /*pIMI*/,
		/*[in]*/ IVsMenuItem* /*pIMIParent*/,
		/*[in]*/ IVsMenuItem* /*pIMIInsertAfter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnChange)(
		/*[in]*/ IVsMenuItem* /*pIMI*/,
		/*[in]*/ VSMEPROPID /*PropId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectionChange)(
		/*[in]*/ IVsMenuItem* /*pIMI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemRect)(
		/*[in]*/ IVsMenuItem* /*pIMI*/,
		/*[out]*/ LPRECT /*prc*/,
		/*[in]*/ BOOL /*fForScrolling*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHeight)(
		/*[out]*/ INT* /*piHeight*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Filter)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ UINT /*uMsg*/,
		/*[in]*/ WPARAM /*wParam*/,
		/*[in]*/ LPARAM /*lParam*/,
		/*[out]*/ LRESULT* /*plResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsActive)(
		/*[out,retval]*/ BOOL* /*pfActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUIState)(
		/*[out,retval]*/ VSMEUISTATE* /*pState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteMenuItem)(
		/*[in]*/ IVsMenuItem* /*pIMI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SelectionChangeFocus)(
		/*[in]*/ IVsMenuItem* /*pIMI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG /*lpMsg*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMenuEditorMockImpl :
	public IVsMenuEditor,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMenuEditorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMenuEditorMockImpl)

	typedef IVsMenuEditor Interface;
	struct AddMenuItemValidValues
	{
		/*[in]*/ IVsMenuItem* pIMI;
		/*[in]*/ IVsMenuItem* pIMIParent;
		/*[in]*/ IVsMenuItem* pIMIInsertAfter;
		HRESULT retValue;
	};

	STDMETHOD(AddMenuItem)(
		/*[in]*/ IVsMenuItem* pIMI,
		/*[in]*/ IVsMenuItem* pIMIParent,
		/*[in]*/ IVsMenuItem* pIMIInsertAfter)
	{
		VSL_DEFINE_MOCK_METHOD(AddMenuItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMI);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMIParent);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMIInsertAfter);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnChangeValidValues
	{
		/*[in]*/ IVsMenuItem* pIMI;
		/*[in]*/ VSMEPROPID PropId;
		HRESULT retValue;
	};

	STDMETHOD(OnChange)(
		/*[in]*/ IVsMenuItem* pIMI,
		/*[in]*/ VSMEPROPID PropId)
	{
		VSL_DEFINE_MOCK_METHOD(OnChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMI);

		VSL_CHECK_VALIDVALUE(PropId);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectionChangeValidValues
	{
		/*[in]*/ IVsMenuItem* pIMI;
		HRESULT retValue;
	};

	STDMETHOD(SelectionChange)(
		/*[in]*/ IVsMenuItem* pIMI)
	{
		VSL_DEFINE_MOCK_METHOD(SelectionChange)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMI);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemRectValidValues
	{
		/*[in]*/ IVsMenuItem* pIMI;
		/*[out]*/ LPRECT prc;
		/*[in]*/ BOOL fForScrolling;
		HRESULT retValue;
	};

	STDMETHOD(GetItemRect)(
		/*[in]*/ IVsMenuItem* pIMI,
		/*[out]*/ LPRECT prc,
		/*[in]*/ BOOL fForScrolling)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemRect)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMI);

		VSL_SET_VALIDVALUE(prc);

		VSL_CHECK_VALIDVALUE(fForScrolling);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHeightValidValues
	{
		/*[out]*/ INT* piHeight;
		HRESULT retValue;
	};

	STDMETHOD(GetHeight)(
		/*[out]*/ INT* piHeight)
	{
		VSL_DEFINE_MOCK_METHOD(GetHeight)

		VSL_SET_VALIDVALUE(piHeight);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ UINT uMsg;
		/*[in]*/ WPARAM wParam;
		/*[in]*/ LPARAM lParam;
		/*[out]*/ LRESULT* plResult;
		HRESULT retValue;
	};

	STDMETHOD(Filter)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ UINT uMsg,
		/*[in]*/ WPARAM wParam,
		/*[in]*/ LPARAM lParam,
		/*[out]*/ LRESULT* plResult)
	{
		VSL_DEFINE_MOCK_METHOD(Filter)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(uMsg);

		VSL_CHECK_VALIDVALUE(wParam);

		VSL_CHECK_VALIDVALUE(lParam);

		VSL_SET_VALIDVALUE(plResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsActiveValidValues
	{
		/*[out,retval]*/ BOOL* pfActive;
		HRESULT retValue;
	};

	STDMETHOD(IsActive)(
		/*[out,retval]*/ BOOL* pfActive)
	{
		VSL_DEFINE_MOCK_METHOD(IsActive)

		VSL_SET_VALIDVALUE(pfActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUIStateValidValues
	{
		/*[out,retval]*/ VSMEUISTATE* pState;
		HRESULT retValue;
	};

	STDMETHOD(GetUIState)(
		/*[out,retval]*/ VSMEUISTATE* pState)
	{
		VSL_DEFINE_MOCK_METHOD(GetUIState)

		VSL_SET_VALIDVALUE(pState);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteMenuItemValidValues
	{
		/*[in]*/ IVsMenuItem* pIMI;
		HRESULT retValue;
	};

	STDMETHOD(DeleteMenuItem)(
		/*[in]*/ IVsMenuItem* pIMI)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteMenuItem)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMI);

		VSL_RETURN_VALIDVALUES();
	}
	struct SelectionChangeFocusValidValues
	{
		/*[in]*/ IVsMenuItem* pIMI;
		HRESULT retValue;
	};

	STDMETHOD(SelectionChangeFocus)(
		/*[in]*/ IVsMenuItem* pIMI)
	{
		VSL_DEFINE_MOCK_METHOD(SelectionChangeFocus)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIMI);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateAcceleratorValidValues
	{
		/*[in]*/ LPMSG lpMsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG lpMsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelerator)

		VSL_CHECK_VALIDVALUE(lpMsg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMENUEDITOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
