/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IWEBFILECTXSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IWEBFILECTXSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "Webapplicationctx.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IWebFileCtxServiceNotImpl :
	public IWebFileCtxService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IWebFileCtxServiceNotImpl)

public:

	typedef IWebFileCtxService Interface;

	STDMETHOD(AddFileToIntellisense)(
		/*[in]*/ LPCWSTR /*pszFilePath*/,
		/*[out]*/ VSITEMID* /*pItemID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnsureFileOpened)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out]*/ IVsWindowFrame** /*ppFrame*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveFileFromIntellisense)(
		/*[in]*/ LPCWSTR /*pszFilePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetWebRootPath)(
		/*[out]*/ BSTR* /*pbstrWebRootPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIntellisenseProjectName)(
		/*[out]*/ BSTR* /*pbstrProjectName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddDependentAssemblyFile)(
		/*[in]*/ LPCWSTR /*pszFilePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveDependentAssemblyFile)(
		/*[in]*/ LPCWSTR /*pszFilePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ConvertToAppRelPath)(
		/*[in]*/ LPCWSTR /*pszFilePath*/,
		/*[out]*/ BSTR* /*pbstrAppRelPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CBMCallbackActive)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WaitForIntellisenseReady)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsDocumentInProject)(
		/*[in]*/ LPCWSTR /*pszFilePath*/,
		/*[out]*/ VSITEMID* /*pItemID*/)VSL_STDMETHOD_NOTIMPL
};

class IWebFileCtxServiceMockImpl :
	public IWebFileCtxService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IWebFileCtxServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IWebFileCtxServiceMockImpl)

	typedef IWebFileCtxService Interface;
	struct AddFileToIntellisenseValidValues
	{
		/*[in]*/ LPCWSTR pszFilePath;
		/*[out]*/ VSITEMID* pItemID;
		HRESULT retValue;
	};

	STDMETHOD(AddFileToIntellisense)(
		/*[in]*/ LPCWSTR pszFilePath,
		/*[out]*/ VSITEMID* pItemID)
	{
		VSL_DEFINE_MOCK_METHOD(AddFileToIntellisense)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilePath);

		VSL_SET_VALIDVALUE(pItemID);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnsureFileOpenedValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[out]*/ IVsWindowFrame** ppFrame;
		HRESULT retValue;
	};

	STDMETHOD(EnsureFileOpened)(
		/*[in]*/ VSITEMID itemid,
		/*[out]*/ IVsWindowFrame** ppFrame)
	{
		VSL_DEFINE_MOCK_METHOD(EnsureFileOpened)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppFrame);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveFileFromIntellisenseValidValues
	{
		/*[in]*/ LPCWSTR pszFilePath;
		HRESULT retValue;
	};

	STDMETHOD(RemoveFileFromIntellisense)(
		/*[in]*/ LPCWSTR pszFilePath)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveFileFromIntellisense)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetWebRootPathValidValues
	{
		/*[out]*/ BSTR* pbstrWebRootPath;
		HRESULT retValue;
	};

	STDMETHOD(GetWebRootPath)(
		/*[out]*/ BSTR* pbstrWebRootPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetWebRootPath)

		VSL_SET_VALIDVALUE_BSTR(pbstrWebRootPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIntellisenseProjectNameValidValues
	{
		/*[out]*/ BSTR* pbstrProjectName;
		HRESULT retValue;
	};

	STDMETHOD(GetIntellisenseProjectName)(
		/*[out]*/ BSTR* pbstrProjectName)
	{
		VSL_DEFINE_MOCK_METHOD(GetIntellisenseProjectName)

		VSL_SET_VALIDVALUE_BSTR(pbstrProjectName);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddDependentAssemblyFileValidValues
	{
		/*[in]*/ LPCWSTR pszFilePath;
		HRESULT retValue;
	};

	STDMETHOD(AddDependentAssemblyFile)(
		/*[in]*/ LPCWSTR pszFilePath)
	{
		VSL_DEFINE_MOCK_METHOD(AddDependentAssemblyFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveDependentAssemblyFileValidValues
	{
		/*[in]*/ LPCWSTR pszFilePath;
		HRESULT retValue;
	};

	STDMETHOD(RemoveDependentAssemblyFile)(
		/*[in]*/ LPCWSTR pszFilePath)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveDependentAssemblyFile)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct ConvertToAppRelPathValidValues
	{
		/*[in]*/ LPCWSTR pszFilePath;
		/*[out]*/ BSTR* pbstrAppRelPath;
		HRESULT retValue;
	};

	STDMETHOD(ConvertToAppRelPath)(
		/*[in]*/ LPCWSTR pszFilePath,
		/*[out]*/ BSTR* pbstrAppRelPath)
	{
		VSL_DEFINE_MOCK_METHOD(ConvertToAppRelPath)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilePath);

		VSL_SET_VALIDVALUE_BSTR(pbstrAppRelPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct CBMCallbackActiveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CBMCallbackActive)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CBMCallbackActive)

		VSL_RETURN_VALIDVALUES();
	}
	struct WaitForIntellisenseReadyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(WaitForIntellisenseReady)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(WaitForIntellisenseReady)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsDocumentInProjectValidValues
	{
		/*[in]*/ LPCWSTR pszFilePath;
		/*[out]*/ VSITEMID* pItemID;
		HRESULT retValue;
	};

	STDMETHOD(IsDocumentInProject)(
		/*[in]*/ LPCWSTR pszFilePath,
		/*[out]*/ VSITEMID* pItemID)
	{
		VSL_DEFINE_MOCK_METHOD(IsDocumentInProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilePath);

		VSL_SET_VALIDVALUE(pItemID);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IWEBFILECTXSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
