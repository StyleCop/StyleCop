/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPUBLISHABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPUBLISHABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsPublishableProjectCfgNotImpl :
	public IVsPublishableProjectCfg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPublishableProjectCfgNotImpl)

public:

	typedef IVsPublishableProjectCfg Interface;

	STDMETHOD(AdvisePublishStatusCallback)(
		/*[in]*/ IVsPublishableProjectStatusCallback* /*pIVsPublishStatusCallback*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadvisePublishStatusCallback)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartPublish)(
		/*[in]*/ IVsOutputWindowPane* /*pIVsOutputWindowPane*/,
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStatusPublish)(
		/*[out]*/ BOOL* /*pfPublishDone*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StopPublish)(
		/*[in]*/ BOOL /*fSync*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowPublishPrompt)(
		/*[out]*/ BOOL* /*pfContinue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStartPublish)(
		/*[in]*/ DWORD /*dwOptions*/,
		/*[out,optional]*/ BOOL* /*pfSupported*/,
		/*[out,optional]*/ BOOL* /*pfReady*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPublishProperty)(
		/*[in]*/ VSPUBLISHOPTS /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPublishableProjectCfgMockImpl :
	public IVsPublishableProjectCfg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPublishableProjectCfgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPublishableProjectCfgMockImpl)

	typedef IVsPublishableProjectCfg Interface;
	struct AdvisePublishStatusCallbackValidValues
	{
		/*[in]*/ IVsPublishableProjectStatusCallback* pIVsPublishStatusCallback;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdvisePublishStatusCallback)(
		/*[in]*/ IVsPublishableProjectStatusCallback* pIVsPublishStatusCallback,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdvisePublishStatusCallback)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsPublishStatusCallback);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadvisePublishStatusCallbackValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadvisePublishStatusCallback)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadvisePublishStatusCallback)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartPublishValidValues
	{
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane;
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(StartPublish)(
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane,
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(StartPublish)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsOutputWindowPane);

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStatusPublishValidValues
	{
		/*[out]*/ BOOL* pfPublishDone;
		HRESULT retValue;
	};

	STDMETHOD(QueryStatusPublish)(
		/*[out]*/ BOOL* pfPublishDone)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStatusPublish)

		VSL_SET_VALIDVALUE(pfPublishDone);

		VSL_RETURN_VALIDVALUES();
	}
	struct StopPublishValidValues
	{
		/*[in]*/ BOOL fSync;
		HRESULT retValue;
	};

	STDMETHOD(StopPublish)(
		/*[in]*/ BOOL fSync)
	{
		VSL_DEFINE_MOCK_METHOD(StopPublish)

		VSL_CHECK_VALIDVALUE(fSync);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowPublishPromptValidValues
	{
		/*[out]*/ BOOL* pfContinue;
		HRESULT retValue;
	};

	STDMETHOD(ShowPublishPrompt)(
		/*[out]*/ BOOL* pfContinue)
	{
		VSL_DEFINE_MOCK_METHOD(ShowPublishPrompt)

		VSL_SET_VALIDVALUE(pfContinue);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStartPublishValidValues
	{
		/*[in]*/ DWORD dwOptions;
		/*[out,optional]*/ BOOL* pfSupported;
		/*[out,optional]*/ BOOL* pfReady;
		HRESULT retValue;
	};

	STDMETHOD(QueryStartPublish)(
		/*[in]*/ DWORD dwOptions,
		/*[out,optional]*/ BOOL* pfSupported,
		/*[out,optional]*/ BOOL* pfReady)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStartPublish)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_SET_VALIDVALUE(pfSupported);

		VSL_SET_VALIDVALUE(pfReady);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPublishPropertyValidValues
	{
		/*[in]*/ VSPUBLISHOPTS propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetPublishProperty)(
		/*[in]*/ VSPUBLISHOPTS propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetPublishProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPUBLISHABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
