/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIDDENTEXTCLIENTEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIDDENTEXTCLIENTEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHiddenTextClientExNotImpl :
	public IVsHiddenTextClientEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextClientExNotImpl)

public:

	typedef IVsHiddenTextClientEx Interface;

	STDMETHOD(GetBannerGlyphWidth)(
		/*[in]*/ long /*iPixSpaceWidth*/,
		/*[out]*/ long* /*pGlyphPix*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DrawBannerGlyph)(
		/*[in]*/ IVsHiddenRegion* /*pHidReg*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*pRect*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHiddenTextClientExMockImpl :
	public IVsHiddenTextClientEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextClientExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHiddenTextClientExMockImpl)

	typedef IVsHiddenTextClientEx Interface;
	struct GetBannerGlyphWidthValidValues
	{
		/*[in]*/ long iPixSpaceWidth;
		/*[out]*/ long* pGlyphPix;
		HRESULT retValue;
	};

	STDMETHOD(GetBannerGlyphWidth)(
		/*[in]*/ long iPixSpaceWidth,
		/*[out]*/ long* pGlyphPix)
	{
		VSL_DEFINE_MOCK_METHOD(GetBannerGlyphWidth)

		VSL_CHECK_VALIDVALUE(iPixSpaceWidth);

		VSL_SET_VALIDVALUE(pGlyphPix);

		VSL_RETURN_VALIDVALUES();
	}
	struct DrawBannerGlyphValidValues
	{
		/*[in]*/ IVsHiddenRegion* pHidReg;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* pRect;
		HRESULT retValue;
	};

	STDMETHOD(DrawBannerGlyph)(
		/*[in]*/ IVsHiddenRegion* pHidReg,
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* pRect)
	{
		VSL_DEFINE_MOCK_METHOD(DrawBannerGlyph)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHidReg);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(pRect);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIDDENTEXTCLIENTEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
