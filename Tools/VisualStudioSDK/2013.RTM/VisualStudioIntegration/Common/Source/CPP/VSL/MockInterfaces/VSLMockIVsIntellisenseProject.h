/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSINTELLISENSEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSINTELLISENSEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "containedlanguage.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsIntellisenseProjectNotImpl :
	public IVsIntellisenseProject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectNotImpl)

public:

	typedef IVsIntellisenseProject Interface;

	STDMETHOD(Init)(
		/*[in]*/ IVsIntellisenseProjectHost* /*pHost*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddFile)(
		/*[in]*/ BSTR /*bstrAbsPath*/,
		/*[in]*/ VSITEMID /*itemid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveFile)(
		/*[in]*/ BSTR /*bstrAbsPath*/,
		/*[in]*/ VSITEMID /*itemid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RenameFile)(
		/*[in]*/ BSTR /*bstrAbsPath*/,
		/*[in]*/ BSTR /*bstrNewAbsPath*/,
		/*[in]*/ VSITEMID /*itemid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsCompilableFile)(
		/*[in]*/ BSTR /*bstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContainedLanguageFactory)(
		/*[out,retval]*/ IVsContainedLanguageFactory** /*ppContainedLanguageFactory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompilerReference)(
		/*[out,retval]*/ IUnknown** /*ppCompilerReference*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetFileCodeModel)(
		/*[in]*/ IUnknown* /*pProj*/,
		/*[in]*/ IUnknown* /*pProjectItem*/,
		/*[out,retval]*/ IUnknown** /*ppCodeModel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectCodeModel)(
		/*[in]*/ IUnknown* /*pProj*/,
		/*[out,retval]*/ IUnknown** /*ppCodeModel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshCompilerOptions)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCodeDomProviderName)(
		/*[out,retval]*/ BSTR* /*pbstrProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsWebFileRequiredByProject)(
		/*[out,retval]*/ BOOL* /*pbReq*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddAssemblyReference)(
		/*[in]*/ BSTR /*bstrAbsPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAssemblyReference)(
		/*[in]*/ BSTR /*bstrAbsPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddP2PReference)(
		/*[in]*/ IUnknown* /*pUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveP2PReference)(
		/*[in]*/ IUnknown* /*pUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StopIntellisenseEngine)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartIntellisenseEngine)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsSupportedP2PReference)(
		/*[in]*/ IUnknown* /*pUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WaitForIntellisenseReady)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExternalErrorReporter)(
		/*[out,retval]*/ IVsReportExternalErrors** /*ppErrorReporter*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SuspendPostedNotifications)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResumePostedNotifications)()VSL_STDMETHOD_NOTIMPL
};

class IVsIntellisenseProjectMockImpl :
	public IVsIntellisenseProject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsIntellisenseProjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsIntellisenseProjectMockImpl)

	typedef IVsIntellisenseProject Interface;
	struct InitValidValues
	{
		/*[in]*/ IVsIntellisenseProjectHost* pHost;
		HRESULT retValue;
	};

	STDMETHOD(Init)(
		/*[in]*/ IVsIntellisenseProjectHost* pHost)
	{
		VSL_DEFINE_MOCK_METHOD(Init)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHost);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
	struct AddFileValidValues
	{
		/*[in]*/ BSTR bstrAbsPath;
		/*[in]*/ VSITEMID itemid;
		HRESULT retValue;
	};

	STDMETHOD(AddFile)(
		/*[in]*/ BSTR bstrAbsPath,
		/*[in]*/ VSITEMID itemid)
	{
		VSL_DEFINE_MOCK_METHOD(AddFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrAbsPath);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveFileValidValues
	{
		/*[in]*/ BSTR bstrAbsPath;
		/*[in]*/ VSITEMID itemid;
		HRESULT retValue;
	};

	STDMETHOD(RemoveFile)(
		/*[in]*/ BSTR bstrAbsPath,
		/*[in]*/ VSITEMID itemid)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrAbsPath);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_RETURN_VALIDVALUES();
	}
	struct RenameFileValidValues
	{
		/*[in]*/ BSTR bstrAbsPath;
		/*[in]*/ BSTR bstrNewAbsPath;
		/*[in]*/ VSITEMID itemid;
		HRESULT retValue;
	};

	STDMETHOD(RenameFile)(
		/*[in]*/ BSTR bstrAbsPath,
		/*[in]*/ BSTR bstrNewAbsPath,
		/*[in]*/ VSITEMID itemid)
	{
		VSL_DEFINE_MOCK_METHOD(RenameFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrAbsPath);

		VSL_CHECK_VALIDVALUE_BSTR(bstrNewAbsPath);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsCompilableFileValidValues
	{
		/*[in]*/ BSTR bstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(IsCompilableFile)(
		/*[in]*/ BSTR bstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(IsCompilableFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContainedLanguageFactoryValidValues
	{
		/*[out,retval]*/ IVsContainedLanguageFactory** ppContainedLanguageFactory;
		HRESULT retValue;
	};

	STDMETHOD(GetContainedLanguageFactory)(
		/*[out,retval]*/ IVsContainedLanguageFactory** ppContainedLanguageFactory)
	{
		VSL_DEFINE_MOCK_METHOD(GetContainedLanguageFactory)

		VSL_SET_VALIDVALUE_INTERFACE(ppContainedLanguageFactory);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompilerReferenceValidValues
	{
		/*[out,retval]*/ IUnknown** ppCompilerReference;
		HRESULT retValue;
	};

	STDMETHOD(GetCompilerReference)(
		/*[out,retval]*/ IUnknown** ppCompilerReference)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompilerReference)

		VSL_SET_VALIDVALUE_INTERFACE(ppCompilerReference);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetFileCodeModelValidValues
	{
		/*[in]*/ IUnknown* pProj;
		/*[in]*/ IUnknown* pProjectItem;
		/*[out,retval]*/ IUnknown** ppCodeModel;
		HRESULT retValue;
	};

	STDMETHOD(GetFileCodeModel)(
		/*[in]*/ IUnknown* pProj,
		/*[in]*/ IUnknown* pProjectItem,
		/*[out,retval]*/ IUnknown** ppCodeModel)
	{
		VSL_DEFINE_MOCK_METHOD(GetFileCodeModel)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProj);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProjectItem);

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeModel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectCodeModelValidValues
	{
		/*[in]*/ IUnknown* pProj;
		/*[out,retval]*/ IUnknown** ppCodeModel;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectCodeModel)(
		/*[in]*/ IUnknown* pProj,
		/*[out,retval]*/ IUnknown** ppCodeModel)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectCodeModel)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProj);

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeModel);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshCompilerOptionsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RefreshCompilerOptions)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RefreshCompilerOptions)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCodeDomProviderNameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeDomProviderName)(
		/*[out,retval]*/ BSTR* pbstrProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeDomProviderName)

		VSL_SET_VALIDVALUE_BSTR(pbstrProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsWebFileRequiredByProjectValidValues
	{
		/*[out,retval]*/ BOOL* pbReq;
		HRESULT retValue;
	};

	STDMETHOD(IsWebFileRequiredByProject)(
		/*[out,retval]*/ BOOL* pbReq)
	{
		VSL_DEFINE_MOCK_METHOD(IsWebFileRequiredByProject)

		VSL_SET_VALIDVALUE(pbReq);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddAssemblyReferenceValidValues
	{
		/*[in]*/ BSTR bstrAbsPath;
		HRESULT retValue;
	};

	STDMETHOD(AddAssemblyReference)(
		/*[in]*/ BSTR bstrAbsPath)
	{
		VSL_DEFINE_MOCK_METHOD(AddAssemblyReference)

		VSL_CHECK_VALIDVALUE_BSTR(bstrAbsPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAssemblyReferenceValidValues
	{
		/*[in]*/ BSTR bstrAbsPath;
		HRESULT retValue;
	};

	STDMETHOD(RemoveAssemblyReference)(
		/*[in]*/ BSTR bstrAbsPath)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveAssemblyReference)

		VSL_CHECK_VALIDVALUE_BSTR(bstrAbsPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddP2PReferenceValidValues
	{
		/*[in]*/ IUnknown* pUnk;
		HRESULT retValue;
	};

	STDMETHOD(AddP2PReference)(
		/*[in]*/ IUnknown* pUnk)
	{
		VSL_DEFINE_MOCK_METHOD(AddP2PReference)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnk);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveP2PReferenceValidValues
	{
		/*[in]*/ IUnknown* pUnk;
		HRESULT retValue;
	};

	STDMETHOD(RemoveP2PReference)(
		/*[in]*/ IUnknown* pUnk)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveP2PReference)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnk);

		VSL_RETURN_VALIDVALUES();
	}
	struct StopIntellisenseEngineValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StopIntellisenseEngine)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StopIntellisenseEngine)

		VSL_RETURN_VALIDVALUES();
	}
	struct StartIntellisenseEngineValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StartIntellisenseEngine)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StartIntellisenseEngine)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsSupportedP2PReferenceValidValues
	{
		/*[in]*/ IUnknown* pUnk;
		HRESULT retValue;
	};

	STDMETHOD(IsSupportedP2PReference)(
		/*[in]*/ IUnknown* pUnk)
	{
		VSL_DEFINE_MOCK_METHOD(IsSupportedP2PReference)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnk);

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
	struct GetExternalErrorReporterValidValues
	{
		/*[out,retval]*/ IVsReportExternalErrors** ppErrorReporter;
		HRESULT retValue;
	};

	STDMETHOD(GetExternalErrorReporter)(
		/*[out,retval]*/ IVsReportExternalErrors** ppErrorReporter)
	{
		VSL_DEFINE_MOCK_METHOD(GetExternalErrorReporter)

		VSL_SET_VALIDVALUE_INTERFACE(ppErrorReporter);

		VSL_RETURN_VALIDVALUES();
	}
	struct SuspendPostedNotificationsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(SuspendPostedNotifications)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(SuspendPostedNotifications)

		VSL_RETURN_VALIDVALUES();
	}
	struct ResumePostedNotificationsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ResumePostedNotifications)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ResumePostedNotifications)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSINTELLISENSEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
