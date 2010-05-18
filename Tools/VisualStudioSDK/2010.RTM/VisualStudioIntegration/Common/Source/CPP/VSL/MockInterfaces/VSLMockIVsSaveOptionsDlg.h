/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSAVEOPTIONSDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSAVEOPTIONSDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSaveOptionsDlgNotImpl :
	public IVsSaveOptionsDlg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSaveOptionsDlgNotImpl)

public:

	typedef IVsSaveOptionsDlg Interface;

	STDMETHOD(ShowSaveOptionsDlg)(
		/*[in]*/ DWORD /*dwReserved*/,
		/*[in]*/ HWND /*hwndDlgParent*/,
		/*[in]*/ WCHAR* /*pszFileName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSaveOptionsDlgMockImpl :
	public IVsSaveOptionsDlg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSaveOptionsDlgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSaveOptionsDlgMockImpl)

	typedef IVsSaveOptionsDlg Interface;
	struct ShowSaveOptionsDlgValidValues
	{
		/*[in]*/ DWORD dwReserved;
		/*[in]*/ HWND hwndDlgParent;
		/*[in]*/ WCHAR* pszFileName;
		HRESULT retValue;
	};

	STDMETHOD(ShowSaveOptionsDlg)(
		/*[in]*/ DWORD dwReserved,
		/*[in]*/ HWND hwndDlgParent,
		/*[in]*/ WCHAR* pszFileName)
	{
		VSL_DEFINE_MOCK_METHOD(ShowSaveOptionsDlg)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_CHECK_VALIDVALUE(hwndDlgParent);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSAVEOPTIONSDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
