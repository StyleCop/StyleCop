/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOLORABLEITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOLORABLEITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsColorableItemNotImpl :
	public IVsColorableItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsColorableItemNotImpl)

public:

	typedef IVsColorableItem Interface;

	STDMETHOD(GetDefaultColors)(
		/*[out]*/ COLORINDEX* /*piForeground*/,
		/*[out]*/ COLORINDEX* /*piBackground*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultFontFlags)(
		/*[out]*/ DWORD* /*pdwFontFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisplayName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsColorableItemMockImpl :
	public IVsColorableItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsColorableItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsColorableItemMockImpl)

	typedef IVsColorableItem Interface;
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
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOLORABLEITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
