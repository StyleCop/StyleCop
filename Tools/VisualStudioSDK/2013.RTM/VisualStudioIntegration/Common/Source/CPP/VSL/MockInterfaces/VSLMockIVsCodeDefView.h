/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODEDEFVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODEDEFVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCodeDefViewNotImpl :
	public IVsCodeDefView
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeDefViewNotImpl)

public:

	typedef IVsCodeDefView Interface;

	STDMETHOD(ShowWindow)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HideWindow)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsVisible)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetContext)(
		/*[in]*/ IVsCodeDefViewContext* /*pIVsCodeDefViewContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRefreshDelay)(
		/*[out]*/ ULONG* /*pcMilliseconds*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ForceIdleProcessing)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsCodeDefView)(
		/*[in]*/ IVsTextView* /*pIVsTextView*/,
		/*[out]*/ BOOL* /*pfIsCodeDefView*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCodeDefViewMockImpl :
	public IVsCodeDefView,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeDefViewMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodeDefViewMockImpl)

	typedef IVsCodeDefView Interface;
	struct ShowWindowValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShowWindow)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShowWindow)

		VSL_RETURN_VALIDVALUES();
	}
	struct HideWindowValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HideWindow)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HideWindow)

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
	struct SetContextValidValues
	{
		/*[in]*/ IVsCodeDefViewContext* pIVsCodeDefViewContext;
		HRESULT retValue;
	};

	STDMETHOD(SetContext)(
		/*[in]*/ IVsCodeDefViewContext* pIVsCodeDefViewContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetContext)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsCodeDefViewContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRefreshDelayValidValues
	{
		/*[out]*/ ULONG* pcMilliseconds;
		HRESULT retValue;
	};

	STDMETHOD(GetRefreshDelay)(
		/*[out]*/ ULONG* pcMilliseconds)
	{
		VSL_DEFINE_MOCK_METHOD(GetRefreshDelay)

		VSL_SET_VALIDVALUE(pcMilliseconds);

		VSL_RETURN_VALIDVALUES();
	}
	struct ForceIdleProcessingValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ForceIdleProcessing)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ForceIdleProcessing)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsCodeDefViewValidValues
	{
		/*[in]*/ IVsTextView* pIVsTextView;
		/*[out]*/ BOOL* pfIsCodeDefView;
		HRESULT retValue;
	};

	STDMETHOD(IsCodeDefView)(
		/*[in]*/ IVsTextView* pIVsTextView,
		/*[out]*/ BOOL* pfIsCodeDefView)
	{
		VSL_DEFINE_MOCK_METHOD(IsCodeDefView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsTextView);

		VSL_SET_VALIDVALUE(pfIsCodeDefView);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODEDEFVIEW_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
