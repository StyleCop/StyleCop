/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPORTPICKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPORTPICKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugPortPickerNotImpl :
	public IDebugPortPicker
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPortPickerNotImpl)

public:

	typedef IDebugPortPicker Interface;

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisplayPortPicker)(
		/*[in]*/ HWND /*hwndParentDialog*/,
		/*[out]*/ BSTR* /*pbstrPortId*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugPortPickerMockImpl :
	public IDebugPortPicker,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPortPickerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugPortPickerMockImpl)

	typedef IDebugPortPicker Interface;
	struct SetSiteValidValues
	{
		/*[in]*/ IServiceProvider* pSP;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* pSP)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisplayPortPickerValidValues
	{
		/*[in]*/ HWND hwndParentDialog;
		/*[out]*/ BSTR* pbstrPortId;
		HRESULT retValue;
	};

	STDMETHOD(DisplayPortPicker)(
		/*[in]*/ HWND hwndParentDialog,
		/*[out]*/ BSTR* pbstrPortId)
	{
		VSL_DEFINE_MOCK_METHOD(DisplayPortPicker)

		VSL_CHECK_VALIDVALUE(hwndParentDialog);

		VSL_SET_VALIDVALUE_BSTR(pbstrPortId);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPORTPICKER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
