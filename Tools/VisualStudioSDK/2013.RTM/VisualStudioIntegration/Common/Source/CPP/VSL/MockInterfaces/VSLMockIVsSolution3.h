/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTION3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTION3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolution3NotImpl :
	public IVsSolution3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolution3NotImpl)

public:

	typedef IVsSolution3 Interface;

	STDMETHOD(CreateNewProjectViaDlgEx)(
		/*[in]*/ LPCOLESTR /*pszDlgTitle*/,
		/*[in]*/ LPCOLESTR /*pszTemplateDir*/,
		/*[in]*/ LPCOLESTR /*pszExpand*/,
		/*[in]*/ LPCOLESTR /*pszSelect*/,
		/*[in]*/ LPCOLESTR /*pszHelpTopic*/,
		/*[in]*/ VSCREATENEWPROJVIADLGEXFLAGS /*cnpvdeFlags*/,
		/*[in]*/ IVsBrowseProjectLocation* /*pBrowse*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUniqueUINameOfProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[out]*/ BSTR* /*pbstrUniqueName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CheckForAndSaveDeferredSaveSolution)(
		/*[in]*/ BOOL /*fCloseSolution*/,
		/*[in]*/ LPCOLESTR /*pszMessage*/,
		/*[in]*/ LPCOLESTR /*pszTitle*/,
		/*[in]*/ VSSAVEDEFERREDSAVEFLAGS /*grfFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateProjectFileLocationForUpgrade)(
		/*[in]*/ LPCOLESTR /*pszCurrentLocation*/,
		/*[in]*/ LPCOLESTR /*pszUpgradedLocation*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolution3MockImpl :
	public IVsSolution3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolution3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolution3MockImpl)

	typedef IVsSolution3 Interface;
	struct CreateNewProjectViaDlgExValidValues
	{
		/*[in]*/ LPCOLESTR pszDlgTitle;
		/*[in]*/ LPCOLESTR pszTemplateDir;
		/*[in]*/ LPCOLESTR pszExpand;
		/*[in]*/ LPCOLESTR pszSelect;
		/*[in]*/ LPCOLESTR pszHelpTopic;
		/*[in]*/ VSCREATENEWPROJVIADLGEXFLAGS cnpvdeFlags;
		/*[in]*/ IVsBrowseProjectLocation* pBrowse;
		HRESULT retValue;
	};

	STDMETHOD(CreateNewProjectViaDlgEx)(
		/*[in]*/ LPCOLESTR pszDlgTitle,
		/*[in]*/ LPCOLESTR pszTemplateDir,
		/*[in]*/ LPCOLESTR pszExpand,
		/*[in]*/ LPCOLESTR pszSelect,
		/*[in]*/ LPCOLESTR pszHelpTopic,
		/*[in]*/ VSCREATENEWPROJVIADLGEXFLAGS cnpvdeFlags,
		/*[in]*/ IVsBrowseProjectLocation* pBrowse)
	{
		VSL_DEFINE_MOCK_METHOD(CreateNewProjectViaDlgEx)

		VSL_CHECK_VALIDVALUE_STRINGW(pszDlgTitle);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTemplateDir);

		VSL_CHECK_VALIDVALUE_STRINGW(pszExpand);

		VSL_CHECK_VALIDVALUE_STRINGW(pszSelect);

		VSL_CHECK_VALIDVALUE_STRINGW(pszHelpTopic);

		VSL_CHECK_VALIDVALUE(cnpvdeFlags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBrowse);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUniqueUINameOfProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[out]*/ BSTR* pbstrUniqueName;
		HRESULT retValue;
	};

	STDMETHOD(GetUniqueUINameOfProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[out]*/ BSTR* pbstrUniqueName)
	{
		VSL_DEFINE_MOCK_METHOD(GetUniqueUINameOfProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_SET_VALIDVALUE_BSTR(pbstrUniqueName);

		VSL_RETURN_VALIDVALUES();
	}
	struct CheckForAndSaveDeferredSaveSolutionValidValues
	{
		/*[in]*/ BOOL fCloseSolution;
		/*[in]*/ LPCOLESTR pszMessage;
		/*[in]*/ LPCOLESTR pszTitle;
		/*[in]*/ VSSAVEDEFERREDSAVEFLAGS grfFlags;
		HRESULT retValue;
	};

	STDMETHOD(CheckForAndSaveDeferredSaveSolution)(
		/*[in]*/ BOOL fCloseSolution,
		/*[in]*/ LPCOLESTR pszMessage,
		/*[in]*/ LPCOLESTR pszTitle,
		/*[in]*/ VSSAVEDEFERREDSAVEFLAGS grfFlags)
	{
		VSL_DEFINE_MOCK_METHOD(CheckForAndSaveDeferredSaveSolution)

		VSL_CHECK_VALIDVALUE(fCloseSolution);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMessage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszTitle);

		VSL_CHECK_VALIDVALUE(grfFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateProjectFileLocationForUpgradeValidValues
	{
		/*[in]*/ LPCOLESTR pszCurrentLocation;
		/*[in]*/ LPCOLESTR pszUpgradedLocation;
		HRESULT retValue;
	};

	STDMETHOD(UpdateProjectFileLocationForUpgrade)(
		/*[in]*/ LPCOLESTR pszCurrentLocation,
		/*[in]*/ LPCOLESTR pszUpgradedLocation)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateProjectFileLocationForUpgrade)

		VSL_CHECK_VALIDVALUE_STRINGW(pszCurrentLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszUpgradedLocation);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTION3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
