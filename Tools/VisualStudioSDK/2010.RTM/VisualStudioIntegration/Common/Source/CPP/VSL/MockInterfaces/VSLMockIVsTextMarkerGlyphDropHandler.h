/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTEXTMARKERGLYPHDROPHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTEXTMARKERGLYPHDROPHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTextMarkerGlyphDropHandlerNotImpl :
	public IVsTextMarkerGlyphDropHandler
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMarkerGlyphDropHandlerNotImpl)

public:

	typedef IVsTextMarkerGlyphDropHandler Interface;

	STDMETHOD(DrawCandidateOutlineGlyph)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ HDC /*hdc*/,
		/*[in]*/ RECT* /*pRect*/,
		/*[in]*/ COLORREF /*clrref*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryDropLocation)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ IVsTextView* /*pDestView*/,
		/*[in]*/ IVsTextLines* /*pDestBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ CharIndex /*iIndex*/,
		/*[out]*/ DWORD* /*pdwDropResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DropAtLocation)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ IVsTextView* /*pDestView*/,
		/*[in]*/ IVsTextLines* /*pDestBuffer*/,
		/*[in]*/ long /*iLine*/,
		/*[in]*/ CharIndex /*iIndex*/,
		/*[out]*/ DWORD* /*pdwDropResult*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTextMarkerGlyphDropHandlerMockImpl :
	public IVsTextMarkerGlyphDropHandler,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTextMarkerGlyphDropHandlerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTextMarkerGlyphDropHandlerMockImpl)

	typedef IVsTextMarkerGlyphDropHandler Interface;
	struct DrawCandidateOutlineGlyphValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ HDC hdc;
		/*[in]*/ RECT* pRect;
		/*[in]*/ COLORREF clrref;
		HRESULT retValue;
	};

	STDMETHOD(DrawCandidateOutlineGlyph)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ HDC hdc,
		/*[in]*/ RECT* pRect,
		/*[in]*/ COLORREF clrref)
	{
		VSL_DEFINE_MOCK_METHOD(DrawCandidateOutlineGlyph)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(hdc);

		VSL_CHECK_VALIDVALUE_POINTER(pRect);

		VSL_CHECK_VALIDVALUE(clrref);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryDropLocationValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ IVsTextView* pDestView;
		/*[in]*/ IVsTextLines* pDestBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ CharIndex iIndex;
		/*[out]*/ DWORD* pdwDropResult;
		HRESULT retValue;
	};

	STDMETHOD(QueryDropLocation)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ IVsTextView* pDestView,
		/*[in]*/ IVsTextLines* pDestBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ CharIndex iIndex,
		/*[out]*/ DWORD* pdwDropResult)
	{
		VSL_DEFINE_MOCK_METHOD(QueryDropLocation)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDestView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDestBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(pdwDropResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct DropAtLocationValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ IVsTextView* pDestView;
		/*[in]*/ IVsTextLines* pDestBuffer;
		/*[in]*/ long iLine;
		/*[in]*/ CharIndex iIndex;
		/*[out]*/ DWORD* pdwDropResult;
		HRESULT retValue;
	};

	STDMETHOD(DropAtLocation)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ IVsTextView* pDestView,
		/*[in]*/ IVsTextLines* pDestBuffer,
		/*[in]*/ long iLine,
		/*[in]*/ CharIndex iIndex,
		/*[out]*/ DWORD* pdwDropResult)
	{
		VSL_DEFINE_MOCK_METHOD(DropAtLocation)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDestView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDestBuffer);

		VSL_CHECK_VALIDVALUE(iLine);

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE(pdwDropResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTEXTMARKERGLYPHDROPHANDLER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
