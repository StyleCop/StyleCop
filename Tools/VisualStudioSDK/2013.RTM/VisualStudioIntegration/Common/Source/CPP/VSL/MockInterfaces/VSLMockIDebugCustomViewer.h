/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGCUSTOMVIEWER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGCUSTOMVIEWER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugCustomViewerNotImpl :
	public IDebugCustomViewer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCustomViewerNotImpl)

public:

	typedef IDebugCustomViewer Interface;

	STDMETHOD(DisplayValue)(
		/*[in]*/ HWND /*hwnd*/,
		/*[in]*/ DWORD /*dwID*/,
		/*[in]*/ IUnknown* /*pHostServices*/,
		/*[in]*/ IDebugProperty3* /*pDebugProperty*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugCustomViewerMockImpl :
	public IDebugCustomViewer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCustomViewerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugCustomViewerMockImpl)

	typedef IDebugCustomViewer Interface;
	struct DisplayValueValidValues
	{
		/*[in]*/ HWND hwnd;
		/*[in]*/ DWORD dwID;
		/*[in]*/ IUnknown* pHostServices;
		/*[in]*/ IDebugProperty3* pDebugProperty;
		HRESULT retValue;
	};

	STDMETHOD(DisplayValue)(
		/*[in]*/ HWND hwnd,
		/*[in]*/ DWORD dwID,
		/*[in]*/ IUnknown* pHostServices,
		/*[in]*/ IDebugProperty3* pDebugProperty)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayValue)

		VSL_CHECK_VALIDVALUE(hwnd);

		VSL_CHECK_VALIDVALUE(dwID);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHostServices);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDebugProperty);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGCUSTOMVIEWER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
