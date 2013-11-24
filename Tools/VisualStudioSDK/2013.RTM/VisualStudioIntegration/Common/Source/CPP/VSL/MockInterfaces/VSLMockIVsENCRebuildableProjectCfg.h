/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSENCREBUILDABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSENCREBUILDABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "encbuild.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsENCRebuildableProjectCfgNotImpl :
	public IVsENCRebuildableProjectCfg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsENCRebuildableProjectCfgNotImpl)

public:

	typedef IVsENCRebuildableProjectCfg Interface;

	STDMETHOD(ENCRebuild)(
		/*[in]*/ IUnknown* /*in_pProgram*/,
		/*[out]*/ IUnknown** /*out_ppSnapshot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CancelENC)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ENCRelink)(
		/*[in]*/ IUnknown* /*pENCRelinkInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartDebugging)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StopDebugging)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BelongToProject)(
		/*[in]*/ LPCOLESTR /*in_szFileName*/,
		/*[in]*/ ENC_REASON /*in_ENCReason*/,
		/*[in]*/ BOOL /*in_fOnContinue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetENCProjectBuildOption)(
		/*[in]*/ REFGUID /*in_guidOption*/,
		/*[in]*/ LPCOLESTR /*in_szOptionValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ENCComplete)(
		/*[in]*/ BOOL /*in_fENCSuccess*/)VSL_STDMETHOD_NOTIMPL
};

class IVsENCRebuildableProjectCfgMockImpl :
	public IVsENCRebuildableProjectCfg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsENCRebuildableProjectCfgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsENCRebuildableProjectCfgMockImpl)

	typedef IVsENCRebuildableProjectCfg Interface;
	struct ENCRebuildValidValues
	{
		/*[in]*/ IUnknown* in_pProgram;
		/*[out]*/ IUnknown** out_ppSnapshot;
		HRESULT retValue;
	};

	STDMETHOD(ENCRebuild)(
		/*[in]*/ IUnknown* in_pProgram,
		/*[out]*/ IUnknown** out_ppSnapshot)
	{
		VSL_DEFINE_MOCK_METHOD(ENCRebuild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(in_pProgram);

		VSL_SET_VALIDVALUE_INTERFACE(out_ppSnapshot);

		VSL_RETURN_VALIDVALUES();
	}
	struct CancelENCValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CancelENC)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CancelENC)

		VSL_RETURN_VALIDVALUES();
	}
	struct ENCRelinkValidValues
	{
		/*[in]*/ IUnknown* pENCRelinkInfo;
		HRESULT retValue;
	};

	STDMETHOD(ENCRelink)(
		/*[in]*/ IUnknown* pENCRelinkInfo)
	{
		VSL_DEFINE_MOCK_METHOD(ENCRelink)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pENCRelinkInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartDebuggingValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StartDebugging)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StartDebugging)

		VSL_RETURN_VALIDVALUES();
	}
	struct StopDebuggingValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(StopDebugging)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(StopDebugging)

		VSL_RETURN_VALIDVALUES();
	}
	struct BelongToProjectValidValues
	{
		/*[in]*/ LPCOLESTR in_szFileName;
		/*[in]*/ ENC_REASON in_ENCReason;
		/*[in]*/ BOOL in_fOnContinue;
		HRESULT retValue;
	};

	STDMETHOD(BelongToProject)(
		/*[in]*/ LPCOLESTR in_szFileName,
		/*[in]*/ ENC_REASON in_ENCReason,
		/*[in]*/ BOOL in_fOnContinue)
	{
		VSL_DEFINE_MOCK_METHOD(BelongToProject)

		VSL_CHECK_VALIDVALUE_STRINGW(in_szFileName);

		VSL_CHECK_VALIDVALUE(in_ENCReason);

		VSL_CHECK_VALIDVALUE(in_fOnContinue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetENCProjectBuildOptionValidValues
	{
		/*[in]*/ REFGUID in_guidOption;
		/*[in]*/ LPCOLESTR in_szOptionValue;
		HRESULT retValue;
	};

	STDMETHOD(SetENCProjectBuildOption)(
		/*[in]*/ REFGUID in_guidOption,
		/*[in]*/ LPCOLESTR in_szOptionValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetENCProjectBuildOption)

		VSL_CHECK_VALIDVALUE(in_guidOption);

		VSL_CHECK_VALIDVALUE_STRINGW(in_szOptionValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct ENCCompleteValidValues
	{
		/*[in]*/ BOOL in_fENCSuccess;
		HRESULT retValue;
	};

	STDMETHOD(ENCComplete)(
		/*[in]*/ BOOL in_fENCSuccess)
	{
		VSL_DEFINE_MOCK_METHOD(ENCComplete)

		VSL_CHECK_VALIDVALUE(in_fENCSuccess);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSENCREBUILDABLEPROJECTCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
