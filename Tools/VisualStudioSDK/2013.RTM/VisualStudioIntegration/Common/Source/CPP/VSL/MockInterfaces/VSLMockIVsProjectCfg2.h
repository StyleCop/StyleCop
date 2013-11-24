/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectCfg2NotImpl :
	public IVsProjectCfg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectCfg2NotImpl)

public:

	typedef IVsProjectCfg2 Interface;

	STDMETHOD(get_CfgType)(
		/*[in]*/ REFIID /*iidCfg*/,
		/*[out,iid_is(iidCfg)]*/ void** /*ppCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OutputGroups)(
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ IVsOutputGroup*[] /*rgpcfg*/,
		/*[out,optional]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenOutputGroup)(
		/*[in]*/ LPCOLESTR /*szCanonicalName*/,
		/*[out]*/ IVsOutputGroup** /*ppIVsOutputGroup*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OutputsRequireAppRoot)(
		/*[out]*/ BOOL* /*pfRequiresAppRoot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_VirtualRoot)(
		/*[out]*/ BSTR* /*pbstrVRoot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsPrivate)(
		/*[out]*/ BOOL* /*pfPrivate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumOutputs)(
		/*[out]*/ IVsEnumOutputs** /*ppIVsEnumOutputs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenOutput)(
		/*[in]*/ LPCOLESTR /*szOutputCanonicalName*/,
		/*[out]*/ IVsOutput** /*ppIVsOutput*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ProjectCfgProvider)(
		/*[out]*/ IVsProjectCfgProvider** /*ppIVsProjectCfgProvider*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_BuildableProjectCfg)(
		/*[out]*/ IVsBuildableProjectCfg** /*ppIVsBuildableProjectCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CanonicalName)(
		/*[out]*/ BSTR* /*pbstrCanonicalName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Platform)(
		/*[out]*/ GUID* /*pguidPlatform*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsPackaged)(
		/*[out]*/ BOOL* /*pfIsPackaged*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsSpecifyingOutputSupported)(
		/*[out]*/ BOOL* /*pfIsSpecifyingOutputSupported*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_TargetCodePage)(
		/*[out]*/ UINT* /*puiTargetCodePage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_UpdateSequenceNumber)(
		/*[out]*/ ULARGE_INTEGER* /*puliUSN*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RootURL)(
		/*[out]*/ BSTR* /*pbstrRootURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DisplayName)(
		/*[out]*/ BSTR* /*pbstrDisplayName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsDebugOnly)(
		/*[out]*/ BOOL* /*pfIsDebugOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsReleaseOnly)(
		/*[out]*/ BOOL* /*pfIsReleaseOnly*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectCfg2MockImpl :
	public IVsProjectCfg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectCfg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectCfg2MockImpl)

	typedef IVsProjectCfg2 Interface;
	struct get_CfgTypeValidValues
	{
		/*[in]*/ REFIID iidCfg;
		/*[out,iid_is(iidCfg)]*/ void** ppCfg;
		HRESULT retValue;
	};

	STDMETHOD(get_CfgType)(
		/*[in]*/ REFIID iidCfg,
		/*[out,iid_is(iidCfg)]*/ void** ppCfg)
	{
		VSL_DEFINE_MOCK_METHOD(get_CfgType)

		VSL_CHECK_VALIDVALUE(iidCfg);

		VSL_SET_VALIDVALUE(ppCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OutputGroupsValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ IVsOutputGroup** rgpcfg;
		/*[out,optional]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(get_OutputGroups)(
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ IVsOutputGroup* rgpcfg[],
		/*[out,optional]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(get_OutputGroups)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(rgpcfg, celt, validValues.celt);

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenOutputGroupValidValues
	{
		/*[in]*/ LPCOLESTR szCanonicalName;
		/*[out]*/ IVsOutputGroup** ppIVsOutputGroup;
		HRESULT retValue;
	};

	STDMETHOD(OpenOutputGroup)(
		/*[in]*/ LPCOLESTR szCanonicalName,
		/*[out]*/ IVsOutputGroup** ppIVsOutputGroup)
	{
		VSL_DEFINE_MOCK_METHOD(OpenOutputGroup)

		VSL_CHECK_VALIDVALUE_STRINGW(szCanonicalName);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsOutputGroup);

		VSL_RETURN_VALIDVALUES();
	}
	struct OutputsRequireAppRootValidValues
	{
		/*[out]*/ BOOL* pfRequiresAppRoot;
		HRESULT retValue;
	};

	STDMETHOD(OutputsRequireAppRoot)(
		/*[out]*/ BOOL* pfRequiresAppRoot)
	{
		VSL_DEFINE_MOCK_METHOD(OutputsRequireAppRoot)

		VSL_SET_VALIDVALUE(pfRequiresAppRoot);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_VirtualRootValidValues
	{
		/*[out]*/ BSTR* pbstrVRoot;
		HRESULT retValue;
	};

	STDMETHOD(get_VirtualRoot)(
		/*[out]*/ BSTR* pbstrVRoot)
	{
		VSL_DEFINE_MOCK_METHOD(get_VirtualRoot)

		VSL_SET_VALIDVALUE_BSTR(pbstrVRoot);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsPrivateValidValues
	{
		/*[out]*/ BOOL* pfPrivate;
		HRESULT retValue;
	};

	STDMETHOD(get_IsPrivate)(
		/*[out]*/ BOOL* pfPrivate)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsPrivate)

		VSL_SET_VALIDVALUE(pfPrivate);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumOutputsValidValues
	{
		/*[out]*/ IVsEnumOutputs** ppIVsEnumOutputs;
		HRESULT retValue;
	};

	STDMETHOD(EnumOutputs)(
		/*[out]*/ IVsEnumOutputs** ppIVsEnumOutputs)
	{
		VSL_DEFINE_MOCK_METHOD(EnumOutputs)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsEnumOutputs);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenOutputValidValues
	{
		/*[in]*/ LPCOLESTR szOutputCanonicalName;
		/*[out]*/ IVsOutput** ppIVsOutput;
		HRESULT retValue;
	};

	STDMETHOD(OpenOutput)(
		/*[in]*/ LPCOLESTR szOutputCanonicalName,
		/*[out]*/ IVsOutput** ppIVsOutput)
	{
		VSL_DEFINE_MOCK_METHOD(OpenOutput)

		VSL_CHECK_VALIDVALUE_STRINGW(szOutputCanonicalName);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsOutput);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ProjectCfgProviderValidValues
	{
		/*[out]*/ IVsProjectCfgProvider** ppIVsProjectCfgProvider;
		HRESULT retValue;
	};

	STDMETHOD(get_ProjectCfgProvider)(
		/*[out]*/ IVsProjectCfgProvider** ppIVsProjectCfgProvider)
	{
		VSL_DEFINE_MOCK_METHOD(get_ProjectCfgProvider)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsProjectCfgProvider);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_BuildableProjectCfgValidValues
	{
		/*[out]*/ IVsBuildableProjectCfg** ppIVsBuildableProjectCfg;
		HRESULT retValue;
	};

	STDMETHOD(get_BuildableProjectCfg)(
		/*[out]*/ IVsBuildableProjectCfg** ppIVsBuildableProjectCfg)
	{
		VSL_DEFINE_MOCK_METHOD(get_BuildableProjectCfg)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsBuildableProjectCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CanonicalNameValidValues
	{
		/*[out]*/ BSTR* pbstrCanonicalName;
		HRESULT retValue;
	};

	STDMETHOD(get_CanonicalName)(
		/*[out]*/ BSTR* pbstrCanonicalName)
	{
		VSL_DEFINE_MOCK_METHOD(get_CanonicalName)

		VSL_SET_VALIDVALUE_BSTR(pbstrCanonicalName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_PlatformValidValues
	{
		/*[out]*/ GUID* pguidPlatform;
		HRESULT retValue;
	};

	STDMETHOD(get_Platform)(
		/*[out]*/ GUID* pguidPlatform)
	{
		VSL_DEFINE_MOCK_METHOD(get_Platform)

		VSL_SET_VALIDVALUE(pguidPlatform);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsPackagedValidValues
	{
		/*[out]*/ BOOL* pfIsPackaged;
		HRESULT retValue;
	};

	STDMETHOD(get_IsPackaged)(
		/*[out]*/ BOOL* pfIsPackaged)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsPackaged)

		VSL_SET_VALIDVALUE(pfIsPackaged);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsSpecifyingOutputSupportedValidValues
	{
		/*[out]*/ BOOL* pfIsSpecifyingOutputSupported;
		HRESULT retValue;
	};

	STDMETHOD(get_IsSpecifyingOutputSupported)(
		/*[out]*/ BOOL* pfIsSpecifyingOutputSupported)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsSpecifyingOutputSupported)

		VSL_SET_VALIDVALUE(pfIsSpecifyingOutputSupported);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TargetCodePageValidValues
	{
		/*[out]*/ UINT* puiTargetCodePage;
		HRESULT retValue;
	};

	STDMETHOD(get_TargetCodePage)(
		/*[out]*/ UINT* puiTargetCodePage)
	{
		VSL_DEFINE_MOCK_METHOD(get_TargetCodePage)

		VSL_SET_VALIDVALUE(puiTargetCodePage);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_UpdateSequenceNumberValidValues
	{
		/*[out]*/ ULARGE_INTEGER* puliUSN;
		HRESULT retValue;
	};

	STDMETHOD(get_UpdateSequenceNumber)(
		/*[out]*/ ULARGE_INTEGER* puliUSN)
	{
		VSL_DEFINE_MOCK_METHOD(get_UpdateSequenceNumber)

		VSL_SET_VALIDVALUE(puliUSN);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RootURLValidValues
	{
		/*[out]*/ BSTR* pbstrRootURL;
		HRESULT retValue;
	};

	STDMETHOD(get_RootURL)(
		/*[out]*/ BSTR* pbstrRootURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_RootURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrRootURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DisplayNameValidValues
	{
		/*[out]*/ BSTR* pbstrDisplayName;
		HRESULT retValue;
	};

	STDMETHOD(get_DisplayName)(
		/*[out]*/ BSTR* pbstrDisplayName)
	{
		VSL_DEFINE_MOCK_METHOD(get_DisplayName)

		VSL_SET_VALIDVALUE_BSTR(pbstrDisplayName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsDebugOnlyValidValues
	{
		/*[out]*/ BOOL* pfIsDebugOnly;
		HRESULT retValue;
	};

	STDMETHOD(get_IsDebugOnly)(
		/*[out]*/ BOOL* pfIsDebugOnly)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsDebugOnly)

		VSL_SET_VALIDVALUE(pfIsDebugOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsReleaseOnlyValidValues
	{
		/*[out]*/ BOOL* pfIsReleaseOnly;
		HRESULT retValue;
	};

	STDMETHOD(get_IsReleaseOnly)(
		/*[out]*/ BOOL* pfIsReleaseOnly)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsReleaseOnly)

		VSL_SET_VALIDVALUE(pfIsReleaseOnly);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
