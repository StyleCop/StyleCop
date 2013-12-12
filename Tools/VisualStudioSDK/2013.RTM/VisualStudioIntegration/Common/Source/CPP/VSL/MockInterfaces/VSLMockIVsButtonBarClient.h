/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBUTTONBARCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBUTTONBARCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsButtonBarClientNotImpl :
	public IVsButtonBarClient
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsButtonBarClientNotImpl)

public:

	typedef IVsButtonBarClient Interface;

	STDMETHOD(SetButtonBar)(
		/*[in]*/ IVsButtonBar* /*pButtonBar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetButtonTipText)(
		/*[in]*/ long /*iButton*/,
		/*[out]*/ BSTR* /*pbstrTip*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnButtonPressed)(
		/*[in]*/ long /*iButton*/)VSL_STDMETHOD_NOTIMPL
};

class IVsButtonBarClientMockImpl :
	public IVsButtonBarClient,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsButtonBarClientMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsButtonBarClientMockImpl)

	typedef IVsButtonBarClient Interface;
	struct SetButtonBarValidValues
	{
		/*[in]*/ IVsButtonBar* pButtonBar;
		HRESULT retValue;
	};

	STDMETHOD(SetButtonBar)(
		/*[in]*/ IVsButtonBar* pButtonBar)
	{
		VSL_DEFINE_MOCK_METHOD(SetButtonBar)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pButtonBar);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetButtonTipTextValidValues
	{
		/*[in]*/ long iButton;
		/*[out]*/ BSTR* pbstrTip;
		HRESULT retValue;
	};

	STDMETHOD(GetButtonTipText)(
		/*[in]*/ long iButton,
		/*[out]*/ BSTR* pbstrTip)
	{
		VSL_DEFINE_MOCK_METHOD(GetButtonTipText)

		VSL_CHECK_VALIDVALUE(iButton);

		VSL_SET_VALIDVALUE_BSTR(pbstrTip);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnButtonPressedValidValues
	{
		/*[in]*/ long iButton;
		HRESULT retValue;
	};

	STDMETHOD(OnButtonPressed)(
		/*[in]*/ long iButton)
	{
		VSL_DEFINE_MOCK_METHOD(OnButtonPressed)

		VSL_CHECK_VALIDVALUE(iButton);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBUTTONBARCLIENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
