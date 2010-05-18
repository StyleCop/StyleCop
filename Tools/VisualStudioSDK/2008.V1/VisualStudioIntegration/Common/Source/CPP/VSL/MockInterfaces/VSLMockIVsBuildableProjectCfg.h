/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBUILDABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBUILDABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsBuildableProjectCfgNotImpl :
	public IVsBuildableProjectCfg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildableProjectCfgNotImpl)

public:

	typedef IVsBuildableProjectCfg Interface;

	STDMETHOD(get_ProjectCfg)(
		/*[out]*/ IVsProjectCfg** /*ppIVsProjectCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseBuildStatusCallback)(
		/*[in]*/ IVsBuildStatusCallback* /*pIVsBuildStatusCallback*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseBuildStatusCallback)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartBuild)(
		/*[in]*/ IVsOutputWindowPane* /*pIVsOutputWindowPane*/,
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartClean)(
		/*[in]*/ IVsOutputWindowPane* /*pIVsOutputWindowPane*/,
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartUpToDateCheck)(
		/*[in]*/ IVsOutputWindowPane* /*pIVsOutputWindowPane*/,
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStatus)(
		/*[out]*/ BOOL* /*pfBuildDone*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Stop)(
		/*[in]*/ BOOL /*fSync*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Wait)(
		/*[in]*/ DWORD /*dwMilliseconds*/,
		/*[in]*/ BOOL /*fTickWhenMessageQNotEmpty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStartBuild)(
		/*[in]*/ DWORD /*dwOptions*/,
		/*[out,optional]*/ BOOL* /*pfSupported*/,
		/*[out,optional]*/ BOOL* /*pfReady*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStartClean)(
		/*[in]*/ DWORD /*dwOptions*/,
		/*[out,optional]*/ BOOL* /*pfSupported*/,
		/*[out,optional]*/ BOOL* /*pfReady*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStartUpToDateCheck)(
		/*[in]*/ DWORD /*dwOptions*/,
		/*[out,optional]*/ BOOL* /*pfSupported*/,
		/*[out,optional]*/ BOOL* /*pfReady*/)VSL_STDMETHOD_NOTIMPL
};

class IVsBuildableProjectCfgMockImpl :
	public IVsBuildableProjectCfg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildableProjectCfgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsBuildableProjectCfgMockImpl)

	typedef IVsBuildableProjectCfg Interface;
	struct get_ProjectCfgValidValues
	{
		/*[out]*/ IVsProjectCfg** ppIVsProjectCfg;
		HRESULT retValue;
	};

	STDMETHOD(get_ProjectCfg)(
		/*[out]*/ IVsProjectCfg** ppIVsProjectCfg)
	{
		VSL_DEFINE_MOCK_METHOD(get_ProjectCfg)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsProjectCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseBuildStatusCallbackValidValues
	{
		/*[in]*/ IVsBuildStatusCallback* pIVsBuildStatusCallback;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseBuildStatusCallback)(
		/*[in]*/ IVsBuildStatusCallback* pIVsBuildStatusCallback,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseBuildStatusCallback)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsBuildStatusCallback);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseBuildStatusCallbackValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseBuildStatusCallback)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseBuildStatusCallback)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartBuildValidValues
	{
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane;
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(StartBuild)(
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane,
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(StartBuild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsOutputWindowPane);

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartCleanValidValues
	{
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane;
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(StartClean)(
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane,
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(StartClean)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsOutputWindowPane);

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartUpToDateCheckValidValues
	{
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane;
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(StartUpToDateCheck)(
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane,
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(StartUpToDateCheck)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsOutputWindowPane);

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStatusValidValues
	{
		/*[out]*/ BOOL* pfBuildDone;
		HRESULT retValue;
	};

	STDMETHOD(QueryStatus)(
		/*[out]*/ BOOL* pfBuildDone)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStatus)

		VSL_SET_VALIDVALUE(pfBuildDone);

		VSL_RETURN_VALIDVALUES();
	}
	struct StopValidValues
	{
		/*[in]*/ BOOL fSync;
		HRESULT retValue;
	};

	STDMETHOD(Stop)(
		/*[in]*/ BOOL fSync)
	{
		VSL_DEFINE_MOCK_METHOD(Stop)

		VSL_CHECK_VALIDVALUE(fSync);

		VSL_RETURN_VALIDVALUES();
	}
	struct WaitValidValues
	{
		/*[in]*/ DWORD dwMilliseconds;
		/*[in]*/ BOOL fTickWhenMessageQNotEmpty;
		HRESULT retValue;
	};

	STDMETHOD(Wait)(
		/*[in]*/ DWORD dwMilliseconds,
		/*[in]*/ BOOL fTickWhenMessageQNotEmpty)
	{
		VSL_DEFINE_MOCK_METHOD(Wait)

		VSL_CHECK_VALIDVALUE(dwMilliseconds);

		VSL_CHECK_VALIDVALUE(fTickWhenMessageQNotEmpty);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStartBuildValidValues
	{
		/*[in]*/ DWORD dwOptions;
		/*[out,optional]*/ BOOL* pfSupported;
		/*[out,optional]*/ BOOL* pfReady;
		HRESULT retValue;
	};

	STDMETHOD(QueryStartBuild)(
		/*[in]*/ DWORD dwOptions,
		/*[out,optional]*/ BOOL* pfSupported,
		/*[out,optional]*/ BOOL* pfReady)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStartBuild)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_SET_VALIDVALUE(pfSupported);

		VSL_SET_VALIDVALUE(pfReady);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStartCleanValidValues
	{
		/*[in]*/ DWORD dwOptions;
		/*[out,optional]*/ BOOL* pfSupported;
		/*[out,optional]*/ BOOL* pfReady;
		HRESULT retValue;
	};

	STDMETHOD(QueryStartClean)(
		/*[in]*/ DWORD dwOptions,
		/*[out,optional]*/ BOOL* pfSupported,
		/*[out,optional]*/ BOOL* pfReady)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStartClean)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_SET_VALIDVALUE(pfSupported);

		VSL_SET_VALIDVALUE(pfReady);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStartUpToDateCheckValidValues
	{
		/*[in]*/ DWORD dwOptions;
		/*[out,optional]*/ BOOL* pfSupported;
		/*[out,optional]*/ BOOL* pfReady;
		HRESULT retValue;
	};

	STDMETHOD(QueryStartUpToDateCheck)(
		/*[in]*/ DWORD dwOptions,
		/*[out,optional]*/ BOOL* pfSupported,
		/*[out,optional]*/ BOOL* pfReady)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStartUpToDateCheck)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_SET_VALIDVALUE(pfSupported);

		VSL_SET_VALIDVALUE(pfReady);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBUILDABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
