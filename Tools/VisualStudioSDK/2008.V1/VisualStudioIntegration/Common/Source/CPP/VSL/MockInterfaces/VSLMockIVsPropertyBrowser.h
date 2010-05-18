/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROPERTYBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROPERTYBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPropertyBrowserNotImpl :
	public IVsPropertyBrowser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyBrowserNotImpl)

public:

	typedef IVsPropertyBrowser Interface;

	STDMETHOD(GetState)(
		/*[in,out]*/ VsPropertyBrowserState* /*pState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetState)(
		/*[in]*/ const VsPropertyBrowserState* /*pState*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPropertyBrowserMockImpl :
	public IVsPropertyBrowser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyBrowserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPropertyBrowserMockImpl)

	typedef IVsPropertyBrowser Interface;
	struct GetStateValidValues
	{
		/*[in,out]*/ VsPropertyBrowserState* pState;
		HRESULT retValue;
	};

	STDMETHOD(GetState)(
		/*[in,out]*/ VsPropertyBrowserState* pState)
	{
		VSL_DEFINE_MOCK_METHOD(GetState)

		VSL_SET_VALIDVALUE(pState);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStateValidValues
	{
		/*[in]*/ VsPropertyBrowserState* pState;
		HRESULT retValue;
	};

	STDMETHOD(SetState)(
		/*[in]*/ const VsPropertyBrowserState* pState)
	{
		VSL_DEFINE_MOCK_METHOD(SetState)

		VSL_CHECK_VALIDVALUE_POINTER(pState);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROPERTYBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
