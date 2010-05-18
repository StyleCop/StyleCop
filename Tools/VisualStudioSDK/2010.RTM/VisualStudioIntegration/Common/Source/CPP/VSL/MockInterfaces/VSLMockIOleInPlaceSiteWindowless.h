/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEINPLACESITEWINDOWLESS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEINPLACESITEWINDOWLESS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleInPlaceSiteWindowlessNotImpl :
	public IOleInPlaceSiteWindowless
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceSiteWindowlessNotImpl)

public:

	typedef IOleInPlaceSiteWindowless Interface;

	STDMETHOD(CanWindowlessActivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCapture)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetCapture)(
		/*[in]*/ BOOL /*fCapture*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFocus)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFocus)(
		/*[in]*/ BOOL /*fFocus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDC)(
		/*[in]*/ LPCRECT /*pRect*/,
		/*[in]*/ DWORD /*grfFlags*/,
		/*[out]*/ HDC* /*phDC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseDC)(
		/*[in]*/ HDC /*hDC*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InvalidateRect)(
		/*[in]*/ LPCRECT /*pRect*/,
		/*[in]*/ BOOL /*fErase*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InvalidateRgn)(
		/*[in]*/ HRGN /*hRGN*/,
		/*[in]*/ BOOL /*fErase*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ScrollRect)(
		/*[in]*/ INT /*dx*/,
		/*[in]*/ INT /*dy*/,
		/*[in]*/ LPCRECT /*pRectScroll*/,
		/*[in]*/ LPCRECT /*pRectClip*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdjustRect)(
		/*[in,out]*/ LPRECT /*prc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDefWindowMessage)(
		/*[in]*/ UINT /*msg*/,
		/*[in]*/ WPARAM /*wParam*/,
		/*[in]*/ LPARAM /*lParam*/,
		/*[out]*/ LRESULT* /*plResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInPlaceActivateEx)(
		/*[out]*/ BOOL* /*pfNoRedraw*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInPlaceDeactivateEx)(
		/*[in]*/ BOOL /*fNoRedraw*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RequestUIActivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanInPlaceActivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInPlaceActivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnUIActivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWindowContext)(
		/*[out]*/ IOleInPlaceFrame** /*ppFrame*/,
		/*[out]*/ IOleInPlaceUIWindow** /*ppDoc*/,
		/*[out]*/ LPRECT /*lprcPosRect*/,
		/*[out]*/ LPRECT /*lprcClipRect*/,
		/*[in,out]*/ LPOLEINPLACEFRAMEINFO /*lpFrameInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Scroll)(
		/*[in]*/ SIZE /*scrollExtant*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnUIDeactivate)(
		/*[in]*/ BOOL /*fUndoable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInPlaceDeactivate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DiscardUndoState)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeactivateAndUndo)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnPosRectChange)(
		/*[in]*/ LPCRECT /*lprcPosRect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWindow)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ContextSensitiveHelp)(
		/*[in]*/ BOOL /*fEnterMode*/)VSL_STDMETHOD_NOTIMPL
};

class IOleInPlaceSiteWindowlessMockImpl :
	public IOleInPlaceSiteWindowless,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceSiteWindowlessMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleInPlaceSiteWindowlessMockImpl)

	typedef IOleInPlaceSiteWindowless Interface;
	struct CanWindowlessActivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanWindowlessActivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanWindowlessActivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCaptureValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(GetCapture)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GetCapture)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetCaptureValidValues
	{
		/*[in]*/ BOOL fCapture;
		HRESULT retValue;
	};

	STDMETHOD(SetCapture)(
		/*[in]*/ BOOL fCapture)
	{
		VSL_DEFINE_MOCK_METHOD(SetCapture)

		VSL_CHECK_VALIDVALUE(fCapture);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFocusValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(GetFocus)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(GetFocus)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFocusValidValues
	{
		/*[in]*/ BOOL fFocus;
		HRESULT retValue;
	};

	STDMETHOD(SetFocus)(
		/*[in]*/ BOOL fFocus)
	{
		VSL_DEFINE_MOCK_METHOD(SetFocus)

		VSL_CHECK_VALIDVALUE(fFocus);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDCValidValues
	{
		/*[in]*/ LPCRECT pRect;
		/*[in]*/ DWORD grfFlags;
		/*[out]*/ HDC* phDC;
		HRESULT retValue;
	};

	STDMETHOD(GetDC)(
		/*[in]*/ LPCRECT pRect,
		/*[in]*/ DWORD grfFlags,
		/*[out]*/ HDC* phDC)
	{
		VSL_DEFINE_MOCK_METHOD(GetDC)

		VSL_CHECK_VALIDVALUE(pRect);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_SET_VALIDVALUE(phDC);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseDCValidValues
	{
		/*[in]*/ HDC hDC;
		HRESULT retValue;
	};

	STDMETHOD(ReleaseDC)(
		/*[in]*/ HDC hDC)
	{
		VSL_DEFINE_MOCK_METHOD(ReleaseDC)

		VSL_CHECK_VALIDVALUE(hDC);

		VSL_RETURN_VALIDVALUES();
	}
	struct InvalidateRectValidValues
	{
		/*[in]*/ LPCRECT pRect;
		/*[in]*/ BOOL fErase;
		HRESULT retValue;
	};

	STDMETHOD(InvalidateRect)(
		/*[in]*/ LPCRECT pRect,
		/*[in]*/ BOOL fErase)
	{
		VSL_DEFINE_MOCK_METHOD(InvalidateRect)

		VSL_CHECK_VALIDVALUE(pRect);

		VSL_CHECK_VALIDVALUE(fErase);

		VSL_RETURN_VALIDVALUES();
	}
	struct InvalidateRgnValidValues
	{
		/*[in]*/ HRGN hRGN;
		/*[in]*/ BOOL fErase;
		HRESULT retValue;
	};

	STDMETHOD(InvalidateRgn)(
		/*[in]*/ HRGN hRGN,
		/*[in]*/ BOOL fErase)
	{
		VSL_DEFINE_MOCK_METHOD(InvalidateRgn)

		VSL_CHECK_VALIDVALUE(hRGN);

		VSL_CHECK_VALIDVALUE(fErase);

		VSL_RETURN_VALIDVALUES();
	}
	struct ScrollRectValidValues
	{
		/*[in]*/ INT dx;
		/*[in]*/ INT dy;
		/*[in]*/ LPCRECT pRectScroll;
		/*[in]*/ LPCRECT pRectClip;
		HRESULT retValue;
	};

	STDMETHOD(ScrollRect)(
		/*[in]*/ INT dx,
		/*[in]*/ INT dy,
		/*[in]*/ LPCRECT pRectScroll,
		/*[in]*/ LPCRECT pRectClip)
	{
		VSL_DEFINE_MOCK_METHOD(ScrollRect)

		VSL_CHECK_VALIDVALUE(dx);

		VSL_CHECK_VALIDVALUE(dy);

		VSL_CHECK_VALIDVALUE(pRectScroll);

		VSL_CHECK_VALIDVALUE(pRectClip);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdjustRectValidValues
	{
		/*[in,out]*/ LPRECT prc;
		HRESULT retValue;
	};

	STDMETHOD(AdjustRect)(
		/*[in,out]*/ LPRECT prc)
	{
		VSL_DEFINE_MOCK_METHOD(AdjustRect)

		VSL_SET_VALIDVALUE(prc);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDefWindowMessageValidValues
	{
		/*[in]*/ UINT msg;
		/*[in]*/ WPARAM wParam;
		/*[in]*/ LPARAM lParam;
		/*[out]*/ LRESULT* plResult;
		HRESULT retValue;
	};

	STDMETHOD(OnDefWindowMessage)(
		/*[in]*/ UINT msg,
		/*[in]*/ WPARAM wParam,
		/*[in]*/ LPARAM lParam,
		/*[out]*/ LRESULT* plResult)
	{
		VSL_DEFINE_MOCK_METHOD(OnDefWindowMessage)

		VSL_CHECK_VALIDVALUE(msg);

		VSL_CHECK_VALIDVALUE(wParam);

		VSL_CHECK_VALIDVALUE(lParam);

		VSL_SET_VALIDVALUE(plResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInPlaceActivateExValidValues
	{
		/*[out]*/ BOOL* pfNoRedraw;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(OnInPlaceActivateEx)(
		/*[out]*/ BOOL* pfNoRedraw,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(OnInPlaceActivateEx)

		VSL_SET_VALIDVALUE(pfNoRedraw);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInPlaceDeactivateExValidValues
	{
		/*[in]*/ BOOL fNoRedraw;
		HRESULT retValue;
	};

	STDMETHOD(OnInPlaceDeactivateEx)(
		/*[in]*/ BOOL fNoRedraw)
	{
		VSL_DEFINE_MOCK_METHOD(OnInPlaceDeactivateEx)

		VSL_CHECK_VALIDVALUE(fNoRedraw);

		VSL_RETURN_VALIDVALUES();
	}
	struct RequestUIActivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RequestUIActivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RequestUIActivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct CanInPlaceActivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanInPlaceActivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanInPlaceActivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInPlaceActivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnInPlaceActivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnInPlaceActivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnUIActivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnUIActivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnUIActivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWindowContextValidValues
	{
		/*[out]*/ IOleInPlaceFrame** ppFrame;
		/*[out]*/ IOleInPlaceUIWindow** ppDoc;
		/*[out]*/ LPRECT lprcPosRect;
		/*[out]*/ LPRECT lprcClipRect;
		/*[in,out]*/ LPOLEINPLACEFRAMEINFO lpFrameInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetWindowContext)(
		/*[out]*/ IOleInPlaceFrame** ppFrame,
		/*[out]*/ IOleInPlaceUIWindow** ppDoc,
		/*[out]*/ LPRECT lprcPosRect,
		/*[out]*/ LPRECT lprcClipRect,
		/*[in,out]*/ LPOLEINPLACEFRAMEINFO lpFrameInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetWindowContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppFrame);

		VSL_SET_VALIDVALUE_INTERFACE(ppDoc);

		VSL_SET_VALIDVALUE(lprcPosRect);

		VSL_SET_VALIDVALUE(lprcClipRect);

		VSL_SET_VALIDVALUE(lpFrameInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct ScrollValidValues
	{
		/*[in]*/ SIZE scrollExtant;
		HRESULT retValue;
	};

	STDMETHOD(Scroll)(
		/*[in]*/ SIZE scrollExtant)
	{
		VSL_DEFINE_MOCK_METHOD(Scroll)

		VSL_CHECK_VALIDVALUE(scrollExtant);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnUIDeactivateValidValues
	{
		/*[in]*/ BOOL fUndoable;
		HRESULT retValue;
	};

	STDMETHOD(OnUIDeactivate)(
		/*[in]*/ BOOL fUndoable)
	{
		VSL_DEFINE_MOCK_METHOD(OnUIDeactivate)

		VSL_CHECK_VALIDVALUE(fUndoable);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInPlaceDeactivateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnInPlaceDeactivate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnInPlaceDeactivate)

		VSL_RETURN_VALIDVALUES();
	}
	struct DiscardUndoStateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DiscardUndoState)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DiscardUndoState)

		VSL_RETURN_VALIDVALUES();
	}
	struct DeactivateAndUndoValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DeactivateAndUndo)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DeactivateAndUndo)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnPosRectChangeValidValues
	{
		/*[in]*/ LPCRECT lprcPosRect;
		HRESULT retValue;
	};

	STDMETHOD(OnPosRectChange)(
		/*[in]*/ LPCRECT lprcPosRect)
	{
		VSL_DEFINE_MOCK_METHOD(OnPosRectChange)

		VSL_CHECK_VALIDVALUE(lprcPosRect);

		VSL_RETURN_VALIDVALUES();
	}
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

#endif // IOLEINPLACESITEWINDOWLESS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
