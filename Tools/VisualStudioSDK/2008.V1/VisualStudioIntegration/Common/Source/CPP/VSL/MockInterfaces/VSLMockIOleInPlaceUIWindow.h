/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLEINPLACEUIWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLEINPLACEUIWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleInPlaceUIWindowNotImpl :
	public IOleInPlaceUIWindow
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceUIWindowNotImpl)

public:

	typedef IOleInPlaceUIWindow Interface;

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

class IOleInPlaceUIWindowMockImpl :
	public IOleInPlaceUIWindow,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleInPlaceUIWindowMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleInPlaceUIWindowMockImpl)

	typedef IOleInPlaceUIWindow Interface;
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

#endif // IOLEINPLACEUIWINDOW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
