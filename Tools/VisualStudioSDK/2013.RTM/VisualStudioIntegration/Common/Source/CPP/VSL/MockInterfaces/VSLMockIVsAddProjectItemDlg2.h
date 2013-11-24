/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSADDPROJECTITEMDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSADDPROJECTITEMDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAddProjectItemDlg2NotImpl :
	public IVsAddProjectItemDlg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddProjectItemDlg2NotImpl)

public:

	typedef IVsAddProjectItemDlg2 Interface;

	STDMETHOD(AddProjectItemDlgTitled)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ REFGUID /*rguidProject*/,
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ VSADDITEMFLAGS /*grfAddFlags*/,
		/*[in]*/ LPCOLESTR /*lpszDlgTitle*/,
		/*[in]*/ LPCOLESTR /*lpszExpand*/,
		/*[in]*/ LPCOLESTR /*lpszSelect*/,
		/*[in,out]*/ BSTR* /*pbstrLocation*/,
		/*[in,out]*/ BSTR* /*pbstrFilter*/,
		/*[out]*/ BOOL* /*pfDontShowAgain*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddNewProjectItem)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ REFGUID /*rguidProject*/,
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ VSSPECIFICEDITORFLAGS /*grfEditorFlags*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ LPCOLESTR /*pszItemName*/,
		/*[in,out]*/ BSTR* /*pbstrFileToAdd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddExistingProjectItems)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ REFGUID /*rguidProject*/,
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ VSSPECIFICEDITORFLAGS /*grfEditorFlags*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[in]*/ ULONG /*cFilesToAdd*/,
		/*[in,size_is(cFilesToAdd)]*/ LPCOLESTR[] /*rgpszFilesToAdd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddProjectItemDlgTitledEx)(
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ REFGUID /*rguidProject*/,
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ VSADDITEMFLAGS /*grfAddFlags*/,
		/*[in]*/ LPCOLESTR /*lpszDlgTitle*/,
		/*[in]*/ LPCOLESTR /*lpszTreeViewTitle*/,
		/*[in]*/ LPCOLESTR /*lpszHelpTopic*/,
		/*[in]*/ LPCOLESTR /*lpszExpand*/,
		/*[in]*/ LPCOLESTR /*lpszSelect*/,
		/*[in,out]*/ BSTR* /*pbstrLocation*/,
		/*[in,out]*/ BSTR* /*pbstrFilter*/,
		/*[out]*/ BOOL* /*pfDontShowAgain*/)VSL_STDMETHOD_NOTIMPL

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

class IVsAddProjectItemDlg2MockImpl :
	public IVsAddProjectItemDlg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAddProjectItemDlg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAddProjectItemDlg2MockImpl)

	typedef IVsAddProjectItemDlg2 Interface;
	struct AddProjectItemDlgTitledValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ REFGUID rguidProject;
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ VSADDITEMFLAGS grfAddFlags;
		/*[in]*/ LPCOLESTR lpszDlgTitle;
		/*[in]*/ LPCOLESTR lpszExpand;
		/*[in]*/ LPCOLESTR lpszSelect;
		/*[in,out]*/ BSTR* pbstrLocation;
		/*[in,out]*/ BSTR* pbstrFilter;
		/*[out]*/ BOOL* pfDontShowAgain;
		HRESULT retValue;
	};

	STDMETHOD(AddProjectItemDlgTitled)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ REFGUID rguidProject,
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ VSADDITEMFLAGS grfAddFlags,
		/*[in]*/ LPCOLESTR lpszDlgTitle,
		/*[in]*/ LPCOLESTR lpszExpand,
		/*[in]*/ LPCOLESTR lpszSelect,
		/*[in,out]*/ BSTR* pbstrLocation,
		/*[in,out]*/ BSTR* pbstrFilter,
		/*[out]*/ BOOL* pfDontShowAgain)
	{
		VSL_DEFINE_MOCK_METHOD(AddProjectItemDlgTitled)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(rguidProject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(grfAddFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszDlgTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszExpand);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszSelect);

		VSL_SET_VALIDVALUE_BSTR(pbstrLocation);

		VSL_SET_VALIDVALUE_BSTR(pbstrFilter);

		VSL_SET_VALIDVALUE(pfDontShowAgain);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddNewProjectItemValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ REFGUID rguidProject;
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ LPCOLESTR pszItemName;
		/*[in,out]*/ BSTR* pbstrFileToAdd;
		HRESULT retValue;
	};

	STDMETHOD(AddNewProjectItem)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ REFGUID rguidProject,
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ LPCOLESTR pszItemName,
		/*[in,out]*/ BSTR* pbstrFileToAdd)
	{
		VSL_DEFINE_MOCK_METHOD(AddNewProjectItem)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(rguidProject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(grfEditorFlags);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE_STRINGW(pszItemName);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileToAdd);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddExistingProjectItemsValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ REFGUID rguidProject;
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[in]*/ ULONG cFilesToAdd;
		/*[in,size_is(cFilesToAdd)]*/ LPCOLESTR* rgpszFilesToAdd;
		HRESULT retValue;
	};

	STDMETHOD(AddExistingProjectItems)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ REFGUID rguidProject,
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[in]*/ ULONG cFilesToAdd,
		/*[in,size_is(cFilesToAdd)]*/ LPCOLESTR rgpszFilesToAdd[])
	{
		VSL_DEFINE_MOCK_METHOD(AddExistingProjectItems)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(rguidProject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(grfEditorFlags);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_CHECK_VALIDVALUE(cFilesToAdd);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszFilesToAdd, cFilesToAdd*sizeof(rgpszFilesToAdd[0]), validValues.cFilesToAdd*sizeof(validValues.rgpszFilesToAdd[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct AddProjectItemDlgTitledExValidValues
	{
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ REFGUID rguidProject;
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ VSADDITEMFLAGS grfAddFlags;
		/*[in]*/ LPCOLESTR lpszDlgTitle;
		/*[in]*/ LPCOLESTR lpszTreeViewTitle;
		/*[in]*/ LPCOLESTR lpszHelpTopic;
		/*[in]*/ LPCOLESTR lpszExpand;
		/*[in]*/ LPCOLESTR lpszSelect;
		/*[in,out]*/ BSTR* pbstrLocation;
		/*[in,out]*/ BSTR* pbstrFilter;
		/*[out]*/ BOOL* pfDontShowAgain;
		HRESULT retValue;
	};

	STDMETHOD(AddProjectItemDlgTitledEx)(
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ REFGUID rguidProject,
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ VSADDITEMFLAGS grfAddFlags,
		/*[in]*/ LPCOLESTR lpszDlgTitle,
		/*[in]*/ LPCOLESTR lpszTreeViewTitle,
		/*[in]*/ LPCOLESTR lpszHelpTopic,
		/*[in]*/ LPCOLESTR lpszExpand,
		/*[in]*/ LPCOLESTR lpszSelect,
		/*[in,out]*/ BSTR* pbstrLocation,
		/*[in,out]*/ BSTR* pbstrFilter,
		/*[out]*/ BOOL* pfDontShowAgain)
	{
		VSL_DEFINE_MOCK_METHOD(AddProjectItemDlgTitledEx)

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(rguidProject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(grfAddFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszDlgTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszTreeViewTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszHelpTopic);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszExpand);

		VSL_CHECK_VALIDVALUE_STRINGW(lpszSelect);

		VSL_SET_VALIDVALUE_BSTR(pbstrLocation);

		VSL_SET_VALIDVALUE_BSTR(pbstrFilter);

		VSL_SET_VALIDVALUE(pfDontShowAgain);

		VSL_RETURN_VALIDVALUES();
	}
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

#endif // IVSADDPROJECTITEMDLG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
