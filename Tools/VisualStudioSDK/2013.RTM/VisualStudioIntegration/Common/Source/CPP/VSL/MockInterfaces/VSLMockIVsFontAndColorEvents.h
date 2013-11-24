/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFONTANDCOLOREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFONTANDCOLOREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFontAndColorEventsNotImpl :
	public IVsFontAndColorEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorEventsNotImpl)

public:

	typedef IVsFontAndColorEvents Interface;

	STDMETHOD(OnFontChanged)(
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[in]*/ const FontInfo* /*pInfo*/,
		/*[in]*/ const LOGFONTW* /*pLOGFONT*/,
		/*[in]*/ HFONT /*hFont*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnItemChanged)(
		/*[in]*/ REFGUID /*rguidCategory*/,
		/*[in]*/ LPCOLESTR /*szItem*/,
		/*[in]*/ LONG /*iItem*/,
		/*[in]*/ const ColorableItemInfo* /*pInfo*/,
		/*[in]*/ COLORREF /*crLiteralForeground*/,
		/*[in]*/ COLORREF /*crLiteralBackground*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnReset)(
		/*[in]*/ REFGUID /*rguidCategory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnResetToBaseCategory)(
		/*[in]*/ REFGUID /*rguidCategory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnApply)()VSL_STDMETHOD_NOTIMPL
};

class IVsFontAndColorEventsMockImpl :
	public IVsFontAndColorEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFontAndColorEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFontAndColorEventsMockImpl)

	typedef IVsFontAndColorEvents Interface;
	struct OnFontChangedValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		/*[in]*/ FontInfo* pInfo;
		/*[in]*/ LOGFONTW* pLOGFONT;
		/*[in]*/ HFONT hFont;
		HRESULT retValue;
	};

	STDMETHOD(OnFontChanged)(
		/*[in]*/ REFGUID rguidCategory,
		/*[in]*/ const FontInfo* pInfo,
		/*[in]*/ const LOGFONTW* pLOGFONT,
		/*[in]*/ HFONT hFont)
	{
		VSL_DEFINE_MOCK_METHOD(OnFontChanged)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_CHECK_VALIDVALUE_POINTER(pInfo);

		VSL_CHECK_VALIDVALUE_POINTER(pLOGFONT);

		VSL_CHECK_VALIDVALUE(hFont);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnItemChangedValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		/*[in]*/ LPCOLESTR szItem;
		/*[in]*/ LONG iItem;
		/*[in]*/ ColorableItemInfo* pInfo;
		/*[in]*/ COLORREF crLiteralForeground;
		/*[in]*/ COLORREF crLiteralBackground;
		HRESULT retValue;
	};

	STDMETHOD(OnItemChanged)(
		/*[in]*/ REFGUID rguidCategory,
		/*[in]*/ LPCOLESTR szItem,
		/*[in]*/ LONG iItem,
		/*[in]*/ const ColorableItemInfo* pInfo,
		/*[in]*/ COLORREF crLiteralForeground,
		/*[in]*/ COLORREF crLiteralBackground)
	{
		VSL_DEFINE_MOCK_METHOD(OnItemChanged)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_CHECK_VALIDVALUE_STRINGW(szItem);

		VSL_CHECK_VALIDVALUE(iItem);

		VSL_CHECK_VALIDVALUE_POINTER(pInfo);

		VSL_CHECK_VALIDVALUE(crLiteralForeground);

		VSL_CHECK_VALIDVALUE(crLiteralBackground);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnResetValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		HRESULT retValue;
	};

	STDMETHOD(OnReset)(
		/*[in]*/ REFGUID rguidCategory)
	{
		VSL_DEFINE_MOCK_METHOD(OnReset)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnResetToBaseCategoryValidValues
	{
		/*[in]*/ REFGUID rguidCategory;
		HRESULT retValue;
	};

	STDMETHOD(OnResetToBaseCategory)(
		/*[in]*/ REFGUID rguidCategory)
	{
		VSL_DEFINE_MOCK_METHOD(OnResetToBaseCategory)

		VSL_CHECK_VALIDVALUE(rguidCategory);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnApplyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnApply)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnApply)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFONTANDCOLOREVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
