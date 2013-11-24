/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEINPLACEFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEINPLACEFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleInPlaceFrameNotImpl :
	public IOleInPlaceFrame
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceFrameNotImpl)

public:

	typedef IOleInPlaceFrame Interface;

	STDMETHOD(InsertMenus)(
		/*[in]*/ HMENU /*hmenuShared*/,
		/*[in,out]*/ LPOLEMENUGROUPWIDTHS /*lpMenuWidths*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMenu)(
		/*[in]*/ HMENU /*hmenuShared*/,
		/*[in]*/ HOLEMENU /*holemenu*/,
		/*[in]*/ HWND /*hwndActiveObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveMenus)(
		/*[in]*/ HMENU /*hmenuShared*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStatusText)(
		/*[in,unique]*/ LPCOLESTR /*pszStatusText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnableModeless)(
		/*[in]*/ BOOL /*fEnable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG /*lpmsg*/,
		/*[in]*/ WORD /*wID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBorder)(
		/*[out]*/ LPRECT /*lprectBorder*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RequestBorderSpace)(
		/*[in,unique]*/ LPCBORDERWIDTHS /*pborderwidths*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBorderSpace)(
		/*[in,unique]*/ LPCBORDERWIDTHS /*pborderwidths*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetActiveObject)(
		/*[in,unique]*/ IOleInPlaceActiveObject* /*pActiveObject*/,
		/*[in,string,unique]*/ LPCOLESTR /*pszObjName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWindow)(
		/*[out]*/ HWND* /*phwnd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ContextSensitiveHelp)(
		/*[in]*/ BOOL /*fEnterMode*/)VSL_STDMETHOD_NOTIMPL
};

class IOleInPlaceFrameMockImpl :
	public IOleInPlaceFrame,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceFrameMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleInPlaceFrameMockImpl)

	typedef IOleInPlaceFrame Interface;
	struct InsertMenusValidValues
	{
		/*[in]*/ HMENU hmenuShared;
		/*[in,out]*/ LPOLEMENUGROUPWIDTHS lpMenuWidths;
		HRESULT retValue;
	};

	STDMETHOD(InsertMenus)(
		/*[in]*/ HMENU hmenuShared,
		/*[in,out]*/ LPOLEMENUGROUPWIDTHS lpMenuWidths)
	{
		VSL_DEFINE_MOCK_METHOD(InsertMenus)

		VSL_CHECK_VALIDVALUE(hmenuShared);

		VSL_SET_VALIDVALUE(lpMenuWidths);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetMenuValidValues
	{
		/*[in]*/ HMENU hmenuShared;
		/*[in]*/ HOLEMENU holemenu;
		/*[in]*/ HWND hwndActiveObject;
		HRESULT retValue;
	};

	STDMETHOD(SetMenu)(
		/*[in]*/ HMENU hmenuShared,
		/*[in]*/ HOLEMENU holemenu,
		/*[in]*/ HWND hwndActiveObject)
	{
		VSL_DEFINE_MOCK_METHOD(SetMenu)

		VSL_CHECK_VALIDVALUE(hmenuShared);

		VSL_CHECK_VALIDVALUE(holemenu);

		VSL_CHECK_VALIDVALUE(hwndActiveObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveMenusValidValues
	{
		/*[in]*/ HMENU hmenuShared;
		HRESULT retValue;
	};

	STDMETHOD(RemoveMenus)(
		/*[in]*/ HMENU hmenuShared)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveMenus)

		VSL_CHECK_VALIDVALUE(hmenuShared);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStatusTextValidValues
	{
		/*[in,unique]*/ LPCOLESTR pszStatusText;
		HRESULT retValue;
	};

	STDMETHOD(SetStatusText)(
		/*[in,unique]*/ LPCOLESTR pszStatusText)
	{
		VSL_DEFINE_MOCK_METHOD(SetStatusText)

		VSL_CHECK_VALIDVALUE_STRINGW(pszStatusText);

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
	struct TranslateAcceleratorValidValues
	{
		/*[in]*/ LPMSG lpmsg;
		/*[in]*/ WORD wID;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ LPMSG lpmsg,
		/*[in]*/ WORD wID)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelerator)

		VSL_CHECK_VALIDVALUE(lpmsg);

		VSL_CHECK_VALIDVALUE(wID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBorderValidValues
	{
		/*[out]*/ LPRECT lprectBorder;
		HRESULT retValue;
	};

	STDMETHOD(GetBorder)(
		/*[out]*/ LPRECT lprectBorder)
	{
		VSL_DEFINE_MOCK_METHOD(GetBorder)

		VSL_SET_VALIDVALUE(lprectBorder);

		VSL_RETURN_VALIDVALUES();
	}
	struct RequestBorderSpaceValidValues
	{
		/*[in,unique]*/ LPCBORDERWIDTHS pborderwidths;
		HRESULT retValue;
	};

	STDMETHOD(RequestBorderSpace)(
		/*[in,unique]*/ LPCBORDERWIDTHS pborderwidths)
	{
		VSL_DEFINE_MOCK_METHOD(RequestBorderSpace)

		VSL_CHECK_VALIDVALUE(pborderwidths);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBorderSpaceValidValues
	{
		/*[in,unique]*/ LPCBORDERWIDTHS pborderwidths;
		HRESULT retValue;
	};

	STDMETHOD(SetBorderSpace)(
		/*[in,unique]*/ LPCBORDERWIDTHS pborderwidths)
	{
		VSL_DEFINE_MOCK_METHOD(SetBorderSpace)

		VSL_CHECK_VALIDVALUE(pborderwidths);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetActiveObjectValidValues
	{
		/*[in,unique]*/ IOleInPlaceActiveObject* pActiveObject;
		/*[in,string,unique]*/ LPCOLESTR pszObjName;
		HRESULT retValue;
	};

	STDMETHOD(SetActiveObject)(
		/*[in,unique]*/ IOleInPlaceActiveObject* pActiveObject,
		/*[in,string,unique]*/ LPCOLESTR pszObjName)
	{
		VSL_DEFINE_MOCK_METHOD(SetActiveObject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pActiveObject);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjName);

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

#endif // IOLEINPLACEFRAME_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
