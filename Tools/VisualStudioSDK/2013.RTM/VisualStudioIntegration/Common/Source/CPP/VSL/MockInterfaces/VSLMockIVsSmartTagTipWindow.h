/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSMARTTAGTIPWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSMARTTAGTIPWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSmartTagTipWindowNotImpl :
	public IVsSmartTagTipWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSmartTagTipWindowNotImpl)

public:

	typedef IVsSmartTagTipWindow Interface;

	STDMETHOD(GetContextStream)(
		/*[out]*/ long* /*piPos*/,
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizePreferences)(
		/*[in]*/ const RECT* /*prcCtxBounds*/,
		/*[out]*/ SMARTTAGSIZEDATA* /*pSizeData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Paint)(
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ const RECT* /*prc*/,
		/*[in]*/ COLORREF /*pColor*/,
		/*[in]*/ COLORREF /*pColorText*/,
		/*[in]*/ BOOL /*fSel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Dismiss)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WndProc)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ UINT /*iMsg*/,
		/*[in]*/ WPARAM /*wParam*/,
		/*[in]*/ LPARAM /*lParam*/,
		/*[in]*/ LRESULT* /*pLResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSmartTagData)(
		/*[in]*/ IVsSmartTagData* /*pSmartTagData*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSmartTagTipWindowMockImpl :
	public IVsSmartTagTipWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSmartTagTipWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSmartTagTipWindowMockImpl)

	typedef IVsSmartTagTipWindow Interface;
	struct GetContextStreamValidValues
	{
		/*[out]*/ long* piPos;
		/*[out]*/ long* piLength;
		HRESULT retValue;
	};

	STDMETHOD(GetContextStream)(
		/*[out]*/ long* piPos,
		/*[out]*/ long* piLength)
	{
		VSL_DEFINE_MOCK_METHOD(GetContextStream)

		VSL_SET_VALIDVALUE(piPos);

		VSL_SET_VALIDVALUE(piLength);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizePreferencesValidValues
	{
		/*[in]*/ RECT* prcCtxBounds;
		/*[out]*/ SMARTTAGSIZEDATA* pSizeData;
		HRESULT retValue;
	};

	STDMETHOD(GetSizePreferences)(
		/*[in]*/ const RECT* prcCtxBounds,
		/*[out]*/ SMARTTAGSIZEDATA* pSizeData)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizePreferences)

		VSL_CHECK_VALIDVALUE_POINTER(prcCtxBounds);

		VSL_SET_VALIDVALUE(pSizeData);

		VSL_RETURN_VALIDVALUES();
	}
	struct PaintValidValues
	{
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* prc;
		/*[in]*/ COLORREF pColor;
		/*[in]*/ COLORREF pColorText;
		/*[in]*/ BOOL fSel;
		HRESULT retValue;
	};

	STDMETHOD(Paint)(
		/*[in]*/ HDC hdc,
		/*[in]*/ const RECT* prc,
		/*[in]*/ COLORREF pColor,
		/*[in]*/ COLORREF pColorText,
		/*[in]*/ BOOL fSel)
	{
		VSL_DEFINE_MOCK_METHOD(Paint)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(prc);

		VSL_CHECK_VALIDVALUE(pColor);

		VSL_CHECK_VALIDVALUE(pColorText);

		VSL_CHECK_VALIDVALUE(fSel);

		VSL_RETURN_VALIDVALUES();
	}
	struct DismissValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Dismiss)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Dismiss)

		VSL_RETURN_VALIDVALUES();
	}
	struct WndProcValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ UINT iMsg;
		/*[in]*/ WPARAM wParam;
		/*[in]*/ LPARAM lParam;
		/*[in]*/ LRESULT* pLResult;
		HRESULT retValue;
	};

	STDMETHOD(WndProc)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ UINT iMsg,
		/*[in]*/ WPARAM wParam,
		/*[in]*/ LPARAM lParam,
		/*[in]*/ LRESULT* pLResult)
	{
		VSL_DEFINE_MOCK_METHOD(WndProc)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(iMsg);

		VSL_CHECK_VALIDVALUE(wParam);

		VSL_CHECK_VALIDVALUE(lParam);

		VSL_CHECK_VALIDVALUE_POINTER(pLResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSmartTagDataValidValues
	{
		/*[in]*/ IVsSmartTagData* pSmartTagData;
		HRESULT retValue;
	};

	STDMETHOD(SetSmartTagData)(
		/*[in]*/ IVsSmartTagData* pSmartTagData)
	{
		VSL_DEFINE_MOCK_METHOD(SetSmartTagData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSmartTagData);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSMARTTAGTIPWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
