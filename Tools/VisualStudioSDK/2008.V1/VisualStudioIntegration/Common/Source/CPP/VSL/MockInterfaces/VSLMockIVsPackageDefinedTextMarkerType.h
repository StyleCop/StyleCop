/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPACKAGEDEFINEDTEXTMARKERTYPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPACKAGEDEFINEDTEXTMARKERTYPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPackageDefinedTextMarkerTypeNotImpl :
	public IVsPackageDefinedTextMarkerType
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPackageDefinedTextMarkerTypeNotImpl)

public:

	typedef IVsPackageDefinedTextMarkerType Interface;

	STDMETHOD(GetVisualStyle)(
		/*[out]*/ DWORD* /*pdwVisualFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultColors)(
		/*[out]*/ COLORINDEX* /*piForeground*/,
		/*[out]*/ COLORINDEX* /*piBackground*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultLineStyle)(
		/*[out]*/ COLORINDEX* /*piLineColor*/,
		/*[out]*/ LINESTYLE* /*piLineIndex*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultFontFlags)(
		/*[out]*/ DWORD* /*pdwFontFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DrawGlyphWithColors)(
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*pRect*/,
		/*[in]*/ long /*iMarkerType*/,
		/*[in]*/ IVsTextMarkerColorSet* /*pMarkerColors*/,
		/*[in]*/ DWORD /*dwGlyphDrawFlags*/,
		/*[in]*/ long /*iLineHeight*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBehaviorFlags)(
		/*[out]*/ DWORD* /*pdwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPriorityIndex)(
		/*[out]*/ long* /*piPriorityIndex*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPackageDefinedTextMarkerTypeMockImpl :
	public IVsPackageDefinedTextMarkerType,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPackageDefinedTextMarkerTypeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPackageDefinedTextMarkerTypeMockImpl)

	typedef IVsPackageDefinedTextMarkerType Interface;
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
	struct GetDefaultFontFlagsValidValues
	{
		/*[out]*/ DWORD* pdwFontFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultFontFlags)(
		/*[out]*/ DWORD* pdwFontFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultFontFlags)

		VSL_SET_VALIDVALUE(pdwFontFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct DrawGlyphWithColorsValidValues
	{
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* pRect;
		/*[in]*/ long iMarkerType;
		/*[in]*/ IVsTextMarkerColorSet* pMarkerColors;
		/*[in]*/ DWORD dwGlyphDrawFlags;
		/*[in]*/ long iLineHeight;
		HRESULT retValue;
	};

	STDMETHOD(DrawGlyphWithColors)(
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* pRect,
		/*[in]*/ long iMarkerType,
		/*[in]*/ IVsTextMarkerColorSet* pMarkerColors,
		/*[in]*/ DWORD dwGlyphDrawFlags,
		/*[in]*/ long iLineHeight)
	{
		VSL_DEFINE_MOCK_METHOD(DrawGlyphWithColors)

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(pRect);

		VSL_CHECK_VALIDVALUE(iMarkerType);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMarkerColors);

		VSL_CHECK_VALIDVALUE(dwGlyphDrawFlags);

		VSL_CHECK_VALIDVALUE(iLineHeight);

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
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPACKAGEDEFINEDTEXTMARKERTYPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
