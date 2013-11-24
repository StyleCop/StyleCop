/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODEWINDOWEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODEWINDOWEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCodeWindowEventsNotImpl :
	public IVsCodeWindowEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowEventsNotImpl)

public:

	typedef IVsCodeWindowEvents Interface;

	STDMETHOD(OnNewView)(
		/*[in]*/ IVsTextView* /*pView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnCloseView)(
		/*[in]*/ IVsTextView* /*pView*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCodeWindowEventsMockImpl :
	public IVsCodeWindowEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodeWindowEventsMockImpl)

	typedef IVsCodeWindowEvents Interface;
	struct OnNewViewValidValues
	{
		/*[in]*/ IVsTextView* pView;
		HRESULT retValue;
	};

	STDMETHOD(OnNewView)(
		/*[in]*/ IVsTextView* pView)
	{
		VSL_DEFINE_MOCK_METHOD(OnNewView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnCloseViewValidValues
	{
		/*[in]*/ IVsTextView* pView;
		HRESULT retValue;
	};

	STDMETHOD(OnCloseView)(
		/*[in]*/ IVsTextView* pView)
	{
		VSL_DEFINE_MOCK_METHOD(OnCloseView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODEWINDOWEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
