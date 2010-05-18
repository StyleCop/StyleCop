/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSCCOPENFROMSOURCECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSCCOPENFROMSOURCECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsSccOpenFromSourceControl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSccOpenFromSourceControlNotImpl :
	public IVsSccOpenFromSourceControl
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccOpenFromSourceControlNotImpl)

public:

	typedef IVsSccOpenFromSourceControl Interface;

	STDMETHOD(OpenSolutionFromSourceControl)(
		/*[in]*/ LPCOLESTR /*pszSolutionStoreUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddProjectFromSourceControl)(
		/*[in]*/ LPCOLESTR /*pszProjectStoreUrl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddItemFromSourceControl)(
		/*[in]*/ IVsProject* /*pProject*/,
		/*[in]*/ VSITEMID /*itemidLoc*/,
		/*[in]*/ ULONG /*cFilesToAdd*/,
		/*[in,size_is(cFilesToAdd)]*/ LPCOLESTR[] /*rgpszFilesToAdd*/,
		/*[in]*/ HWND /*hwndDlgOwner*/,
		/*[in]*/ VSSPECIFICEDITORFLAGS /*grfEditorFlags*/,
		/*[in]*/ REFGUID /*rguidEditorType*/,
		/*[in]*/ LPCOLESTR /*pszPhysicalView*/,
		/*[in]*/ REFGUID /*rguidLogicalView*/,
		/*[out,retval]*/ VSADDRESULT* /*pResult*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetNamespaceExtensionInformation)(
		/*[in]*/ VSOPENFROMSCCDLG /*vsofsdDlg*/,
		/*[out]*/ BSTR* /*pbstrNamespaceGUID*/,
		/*[out]*/ BSTR* /*pbstrTrayDisplayName*/,
		/*[out]*/ BSTR* /*pbstrProtocolPrefix*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSccOpenFromSourceControlMockImpl :
	public IVsSccOpenFromSourceControl,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSccOpenFromSourceControlMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSccOpenFromSourceControlMockImpl)

	typedef IVsSccOpenFromSourceControl Interface;
	struct OpenSolutionFromSourceControlValidValues
	{
		/*[in]*/ LPCOLESTR pszSolutionStoreUrl;
		HRESULT retValue;
	};

	STDMETHOD(OpenSolutionFromSourceControl)(
		/*[in]*/ LPCOLESTR pszSolutionStoreUrl)
	{
		VSL_DEFINE_MOCK_METHOD(OpenSolutionFromSourceControl)

		VSL_CHECK_VALIDVALUE_STRINGW(pszSolutionStoreUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddProjectFromSourceControlValidValues
	{
		/*[in]*/ LPCOLESTR pszProjectStoreUrl;
		HRESULT retValue;
	};

	STDMETHOD(AddProjectFromSourceControl)(
		/*[in]*/ LPCOLESTR pszProjectStoreUrl)
	{
		VSL_DEFINE_MOCK_METHOD(AddProjectFromSourceControl)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjectStoreUrl);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddItemFromSourceControlValidValues
	{
		/*[in]*/ IVsProject* pProject;
		/*[in]*/ VSITEMID itemidLoc;
		/*[in]*/ ULONG cFilesToAdd;
		/*[in,size_is(cFilesToAdd)]*/ LPCOLESTR* rgpszFilesToAdd;
		/*[in]*/ HWND hwndDlgOwner;
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags;
		/*[in]*/ REFGUID rguidEditorType;
		/*[in]*/ LPCOLESTR pszPhysicalView;
		/*[in]*/ REFGUID rguidLogicalView;
		/*[out,retval]*/ VSADDRESULT* pResult;
		HRESULT retValue;
	};

	STDMETHOD(AddItemFromSourceControl)(
		/*[in]*/ IVsProject* pProject,
		/*[in]*/ VSITEMID itemidLoc,
		/*[in]*/ ULONG cFilesToAdd,
		/*[in,size_is(cFilesToAdd)]*/ LPCOLESTR rgpszFilesToAdd[],
		/*[in]*/ HWND hwndDlgOwner,
		/*[in]*/ VSSPECIFICEDITORFLAGS grfEditorFlags,
		/*[in]*/ REFGUID rguidEditorType,
		/*[in]*/ LPCOLESTR pszPhysicalView,
		/*[in]*/ REFGUID rguidLogicalView,
		/*[out,retval]*/ VSADDRESULT* pResult)
	{
		VSL_DEFINE_MOCK_METHOD(AddItemFromSourceControl)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_CHECK_VALIDVALUE(itemidLoc);

		VSL_CHECK_VALIDVALUE(cFilesToAdd);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpszFilesToAdd, cFilesToAdd*sizeof(rgpszFilesToAdd[0]), validValues.cFilesToAdd*sizeof(validValues.rgpszFilesToAdd[0]));

		VSL_CHECK_VALIDVALUE(hwndDlgOwner);

		VSL_CHECK_VALIDVALUE(grfEditorFlags);

		VSL_CHECK_VALIDVALUE(rguidEditorType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPhysicalView);

		VSL_CHECK_VALIDVALUE(rguidLogicalView);

		VSL_SET_VALIDVALUE(pResult);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNamespaceExtensionInformationValidValues
	{
		/*[in]*/ VSOPENFROMSCCDLG vsofsdDlg;
		/*[out]*/ BSTR* pbstrNamespaceGUID;
		/*[out]*/ BSTR* pbstrTrayDisplayName;
		/*[out]*/ BSTR* pbstrProtocolPrefix;
		HRESULT retValue;
	};

	STDMETHOD(GetNamespaceExtensionInformation)(
		/*[in]*/ VSOPENFROMSCCDLG vsofsdDlg,
		/*[out]*/ BSTR* pbstrNamespaceGUID,
		/*[out]*/ BSTR* pbstrTrayDisplayName,
		/*[out]*/ BSTR* pbstrProtocolPrefix)
	{
		VSL_DEFINE_MOCK_METHOD(GetNamespaceExtensionInformation)

		VSL_CHECK_VALIDVALUE(vsofsdDlg);

		VSL_SET_VALIDVALUE_BSTR(pbstrNamespaceGUID);

		VSL_SET_VALIDVALUE_BSTR(pbstrTrayDisplayName);

		VSL_SET_VALIDVALUE_BSTR(pbstrProtocolPrefix);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSCCOPENFROMSOURCECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
