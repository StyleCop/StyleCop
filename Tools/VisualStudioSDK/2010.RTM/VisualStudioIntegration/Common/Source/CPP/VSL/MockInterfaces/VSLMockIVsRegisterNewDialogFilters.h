/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSREGISTERNEWDIALOGFILTERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSREGISTERNEWDIALOGFILTERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsRegisterNewDialogFiltersNotImpl :
	public IVsRegisterNewDialogFilters
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterNewDialogFiltersNotImpl)

public:

	typedef IVsRegisterNewDialogFilters Interface;

	STDMETHOD(RegisterNewProjectDialogFilter)(
		/*[in]*/ IVsFilterNewProjectDlg* /*pFilter*/,
		/*[out]*/ VSCOOKIE* /*pdwFilterCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterNewProjectDialogFilter)(
		/*[in]*/ VSCOOKIE /*dwFilterCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterAddNewItemDialogFilter)(
		/*[in]*/ IVsFilterAddProjectItemDlg* /*pFilter*/,
		/*[out]*/ VSCOOKIE* /*pdwFilterCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnregisterAddNewItemDialogFilter)(
		/*[in]*/ VSCOOKIE /*dwFilterCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRegisterNewDialogFiltersMockImpl :
	public IVsRegisterNewDialogFilters,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterNewDialogFiltersMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRegisterNewDialogFiltersMockImpl)

	typedef IVsRegisterNewDialogFilters Interface;
	struct RegisterNewProjectDialogFilterValidValues
	{
		/*[in]*/ IVsFilterNewProjectDlg* pFilter;
		/*[out]*/ VSCOOKIE* pdwFilterCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterNewProjectDialogFilter)(
		/*[in]*/ IVsFilterNewProjectDlg* pFilter,
		/*[out]*/ VSCOOKIE* pdwFilterCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterNewProjectDialogFilter)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFilter);

		VSL_SET_VALIDVALUE(pdwFilterCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterNewProjectDialogFilterValidValues
	{
		/*[in]*/ VSCOOKIE dwFilterCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterNewProjectDialogFilter)(
		/*[in]*/ VSCOOKIE dwFilterCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterNewProjectDialogFilter)

		VSL_CHECK_VALIDVALUE(dwFilterCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterAddNewItemDialogFilterValidValues
	{
		/*[in]*/ IVsFilterAddProjectItemDlg* pFilter;
		/*[out]*/ VSCOOKIE* pdwFilterCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterAddNewItemDialogFilter)(
		/*[in]*/ IVsFilterAddProjectItemDlg* pFilter,
		/*[out]*/ VSCOOKIE* pdwFilterCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterAddNewItemDialogFilter)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFilter);

		VSL_SET_VALIDVALUE(pdwFilterCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnregisterAddNewItemDialogFilterValidValues
	{
		/*[in]*/ VSCOOKIE dwFilterCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnregisterAddNewItemDialogFilter)(
		/*[in]*/ VSCOOKIE dwFilterCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnregisterAddNewItemDialogFilter)

		VSL_CHECK_VALIDVALUE(dwFilterCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSREGISTERNEWDIALOGFILTERS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
