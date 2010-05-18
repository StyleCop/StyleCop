/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTIONBUILDMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTIONBUILDMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolutionBuildManager2NotImpl :
	public IVsSolutionBuildManager2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionBuildManager2NotImpl)

public:

	typedef IVsSolutionBuildManager2 Interface;

	STDMETHOD(StartUpdateProjectConfigurations)(
		/*[in]*/ UINT /*cProjs*/,
		/*[in,size_is(cProjs)]*/ IVsHierarchy*[] /*rgpHierProjs*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ BOOL /*fSuppressUI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CalculateProjectDependencies)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryProjectDependency)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ IVsHierarchy* /*pHierDependentOn*/,
		/*[out]*/ BOOL* /*pfIsDependentOn*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SaveDocumentsBeforeBuild)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ VSCOOKIE /*docCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartUpdateSpecificProjectConfigurations)(
		/*[in]*/ UINT /*cProjs*/,
		/*[in,size_is(cProjs)]*/ IVsHierarchy*[] /*rgpHier*/,
		/*[in,size_is(cProjs)]*/ IVsCfg*[] /*rgpCfg*/,
		/*[in,size_is(cProjs)]*/ DWORD[] /*rgdwCleanFlags*/,
		/*[in,size_is(cProjs)]*/ DWORD[] /*rgdwBuildFlags*/,
		/*[in,size_is(cProjs)]*/ DWORD[] /*rgdwDeployFlags*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ BOOL /*fSuppressUI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS /*grfLaunch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartSimpleUpdateSolutionConfiguration)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ DWORD /*dwDefQueryResults*/,
		/*[in]*/ BOOL /*fSuppressUI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseUpdateSolutionEvents)(
		/*[in]*/ IVsUpdateSolutionEvents* /*pIVsUpdateSolutionEvents*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseUpdateSolutionEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateSolutionConfigurationIsActive)(
		/*[out]*/ BOOL* /*pfIsActive*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanCancelUpdateSolutionConfiguration)(
		/*[out]*/ BOOL* /*pfCanCancel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CancelUpdateSolutionConfiguration)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryDebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS /*grfLaunch*/,
		/*[out]*/ BOOL* /*pfCanLaunch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryBuildManagerBusy)(
		/*[out]*/ BOOL* /*pfBuildManagerBusy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindActiveProjectCfg)(
		/*[in,unique]*/ IVsHierarchy* /*pvReserved1*/,
		/*[in,unique]*/ LPCOLESTR /*pvReserved2*/,
		/*[in,unique]*/ IVsHierarchy* /*pIVsHierarchy_RequestedProject*/,
		/*[out,optional]*/ IVsProjectCfg** /*ppIVsProjectCfg_Active*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsDebug)(
		/*[out]*/ BOOL* /*pfIsDebug*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_IsDebug)(
		/*[in]*/ BOOL /*fIsDebug*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CodePage)(
		/*[out]*/ UINT* /*puiCodePage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_CodePage)(
		/*[in]*/ UINT /*uiCodePage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartSimpleUpdateProjectConfiguration)(
		/*[in]*/ IVsHierarchy* /*pIVsHierarchyToBuild*/,
		/*[in]*/ IVsHierarchy* /*pIVsHierarchyDependent*/,
		/*[in]*/ LPCOLESTR /*pszDependentConfigurationCanonicalName*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ DWORD /*dwDefQueryResults*/,
		/*[in]*/ BOOL /*fSuppressUI*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartupProject)(
		/*[out]*/ IVsHierarchy** /*ppHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(set_StartupProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectDependencies)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ IVsHierarchy*[] /*rgpHier*/,
		/*[out,optional]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolutionBuildManager2MockImpl :
	public IVsSolutionBuildManager2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionBuildManager2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolutionBuildManager2MockImpl)

	typedef IVsSolutionBuildManager2 Interface;
	struct StartUpdateProjectConfigurationsValidValues
	{
		/*[in]*/ UINT cProjs;
		/*[in,size_is(cProjs)]*/ IVsHierarchy** rgpHierProjs;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ BOOL fSuppressUI;
		HRESULT retValue;
	};

	STDMETHOD(StartUpdateProjectConfigurations)(
		/*[in]*/ UINT cProjs,
		/*[in,size_is(cProjs)]*/ IVsHierarchy* rgpHierProjs[],
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ BOOL fSuppressUI)
	{
		VSL_DEFINE_MOCK_METHOD(StartUpdateProjectConfigurations)

		VSL_CHECK_VALIDVALUE(cProjs);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpHierProjs, cProjs, validValues.cProjs);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(fSuppressUI);

		VSL_RETURN_VALIDVALUES();
	}
	struct CalculateProjectDependenciesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CalculateProjectDependencies)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CalculateProjectDependencies)

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryProjectDependencyValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ IVsHierarchy* pHierDependentOn;
		/*[out]*/ BOOL* pfIsDependentOn;
		HRESULT retValue;
	};

	STDMETHOD(QueryProjectDependency)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ IVsHierarchy* pHierDependentOn,
		/*[out]*/ BOOL* pfIsDependentOn)
	{
		VSL_DEFINE_MOCK_METHOD(QueryProjectDependency)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierDependentOn);

		VSL_SET_VALIDVALUE(pfIsDependentOn);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveDocumentsBeforeBuildValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ VSCOOKIE docCookie;
		HRESULT retValue;
	};

	STDMETHOD(SaveDocumentsBeforeBuild)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ VSCOOKIE docCookie)
	{
		VSL_DEFINE_MOCK_METHOD(SaveDocumentsBeforeBuild)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE(docCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartUpdateSpecificProjectConfigurationsValidValues
	{
		/*[in]*/ UINT cProjs;
		/*[in,size_is(cProjs)]*/ IVsHierarchy** rgpHier;
		/*[in,size_is(cProjs)]*/ IVsCfg** rgpCfg;
		/*[in,size_is(cProjs)]*/ DWORD* rgdwCleanFlags;
		/*[in,size_is(cProjs)]*/ DWORD* rgdwBuildFlags;
		/*[in,size_is(cProjs)]*/ DWORD* rgdwDeployFlags;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ BOOL fSuppressUI;
		HRESULT retValue;
	};

	STDMETHOD(StartUpdateSpecificProjectConfigurations)(
		/*[in]*/ UINT cProjs,
		/*[in,size_is(cProjs)]*/ IVsHierarchy* rgpHier[],
		/*[in,size_is(cProjs)]*/ IVsCfg* rgpCfg[],
		/*[in,size_is(cProjs)]*/ DWORD rgdwCleanFlags[],
		/*[in,size_is(cProjs)]*/ DWORD rgdwBuildFlags[],
		/*[in,size_is(cProjs)]*/ DWORD rgdwDeployFlags[],
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ BOOL fSuppressUI)
	{
		VSL_DEFINE_MOCK_METHOD(StartUpdateSpecificProjectConfigurations)

		VSL_CHECK_VALIDVALUE(cProjs);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpHier, cProjs, validValues.cProjs);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpCfg, cProjs, validValues.cProjs);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgdwCleanFlags, cProjs*sizeof(rgdwCleanFlags[0]), validValues.cProjs*sizeof(validValues.rgdwCleanFlags[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgdwBuildFlags, cProjs*sizeof(rgdwBuildFlags[0]), validValues.cProjs*sizeof(validValues.rgdwBuildFlags[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(rgdwDeployFlags, cProjs*sizeof(rgdwDeployFlags[0]), validValues.cProjs*sizeof(validValues.rgdwDeployFlags[0]));

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(fSuppressUI);

		VSL_RETURN_VALIDVALUES();
	}
	struct DebugLaunchValidValues
	{
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch;
		HRESULT retValue;
	};

	STDMETHOD(DebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch)
	{
		VSL_DEFINE_MOCK_METHOD(DebugLaunch)

		VSL_CHECK_VALIDVALUE(grfLaunch);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartSimpleUpdateSolutionConfigurationValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ DWORD dwDefQueryResults;
		/*[in]*/ BOOL fSuppressUI;
		HRESULT retValue;
	};

	STDMETHOD(StartSimpleUpdateSolutionConfiguration)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ DWORD dwDefQueryResults,
		/*[in]*/ BOOL fSuppressUI)
	{
		VSL_DEFINE_MOCK_METHOD(StartSimpleUpdateSolutionConfiguration)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(dwDefQueryResults);

		VSL_CHECK_VALIDVALUE(fSuppressUI);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseUpdateSolutionEventsValidValues
	{
		/*[in]*/ IVsUpdateSolutionEvents* pIVsUpdateSolutionEvents;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseUpdateSolutionEvents)(
		/*[in]*/ IVsUpdateSolutionEvents* pIVsUpdateSolutionEvents,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseUpdateSolutionEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsUpdateSolutionEvents);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseUpdateSolutionEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseUpdateSolutionEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseUpdateSolutionEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateSolutionConfigurationIsActiveValidValues
	{
		/*[out]*/ BOOL* pfIsActive;
		HRESULT retValue;
	};

	STDMETHOD(UpdateSolutionConfigurationIsActive)(
		/*[out]*/ BOOL* pfIsActive)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateSolutionConfigurationIsActive)

		VSL_SET_VALIDVALUE(pfIsActive);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanCancelUpdateSolutionConfigurationValidValues
	{
		/*[out]*/ BOOL* pfCanCancel;
		HRESULT retValue;
	};

	STDMETHOD(CanCancelUpdateSolutionConfiguration)(
		/*[out]*/ BOOL* pfCanCancel)
	{
		VSL_DEFINE_MOCK_METHOD(CanCancelUpdateSolutionConfiguration)

		VSL_SET_VALIDVALUE(pfCanCancel);

		VSL_RETURN_VALIDVALUES();
	}
	struct CancelUpdateSolutionConfigurationValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CancelUpdateSolutionConfiguration)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CancelUpdateSolutionConfiguration)

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryDebugLaunchValidValues
	{
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch;
		/*[out]*/ BOOL* pfCanLaunch;
		HRESULT retValue;
	};

	STDMETHOD(QueryDebugLaunch)(
		/*[in]*/ VSDBGLAUNCHFLAGS grfLaunch,
		/*[out]*/ BOOL* pfCanLaunch)
	{
		VSL_DEFINE_MOCK_METHOD(QueryDebugLaunch)

		VSL_CHECK_VALIDVALUE(grfLaunch);

		VSL_SET_VALIDVALUE(pfCanLaunch);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryBuildManagerBusyValidValues
	{
		/*[out]*/ BOOL* pfBuildManagerBusy;
		HRESULT retValue;
	};

	STDMETHOD(QueryBuildManagerBusy)(
		/*[out]*/ BOOL* pfBuildManagerBusy)
	{
		VSL_DEFINE_MOCK_METHOD(QueryBuildManagerBusy)

		VSL_SET_VALIDVALUE(pfBuildManagerBusy);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindActiveProjectCfgValidValues
	{
		/*[in,unique]*/ IVsHierarchy* pvReserved1;
		/*[in,unique]*/ LPCOLESTR pvReserved2;
		/*[in,unique]*/ IVsHierarchy* pIVsHierarchy_RequestedProject;
		/*[out,optional]*/ IVsProjectCfg** ppIVsProjectCfg_Active;
		HRESULT retValue;
	};

	STDMETHOD(FindActiveProjectCfg)(
		/*[in,unique]*/ IVsHierarchy* pvReserved1,
		/*[in,unique]*/ LPCOLESTR pvReserved2,
		/*[in,unique]*/ IVsHierarchy* pIVsHierarchy_RequestedProject,
		/*[out,optional]*/ IVsProjectCfg** ppIVsProjectCfg_Active)
	{
		VSL_DEFINE_MOCK_METHOD(FindActiveProjectCfg)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pvReserved1);

		VSL_CHECK_VALIDVALUE_STRINGW(pvReserved2);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsHierarchy_RequestedProject);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsProjectCfg_Active);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsDebugValidValues
	{
		/*[out]*/ BOOL* pfIsDebug;
		HRESULT retValue;
	};

	STDMETHOD(get_IsDebug)(
		/*[out]*/ BOOL* pfIsDebug)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsDebug)

		VSL_SET_VALIDVALUE(pfIsDebug);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_IsDebugValidValues
	{
		/*[in]*/ BOOL fIsDebug;
		HRESULT retValue;
	};

	STDMETHOD(put_IsDebug)(
		/*[in]*/ BOOL fIsDebug)
	{
		VSL_DEFINE_MOCK_METHOD(put_IsDebug)

		VSL_CHECK_VALIDVALUE(fIsDebug);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CodePageValidValues
	{
		/*[out]*/ UINT* puiCodePage;
		HRESULT retValue;
	};

	STDMETHOD(get_CodePage)(
		/*[out]*/ UINT* puiCodePage)
	{
		VSL_DEFINE_MOCK_METHOD(get_CodePage)

		VSL_SET_VALIDVALUE(puiCodePage);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CodePageValidValues
	{
		/*[in]*/ UINT uiCodePage;
		HRESULT retValue;
	};

	STDMETHOD(put_CodePage)(
		/*[in]*/ UINT uiCodePage)
	{
		VSL_DEFINE_MOCK_METHOD(put_CodePage)

		VSL_CHECK_VALIDVALUE(uiCodePage);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartSimpleUpdateProjectConfigurationValidValues
	{
		/*[in]*/ IVsHierarchy* pIVsHierarchyToBuild;
		/*[in]*/ IVsHierarchy* pIVsHierarchyDependent;
		/*[in]*/ LPCOLESTR pszDependentConfigurationCanonicalName;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ DWORD dwDefQueryResults;
		/*[in]*/ BOOL fSuppressUI;
		HRESULT retValue;
	};

	STDMETHOD(StartSimpleUpdateProjectConfiguration)(
		/*[in]*/ IVsHierarchy* pIVsHierarchyToBuild,
		/*[in]*/ IVsHierarchy* pIVsHierarchyDependent,
		/*[in]*/ LPCOLESTR pszDependentConfigurationCanonicalName,
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ DWORD dwDefQueryResults,
		/*[in]*/ BOOL fSuppressUI)
	{
		VSL_DEFINE_MOCK_METHOD(StartSimpleUpdateProjectConfiguration)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsHierarchyToBuild);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsHierarchyDependent);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDependentConfigurationCanonicalName);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(dwDefQueryResults);

		VSL_CHECK_VALIDVALUE(fSuppressUI);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartupProjectValidValues
	{
		/*[out]*/ IVsHierarchy** ppHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(get_StartupProject)(
		/*[out]*/ IVsHierarchy** ppHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartupProject)

		VSL_SET_VALIDVALUE_INTERFACE(ppHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct set_StartupProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(set_StartupProject)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(set_StartupProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectDependenciesValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ IVsHierarchy** rgpHier;
		/*[out,optional]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectDependencies)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ IVsHierarchy* rgpHier[],
		/*[out,optional]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectDependencies)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_INTERFACEARRAY(rgpHier, celt, validValues.celt);

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTIONBUILDMANAGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
