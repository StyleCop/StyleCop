/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFILTERNEWPROJECTDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFILTERNEWPROJECTDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFilterNewProjectDlgNotImpl :
	public IVsFilterNewProjectDlg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFilterNewProjectDlgNotImpl)

public:

	typedef IVsFilterNewProjectDlg Interface;

	STDMETHOD(FilterTreeItemByLocalizedName)(
		/*[in]*/ LPCOLESTR /*pszLocalizedName*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterTreeItemByTemplateDir)(
		/*[in]*/ LPCOLESTR /*pszTemplateDir*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterListItemByLocalizedName)(
		/*[in]*/ LPCOLESTR /*pszLocalizedName*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FilterListItemByTemplateFile)(
		/*[in]*/ LPCOLESTR /*pszTemplateFile*/,
		/*[out]*/ BOOL* /*pfFilter*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFilterNewProjectDlgMockImpl :
	public IVsFilterNewProjectDlg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFilterNewProjectDlgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFilterNewProjectDlgMockImpl)

	typedef IVsFilterNewProjectDlg Interface;
	struct FilterTreeItemByLocalizedNameValidValues
	{
		/*[in]*/ LPCOLESTR pszLocalizedName;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterTreeItemByLocalizedName)(
		/*[in]*/ LPCOLESTR pszLocalizedName,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterTreeItemByLocalizedName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocalizedName);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterTreeItemByTemplateDirValidValues
	{
		/*[in]*/ LPCOLESTR pszTemplateDir;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterTreeItemByTemplateDir)(
		/*[in]*/ LPCOLESTR pszTemplateDir,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterTreeItemByTemplateDir)

		VSL_CHECK_VALIDVALUE_STRINGW(pszTemplateDir);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterListItemByLocalizedNameValidValues
	{
		/*[in]*/ LPCOLESTR pszLocalizedName;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterListItemByLocalizedName)(
		/*[in]*/ LPCOLESTR pszLocalizedName,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterListItemByLocalizedName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocalizedName);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
	struct FilterListItemByTemplateFileValidValues
	{
		/*[in]*/ LPCOLESTR pszTemplateFile;
		/*[out]*/ BOOL* pfFilter;
		HRESULT retValue;
	};

	STDMETHOD(FilterListItemByTemplateFile)(
		/*[in]*/ LPCOLESTR pszTemplateFile,
		/*[out]*/ BOOL* pfFilter)
	{
		VSL_DEFINE_MOCK_METHOD(FilterListItemByTemplateFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszTemplateFile);

		VSL_SET_VALIDVALUE(pfFilter);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFILTERNEWPROJECTDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
