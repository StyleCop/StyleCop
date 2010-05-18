/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBACKFORWARDNAVIGATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBACKFORWARDNAVIGATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsBackForwardNavigationNotImpl :
	public IVsBackForwardNavigation
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBackForwardNavigationNotImpl)

public:

	typedef IVsBackForwardNavigation Interface;

	STDMETHOD(NavigateTo)(
		/*[in]*/ IVsWindowFrame* /*pFrame*/,
		/*[in]*/ BSTR /*bstrData*/,
		/*[in]*/ IUnknown* /*punk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsEqual)(
		/*[in]*/ IVsWindowFrame* /*pFrame*/,
		/*[in]*/ BSTR /*bstrData*/,
		/*[in]*/ IUnknown* /*punk*/,
		/*[out,retval]*/ BOOL* /*fReplaceSelf*/)VSL_STDMETHOD_NOTIMPL
};

class IVsBackForwardNavigationMockImpl :
	public IVsBackForwardNavigation,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBackForwardNavigationMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsBackForwardNavigationMockImpl)

	typedef IVsBackForwardNavigation Interface;
	struct NavigateToValidValues
	{
		/*[in]*/ IVsWindowFrame* pFrame;
		/*[in]*/ BSTR bstrData;
		/*[in]*/ IUnknown* punk;
		HRESULT retValue;
	};

	STDMETHOD(NavigateTo)(
		/*[in]*/ IVsWindowFrame* pFrame,
		/*[in]*/ BSTR bstrData,
		/*[in]*/ IUnknown* punk)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateTo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFrame);

		VSL_CHECK_VALIDVALUE_BSTR(bstrData);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsEqualValidValues
	{
		/*[in]*/ IVsWindowFrame* pFrame;
		/*[in]*/ BSTR bstrData;
		/*[in]*/ IUnknown* punk;
		/*[out,retval]*/ BOOL* fReplaceSelf;
		HRESULT retValue;
	};

	STDMETHOD(IsEqual)(
		/*[in]*/ IVsWindowFrame* pFrame,
		/*[in]*/ BSTR bstrData,
		/*[in]*/ IUnknown* punk,
		/*[out,retval]*/ BOOL* fReplaceSelf)
	{
		VSL_DEFINE_MOCK_METHOD(IsEqual)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFrame);

		VSL_CHECK_VALIDVALUE_BSTR(bstrData);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_SET_VALIDVALUE(fReplaceSelf);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBACKFORWARDNAVIGATION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
