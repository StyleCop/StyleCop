/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IUIELEMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IUIELEMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IUIElementNotImpl :
	public IUIElement
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUIElementNotImpl)

public:

	typedef IUIElement Interface;

	STDMETHOD(Show)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Hide)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsVisible)()VSL_STDMETHOD_NOTIMPL
};

class IUIElementMockImpl :
	public IUIElement,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IUIElementMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IUIElementMockImpl)

	typedef IUIElement Interface;
	struct ShowValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Show)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Show)

		VSL_RETURN_VALIDVALUES();
	}
	struct HideValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Hide)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Hide)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsVisibleValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsVisible)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsVisible)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IUIELEMENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
