/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IUIHOSTLOCALE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IUIHOSTLOCALE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "uilocale.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IUIHostLocaleNotImpl :
	public IUIHostLocale
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUIHostLocaleNotImpl)

public:

	typedef IUIHostLocale Interface;

	STDMETHOD(GetUILocale)(
		/*[out,retval]*/ LCID* /*plcid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDialogFont)(
		/*[out]*/ UIDLGLOGFONT* /*plogfont*/)VSL_STDMETHOD_NOTIMPL
};

class IUIHostLocaleMockImpl :
	public IUIHostLocale,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUIHostLocaleMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IUIHostLocaleMockImpl)

	typedef IUIHostLocale Interface;
	struct GetUILocaleValidValues
	{
		/*[out,retval]*/ LCID* plcid;
		HRESULT retValue;
	};

	STDMETHOD(GetUILocale)(
		/*[out,retval]*/ LCID* plcid)
	{
		VSL_DEFINE_MOCK_METHOD(GetUILocale)

		VSL_SET_VALIDVALUE(plcid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDialogFontValidValues
	{
		/*[out]*/ UIDLGLOGFONT* plogfont;
		HRESULT retValue;
	};

	STDMETHOD(GetDialogFont)(
		/*[out]*/ UIDLGLOGFONT* plogfont)
	{
		VSL_DEFINE_MOCK_METHOD(GetDialogFont)

		VSL_SET_VALIDVALUE(plogfont);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IUIHOSTLOCALE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
