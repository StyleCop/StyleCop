/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPONENTSELECTORDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPONENTSELECTORDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsComponentSelectorDlgNotImpl :
	public IVsComponentSelectorDlg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentSelectorDlgNotImpl)

public:

	typedef IVsComponentSelectorDlg Interface;

	STDMETHOD(ComponentSelectorDlg)(
		/*[in]*/ VSCOMPSELFLAGS /*grfFlags*/,
		/*[in]*/ IVsComponentUser* /*pUser*/,
		/*[in]*/ LPCOLESTR /*lpszDlgTitle*/,
		/*[in]*/ LPCOLESTR /*lpszHelpTopic*/,
		/*[in]*/ REFGUID /*rguidShowOnlyThisTab*/,
		/*[in]*/ REFGUID /*rguidStartOnThisTab*/,
		/*[in]*/ LPCOLESTR /*pszMachineName*/,
		/*[in]*/ ULONG /*cTabInitializers*/,
		/*[in]*/ VSCOMPONENTSELECTORTABINIT* /*prgcstiTabInitializers*/,
		/*[in]*/ LPCOLESTR /*pszBrowseFilters*/,
		/*[in,out]*/ BSTR* /*pbstrBrowseLocation*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComponentSelectorDlgMockImpl :
	public IVsComponentSelectorDlg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentSelectorDlgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComponentSelectorDlgMockImpl)

	typedef IVsComponentSelectorDlg Interface;
	struct ComponentSelectorDlgValidValues
	{
		/*[in]*/ VSCOMPSELFLAGS grfFlags;
		/*[in]*/ IVsComponentUser* pUser;
		/*[in]*/ LPCOLESTR lpszDlgTitle;
		/*[in]*/ LPCOLESTR lpszHelpTopic;
		/*[in]*/ REFGUID rguidShowOnlyThisTab;
		/*[in]*/ REFGUID rguidStartOnThisTab;
		/*[in]*/ LPCOLESTR pszMachineName;
		/*[in]*/ ULONG cTabInitializers;
		/*[in]*/ VSCOMPONENTSELECTORTABINIT* prgcstiTabInitializers;
		/*[in]*/ LPCOLESTR pszBrowseFilters;
		/*[in,out]*/ BSTR* pbstrBrowseLocation;
		HRESULT retValue;
	};

	STDMETHOD(ComponentSelectorDlg)(
		/*[in]*/ VSCOMPSELFLAGS grfFlags,
		/*[in]*/ IVsComponentUser* pUser,
		/*[in]*/ LPCOLESTR lpszDlgTitle,
		/*[in]*/ LPCOLESTR lpszHelpTopic,
		/*[in]*/ REFGUID rguidShowOnlyThisTab,
		/*[in]*/ REFGUID rguidStartOnThisTab,
		/*[in]*/ LPCOLESTR pszMachineName,
		/*[in]*/ ULONG cTabInitializers,
		/*[in]*/ VSCOMPONENTSELECTORTABINIT* prgcstiTabInitializers,
		/*[in]*/ LPCOLESTR pszBrowseFilters,
		/*[in,out]*/ BSTR* pbstrBrowseLocation)
	{
		VSL_DEFINE_MOCK_METHOD(ComponentSelectorDlg)

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUser);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszDlgTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszHelpTopic);

		VSL_CHECK_VALIDVALUE(rguidShowOnlyThisTab);

		VSL_CHECK_VALIDVALUE(rguidStartOnThisTab);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMachineName);

		VSL_CHECK_VALIDVALUE(cTabInitializers);

		VSL_CHECK_VALIDVALUE_POINTER(prgcstiTabInitializers);

		VSL_CHECK_VALIDVALUE_STRINGW(pszBrowseFilters);

		VSL_SET_VALIDVALUE_BSTR(pbstrBrowseLocation);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPONENTSELECTORDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
