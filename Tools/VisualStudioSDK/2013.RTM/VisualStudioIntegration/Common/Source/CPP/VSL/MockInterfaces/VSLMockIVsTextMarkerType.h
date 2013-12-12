/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTMARKERTYPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTMARKERTYPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextMarkerTypeNotImpl :
	public IVsTextMarkerType
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMarkerTypeNotImpl)

public:

	typedef IVsTextMarkerType Interface;

	STDMETHOD(GetVisualStyle)(
		/*[out]*/ DWORD* /*pdwVisualFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultColors)(
		/*[out]*/ COLORINDEX* /*piForeground*/,
		/*[out]*/ COLORINDEX* /*piBackground*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultLineStyle)(
		/*[out]*/ COLORINDEX* /*piLineColor*/,
		/*[out]*/ LINESTYLE* /*piLineIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DrawGlyph)(
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*pRect*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBehaviorFlags)(
		/*[out]*/ DWORD* /*pdwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPriorityIndex)(
		/*[out]*/ long* /*piPriorityIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DrawGlyphEx)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*pRect*/,
		/*[in]*/ long /*iLineHeight*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextMarkerTypeMockImpl :
	public IVsTextMarkerType,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMarkerTypeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextMarkerTypeMockImpl)

	typedef IVsTextMarkerType Interface;
	struct GetVisualStyleValidValues
	{
		/*[out]*/ DWORD* pdwVisualFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetVisualStyle)(
		/*[out]*/ DWORD* pdwVisualFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetVisualStyle)

		VSL_SET_VALIDVALUE(pdwVisualFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultColorsValidValues
	{
		/*[out]*/ COLORINDEX* piForeground;
		/*[out]*/ COLORINDEX* piBackground;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultColors)(
		/*[out]*/ COLORINDEX* piForeground,
		/*[out]*/ COLORINDEX* piBackground)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultColors)

		VSL_SET_VALIDVALUE(piForeground);

		VSL_SET_VALIDVALUE(piBackground);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultLineStyleValidValues
	{
		/*[out]*/ COLORINDEX* piLineColor;
		/*[out]*/ LINESTYLE* piLineIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultLineStyle)(
		/*[out]*/ COLORINDEX* piLineColor,
		/*[out]*/ LINESTYLE* piLineIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultLineStyle)

		VSL_SET_VALIDVALUE(piLineColor);

		VSL_SET_VALIDVALUE(piLineIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct DrawGlyphValidValues
	{
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* pRect;
		HRESULT retValue;
	};

	STDMETHOD(DrawGlyph)(
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* pRect)
	{
		VSL_DEFINE_MOCK_METHOD(DrawGlyph)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(pRect);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBehaviorFlagsValidValues
	{
		/*[out]*/ DWORD* pdwFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetBehaviorFlags)(
		/*[out]*/ DWORD* pdwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetBehaviorFlags)

		VSL_SET_VALIDVALUE(pdwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPriorityIndexValidValues
	{
		/*[out]*/ long* piPriorityIndex;
		HRESULT retValue;
	};

	STDMETHOD(GetPriorityIndex)(
		/*[out]*/ long* piPriorityIndex)
	{
		VSL_DEFINE_MOCK_METHOD(GetPriorityIndex)

		VSL_SET_VALIDVALUE(piPriorityIndex);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisplayNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct DrawGlyphExValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* pRect;
		/*[in]*/ long iLineHeight;
		HRESULT retValue;
	};

	STDMETHOD(DrawGlyphEx)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* pRect,
		/*[in]*/ long iLineHeight)
	{
		VSL_DEFINE_MOCK_METHOD(DrawGlyphEx)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(pRect);

		VSL_CHECK_VALIDVALUE(iLineHeight);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTMARKERTYPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
