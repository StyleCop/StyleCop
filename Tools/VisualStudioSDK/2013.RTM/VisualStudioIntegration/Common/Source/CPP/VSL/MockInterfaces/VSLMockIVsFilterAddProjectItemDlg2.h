/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFILTERADDPROJECTITEMDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFILTERADDPROJECTITEMDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFilterAddProjectItemDlg2NotImpl :
	public IVsFilterAddProjectItemDlg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFilterAddProjectItemDlg2NotImpl)

public:

	typedef IVsFilterAddProjectItemDlg2 Interface;

	STDMETHOD(FilterTreeItemByCategory)(
		/*[in]*/ REFGUID /*rguidProjectItemTemplates*/,
		/*[in]*/ LPCOLESTR /*pszCategoryName*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterListItemByCategory)(
		/*[in]*/ REFGUID /*rguidProjectItemTemplates*/,
		/*[in]*/ LPCOLESTR /*pszCategoryName*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterTreeItemByLocalizedName)(
		/*[in]*/ REFGUID /*rguidProjectItemTemplates*/,
		/*[in]*/ LPCOLESTR /*pszLocalizedName*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterTreeItemByTemplateDir)(
		/*[in]*/ REFGUID /*rguidProjectItemTemplates*/,
		/*[in]*/ LPCOLESTR /*pszTemplateDir*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterListItemByLocalizedName)(
		/*[in]*/ REFGUID /*rguidProjectItemTemplates*/,
		/*[in]*/ LPCOLESTR /*pszLocalizedName*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterListItemByTemplateFile)(
		/*[in]*/ REFGUID /*rguidProjectItemTemplates*/,
		/*[in]*/ LPCOLESTR /*pszTemplateFile*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFilterAddProjectItemDlg2MockImpl :
	public IVsFilterAddProjectItemDlg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFilterAddProjectItemDlg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFilterAddProjectItemDlg2MockImpl)

	typedef IVsFilterAddProjectItemDlg2 Interface;
	struct FilterTreeItemByCategoryValidValues
	{
		/*[in]*/ REFGUID rguidProjectItemTemplates;
		/*[in]*/ LPCOLESTR pszCategoryName;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterTreeItemByCategory)(
		/*[in]*/ REFGUID rguidProjectItemTemplates,
		/*[in]*/ LPCOLESTR pszCategoryName,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterTreeItemByCategory)

		VSL_CHECK_VALIDVALUE(rguidProjectItemTemplates);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCategoryName);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterListItemByCategoryValidValues
	{
		/*[in]*/ REFGUID rguidProjectItemTemplates;
		/*[in]*/ LPCOLESTR pszCategoryName;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterListItemByCategory)(
		/*[in]*/ REFGUID rguidProjectItemTemplates,
		/*[in]*/ LPCOLESTR pszCategoryName,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterListItemByCategory)

		VSL_CHECK_VALIDVALUE(rguidProjectItemTemplates);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCategoryName);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterTreeItemByLocalizedNameValidValues
	{
		/*[in]*/ REFGUID rguidProjectItemTemplates;
		/*[in]*/ LPCOLESTR pszLocalizedName;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterTreeItemByLocalizedName)(
		/*[in]*/ REFGUID rguidProjectItemTemplates,
		/*[in]*/ LPCOLESTR pszLocalizedName,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterTreeItemByLocalizedName)

		VSL_CHECK_VALIDVALUE(rguidProjectItemTemplates);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocalizedName);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterTreeItemByTemplateDirValidValues
	{
		/*[in]*/ REFGUID rguidProjectItemTemplates;
		/*[in]*/ LPCOLESTR pszTemplateDir;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterTreeItemByTemplateDir)(
		/*[in]*/ REFGUID rguidProjectItemTemplates,
		/*[in]*/ LPCOLESTR pszTemplateDir,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterTreeItemByTemplateDir)

		VSL_CHECK_VALIDVALUE(rguidProjectItemTemplates);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTemplateDir);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterListItemByLocalizedNameValidValues
	{
		/*[in]*/ REFGUID rguidProjectItemTemplates;
		/*[in]*/ LPCOLESTR pszLocalizedName;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterListItemByLocalizedName)(
		/*[in]*/ REFGUID rguidProjectItemTemplates,
		/*[in]*/ LPCOLESTR pszLocalizedName,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterListItemByLocalizedName)

		VSL_CHECK_VALIDVALUE(rguidProjectItemTemplates);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocalizedName);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterListItemByTemplateFileValidValues
	{
		/*[in]*/ REFGUID rguidProjectItemTemplates;
		/*[in]*/ LPCOLESTR pszTemplateFile;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterListItemByTemplateFile)(
		/*[in]*/ REFGUID rguidProjectItemTemplates,
		/*[in]*/ LPCOLESTR pszTemplateFile,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterListItemByTemplateFile)

		VSL_CHECK_VALIDVALUE(rguidProjectItemTemplates);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTemplateFile);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFILTERADDPROJECTITEMDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
