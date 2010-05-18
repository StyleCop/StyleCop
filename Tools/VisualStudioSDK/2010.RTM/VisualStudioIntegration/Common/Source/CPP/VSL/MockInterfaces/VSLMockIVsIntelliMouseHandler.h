/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLIMOUSEHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLIMOUSEHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsIntelliMouseHandlerNotImpl :
	public IVsIntelliMouseHandler
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntelliMouseHandlerNotImpl)

public:

	typedef IVsIntelliMouseHandler Interface;

	STDMETHOD(IsMouseWheelRotationMessage)(
		/*[in]*/ UINT /*msg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HandleWheelRotation)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ WPARAM /*wp*/,
		/*[in]*/ DWORD /*dwStyle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HandleWheelButtonDown)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ DWORD /*dwStyle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MouseWheelPresent)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMouseCursor_)(
		/*[in]*/ POINT /*ptOrg*/,
		/*[in]*/ POINT /*ptNew*/,
		/*[in]*/ UINT /*idCurOrg*/,
		/*[in]*/ UINT /*uNeutralRadius*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadBitmap_)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ UINT /*idbmp*/,
		/*[in]*/ UINT /*idcur*/,
		/*[in]*/ POINT /*ptOrg*/,
		/*[in]*/ DWORD* /*lpPanBitmap*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DrawBitmap_)(
		/*[in]*/ DWORD* /*lpPanBitmap*/,
		/*[in]*/ BOOL /*fErase*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMouseWheelMsg_)(
		/*[out]*/ UINT* /*uMsg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteBitmap_)(
		/*[in]*/ DWORD* /*lpPanBitmap*/)VSL_STDMETHOD_NOTIMPL
};

class IVsIntelliMouseHandlerMockImpl :
	public IVsIntelliMouseHandler,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntelliMouseHandlerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntelliMouseHandlerMockImpl)

	typedef IVsIntelliMouseHandler Interface;
	struct IsMouseWheelRotationMessageValidValues
	{
		/*[in]*/ UINT msg;
		HRESULT retValue;
	};

	STDMETHOD(IsMouseWheelRotationMessage)(
		/*[in]*/ UINT msg)
	{
		VSL_DEFINE_MOCK_METHOD(IsMouseWheelRotationMessage)

		VSL_CHECK_VALIDVALUE(msg);

		VSL_RETURN_VALIDVALUES();
	}
	struct HandleWheelRotationValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ WPARAM wp;
		/*[in]*/ DWORD dwStyle;
		HRESULT retValue;
	};

	STDMETHOD(HandleWheelRotation)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ WPARAM wp,
		/*[in]*/ DWORD dwStyle)
	{
		VSL_DEFINE_MOCK_METHOD(HandleWheelRotation)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(wp);

		VSL_CHECK_VALIDVALUE(dwStyle);

		VSL_RETURN_VALIDVALUES();
	}
	struct HandleWheelButtonDownValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ DWORD dwStyle;
		HRESULT retValue;
	};

	STDMETHOD(HandleWheelButtonDown)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ DWORD dwStyle)
	{
		VSL_DEFINE_MOCK_METHOD(HandleWheelButtonDown)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(dwStyle);

		VSL_RETURN_VALIDVALUES();
	}
	struct MouseWheelPresentValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(MouseWheelPresent)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(MouseWheelPresent)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetMouseCursor_ValidValues
	{
		/*[in]*/ POINT ptOrg;
		/*[in]*/ POINT ptNew;
		/*[in]*/ UINT idCurOrg;
		/*[in]*/ UINT uNeutralRadius;
		HRESULT retValue;
	};

	STDMETHOD(SetMouseCursor_)(
		/*[in]*/ POINT ptOrg,
		/*[in]*/ POINT ptNew,
		/*[in]*/ UINT idCurOrg,
		/*[in]*/ UINT uNeutralRadius)
	{
		VSL_DEFINE_MOCK_METHOD(SetMouseCursor_)

		VSL_CHECK_VALIDVALUE(ptOrg);

		VSL_CHECK_VALIDVALUE(ptNew);

		VSL_CHECK_VALIDVALUE(idCurOrg);

		VSL_CHECK_VALIDVALUE(uNeutralRadius);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadBitmap_ValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ UINT idbmp;
		/*[in]*/ UINT idcur;
		/*[in]*/ POINT ptOrg;
		/*[in]*/ DWORD* lpPanBitmap;
		HRESULT retValue;
	};

	STDMETHOD(LoadBitmap_)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ UINT idbmp,
		/*[in]*/ UINT idcur,
		/*[in]*/ POINT ptOrg,
		/*[in]*/ DWORD* lpPanBitmap)
	{
		VSL_DEFINE_MOCK_METHOD(LoadBitmap_)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(idbmp);

		VSL_CHECK_VALIDVALUE(idcur);

		VSL_CHECK_VALIDVALUE(ptOrg);

		VSL_CHECK_VALIDVALUE_POINTER(lpPanBitmap);

		VSL_RETURN_VALIDVALUES();
	}
	struct DrawBitmap_ValidValues
	{
		/*[in]*/ DWORD* lpPanBitmap;
		/*[in]*/ BOOL fErase;
		HRESULT retValue;
	};

	STDMETHOD(DrawBitmap_)(
		/*[in]*/ DWORD* lpPanBitmap,
		/*[in]*/ BOOL fErase)
	{
		VSL_DEFINE_MOCK_METHOD(DrawBitmap_)

		VSL_CHECK_VALIDVALUE_POINTER(lpPanBitmap);

		VSL_CHECK_VALIDVALUE(fErase);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMouseWheelMsg_ValidValues
	{
		/*[out]*/ UINT* uMsg;
		HRESULT retValue;
	};

	STDMETHOD(GetMouseWheelMsg_)(
		/*[out]*/ UINT* uMsg)
	{
		VSL_DEFINE_MOCK_METHOD(GetMouseWheelMsg_)

		VSL_SET_VALIDVALUE(uMsg);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteBitmap_ValidValues
	{
		/*[in]*/ DWORD* lpPanBitmap;
		HRESULT retValue;
	};

	STDMETHOD(DeleteBitmap_)(
		/*[in]*/ DWORD* lpPanBitmap)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteBitmap_)

		VSL_CHECK_VALIDVALUE_POINTER(lpPanBitmap);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLIMOUSEHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
