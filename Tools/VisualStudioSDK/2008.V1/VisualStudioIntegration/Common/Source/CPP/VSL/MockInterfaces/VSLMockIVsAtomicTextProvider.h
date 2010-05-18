/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSATOMICTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSATOMICTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAtomicTextProviderNotImpl :
	public IVsAtomicTextProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAtomicTextProviderNotImpl)

public:

	typedef IVsAtomicTextProvider Interface;

	STDMETHOD(GetAtomFlags)(
		/*[out]*/ DWORD* /*pdwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAtomAttributes)(
		/*[in]*/ DWORD /*dwLength*/,
		/*[out,size_is(dwLength)]*/ ULONG* /*pColorAttr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAtomGlyphWidth)(
		/*[in]*/ long /*iPixSpaceWidth*/,
		/*[out]*/ long* /*pGlyphPix*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DrawAtomGlyph)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*pRect*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAtomicTextProviderMockImpl :
	public IVsAtomicTextProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAtomicTextProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAtomicTextProviderMockImpl)

	typedef IVsAtomicTextProvider Interface;
	struct GetAtomFlagsValidValues
	{
		/*[out]*/ DWORD* pdwFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetAtomFlags)(
		/*[out]*/ DWORD* pdwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetAtomFlags)

		VSL_SET_VALIDVALUE(pdwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAtomAttributesValidValues
	{
		/*[in]*/ DWORD dwLength;
		/*[out,size_is(dwLength)]*/ ULONG* pColorAttr;
		HRESULT retValue;
	};

	STDMETHOD(GetAtomAttributes)(
		/*[in]*/ DWORD dwLength,
		/*[out,size_is(dwLength)]*/ ULONG* pColorAttr)
	{
		VSL_DEFINE_MOCK_METHOD(GetAtomAttributes)

		VSL_CHECK_VALIDVALUE(dwLength);

		VSL_SET_VALIDVALUE_MEMCPY(pColorAttr, dwLength*sizeof(pColorAttr[0]), validValues.dwLength*sizeof(validValues.pColorAttr[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAtomGlyphWidthValidValues
	{
		/*[in]*/ long iPixSpaceWidth;
		/*[out]*/ long* pGlyphPix;
		HRESULT retValue;
	};

	STDMETHOD(GetAtomGlyphWidth)(
		/*[in]*/ long iPixSpaceWidth,
		/*[out]*/ long* pGlyphPix)
	{
		VSL_DEFINE_MOCK_METHOD(GetAtomGlyphWidth)

		VSL_CHECK_VALIDVALUE(iPixSpaceWidth);

		VSL_SET_VALIDVALUE(pGlyphPix);

		VSL_RETURN_VALIDVALUES();
	}
	struct DrawAtomGlyphValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* pRect;
		HRESULT retValue;
	};

	STDMETHOD(DrawAtomGlyph)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* pRect)
	{
		VSL_DEFINE_MOCK_METHOD(DrawAtomGlyph)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(pRect);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSATOMICTEXTPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
