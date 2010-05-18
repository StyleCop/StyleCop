/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHICOLORITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHICOLORITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHiColorItemNotImpl :
	public IVsHiColorItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiColorItemNotImpl)

public:

	typedef IVsHiColorItem Interface;

	STDMETHOD(GetColorData)(
		/*[in]*/ VSCOLORDATA /*cdElement*/,
		/*[out]*/ COLORREF* /*pcrColor*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHiColorItemMockImpl :
	public IVsHiColorItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiColorItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHiColorItemMockImpl)

	typedef IVsHiColorItem Interface;
	struct GetColorDataValidValues
	{
		/*[in]*/ VSCOLORDATA cdElement;
		/*[out]*/ COLORREF* pcrColor;
		HRESULT retValue;
	};

	STDMETHOD(GetColorData)(
		/*[in]*/ VSCOLORDATA cdElement,
		/*[out]*/ COLORREF* pcrColor)
	{
		VSL_DEFINE_MOCK_METHOD(GetColorData)

		VSL_CHECK_VALIDVALUE(cdElement);

		VSL_SET_VALIDVALUE(pcrColor);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHICOLORITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
