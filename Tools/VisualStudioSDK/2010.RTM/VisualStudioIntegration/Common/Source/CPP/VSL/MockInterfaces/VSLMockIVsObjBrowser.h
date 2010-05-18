/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOBJBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOBJBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsObjBrowserNotImpl :
	public IVsObjBrowser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjBrowserNotImpl)

public:

	typedef IVsObjBrowser Interface;

	STDMETHOD(NavigateTo)(
		/*[in]*/ const VSOBJECTINFO* /*pObjInfo*/,
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL
};

class IVsObjBrowserMockImpl :
	public IVsObjBrowser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsObjBrowserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsObjBrowserMockImpl)

	typedef IVsObjBrowser Interface;
	struct NavigateToValidValues
	{
		/*[in]*/ VSOBJECTINFO* pObjInfo;
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(NavigateTo)(
		/*[in]*/ const VSOBJECTINFO* pObjInfo,
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(NavigateTo)

		VSL_CHECK_VALIDVALUE_POINTER(pObjInfo);

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOBJBROWSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
