/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTVIEWEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTVIEWEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextViewExNotImpl :
	public IVsTextViewEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewExNotImpl)

public:

	typedef IVsTextViewEx Interface;

	STDMETHOD(SetHoverWaitTimer)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PersistOutliningState)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateSmartTagWindow)(
		/*[in]*/ IVsSmartTagTipWindow* /*pSmartTagWnd*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSmartTagRect)(
		/*[out]*/ RECT* /*rcSmartTag*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InvokeInsertionUI)(
		/*[in]*/ IVsCompletionSet* /*pCompSet*/,
		/*[in]*/ BSTR /*bstrPrefixText*/,
		/*[in]*/ BSTR /*bstrCompletionChar*/,
		/*[out]*/ IVsInsertionUI** /*pInsertionUI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWindowFrame)(
		/*[out]*/ IUnknown** /*ppFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsCompletorWindowActive)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClusterRange)(
		/*[in]*/ long /*iLine*/,
		/*[in]*/ INT /*iDisplayCol*/,
		/*[out]*/ INT* /*picCharacter*/,
		/*[out]*/ INT* /*piStartCol*/,
		/*[out]*/ INT* /*piEndCol*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetIgnoreMarkerTypes)(
		/*[in]*/ long /*iCountMarkerTypes*/,
		/*[in]*/ DWORD* /*rgIgnoreMarkerTypes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AppendViewOnlyMarkerTypes)(
		/*[in]*/ unsigned int /*iCountViewMarkerOnly*/,
		/*[in]*/ const DWORD* /*rgViewMarkerOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveViewOnlyMarkerTypes)(
		/*[in]*/ unsigned int /*iCountViewMarkerOnly*/,
		/*[in]*/ const DWORD* /*rgViewMarkerOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBackgroundColorIndex)(
		/*[in]*/ long /*iBackgroundIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsExpansionUIActive)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsReadOnly)()VSL_STDMETHOD_NOTIMPL
};

class IVsTextViewExMockImpl :
	public IVsTextViewEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextViewExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextViewExMockImpl)

	typedef IVsTextViewEx Interface;
	struct SetHoverWaitTimerValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SetHoverWaitTimer)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SetHoverWaitTimer)

		VSL_RETURN_VALIDVALUES();
	}
	struct PersistOutliningStateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(PersistOutliningState)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(PersistOutliningState)

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateSmartTagWindowValidValues
	{
		/*[in]*/ IVsSmartTagTipWindow* pSmartTagWnd;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(UpdateSmartTagWindow)(
		/*[in]*/ IVsSmartTagTipWindow* pSmartTagWnd,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateSmartTagWindow)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSmartTagWnd);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSmartTagRectValidValues
	{
		/*[out]*/ RECT* rcSmartTag;
		HRESULT retValue;
	};

	STDMETHOD(GetSmartTagRect)(
		/*[out]*/ RECT* rcSmartTag)
	{
		VSL_DEFINE_MOCK_METHOD(GetSmartTagRect)

		VSL_SET_VALIDVALUE(rcSmartTag);

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeInsertionUIValidValues
	{
		/*[in]*/ IVsCompletionSet* pCompSet;
		/*[in]*/ BSTR bstrPrefixText;
		/*[in]*/ BSTR bstrCompletionChar;
		/*[out]*/ IVsInsertionUI** pInsertionUI;
		HRESULT retValue;
	};

	STDMETHOD(InvokeInsertionUI)(
		/*[in]*/ IVsCompletionSet* pCompSet,
		/*[in]*/ BSTR bstrPrefixText,
		/*[in]*/ BSTR bstrCompletionChar,
		/*[out]*/ IVsInsertionUI** pInsertionUI)
	{
		VSL_DEFINE_MOCK_METHOD(InvokeInsertionUI)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCompSet);

		VSL_CHECK_VALIDVALUE_BSTR(bstrPrefixText);

		VSL_CHECK_VALIDVALUE_BSTR(bstrCompletionChar);

		VSL_SET_VALIDVALUE_INTERFACE(pInsertionUI);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWindowFrameValidValues
	{
		/*[out]*/ IUnknown** ppFrame;
		HRESULT retValue;
	};

	STDMETHOD(GetWindowFrame)(
		/*[out]*/ IUnknown** ppFrame)
	{
		VSL_DEFINE_MOCK_METHOD(GetWindowFrame)

		VSL_SET_VALIDVALUE_INTERFACE(ppFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsCompletorWindowActiveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsCompletorWindowActive)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsCompletorWindowActive)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClusterRangeValidValues
	{
		/*[in]*/ long iLine;
		/*[in]*/ INT iDisplayCol;
		/*[out]*/ INT* picCharacter;
		/*[out]*/ INT* piStartCol;
		/*[out]*/ INT* piEndCol;
		HRESULT retValue;
	};

	STDMETHOD(GetClusterRange)(
		/*[in]*/ long iLine,
		/*[in]*/ INT iDisplayCol,
		/*[out]*/ INT* picCharacter,
		/*[out]*/ INT* piStartCol,
		/*[out]*/ INT* piEndCol)
	{
		VSL_DEFINE_MOCK_METHOD(GetClusterRange)

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iDisplayCol);

		VSL_SET_VALIDVALUE(picCharacter);

		VSL_SET_VALIDVALUE(piStartCol);

		VSL_SET_VALIDVALUE(piEndCol);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetIgnoreMarkerTypesValidValues
	{
		/*[in]*/ long iCountMarkerTypes;
		/*[in]*/ DWORD* rgIgnoreMarkerTypes;
		HRESULT retValue;
	};

	STDMETHOD(SetIgnoreMarkerTypes)(
		/*[in]*/ long iCountMarkerTypes,
		/*[in]*/ DWORD* rgIgnoreMarkerTypes)
	{
		VSL_DEFINE_MOCK_METHOD(SetIgnoreMarkerTypes)

		VSL_CHECK_VALIDVALUE(iCountMarkerTypes);

		VSL_CHECK_VALIDVALUE_POINTER(rgIgnoreMarkerTypes);

		VSL_RETURN_VALIDVALUES();
	}
	struct AppendViewOnlyMarkerTypesValidValues
	{
		/*[in]*/ unsigned int iCountViewMarkerOnly;
		/*[in]*/ DWORD* rgViewMarkerOnly;
		HRESULT retValue;
	};

	STDMETHOD(AppendViewOnlyMarkerTypes)(
		/*[in]*/ unsigned int iCountViewMarkerOnly,
		/*[in]*/ const DWORD* rgViewMarkerOnly)
	{
		VSL_DEFINE_MOCK_METHOD(AppendViewOnlyMarkerTypes)

		VSL_CHECK_VALIDVALUE(iCountViewMarkerOnly);

		VSL_CHECK_VALIDVALUE_POINTER(rgViewMarkerOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveViewOnlyMarkerTypesValidValues
	{
		/*[in]*/ unsigned int iCountViewMarkerOnly;
		/*[in]*/ DWORD* rgViewMarkerOnly;
		HRESULT retValue;
	};

	STDMETHOD(RemoveViewOnlyMarkerTypes)(
		/*[in]*/ unsigned int iCountViewMarkerOnly,
		/*[in]*/ const DWORD* rgViewMarkerOnly)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveViewOnlyMarkerTypes)

		VSL_CHECK_VALIDVALUE(iCountViewMarkerOnly);

		VSL_CHECK_VALIDVALUE_POINTER(rgViewMarkerOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBackgroundColorIndexValidValues
	{
		/*[in]*/ long iBackgroundIndex;
		HRESULT retValue;
	};

	STDMETHOD(SetBackgroundColorIndex)(
		/*[in]*/ long iBackgroundIndex)
	{
		VSL_DEFINE_MOCK_METHOD(SetBackgroundColorIndex)

		VSL_CHECK_VALIDVALUE(iBackgroundIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsExpansionUIActiveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsExpansionUIActive)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsExpansionUIActive)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsReadOnlyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsReadOnly)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsReadOnly)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTVIEWEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
