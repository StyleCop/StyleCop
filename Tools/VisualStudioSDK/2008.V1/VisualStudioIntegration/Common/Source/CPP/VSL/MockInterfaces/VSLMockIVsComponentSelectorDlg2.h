/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMPONENTSELECTORDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMPONENTSELECTORDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsComponentSelectorDlg2NotImpl :
	public IVsComponentSelectorDlg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentSelectorDlg2NotImpl)

public:

	typedef IVsComponentSelectorDlg2 Interface;

	STDMETHOD(ComponentSelectorDlg2)(
		/*[in]*/ VSCOMPSELFLAGS2 /*grfFlags*/,
		/*[in]*/ IVsComponentUser* /*pUser*/,
		/*[in]*/ ULONG /*cComponents*/,
		/*[in,size_is(cComponents)]*/ PVSCOMPONENTSELECTORDATA[] /*rgpcsdComponents*/,
		/*[in]*/ LPCOLESTR /*lpszDlgTitle*/,
		/*[in]*/ LPCOLESTR /*lpszHelpTopic*/,
		/*[in,out]*/ ULONG* /*pxDlgSize*/,
		/*[in,out]*/ ULONG* /*pyDlgSize*/,
		/*[in]*/ ULONG /*cTabInitializers*/,
		/*[in,size_is(cTabInitializers)]*/ VSCOMPONENTSELECTORTABINIT[] /*rgcstiTabInitializers*/,
		/*[in,out]*/ GUID* /*pguidStartOnThisTab*/,
		/*[in]*/ LPCOLESTR /*pszBrowseFilters*/,
		/*[in,out]*/ BSTR* /*pbstrBrowseLocation*/)VSL_STDMETHOD_NOTIMPL
};

class IVsComponentSelectorDlg2MockImpl :
	public IVsComponentSelectorDlg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsComponentSelectorDlg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsComponentSelectorDlg2MockImpl)

	typedef IVsComponentSelectorDlg2 Interface;
	struct ComponentSelectorDlg2ValidValues
	{
		/*[in]*/ VSCOMPSELFLAGS2 grfFlags;
		/*[in]*/ IVsComponentUser* pUser;
		/*[in]*/ ULONG cComponents;
		/*[in,size_is(cComponents)]*/ PVSCOMPONENTSELECTORDATA* rgpcsdComponents;
		/*[in]*/ LPCOLESTR lpszDlgTitle;
		/*[in]*/ LPCOLESTR lpszHelpTopic;
		/*[in,out]*/ ULONG* pxDlgSize;
		/*[in,out]*/ ULONG* pyDlgSize;
		/*[in]*/ ULONG cTabInitializers;
		/*[in,size_is(cTabInitializers)]*/ VSCOMPONENTSELECTORTABINIT* rgcstiTabInitializers;
		/*[in,out]*/ GUID* pguidStartOnThisTab;
		/*[in]*/ LPCOLESTR pszBrowseFilters;
		/*[in,out]*/ BSTR* pbstrBrowseLocation;
		HRESULT retValue;
	};

	STDMETHOD(ComponentSelectorDlg2)(
		/*[in]*/ VSCOMPSELFLAGS2 grfFlags,
		/*[in]*/ IVsComponentUser* pUser,
		/*[in]*/ ULONG cComponents,
		/*[in,size_is(cComponents)]*/ PVSCOMPONENTSELECTORDATA rgpcsdComponents[],
		/*[in]*/ LPCOLESTR lpszDlgTitle,
		/*[in]*/ LPCOLESTR lpszHelpTopic,
		/*[in,out]*/ ULONG* pxDlgSize,
		/*[in,out]*/ ULONG* pyDlgSize,
		/*[in]*/ ULONG cTabInitializers,
		/*[in,size_is(cTabInitializers)]*/ VSCOMPONENTSELECTORTABINIT rgcstiTabInitializers[],
		/*[in,out]*/ GUID* pguidStartOnThisTab,
		/*[in]*/ LPCOLESTR pszBrowseFilters,
		/*[in,out]*/ BSTR* pbstrBrowseLocation)
	{
		VSL_DEFINE_MOCK_METHOD(ComponentSelectorDlg2)

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUser);

		VSL_CHECK_VALIDVALUE(cComponents);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpcsdComponents, cComponents*sizeof(rgpcsdComponents[0]), validValues.cComponents*sizeof(validValues.rgpcsdComponents[0]));

		VSL_CHECK_VALIDVALUE_STRINGW(lpszDlgTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszHelpTopic);

		VSL_SET_VALIDVALUE(pxDlgSize);

		VSL_SET_VALIDVALUE(pyDlgSize);

		VSL_CHECK_VALIDVALUE(cTabInitializers);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgcstiTabInitializers, cTabInitializers*sizeof(rgcstiTabInitializers[0]), validValues.cTabInitializers*sizeof(validValues.rgcstiTabInitializers[0]));

		VSL_SET_VALIDVALUE(pguidStartOnThisTab);

		VSL_CHECK_VALIDVALUE_STRINGW(pszBrowseFilters);

		VSL_SET_VALIDVALUE_BSTR(pbstrBrowseLocation);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMPONENTSELECTORDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
