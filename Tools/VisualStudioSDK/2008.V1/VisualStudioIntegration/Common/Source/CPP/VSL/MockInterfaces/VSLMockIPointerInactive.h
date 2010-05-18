/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPOINTERINACTIVE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPOINTERINACTIVE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPointerInactiveNotImpl :
	public IPointerInactive
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPointerInactiveNotImpl)

public:

	typedef IPointerInactive Interface;

	STDMETHOD(GetActivationPolicy)(
		/*[out]*/ DWORD* /*pdwPolicy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInactiveMouseMove)(
		/*[in]*/ LPCRECT /*pRectBounds*/,
		/*[in]*/ LONG /*x*/,
		/*[in]*/ LONG /*y*/,
		/*[in]*/ DWORD /*grfKeyState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnInactiveSetCursor)(
		/*[in]*/ LPCRECT /*pRectBounds*/,
		/*[in]*/ LONG /*x*/,
		/*[in]*/ LONG /*y*/,
		/*[in]*/ DWORD /*dwMouseMsg*/,
		/*[in]*/ BOOL /*fSetAlways*/)VSL_STDMETHOD_NOTIMPL
};

class IPointerInactiveMockImpl :
	public IPointerInactive,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPointerInactiveMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPointerInactiveMockImpl)

	typedef IPointerInactive Interface;
	struct GetActivationPolicyValidValues
	{
		/*[out]*/ DWORD* pdwPolicy;
		HRESULT retValue;
	};

	STDMETHOD(GetActivationPolicy)(
		/*[out]*/ DWORD* pdwPolicy)
	{
		VSL_DEFINE_MOCK_METHOD(GetActivationPolicy)

		VSL_SET_VALIDVALUE(pdwPolicy);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInactiveMouseMoveValidValues
	{
		/*[in]*/ LPCRECT pRectBounds;
		/*[in]*/ LONG x;
		/*[in]*/ LONG y;
		/*[in]*/ DWORD grfKeyState;
		HRESULT retValue;
	};

	STDMETHOD(OnInactiveMouseMove)(
		/*[in]*/ LPCRECT pRectBounds,
		/*[in]*/ LONG x,
		/*[in]*/ LONG y,
		/*[in]*/ DWORD grfKeyState)
	{
		VSL_DEFINE_MOCK_METHOD(OnInactiveMouseMove)

		VSL_CHECK_VALIDVALUE(pRectBounds);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(grfKeyState);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnInactiveSetCursorValidValues
	{
		/*[in]*/ LPCRECT pRectBounds;
		/*[in]*/ LONG x;
		/*[in]*/ LONG y;
		/*[in]*/ DWORD dwMouseMsg;
		/*[in]*/ BOOL fSetAlways;
		HRESULT retValue;
	};

	STDMETHOD(OnInactiveSetCursor)(
		/*[in]*/ LPCRECT pRectBounds,
		/*[in]*/ LONG x,
		/*[in]*/ LONG y,
		/*[in]*/ DWORD dwMouseMsg,
		/*[in]*/ BOOL fSetAlways)
	{
		VSL_DEFINE_MOCK_METHOD(OnInactiveSetCursor)

		VSL_CHECK_VALIDVALUE(pRectBounds);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(dwMouseMsg);

		VSL_CHECK_VALIDVALUE(fSetAlways);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPOINTERINACTIVE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
