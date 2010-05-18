/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMETHODTIPWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMETHODTIPWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsMethodTipWindowNotImpl :
	public IVsMethodTipWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodTipWindowNotImpl)

public:

	typedef IVsMethodTipWindow Interface;

	STDMETHOD(SetMethodData)(
		/*[in]*/ IVsMethodData* /*pMethodData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContextStream)(
		/*[out]*/ long* /*piPos*/,
		/*[out]*/ long* /*piLength*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizePreferences)(
		/*[out]*/ const RECT* /*prcCtxBounds*/,
		/*[out]*/ TIPSIZEDATA* /*pSizeData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Paint)(
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ const RECT* /*prc*/)VSL_STDMETHOD_NOTIMPL

	virtual void STDMETHODCALLTYPE Dismiss(){ return ; }

	virtual LRESULT STDMETHODCALLTYPE WndProc(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ UINT /*iMsg*/,
		/*[in]*/ WPARAM /*wParam*/,
		/*[in]*/ LPARAM /*lParam*/){ return LRESULT(); }
};

class IVsMethodTipWindowMockImpl :
	public IVsMethodTipWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMethodTipWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMethodTipWindowMockImpl)

	typedef IVsMethodTipWindow Interface;
	struct SetMethodDataValidValues
	{
		/*[in]*/ IVsMethodData* pMethodData;
		HRESULT retValue;
	};

	STDMETHOD(SetMethodData)(
		/*[in]*/ IVsMethodData* pMethodData)
	{
		VSL_DEFINE_MOCK_METHOD(SetMethodData)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMethodData);

		VSL_RETURN_VALIDVALUES();
	}
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
		/*[out]*/ RECT* prcCtxBounds;
		/*[out]*/ TIPSIZEDATA* pSizeData;
		HRESULT retValue;
	};

	STDMETHOD(GetSizePreferences)(
		/*[out]*/ const RECT* prcCtxBounds,
		/*[out]*/ TIPSIZEDATA* pSizeData)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizePreferences)

		VSL_SET_VALIDVALUE_CONST(prcCtxBounds, RECT*);

		VSL_SET_VALIDVALUE(pSizeData);

		VSL_RETURN_VALIDVALUES();
	}
	struct PaintValidValues
	{
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* prc;
		HRESULT retValue;
	};

	STDMETHOD(Paint)(
		/*[in]*/ HDC hdc,
		/*[in]*/ const RECT* prc)
	{
		VSL_DEFINE_MOCK_METHOD(Paint)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(prc);

		VSL_RETURN_VALIDVALUES();
	}

	virtual void _stdcall Dismiss()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(Dismiss)

	}
	struct WndProcValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ UINT iMsg;
		/*[in]*/ WPARAM wParam;
		/*[in]*/ LPARAM lParam;
		LRESULT retValue;
	};

	virtual LRESULT _stdcall WndProc(
		/*[in]*/ HWND hwnd,
		/*[in]*/ UINT iMsg,
		/*[in]*/ WPARAM wParam,
		/*[in]*/ LPARAM lParam)
	{
		VSL_DEFINE_MOCK_METHOD(WndProc)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(iMsg);

		VSL_CHECK_VALIDVALUE(wParam);

		VSL_CHECK_VALIDVALUE(lParam);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMETHODTIPWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
