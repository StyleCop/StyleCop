/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEINPLACEACTIVEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEINPLACEACTIVEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleInPlaceActiveObjectNotImpl :
	public IOleInPlaceActiveObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceActiveObjectNotImpl)

public:

	typedef IOleInPlaceActiveObject Interface;

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG /*lpmsg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnFrameWindowActivate)(
		/*[in]*/ BOOL /*fActivate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDocWindowActivate)(
		/*[in]*/ BOOL /*fActivate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResizeBorder)(
		/*[in]*/ LPCRECT /*prcBorder*/,
		/*[in,unique]*/ IOleInPlaceUIWindow* /*pUIWindow*/,
		/*[in]*/ BOOL /*fFrameWindow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnableModeless)(
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWindow)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ContextSensitiveHelp)(
		/*[in]*/ BOOL /*fEnterMode*/)VSL_STDMETHOD_NOTIMPL
};

class IOleInPlaceActiveObjectMockImpl :
	public IOleInPlaceActiveObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceActiveObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleInPlaceActiveObjectMockImpl)

	typedef IOleInPlaceActiveObject Interface;
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
	struct OnFrameWindowActivateValidValues
	{
		/*[in]*/ BOOL fActivate;
		HRESULT retValue;
	};

	STDMETHOD(OnFrameWindowActivate)(
		/*[in]*/ BOOL fActivate)
	{
		VSL_DEFINE_MOCK_METHOD(OnFrameWindowActivate)

		VSL_CHECK_VALIDVALUE(fActivate);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDocWindowActivateValidValues
	{
		/*[in]*/ BOOL fActivate;
		HRESULT retValue;
	};

	STDMETHOD(OnDocWindowActivate)(
		/*[in]*/ BOOL fActivate)
	{
		VSL_DEFINE_MOCK_METHOD(OnDocWindowActivate)

		VSL_CHECK_VALIDVALUE(fActivate);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResizeBorderValidValues
	{
		/*[in]*/ LPCRECT prcBorder;
		/*[in,unique]*/ IOleInPlaceUIWindow* pUIWindow;
		/*[in]*/ BOOL fFrameWindow;
		HRESULT retValue;
	};

	STDMETHOD(ResizeBorder)(
		/*[in]*/ LPCRECT prcBorder,
		/*[in,unique]*/ IOleInPlaceUIWindow* pUIWindow,
		/*[in]*/ BOOL fFrameWindow)
	{
		VSL_DEFINE_MOCK_METHOD(ResizeBorder)

		VSL_CHECK_VALIDVALUE(prcBorder);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUIWindow);

		VSL_CHECK_VALIDVALUE(fFrameWindow);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnableModelessValidValues
	{
		/*[in]*/ BOOL fEnable;
		HRESULT retValue;
	};

	STDMETHOD(EnableModeless)(
		/*[in]*/ BOOL fEnable)
	{
		VSL_DEFINE_MOCK_METHOD(EnableModeless)

		VSL_CHECK_VALIDVALUE(fEnable);

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

#endif // IOLEINPLACEACTIVEOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
