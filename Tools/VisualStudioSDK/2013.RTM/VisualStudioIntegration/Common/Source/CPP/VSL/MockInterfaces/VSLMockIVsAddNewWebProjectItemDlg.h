/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSADDNEWWEBPROJECTITEMDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSADDNEWWEBPROJECTITEMDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAddNewWebProjectItemDlgNotImpl :
	public IVsAddNewWebProjectItemDlg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddNewWebProjectItemDlgNotImpl)

public:

	typedef IVsAddNewWebProjectItemDlg Interface;

	STDMETHOD(AddNewWebProjectItemDlg)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ REFGUID /*rguidProject*/,
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ LPCOLESTR /*pszDlgTitle*/,
		/*[in]*/ LPCOLESTR /*lpszHelpTopic*/,
		/*[in]*/ LPCOLESTR /*lpszLanguage*/,
		/*[in]*/ LPCOLESTR /*lpszSelect*/,
		/*[in]*/ VSADDNEWWEBITEMOPTIONS /*options*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAddNewWebProjectItemDlgMockImpl :
	public IVsAddNewWebProjectItemDlg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddNewWebProjectItemDlgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAddNewWebProjectItemDlgMockImpl)

	typedef IVsAddNewWebProjectItemDlg Interface;
	struct AddNewWebProjectItemDlgValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ REFGUID rguidProject;
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ LPCOLESTR pszDlgTitle;
		/*[in]*/ LPCOLESTR lpszHelpTopic;
		/*[in]*/ LPCOLESTR lpszLanguage;
		/*[in]*/ LPCOLESTR lpszSelect;
		/*[in]*/ VSADDNEWWEBITEMOPTIONS options;
		HRESULT retValue;
	};

	STDMETHOD(AddNewWebProjectItemDlg)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ REFGUID rguidProject,
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ LPCOLESTR pszDlgTitle,
		/*[in]*/ LPCOLESTR lpszHelpTopic,
		/*[in]*/ LPCOLESTR lpszLanguage,
		/*[in]*/ LPCOLESTR lpszSelect,
		/*[in]*/ VSADDNEWWEBITEMOPTIONS options)
	{
		VSL_DEFINE_MOCK_METHOD(AddNewWebProjectItemDlg)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(rguidProject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDlgTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszHelpTopic);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszLanguage);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszSelect);

		VSL_CHECK_VALIDVALUE(options);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSADDNEWWEBPROJECTITEMDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
