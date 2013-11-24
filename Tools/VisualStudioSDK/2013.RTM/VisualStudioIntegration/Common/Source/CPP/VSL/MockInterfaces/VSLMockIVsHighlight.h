/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIGHLIGHT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIGHLIGHT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsHighlightNotImpl :
	public IVsHighlight
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHighlightNotImpl)

public:

	typedef IVsHighlight Interface;

	STDMETHOD(GetHighlightRect)(
		/*[out]*/ RECT* /*prc*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHighlightMockImpl :
	public IVsHighlight,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHighlightMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHighlightMockImpl)

	typedef IVsHighlight Interface;
	struct GetHighlightRectValidValues
	{
		/*[out]*/ RECT* prc;
		HRESULT retValue;
	};

	STDMETHOD(GetHighlightRect)(
		/*[out]*/ RECT* prc)
	{
		VSL_DEFINE_MOCK_METHOD(GetHighlightRect)

		VSL_SET_VALIDVALUE(prc);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIGHLIGHT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
