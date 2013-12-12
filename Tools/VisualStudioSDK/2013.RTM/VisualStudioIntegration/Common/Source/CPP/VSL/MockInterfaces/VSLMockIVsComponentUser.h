/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPONENTUSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPONENTUSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsComponentUserNotImpl :
	public IVsComponentUser
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentUserNotImpl)

public:

	typedef IVsComponentUser Interface;

	STDMETHOD(AddComponent)(
		/*[in]*/ VSADDCOMPOPERATION /*dwAddCompOperation*/,
		/*[in]*/ ULONG /*cComponents*/,
		/*[in,size_is(cComponents)]*/ PVSCOMPONENTSELECTORDATA[] /*rgpcsdComponents*/,
		/*[in]*/ HWND /*hwndPickerDlg*/,
		/*[out,retval]*/ VSADDCOMPRESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComponentUserMockImpl :
	public IVsComponentUser,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentUserMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComponentUserMockImpl)

	typedef IVsComponentUser Interface;
	struct AddComponentValidValues
	{
		/*[in]*/ VSADDCOMPOPERATION dwAddCompOperation;
		/*[in]*/ ULONG cComponents;
		/*[in,size_is(cComponents)]*/ PVSCOMPONENTSELECTORDATA* rgpcsdComponents;
		/*[in]*/ HWND hwndPickerDlg;
		/*[out,retval]*/ VSADDCOMPRESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(AddComponent)(
		/*[in]*/ VSADDCOMPOPERATION dwAddCompOperation,
		/*[in]*/ ULONG cComponents,
		/*[in,size_is(cComponents)]*/ PVSCOMPONENTSELECTORDATA rgpcsdComponents[],
		/*[in]*/ HWND hwndPickerDlg,
		/*[out,retval]*/ VSADDCOMPRESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(AddComponent)

		VSL_CHECK_VALIDVALUE(dwAddCompOperation);

		VSL_CHECK_VALIDVALUE(cComponents);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpcsdComponents, cComponents*sizeof(rgpcsdComponents[0]), validValues.cComponents*sizeof(validValues.rgpcsdComponents[0]));

		VSL_CHECK_VALIDVALUE(hwndPickerDlg);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPONENTUSER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
