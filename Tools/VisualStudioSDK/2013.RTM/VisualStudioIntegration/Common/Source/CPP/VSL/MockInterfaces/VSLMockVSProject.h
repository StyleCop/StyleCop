/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef VSPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define VSPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class VSProjectNotImpl :
	public VSProject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(VSProjectNotImpl)

public:

	typedef VSProject Interface;

	STDMETHOD(get_References)(
		/*[out,retval]*/ References** /*ppRefs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_BuildManager)(
		/*[out,retval]*/ BuildManager** /*ppBuildMgr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DTE)(
		/*[out,retval]*/ DTE** /*ppDTE*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Project)(
		/*[out,retval]*/ Project** /*ppProject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateWebReferencesFolder)(
		/*[out,retval]*/ ProjectItem** /*ppProjectItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WebReferencesFolder)(
		/*[out,retval]*/ ProjectItem** /*ppProjectItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddWebReference)(
		/*[in]*/ BSTR /*bstrUrl*/,
		/*[out,retval]*/ ProjectItem** /*ppProjectItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_TemplatePath)(
		/*[out,retval]*/ BSTR* /*pbstrTemplatePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Refresh)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WorkOffline)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbWorkOffline*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_WorkOffline)(
		/*[in]*/ VARIANT_BOOL /*bWorkOffline*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Imports)(
		/*[out,retval]*/ Imports** /*ppImports*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Events)(
		/*[out,retval]*/ VSProjectEvents** /*ppEvents*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CopyProject)(
		/*[in]*/ BSTR /*bstrDestFolder*/,
		/*[in]*/ BSTR /*bstrDestUNCPath*/,
		/*[in]*/ prjCopyProjectOption /*copyProjectOption*/,
		/*[in]*/ BSTR /*bstrUsername*/,
		/*[in]*/ BSTR /*bstrPassword*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Exec)(
		/*[in]*/ prjExecCommand /*command*/,
		/*[in]*/ BOOL /*bSuppressUI*/,
		/*[in]*/ VARIANT /*varIn*/,
		/*[out]*/ VARIANT* /*pVarOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GenerateKeyPairFiles)(
		/*[in]*/ BSTR /*strPublicPrivateFile*/,
		/*[in,defaultvalue(NULL)]*/ BSTR /*strPublicOnlyFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUniqueFilename)(
		/*[in]*/ IDispatch* /*pDispatch*/,
		/*[in]*/ BSTR /*bstrRoot*/,
		/*[in]*/ BSTR /*bstrDesiredExt*/,
		/*[out,retval]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* /*pctinfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT /*iTInfo*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID /*riid*/,
		/*[in,size_is(cNames)]*/ LPOLESTR* /*rgszNames*/,
		/*[in]*/ UINT /*cNames*/,
		/*[in]*/ LCID /*lcid*/,
		/*[out,size_is(cNames)]*/ DISPID* /*rgDispId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID /*dispIdMember*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ LCID /*lcid*/,
		/*[in]*/ WORD /*wFlags*/,
		/*[in,out]*/ DISPPARAMS* /*pDispParams*/,
		/*[out]*/ VARIANT* /*pVarResult*/,
		/*[out]*/ EXCEPINFO* /*pExcepInfo*/,
		/*[out]*/ UINT* /*puArgErr*/)VSL_STDMETHOD_NOTIMPL
};

class VSProjectMockImpl :
	public VSProject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(VSProjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(VSProjectMockImpl)

	typedef VSProject Interface;
	struct get_ReferencesValidValues
	{
		/*[out,retval]*/ References** ppRefs;
		HRESULT retValue;
	};

	STDMETHOD(get_References)(
		/*[out,retval]*/ References** ppRefs)
	{
		VSL_DEFINE_MOCK_METHOD(get_References)

		VSL_SET_VALIDVALUE_INTERFACE(ppRefs);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_BuildManagerValidValues
	{
		/*[out,retval]*/ BuildManager** ppBuildMgr;
		HRESULT retValue;
	};

	STDMETHOD(get_BuildManager)(
		/*[out,retval]*/ BuildManager** ppBuildMgr)
	{
		VSL_DEFINE_MOCK_METHOD(get_BuildManager)

		VSL_SET_VALIDVALUE_INTERFACE(ppBuildMgr);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DTEValidValues
	{
		/*[out,retval]*/ DTE** ppDTE;
		HRESULT retValue;
	};

	STDMETHOD(get_DTE)(
		/*[out,retval]*/ DTE** ppDTE)
	{
		VSL_DEFINE_MOCK_METHOD(get_DTE)

		VSL_SET_VALIDVALUE(ppDTE);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ProjectValidValues
	{
		/*[out,retval]*/ Project** ppProject;
		HRESULT retValue;
	};

	STDMETHOD(get_Project)(
		/*[out,retval]*/ Project** ppProject)
	{
		VSL_DEFINE_MOCK_METHOD(get_Project)

		VSL_SET_VALIDVALUE(ppProject);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateWebReferencesFolderValidValues
	{
		/*[out,retval]*/ ProjectItem** ppProjectItem;
		HRESULT retValue;
	};

	STDMETHOD(CreateWebReferencesFolder)(
		/*[out,retval]*/ ProjectItem** ppProjectItem)
	{
		VSL_DEFINE_MOCK_METHOD(CreateWebReferencesFolder)

		VSL_SET_VALIDVALUE(ppProjectItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WebReferencesFolderValidValues
	{
		/*[out,retval]*/ ProjectItem** ppProjectItem;
		HRESULT retValue;
	};

	STDMETHOD(get_WebReferencesFolder)(
		/*[out,retval]*/ ProjectItem** ppProjectItem)
	{
		VSL_DEFINE_MOCK_METHOD(get_WebReferencesFolder)

		VSL_SET_VALIDVALUE(ppProjectItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddWebReferenceValidValues
	{
		/*[in]*/ BSTR bstrUrl;
		/*[out,retval]*/ ProjectItem** ppProjectItem;
		HRESULT retValue;
	};

	STDMETHOD(AddWebReference)(
		/*[in]*/ BSTR bstrUrl,
		/*[out,retval]*/ ProjectItem** ppProjectItem)
	{
		VSL_DEFINE_MOCK_METHOD(AddWebReference)

		VSL_CHECK_VALIDVALUE_BSTR(bstrUrl);

		VSL_SET_VALIDVALUE(ppProjectItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TemplatePathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrTemplatePath;
		HRESULT retValue;
	};

	STDMETHOD(get_TemplatePath)(
		/*[out,retval]*/ BSTR* pbstrTemplatePath)
	{
		VSL_DEFINE_MOCK_METHOD(get_TemplatePath)

		VSL_SET_VALIDVALUE_BSTR(pbstrTemplatePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Refresh)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Refresh)

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WorkOfflineValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbWorkOffline;
		HRESULT retValue;
	};

	STDMETHOD(get_WorkOffline)(
		/*[out,retval]*/ VARIANT_BOOL* pbWorkOffline)
	{
		VSL_DEFINE_MOCK_METHOD(get_WorkOffline)

		VSL_SET_VALIDVALUE(pbWorkOffline);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_WorkOfflineValidValues
	{
		/*[in]*/ VARIANT_BOOL bWorkOffline;
		HRESULT retValue;
	};

	STDMETHOD(put_WorkOffline)(
		/*[in]*/ VARIANT_BOOL bWorkOffline)
	{
		VSL_DEFINE_MOCK_METHOD(put_WorkOffline)

		VSL_CHECK_VALIDVALUE(bWorkOffline);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ImportsValidValues
	{
		/*[out,retval]*/ Imports** ppImports;
		HRESULT retValue;
	};

	STDMETHOD(get_Imports)(
		/*[out,retval]*/ Imports** ppImports)
	{
		VSL_DEFINE_MOCK_METHOD(get_Imports)

		VSL_SET_VALIDVALUE_INTERFACE(ppImports);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_EventsValidValues
	{
		/*[out,retval]*/ VSProjectEvents** ppEvents;
		HRESULT retValue;
	};

	STDMETHOD(get_Events)(
		/*[out,retval]*/ VSProjectEvents** ppEvents)
	{
		VSL_DEFINE_MOCK_METHOD(get_Events)

		VSL_SET_VALIDVALUE(ppEvents);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyProjectValidValues
	{
		/*[in]*/ BSTR bstrDestFolder;
		/*[in]*/ BSTR bstrDestUNCPath;
		/*[in]*/ prjCopyProjectOption copyProjectOption;
		/*[in]*/ BSTR bstrUsername;
		/*[in]*/ BSTR bstrPassword;
		HRESULT retValue;
	};

	STDMETHOD(CopyProject)(
		/*[in]*/ BSTR bstrDestFolder,
		/*[in]*/ BSTR bstrDestUNCPath,
		/*[in]*/ prjCopyProjectOption copyProjectOption,
		/*[in]*/ BSTR bstrUsername,
		/*[in]*/ BSTR bstrPassword)
	{
		VSL_DEFINE_MOCK_METHOD(CopyProject)

		VSL_CHECK_VALIDVALUE_BSTR(bstrDestFolder);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDestUNCPath);

		VSL_CHECK_VALIDVALUE(copyProjectOption);

		VSL_CHECK_VALIDVALUE_BSTR(bstrUsername);

		VSL_CHECK_VALIDVALUE_BSTR(bstrPassword);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecValidValues
	{
		/*[in]*/ prjExecCommand command;
		/*[in]*/ BOOL bSuppressUI;
		/*[in]*/ VARIANT varIn;
		/*[out]*/ VARIANT* pVarOut;
		HRESULT retValue;
	};

	STDMETHOD(Exec)(
		/*[in]*/ prjExecCommand command,
		/*[in]*/ BOOL bSuppressUI,
		/*[in]*/ VARIANT varIn,
		/*[out]*/ VARIANT* pVarOut)
	{
		VSL_DEFINE_MOCK_METHOD(Exec)

		VSL_CHECK_VALIDVALUE(command);

		VSL_CHECK_VALIDVALUE(bSuppressUI);

		VSL_CHECK_VALIDVALUE(varIn);

		VSL_SET_VALIDVALUE_VARIANT(pVarOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GenerateKeyPairFilesValidValues
	{
		/*[in]*/ BSTR strPublicPrivateFile;
		/*[in,defaultvalue(NULL)]*/ BSTR strPublicOnlyFile;
		HRESULT retValue;
	};

	STDMETHOD(GenerateKeyPairFiles)(
		/*[in]*/ BSTR strPublicPrivateFile,
		/*[in,defaultvalue(NULL)]*/ BSTR strPublicOnlyFile)
	{
		VSL_DEFINE_MOCK_METHOD(GenerateKeyPairFiles)

		VSL_CHECK_VALIDVALUE_BSTR(strPublicPrivateFile);

		VSL_CHECK_VALIDVALUE_BSTR(strPublicOnlyFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUniqueFilenameValidValues
	{
		/*[in]*/ IDispatch* pDispatch;
		/*[in]*/ BSTR bstrRoot;
		/*[in]*/ BSTR bstrDesiredExt;
		/*[out,retval]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetUniqueFilename)(
		/*[in]*/ IDispatch* pDispatch,
		/*[in]*/ BSTR bstrRoot,
		/*[in]*/ BSTR bstrDesiredExt,
		/*[out,retval]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetUniqueFilename)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDispatch);

		VSL_CHECK_VALIDVALUE_BSTR(bstrRoot);

		VSL_CHECK_VALIDVALUE_BSTR(bstrDesiredExt);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoCountValidValues
	{
		/*[out]*/ UINT* pctinfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfoCount)(
		/*[out]*/ UINT* pctinfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfoCount)

		VSL_SET_VALIDVALUE(pctinfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTypeInfoValidValues
	{
		/*[in]*/ UINT iTInfo;
		/*[in]*/ LCID lcid;
		/*[out]*/ ITypeInfo** ppTInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetTypeInfo)(
		/*[in]*/ UINT iTInfo,
		/*[in]*/ LCID lcid,
		/*[out]*/ ITypeInfo** ppTInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetTypeInfo)

		VSL_CHECK_VALIDVALUE(iTInfo);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetIDsOfNamesValidValues
	{
		/*[in]*/ REFIID riid;
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames;
		/*[in]*/ UINT cNames;
		/*[in]*/ LCID lcid;
		/*[out,size_is(cNames)]*/ DISPID* rgDispId;
		HRESULT retValue;
	};

	STDMETHOD(GetIDsOfNames)(
		/*[in]*/ REFIID riid,
		/*[in,size_is(cNames)]*/ LPOLESTR* rgszNames,
		/*[in]*/ UINT cNames,
		/*[in]*/ LCID lcid,
		/*[out,size_is(cNames)]*/ DISPID* rgDispId)
	{
		VSL_DEFINE_MOCK_METHOD(GetIDsOfNames)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszNames, cNames*sizeof(rgszNames[0]), validValues.cNames*sizeof(validValues.rgszNames[0]));

		VSL_CHECK_VALIDVALUE(cNames);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_SET_VALIDVALUE_MEMCPY(rgDispId, cNames*sizeof(rgDispId[0]), validValues.cNames*sizeof(validValues.rgDispId[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeValidValues
	{
		/*[in]*/ DISPID dispIdMember;
		/*[in]*/ REFIID riid;
		/*[in]*/ LCID lcid;
		/*[in]*/ WORD wFlags;
		/*[in,out]*/ DISPPARAMS* pDispParams;
		/*[out]*/ VARIANT* pVarResult;
		/*[out]*/ EXCEPINFO* pExcepInfo;
		/*[out]*/ UINT* puArgErr;
		HRESULT retValue;
	};

	STDMETHOD(Invoke)(
		/*[in]*/ DISPID dispIdMember,
		/*[in]*/ REFIID riid,
		/*[in]*/ LCID lcid,
		/*[in]*/ WORD wFlags,
		/*[in,out]*/ DISPPARAMS* pDispParams,
		/*[out]*/ VARIANT* pVarResult,
		/*[out]*/ EXCEPINFO* pExcepInfo,
		/*[out]*/ UINT* puArgErr)
	{
		VSL_DEFINE_MOCK_METHOD(Invoke)

		VSL_CHECK_VALIDVALUE(dispIdMember);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(lcid);

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE(pDispParams);

		VSL_SET_VALIDVALUE_VARIANT(pVarResult);

		VSL_SET_VALIDVALUE(pExcepInfo);

		VSL_SET_VALIDVALUE(puArgErr);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // VSPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
