/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWINDOWFRAMENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWINDOWFRAMENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWindowFrameNotifyNotImpl :
	public IVsWindowFrameNotify
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrameNotifyNotImpl)

public:

	typedef IVsWindowFrameNotify Interface;

	STDMETHOD(OnShow)(
		/*[in]*/ FRAMESHOW /*fShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnMove)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnSize)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDockableChange)(
		/*[in]*/ BOOL /*fDockable*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWindowFrameNotifyMockImpl :
	public IVsWindowFrameNotify,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrameNotifyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWindowFrameNotifyMockImpl)

	typedef IVsWindowFrameNotify Interface;
	struct OnShowValidValues
	{
		/*[in]*/ FRAMESHOW fShow;
		HRESULT retValue;
	};

	STDMETHOD(OnShow)(
		/*[in]*/ FRAMESHOW fShow)
	{
		VSL_DEFINE_MOCK_METHOD(OnShow)

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnMoveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnMove)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnMove)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnSizeValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnSize)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnSize)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDockableChangeValidValues
	{
		/*[in]*/ BOOL fDockable;
		HRESULT retValue;
	};

	STDMETHOD(OnDockableChange)(
		/*[in]*/ BOOL fDockable)
	{
		VSL_DEFINE_MOCK_METHOD(OnDockableChange)

		VSL_CHECK_VALIDVALUE(fDockable);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWINDOWFRAMENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
