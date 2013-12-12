/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSADDPROJECTITEMDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSADDPROJECTITEMDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAddProjectItemDlgNotImpl :
	public IVsAddProjectItemDlg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddProjectItemDlgNotImpl)

public:

	typedef IVsAddProjectItemDlg Interface;

	STDMETHOD(AddProjectItemDlg)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ REFGUID /*rguidProject*/,
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ VSADDITEMFLAGS /*grfAddFlags*/,
		/*[in]*/ LPCOLESTR /*lpszExpand*/,
		/*[in]*/ LPCOLESTR /*lpszSelect*/,
		/*[in,out]*/ BSTR* /*pbstrLocation*/,
		/*[in,out]*/ BSTR* /*pbstrFilter*/,
		/*[out]*/ BOOL* /*pfDontShowAgain*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAddProjectItemDlgMockImpl :
	public IVsAddProjectItemDlg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddProjectItemDlgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAddProjectItemDlgMockImpl)

	typedef IVsAddProjectItemDlg Interface;
	struct AddProjectItemDlgValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ REFGUID rguidProject;
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ VSADDITEMFLAGS grfAddFlags;
		/*[in]*/ LPCOLESTR lpszExpand;
		/*[in]*/ LPCOLESTR lpszSelect;
		/*[in,out]*/ BSTR* pbstrLocation;
		/*[in,out]*/ BSTR* pbstrFilter;
		/*[out]*/ BOOL* pfDontShowAgain;
		HRESULT retValue;
	};

	STDMETHOD(AddProjectItemDlg)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ REFGUID rguidProject,
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ VSADDITEMFLAGS grfAddFlags,
		/*[in]*/ LPCOLESTR lpszExpand,
		/*[in]*/ LPCOLESTR lpszSelect,
		/*[in,out]*/ BSTR* pbstrLocation,
		/*[in,out]*/ BSTR* pbstrFilter,
		/*[out]*/ BOOL* pfDontShowAgain)
	{
		VSL_DEFINE_MOCK_METHOD(AddProjectItemDlg)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(rguidProject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(grfAddFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszExpand);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszSelect);

		VSL_SET_VALIDVALUE_BSTR(pbstrLocation);

		VSL_SET_VALIDVALUE_BSTR(pbstrFilter);

		VSL_SET_VALIDVALUE(pfDontShowAgain);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSADDPROJECTITEMDLG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
