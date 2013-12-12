/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWINDOWFRAMENOTIFY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWINDOWFRAMENOTIFY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWindowFrameNotify3NotImpl :
	public IVsWindowFrameNotify3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrameNotify3NotImpl)

public:

	typedef IVsWindowFrameNotify3 Interface;

	STDMETHOD(OnShow)(
		/*[in]*/ FRAMESHOW2 /*fShow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnMove)(
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[in]*/ int /*w*/,
		/*[in]*/ int /*h*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnSize)(
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[in]*/ int /*w*/,
		/*[in]*/ int /*h*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnDockableChange)(
		/*[in]*/ BOOL /*fDockable*/,
		/*[in]*/ int /*x*/,
		/*[in]*/ int /*y*/,
		/*[in]*/ int /*w*/,
		/*[in]*/ int /*h*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnClose)(
		/*[in,out]*/ FRAMECLOSE* /*pgrfSaveOptions*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWindowFrameNotify3MockImpl :
	public IVsWindowFrameNotify3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrameNotify3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWindowFrameNotify3MockImpl)

	typedef IVsWindowFrameNotify3 Interface;
	struct OnShowValidValues
	{
		/*[in]*/ FRAMESHOW2 fShow;
		HRESULT retValue;
	};

	STDMETHOD(OnShow)(
		/*[in]*/ FRAMESHOW2 fShow)
	{
		VSL_DEFINE_MOCK_METHOD(OnShow)

		VSL_CHECK_VALIDVALUE(fShow);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnMoveValidValues
	{
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[in]*/ int w;
		/*[in]*/ int h;
		HRESULT retValue;
	};

	STDMETHOD(OnMove)(
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[in]*/ int w,
		/*[in]*/ int h)
	{
		VSL_DEFINE_MOCK_METHOD(OnMove)

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(w);

		VSL_CHECK_VALIDVALUE(h);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnSizeValidValues
	{
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[in]*/ int w;
		/*[in]*/ int h;
		HRESULT retValue;
	};

	STDMETHOD(OnSize)(
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[in]*/ int w,
		/*[in]*/ int h)
	{
		VSL_DEFINE_MOCK_METHOD(OnSize)

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(w);

		VSL_CHECK_VALIDVALUE(h);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnDockableChangeValidValues
	{
		/*[in]*/ BOOL fDockable;
		/*[in]*/ int x;
		/*[in]*/ int y;
		/*[in]*/ int w;
		/*[in]*/ int h;
		HRESULT retValue;
	};

	STDMETHOD(OnDockableChange)(
		/*[in]*/ BOOL fDockable,
		/*[in]*/ int x,
		/*[in]*/ int y,
		/*[in]*/ int w,
		/*[in]*/ int h)
	{
		VSL_DEFINE_MOCK_METHOD(OnDockableChange)

		VSL_CHECK_VALIDVALUE(fDockable);

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(w);

		VSL_CHECK_VALIDVALUE(h);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCloseValidValues
	{
		/*[in,out]*/ FRAMECLOSE* pgrfSaveOptions;
		HRESULT retValue;
	};

	STDMETHOD(OnClose)(
		/*[in,out]*/ FRAMECLOSE* pgrfSaveOptions)
	{
		VSL_DEFINE_MOCK_METHOD(OnClose)

		VSL_SET_VALIDVALUE(pgrfSaveOptions);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWINDOWFRAMENOTIFY3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
