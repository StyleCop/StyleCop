/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsWebProjectNotImpl :
	public IVsWebProject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebProjectNotImpl)

public:

	typedef IVsWebProject Interface;

	STDMETHOD(AddNewWebItem)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ VSADDITEMOPERATION /*dwAddItemOperation*/,
		/*[in]*/ LPCOLESTR /*pszItemName*/,
		/*[in]*/ LPCOLESTR /*pszFileTemplate*/,
		/*[in]*/ VSADDNEWWEBITEMOPTIONS /*options*/,
		/*[in]*/ LPCOLESTR /*pszSelectedLanguage*/,
		/*[in]*/ HWND /*hwndDlgOwner*/,
		/*[out,retval]*/ VSADDRESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebProjectMockImpl :
	public IVsWebProject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebProjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebProjectMockImpl)

	typedef IVsWebProject Interface;
	struct AddNewWebItemValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ VSADDITEMOPERATION dwAddItemOperation;
		/*[in]*/ LPCOLESTR pszItemName;
		/*[in]*/ LPCOLESTR pszFileTemplate;
		/*[in]*/ VSADDNEWWEBITEMOPTIONS options;
		/*[in]*/ LPCOLESTR pszSelectedLanguage;
		/*[in]*/ HWND hwndDlgOwner;
		/*[out,retval]*/ VSADDRESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(AddNewWebItem)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ VSADDITEMOPERATION dwAddItemOperation,
		/*[in]*/ LPCOLESTR pszItemName,
		/*[in]*/ LPCOLESTR pszFileTemplate,
		/*[in]*/ VSADDNEWWEBITEMOPTIONS options,
		/*[in]*/ LPCOLESTR pszSelectedLanguage,
		/*[in]*/ HWND hwndDlgOwner,
		/*[out,retval]*/ VSADDRESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(AddNewWebItem)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(dwAddItemOperation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszItemName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFileTemplate);

		VSL_CHECK_VALIDVALUE(options);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSelectedLanguage);

		VSL_CHECK_VALIDVALUE(hwndDlgOwner);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
