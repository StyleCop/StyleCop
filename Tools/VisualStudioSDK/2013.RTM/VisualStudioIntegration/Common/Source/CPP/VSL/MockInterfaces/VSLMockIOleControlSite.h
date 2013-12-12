/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECONTROLSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECONTROLSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IOleControlSiteNotImpl :
	public IOleControlSite
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleControlSiteNotImpl)

public:

	typedef IOleControlSite Interface;

	STDMETHOD(OnControlInfoChanged)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockInPlaceActive)(
		/*[in]*/ BOOL /*fLock*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExtendedControl)(
		/*[out]*/ IDispatch** /*ppDisp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TransformCoords)(
		/*[in,out]*/ POINTL* /*pPtlHimetric*/,
		/*[in,out]*/ POINTF* /*pPtfContainer*/,
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ MSG* /*pMsg*/,
		/*[in]*/ DWORD /*grfModifiers*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnFocus)(
		/*[in]*/ BOOL /*fGotFocus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowPropertyFrame)()VSL_STDMETHOD_NOTIMPL
};

class IOleControlSiteMockImpl :
	public IOleControlSite,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleControlSiteMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleControlSiteMockImpl)

	typedef IOleControlSite Interface;
	struct OnControlInfoChangedValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnControlInfoChanged)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnControlInfoChanged)

		VSL_RETURN_VALIDVALUES();
	}
	struct LockInPlaceActiveValidValues
	{
		/*[in]*/ BOOL fLock;
		HRESULT retValue;
	};

	STDMETHOD(LockInPlaceActive)(
		/*[in]*/ BOOL fLock)
	{
		VSL_DEFINE_MOCK_METHOD(LockInPlaceActive)

		VSL_CHECK_VALIDVALUE(fLock);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExtendedControlValidValues
	{
		/*[out]*/ IDispatch** ppDisp;
		HRESULT retValue;
	};

	STDMETHOD(GetExtendedControl)(
		/*[out]*/ IDispatch** ppDisp)
	{
		VSL_DEFINE_MOCK_METHOD(GetExtendedControl)

		VSL_SET_VALIDVALUE_INTERFACE(ppDisp);

		VSL_RETURN_VALIDVALUES();
	}
	struct TransformCoordsValidValues
	{
		/*[in,out]*/ POINTL* pPtlHimetric;
		/*[in,out]*/ POINTF* pPtfContainer;
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(TransformCoords)(
		/*[in,out]*/ POINTL* pPtlHimetric,
		/*[in,out]*/ POINTF* pPtfContainer,
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(TransformCoords)

		VSL_SET_VALIDVALUE(pPtlHimetric);

		VSL_SET_VALIDVALUE(pPtfContainer);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateAcceleratorValidValues
	{
		/*[in]*/ MSG* pMsg;
		/*[in]*/ DWORD grfModifiers;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ MSG* pMsg,
		/*[in]*/ DWORD grfModifiers)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelerator)

		VSL_CHECK_VALIDVALUE_POINTER(pMsg);

		VSL_CHECK_VALIDVALUE(grfModifiers);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnFocusValidValues
	{
		/*[in]*/ BOOL fGotFocus;
		HRESULT retValue;
	};

	STDMETHOD(OnFocus)(
		/*[in]*/ BOOL fGotFocus)
	{
		VSL_DEFINE_MOCK_METHOD(OnFocus)

		VSL_CHECK_VALIDVALUE(fGotFocus);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowPropertyFrameValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShowPropertyFrame)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShowPropertyFrame)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECONTROLSITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
