/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEPLOYABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEPLOYABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDeployableProjectCfg2NotImpl :
	public IVsDeployableProjectCfg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDeployableProjectCfg2NotImpl)

public:

	typedef IVsDeployableProjectCfg2 Interface;

	STDMETHOD(StartCleanDeploy)(
		/*[in]*/ IVsOutputWindowPane* /*pIVsOutputWindowPane*/,
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseDeployStatusCallback)(
		/*[in]*/ IVsDeployStatusCallback* /*pIVsDeployStatusCallback*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseDeployStatusCallback)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartDeploy)(
		/*[in]*/ IVsOutputWindowPane* /*pIVsOutputWindowPane*/,
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStatusDeploy)(
		/*[out]*/ BOOL* /*pfDeployDone*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StopDeploy)(
		/*[in]*/ BOOL /*fSync*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WaitDeploy)(
		/*[in]*/ DWORD /*dwMilliseconds*/,
		/*[in]*/ BOOL /*fTickWhenMessageQNotEmpty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStartDeploy)(
		/*[in]*/ DWORD /*dwOptions*/,
		/*[out,optional]*/ BOOL* /*pfSupported*/,
		/*[out,optional]*/ BOOL* /*pfReady*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Commit)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Rollback)(
		/*[in]*/ DWORD /*dwReserved*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDeployableProjectCfg2MockImpl :
	public IVsDeployableProjectCfg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDeployableProjectCfg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDeployableProjectCfg2MockImpl)

	typedef IVsDeployableProjectCfg2 Interface;
	struct StartCleanDeployValidValues
	{
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane;
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(StartCleanDeploy)(
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane,
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(StartCleanDeploy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsOutputWindowPane);

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseDeployStatusCallbackValidValues
	{
		/*[in]*/ IVsDeployStatusCallback* pIVsDeployStatusCallback;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseDeployStatusCallback)(
		/*[in]*/ IVsDeployStatusCallback* pIVsDeployStatusCallback,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseDeployStatusCallback)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsDeployStatusCallback);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseDeployStatusCallbackValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseDeployStatusCallback)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseDeployStatusCallback)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartDeployValidValues
	{
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane;
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(StartDeploy)(
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane,
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(StartDeploy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsOutputWindowPane);

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStatusDeployValidValues
	{
		/*[out]*/ BOOL* pfDeployDone;
		HRESULT retValue;
	};

	STDMETHOD(QueryStatusDeploy)(
		/*[out]*/ BOOL* pfDeployDone)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStatusDeploy)

		VSL_SET_VALIDVALUE(pfDeployDone);

		VSL_RETURN_VALIDVALUES();
	}
	struct StopDeployValidValues
	{
		/*[in]*/ BOOL fSync;
		HRESULT retValue;
	};

	STDMETHOD(StopDeploy)(
		/*[in]*/ BOOL fSync)
	{
		VSL_DEFINE_MOCK_METHOD(StopDeploy)

		VSL_CHECK_VALIDVALUE(fSync);

		VSL_RETURN_VALIDVALUES();
	}
	struct WaitDeployValidValues
	{
		/*[in]*/ DWORD dwMilliseconds;
		/*[in]*/ BOOL fTickWhenMessageQNotEmpty;
		HRESULT retValue;
	};

	STDMETHOD(WaitDeploy)(
		/*[in]*/ DWORD dwMilliseconds,
		/*[in]*/ BOOL fTickWhenMessageQNotEmpty)
	{
		VSL_DEFINE_MOCK_METHOD(WaitDeploy)

		VSL_CHECK_VALIDVALUE(dwMilliseconds);

		VSL_CHECK_VALIDVALUE(fTickWhenMessageQNotEmpty);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStartDeployValidValues
	{
		/*[in]*/ DWORD dwOptions;
		/*[out,optional]*/ BOOL* pfSupported;
		/*[out,optional]*/ BOOL* pfReady;
		HRESULT retValue;
	};

	STDMETHOD(QueryStartDeploy)(
		/*[in]*/ DWORD dwOptions,
		/*[out,optional]*/ BOOL* pfSupported,
		/*[out,optional]*/ BOOL* pfReady)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStartDeploy)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_SET_VALIDVALUE(pfSupported);

		VSL_SET_VALIDVALUE(pfReady);

		VSL_RETURN_VALIDVALUES();
	}
	struct CommitValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(Commit)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(Commit)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
	struct RollbackValidValues
	{
		/*[in]*/ DWORD dwReserved;
		HRESULT retValue;
	};

	STDMETHOD(Rollback)(
		/*[in]*/ DWORD dwReserved)
	{
		VSL_DEFINE_MOCK_METHOD(Rollback)

		VSL_CHECK_VALIDVALUE(dwReserved);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEPLOYABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
