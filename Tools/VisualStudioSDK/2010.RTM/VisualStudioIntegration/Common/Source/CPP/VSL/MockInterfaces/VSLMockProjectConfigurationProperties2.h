/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef PROJECTCONFIGURATIONPROPERTIES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define PROJECTCONFIGURATIONPROPERTIES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ProjectConfigurationProperties2NotImpl :
	public ProjectConfigurationProperties2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ProjectConfigurationProperties2NotImpl)

public:

	typedef ProjectConfigurationProperties2 Interface;

	STDMETHOD(get_NoWarn)(
		/*[out,retval]*/ BSTR* /*pbstrWarnings*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_NoWarn)(
		/*[in]*/ BSTR /*bstrWarnings*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_NoStdLib)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbNoStdLib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_NoStdLib)(
		/*[in]*/ VARIANT_BOOL /*bNoStdLib*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get___id)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DebugSymbols)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbGenerate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DebugSymbols)(
		/*[in]*/ VARIANT_BOOL /*bGenerate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefineDebug)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbDefineDebug*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DefineDebug)(
		/*[in]*/ VARIANT_BOOL /*bDefineDebug*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefineTrace)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbDefineTrace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DefineTrace)(
		/*[in]*/ VARIANT_BOOL /*bDefineTrace*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_OutputPath)(
		/*[out,retval]*/ BSTR* /*pbstrOutputPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_OutputPath)(
		/*[in]*/ BSTR /*bstrOutputPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IntermediatePath)(
		/*[out,retval]*/ BSTR* /*pbstrIntermediatePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_IntermediatePath)(
		/*[in]*/ BSTR /*bstrIntermediatePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DefineConstants)(
		/*[out,retval]*/ BSTR* /*pbstrDefineConstants*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DefineConstants)(
		/*[in]*/ BSTR /*bstrDefineConstants*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RemoveIntegerChecks)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbRemoveIntegerChecks*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_RemoveIntegerChecks)(
		/*[in]*/ VARIANT_BOOL /*bRemoveIntegerChecks*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_BaseAddress)(
		/*[out,retval]*/ DWORD* /*pdwBaseAddress*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_BaseAddress)(
		/*[in]*/ DWORD /*dwBaseAddress*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_AllowUnsafeBlocks)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbUnsafe*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_AllowUnsafeBlocks)(
		/*[in]*/ VARIANT_BOOL /*bUnsafe*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_CheckForOverflowUnderflow)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbCheckForOverflowUnderflow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_CheckForOverflowUnderflow)(
		/*[in]*/ VARIANT_BOOL /*bCheckForOverflowUnderflow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DocumentationFile)(
		/*[out,retval]*/ BSTR* /*pbstrDocumentationFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_DocumentationFile)(
		/*[in]*/ BSTR /*bstrDocumentationFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Optimize)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbOptimize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_Optimize)(
		/*[in]*/ VARIANT_BOOL /*bCheckForOverflowUnderflow*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IncrementalBuild)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbIncrementalBuild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_IncrementalBuild)(
		/*[in]*/ VARIANT_BOOL /*bIncrementalBuild*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartProgram)(
		/*[out,retval]*/ BSTR* /*pbstrStartProgram*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartProgram)(
		/*[in]*/ BSTR /*bstrStartProgram*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartWorkingDirectory)(
		/*[out,retval]*/ BSTR* /*pbstrStartWorkingDirectory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartWorkingDirectory)(
		/*[in]*/ BSTR /*bstrStartWorkingDirectory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartURL)(
		/*[out,retval]*/ BSTR* /*pbstrStartURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartURL)(
		/*[in]*/ BSTR /*bstrStartURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartPage)(
		/*[out,retval]*/ BSTR* /*pbstrStartPage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartPage)(
		/*[in]*/ BSTR /*bstrStartPage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartArguments)(
		/*[out,retval]*/ BSTR* /*pbstrStartArguments*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartArguments)(
		/*[in]*/ BSTR /*bstrStartArguments*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartWithIE)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbStartWithIE*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartWithIE)(
		/*[in]*/ VARIANT_BOOL /*bStartWithIE*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_EnableASPDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbEnableASPDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_EnableASPDebugging)(
		/*[in]*/ VARIANT_BOOL /*bEnableASPDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_EnableASPXDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbEnableASPXDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_EnableASPXDebugging)(
		/*[in]*/ VARIANT_BOOL /*bEnableASPXDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_EnableUnmanagedDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbEnableUnmanagedDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_EnableUnmanagedDebugging)(
		/*[in]*/ VARIANT_BOOL /*bEnableUnmanagedDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_StartAction)(
		/*[out,retval]*/ prjStartAction* /*pdebugStartMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_StartAction)(
		/*[in]*/ prjStartAction /*debugStartMode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Extender)(
		/*[in]*/ BSTR /*ExtenderName*/,
		/*[out,retval]*/ IDispatch** /*Extender*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderNames)(
		/*[out,retval]*/ VARIANT* /*ExtenderNames*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ExtenderCATID)(
		/*[out,retval]*/ BSTR* /*pRetval*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_WarningLevel)(
		/*[out,retval]*/ prjWarningLevel* /*pWarningLeve*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_WarningLevel)(
		/*[in]*/ prjWarningLevel /*warningLevel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_TreatWarningsAsErrors)(
		/*[out,retval]*/ VARIANT_BOOL* /*pWarningAsError*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_TreatWarningsAsErrors)(
		/*[in]*/ VARIANT_BOOL /*warningAsError*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_EnableSQLServerDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbEnableSQLServerDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_EnableSQLServerDebugging)(
		/*[in]*/ VARIANT_BOOL /*bEnableSQLServerDebugging*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_FileAlignment)(
		/*[out,retval]*/ DWORD* /*pdwFileAlignment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_FileAlignment)(
		/*[in]*/ DWORD /*dwFileAlignment*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RegisterForComInterop)(
		/*[out,retval]*/ VARIANT_BOOL* /*pVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_RegisterForComInterop)(
		/*[in]*/ VARIANT_BOOL /*val*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ConfigurationOverrideFile)(
		/*[out,retval]*/ BSTR* /*pbstrConfigFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_ConfigurationOverrideFile)(
		/*[in]*/ BSTR /*bstrConfigFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RemoteDebugEnabled)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbEnableRemoteLaunch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_RemoteDebugEnabled)(
		/*[in]*/ VARIANT_BOOL /*bEnableRemoteLaunch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_RemoteDebugMachine)(
		/*[out,retval]*/ BSTR* /*pbstrRemoteLaunchMach*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(put_RemoteDebugMachine)(
		/*[in]*/ BSTR /*bstrRemoteLaunchMach*/)VSL_STDMETHOD_NOTIMPL

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

class ProjectConfigurationProperties2MockImpl :
	public ProjectConfigurationProperties2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ProjectConfigurationProperties2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ProjectConfigurationProperties2MockImpl)

	typedef ProjectConfigurationProperties2 Interface;
	struct get_NoWarnValidValues
	{
		/*[out,retval]*/ BSTR* pbstrWarnings;
		HRESULT retValue;
	};

	STDMETHOD(get_NoWarn)(
		/*[out,retval]*/ BSTR* pbstrWarnings)
	{
		VSL_DEFINE_MOCK_METHOD(get_NoWarn)

		VSL_SET_VALIDVALUE_BSTR(pbstrWarnings);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_NoWarnValidValues
	{
		/*[in]*/ BSTR bstrWarnings;
		HRESULT retValue;
	};

	STDMETHOD(put_NoWarn)(
		/*[in]*/ BSTR bstrWarnings)
	{
		VSL_DEFINE_MOCK_METHOD(put_NoWarn)

		VSL_CHECK_VALIDVALUE_BSTR(bstrWarnings);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_NoStdLibValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbNoStdLib;
		HRESULT retValue;
	};

	STDMETHOD(get_NoStdLib)(
		/*[out,retval]*/ VARIANT_BOOL* pbNoStdLib)
	{
		VSL_DEFINE_MOCK_METHOD(get_NoStdLib)

		VSL_SET_VALIDVALUE(pbNoStdLib);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_NoStdLibValidValues
	{
		/*[in]*/ VARIANT_BOOL bNoStdLib;
		HRESULT retValue;
	};

	STDMETHOD(put_NoStdLib)(
		/*[in]*/ VARIANT_BOOL bNoStdLib)
	{
		VSL_DEFINE_MOCK_METHOD(put_NoStdLib)

		VSL_CHECK_VALIDVALUE(bNoStdLib);

		VSL_RETURN_VALIDVALUES();
	}
	struct get___idValidValues
	{
		/*[out,retval]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get___id)(
		/*[out,retval]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get___id)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DebugSymbolsValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbGenerate;
		HRESULT retValue;
	};

	STDMETHOD(get_DebugSymbols)(
		/*[out,retval]*/ VARIANT_BOOL* pbGenerate)
	{
		VSL_DEFINE_MOCK_METHOD(get_DebugSymbols)

		VSL_SET_VALIDVALUE(pbGenerate);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DebugSymbolsValidValues
	{
		/*[in]*/ VARIANT_BOOL bGenerate;
		HRESULT retValue;
	};

	STDMETHOD(put_DebugSymbols)(
		/*[in]*/ VARIANT_BOOL bGenerate)
	{
		VSL_DEFINE_MOCK_METHOD(put_DebugSymbols)

		VSL_CHECK_VALIDVALUE(bGenerate);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefineDebugValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbDefineDebug;
		HRESULT retValue;
	};

	STDMETHOD(get_DefineDebug)(
		/*[out,retval]*/ VARIANT_BOOL* pbDefineDebug)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefineDebug)

		VSL_SET_VALIDVALUE(pbDefineDebug);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DefineDebugValidValues
	{
		/*[in]*/ VARIANT_BOOL bDefineDebug;
		HRESULT retValue;
	};

	STDMETHOD(put_DefineDebug)(
		/*[in]*/ VARIANT_BOOL bDefineDebug)
	{
		VSL_DEFINE_MOCK_METHOD(put_DefineDebug)

		VSL_CHECK_VALIDVALUE(bDefineDebug);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefineTraceValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbDefineTrace;
		HRESULT retValue;
	};

	STDMETHOD(get_DefineTrace)(
		/*[out,retval]*/ VARIANT_BOOL* pbDefineTrace)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefineTrace)

		VSL_SET_VALIDVALUE(pbDefineTrace);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DefineTraceValidValues
	{
		/*[in]*/ VARIANT_BOOL bDefineTrace;
		HRESULT retValue;
	};

	STDMETHOD(put_DefineTrace)(
		/*[in]*/ VARIANT_BOOL bDefineTrace)
	{
		VSL_DEFINE_MOCK_METHOD(put_DefineTrace)

		VSL_CHECK_VALIDVALUE(bDefineTrace);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OutputPathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrOutputPath;
		HRESULT retValue;
	};

	STDMETHOD(get_OutputPath)(
		/*[out,retval]*/ BSTR* pbstrOutputPath)
	{
		VSL_DEFINE_MOCK_METHOD(get_OutputPath)

		VSL_SET_VALIDVALUE_BSTR(pbstrOutputPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OutputPathValidValues
	{
		/*[in]*/ BSTR bstrOutputPath;
		HRESULT retValue;
	};

	STDMETHOD(put_OutputPath)(
		/*[in]*/ BSTR bstrOutputPath)
	{
		VSL_DEFINE_MOCK_METHOD(put_OutputPath)

		VSL_CHECK_VALIDVALUE_BSTR(bstrOutputPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IntermediatePathValidValues
	{
		/*[out,retval]*/ BSTR* pbstrIntermediatePath;
		HRESULT retValue;
	};

	STDMETHOD(get_IntermediatePath)(
		/*[out,retval]*/ BSTR* pbstrIntermediatePath)
	{
		VSL_DEFINE_MOCK_METHOD(get_IntermediatePath)

		VSL_SET_VALIDVALUE_BSTR(pbstrIntermediatePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_IntermediatePathValidValues
	{
		/*[in]*/ BSTR bstrIntermediatePath;
		HRESULT retValue;
	};

	STDMETHOD(put_IntermediatePath)(
		/*[in]*/ BSTR bstrIntermediatePath)
	{
		VSL_DEFINE_MOCK_METHOD(put_IntermediatePath)

		VSL_CHECK_VALIDVALUE_BSTR(bstrIntermediatePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DefineConstantsValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDefineConstants;
		HRESULT retValue;
	};

	STDMETHOD(get_DefineConstants)(
		/*[out,retval]*/ BSTR* pbstrDefineConstants)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefineConstants)

		VSL_SET_VALIDVALUE_BSTR(pbstrDefineConstants);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DefineConstantsValidValues
	{
		/*[in]*/ BSTR bstrDefineConstants;
		HRESULT retValue;
	};

	STDMETHOD(put_DefineConstants)(
		/*[in]*/ BSTR bstrDefineConstants)
	{
		VSL_DEFINE_MOCK_METHOD(put_DefineConstants)

		VSL_CHECK_VALIDVALUE_BSTR(bstrDefineConstants);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RemoveIntegerChecksValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbRemoveIntegerChecks;
		HRESULT retValue;
	};

	STDMETHOD(get_RemoveIntegerChecks)(
		/*[out,retval]*/ VARIANT_BOOL* pbRemoveIntegerChecks)
	{
		VSL_DEFINE_MOCK_METHOD(get_RemoveIntegerChecks)

		VSL_SET_VALIDVALUE(pbRemoveIntegerChecks);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_RemoveIntegerChecksValidValues
	{
		/*[in]*/ VARIANT_BOOL bRemoveIntegerChecks;
		HRESULT retValue;
	};

	STDMETHOD(put_RemoveIntegerChecks)(
		/*[in]*/ VARIANT_BOOL bRemoveIntegerChecks)
	{
		VSL_DEFINE_MOCK_METHOD(put_RemoveIntegerChecks)

		VSL_CHECK_VALIDVALUE(bRemoveIntegerChecks);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_BaseAddressValidValues
	{
		/*[out,retval]*/ DWORD* pdwBaseAddress;
		HRESULT retValue;
	};

	STDMETHOD(get_BaseAddress)(
		/*[out,retval]*/ DWORD* pdwBaseAddress)
	{
		VSL_DEFINE_MOCK_METHOD(get_BaseAddress)

		VSL_SET_VALIDVALUE(pdwBaseAddress);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_BaseAddressValidValues
	{
		/*[in]*/ DWORD dwBaseAddress;
		HRESULT retValue;
	};

	STDMETHOD(put_BaseAddress)(
		/*[in]*/ DWORD dwBaseAddress)
	{
		VSL_DEFINE_MOCK_METHOD(put_BaseAddress)

		VSL_CHECK_VALIDVALUE(dwBaseAddress);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_AllowUnsafeBlocksValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbUnsafe;
		HRESULT retValue;
	};

	STDMETHOD(get_AllowUnsafeBlocks)(
		/*[out,retval]*/ VARIANT_BOOL* pbUnsafe)
	{
		VSL_DEFINE_MOCK_METHOD(get_AllowUnsafeBlocks)

		VSL_SET_VALIDVALUE(pbUnsafe);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_AllowUnsafeBlocksValidValues
	{
		/*[in]*/ VARIANT_BOOL bUnsafe;
		HRESULT retValue;
	};

	STDMETHOD(put_AllowUnsafeBlocks)(
		/*[in]*/ VARIANT_BOOL bUnsafe)
	{
		VSL_DEFINE_MOCK_METHOD(put_AllowUnsafeBlocks)

		VSL_CHECK_VALIDVALUE(bUnsafe);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CheckForOverflowUnderflowValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbCheckForOverflowUnderflow;
		HRESULT retValue;
	};

	STDMETHOD(get_CheckForOverflowUnderflow)(
		/*[out,retval]*/ VARIANT_BOOL* pbCheckForOverflowUnderflow)
	{
		VSL_DEFINE_MOCK_METHOD(get_CheckForOverflowUnderflow)

		VSL_SET_VALIDVALUE(pbCheckForOverflowUnderflow);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_CheckForOverflowUnderflowValidValues
	{
		/*[in]*/ VARIANT_BOOL bCheckForOverflowUnderflow;
		HRESULT retValue;
	};

	STDMETHOD(put_CheckForOverflowUnderflow)(
		/*[in]*/ VARIANT_BOOL bCheckForOverflowUnderflow)
	{
		VSL_DEFINE_MOCK_METHOD(put_CheckForOverflowUnderflow)

		VSL_CHECK_VALIDVALUE(bCheckForOverflowUnderflow);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DocumentationFileValidValues
	{
		/*[out,retval]*/ BSTR* pbstrDocumentationFile;
		HRESULT retValue;
	};

	STDMETHOD(get_DocumentationFile)(
		/*[out,retval]*/ BSTR* pbstrDocumentationFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_DocumentationFile)

		VSL_SET_VALIDVALUE_BSTR(pbstrDocumentationFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_DocumentationFileValidValues
	{
		/*[in]*/ BSTR bstrDocumentationFile;
		HRESULT retValue;
	};

	STDMETHOD(put_DocumentationFile)(
		/*[in]*/ BSTR bstrDocumentationFile)
	{
		VSL_DEFINE_MOCK_METHOD(put_DocumentationFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrDocumentationFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_OptimizeValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbOptimize;
		HRESULT retValue;
	};

	STDMETHOD(get_Optimize)(
		/*[out,retval]*/ VARIANT_BOOL* pbOptimize)
	{
		VSL_DEFINE_MOCK_METHOD(get_Optimize)

		VSL_SET_VALIDVALUE(pbOptimize);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_OptimizeValidValues
	{
		/*[in]*/ VARIANT_BOOL bCheckForOverflowUnderflow;
		HRESULT retValue;
	};

	STDMETHOD(put_Optimize)(
		/*[in]*/ VARIANT_BOOL bCheckForOverflowUnderflow)
	{
		VSL_DEFINE_MOCK_METHOD(put_Optimize)

		VSL_CHECK_VALIDVALUE(bCheckForOverflowUnderflow);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IncrementalBuildValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbIncrementalBuild;
		HRESULT retValue;
	};

	STDMETHOD(get_IncrementalBuild)(
		/*[out,retval]*/ VARIANT_BOOL* pbIncrementalBuild)
	{
		VSL_DEFINE_MOCK_METHOD(get_IncrementalBuild)

		VSL_SET_VALIDVALUE(pbIncrementalBuild);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_IncrementalBuildValidValues
	{
		/*[in]*/ VARIANT_BOOL bIncrementalBuild;
		HRESULT retValue;
	};

	STDMETHOD(put_IncrementalBuild)(
		/*[in]*/ VARIANT_BOOL bIncrementalBuild)
	{
		VSL_DEFINE_MOCK_METHOD(put_IncrementalBuild)

		VSL_CHECK_VALIDVALUE(bIncrementalBuild);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartProgramValidValues
	{
		/*[out,retval]*/ BSTR* pbstrStartProgram;
		HRESULT retValue;
	};

	STDMETHOD(get_StartProgram)(
		/*[out,retval]*/ BSTR* pbstrStartProgram)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartProgram)

		VSL_SET_VALIDVALUE_BSTR(pbstrStartProgram);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartProgramValidValues
	{
		/*[in]*/ BSTR bstrStartProgram;
		HRESULT retValue;
	};

	STDMETHOD(put_StartProgram)(
		/*[in]*/ BSTR bstrStartProgram)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartProgram)

		VSL_CHECK_VALIDVALUE_BSTR(bstrStartProgram);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartWorkingDirectoryValidValues
	{
		/*[out,retval]*/ BSTR* pbstrStartWorkingDirectory;
		HRESULT retValue;
	};

	STDMETHOD(get_StartWorkingDirectory)(
		/*[out,retval]*/ BSTR* pbstrStartWorkingDirectory)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartWorkingDirectory)

		VSL_SET_VALIDVALUE_BSTR(pbstrStartWorkingDirectory);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartWorkingDirectoryValidValues
	{
		/*[in]*/ BSTR bstrStartWorkingDirectory;
		HRESULT retValue;
	};

	STDMETHOD(put_StartWorkingDirectory)(
		/*[in]*/ BSTR bstrStartWorkingDirectory)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartWorkingDirectory)

		VSL_CHECK_VALIDVALUE_BSTR(bstrStartWorkingDirectory);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartURLValidValues
	{
		/*[out,retval]*/ BSTR* pbstrStartURL;
		HRESULT retValue;
	};

	STDMETHOD(get_StartURL)(
		/*[out,retval]*/ BSTR* pbstrStartURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrStartURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartURLValidValues
	{
		/*[in]*/ BSTR bstrStartURL;
		HRESULT retValue;
	};

	STDMETHOD(put_StartURL)(
		/*[in]*/ BSTR bstrStartURL)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartURL)

		VSL_CHECK_VALIDVALUE_BSTR(bstrStartURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartPageValidValues
	{
		/*[out,retval]*/ BSTR* pbstrStartPage;
		HRESULT retValue;
	};

	STDMETHOD(get_StartPage)(
		/*[out,retval]*/ BSTR* pbstrStartPage)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartPage)

		VSL_SET_VALIDVALUE_BSTR(pbstrStartPage);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartPageValidValues
	{
		/*[in]*/ BSTR bstrStartPage;
		HRESULT retValue;
	};

	STDMETHOD(put_StartPage)(
		/*[in]*/ BSTR bstrStartPage)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartPage)

		VSL_CHECK_VALIDVALUE_BSTR(bstrStartPage);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartArgumentsValidValues
	{
		/*[out,retval]*/ BSTR* pbstrStartArguments;
		HRESULT retValue;
	};

	STDMETHOD(get_StartArguments)(
		/*[out,retval]*/ BSTR* pbstrStartArguments)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartArguments)

		VSL_SET_VALIDVALUE_BSTR(pbstrStartArguments);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartArgumentsValidValues
	{
		/*[in]*/ BSTR bstrStartArguments;
		HRESULT retValue;
	};

	STDMETHOD(put_StartArguments)(
		/*[in]*/ BSTR bstrStartArguments)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartArguments)

		VSL_CHECK_VALIDVALUE_BSTR(bstrStartArguments);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartWithIEValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbStartWithIE;
		HRESULT retValue;
	};

	STDMETHOD(get_StartWithIE)(
		/*[out,retval]*/ VARIANT_BOOL* pbStartWithIE)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartWithIE)

		VSL_SET_VALIDVALUE(pbStartWithIE);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartWithIEValidValues
	{
		/*[in]*/ VARIANT_BOOL bStartWithIE;
		HRESULT retValue;
	};

	STDMETHOD(put_StartWithIE)(
		/*[in]*/ VARIANT_BOOL bStartWithIE)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartWithIE)

		VSL_CHECK_VALIDVALUE(bStartWithIE);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_EnableASPDebuggingValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbEnableASPDebugging;
		HRESULT retValue;
	};

	STDMETHOD(get_EnableASPDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* pbEnableASPDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(get_EnableASPDebugging)

		VSL_SET_VALIDVALUE(pbEnableASPDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_EnableASPDebuggingValidValues
	{
		/*[in]*/ VARIANT_BOOL bEnableASPDebugging;
		HRESULT retValue;
	};

	STDMETHOD(put_EnableASPDebugging)(
		/*[in]*/ VARIANT_BOOL bEnableASPDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(put_EnableASPDebugging)

		VSL_CHECK_VALIDVALUE(bEnableASPDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_EnableASPXDebuggingValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbEnableASPXDebugging;
		HRESULT retValue;
	};

	STDMETHOD(get_EnableASPXDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* pbEnableASPXDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(get_EnableASPXDebugging)

		VSL_SET_VALIDVALUE(pbEnableASPXDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_EnableASPXDebuggingValidValues
	{
		/*[in]*/ VARIANT_BOOL bEnableASPXDebugging;
		HRESULT retValue;
	};

	STDMETHOD(put_EnableASPXDebugging)(
		/*[in]*/ VARIANT_BOOL bEnableASPXDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(put_EnableASPXDebugging)

		VSL_CHECK_VALIDVALUE(bEnableASPXDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_EnableUnmanagedDebuggingValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbEnableUnmanagedDebugging;
		HRESULT retValue;
	};

	STDMETHOD(get_EnableUnmanagedDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* pbEnableUnmanagedDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(get_EnableUnmanagedDebugging)

		VSL_SET_VALIDVALUE(pbEnableUnmanagedDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_EnableUnmanagedDebuggingValidValues
	{
		/*[in]*/ VARIANT_BOOL bEnableUnmanagedDebugging;
		HRESULT retValue;
	};

	STDMETHOD(put_EnableUnmanagedDebugging)(
		/*[in]*/ VARIANT_BOOL bEnableUnmanagedDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(put_EnableUnmanagedDebugging)

		VSL_CHECK_VALIDVALUE(bEnableUnmanagedDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_StartActionValidValues
	{
		/*[out,retval]*/ prjStartAction* pdebugStartMode;
		HRESULT retValue;
	};

	STDMETHOD(get_StartAction)(
		/*[out,retval]*/ prjStartAction* pdebugStartMode)
	{
		VSL_DEFINE_MOCK_METHOD(get_StartAction)

		VSL_SET_VALIDVALUE(pdebugStartMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_StartActionValidValues
	{
		/*[in]*/ prjStartAction debugStartMode;
		HRESULT retValue;
	};

	STDMETHOD(put_StartAction)(
		/*[in]*/ prjStartAction debugStartMode)
	{
		VSL_DEFINE_MOCK_METHOD(put_StartAction)

		VSL_CHECK_VALIDVALUE(debugStartMode);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExtenderValidValues
	{
		/*[in]*/ BSTR ExtenderName;
		/*[out,retval]*/ IDispatch** Extender;
		HRESULT retValue;
	};

	STDMETHOD(get_Extender)(
		/*[in]*/ BSTR ExtenderName,
		/*[out,retval]*/ IDispatch** Extender)
	{
		VSL_DEFINE_MOCK_METHOD(get_Extender)

		VSL_CHECK_VALIDVALUE_BSTR(ExtenderName);

		VSL_SET_VALIDVALUE_INTERFACE(Extender);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExtenderNamesValidValues
	{
		/*[out,retval]*/ VARIANT* ExtenderNames;
		HRESULT retValue;
	};

	STDMETHOD(get_ExtenderNames)(
		/*[out,retval]*/ VARIANT* ExtenderNames)
	{
		VSL_DEFINE_MOCK_METHOD(get_ExtenderNames)

		VSL_SET_VALIDVALUE_VARIANT(ExtenderNames);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ExtenderCATIDValidValues
	{
		/*[out,retval]*/ BSTR* pRetval;
		HRESULT retValue;
	};

	STDMETHOD(get_ExtenderCATID)(
		/*[out,retval]*/ BSTR* pRetval)
	{
		VSL_DEFINE_MOCK_METHOD(get_ExtenderCATID)

		VSL_SET_VALIDVALUE_BSTR(pRetval);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_WarningLevelValidValues
	{
		/*[out,retval]*/ prjWarningLevel* pWarningLeve;
		HRESULT retValue;
	};

	STDMETHOD(get_WarningLevel)(
		/*[out,retval]*/ prjWarningLevel* pWarningLeve)
	{
		VSL_DEFINE_MOCK_METHOD(get_WarningLevel)

		VSL_SET_VALIDVALUE(pWarningLeve);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_WarningLevelValidValues
	{
		/*[in]*/ prjWarningLevel warningLevel;
		HRESULT retValue;
	};

	STDMETHOD(put_WarningLevel)(
		/*[in]*/ prjWarningLevel warningLevel)
	{
		VSL_DEFINE_MOCK_METHOD(put_WarningLevel)

		VSL_CHECK_VALIDVALUE(warningLevel);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TreatWarningsAsErrorsValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pWarningAsError;
		HRESULT retValue;
	};

	STDMETHOD(get_TreatWarningsAsErrors)(
		/*[out,retval]*/ VARIANT_BOOL* pWarningAsError)
	{
		VSL_DEFINE_MOCK_METHOD(get_TreatWarningsAsErrors)

		VSL_SET_VALIDVALUE(pWarningAsError);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_TreatWarningsAsErrorsValidValues
	{
		/*[in]*/ VARIANT_BOOL warningAsError;
		HRESULT retValue;
	};

	STDMETHOD(put_TreatWarningsAsErrors)(
		/*[in]*/ VARIANT_BOOL warningAsError)
	{
		VSL_DEFINE_MOCK_METHOD(put_TreatWarningsAsErrors)

		VSL_CHECK_VALIDVALUE(warningAsError);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_EnableSQLServerDebuggingValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbEnableSQLServerDebugging;
		HRESULT retValue;
	};

	STDMETHOD(get_EnableSQLServerDebugging)(
		/*[out,retval]*/ VARIANT_BOOL* pbEnableSQLServerDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(get_EnableSQLServerDebugging)

		VSL_SET_VALIDVALUE(pbEnableSQLServerDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_EnableSQLServerDebuggingValidValues
	{
		/*[in]*/ VARIANT_BOOL bEnableSQLServerDebugging;
		HRESULT retValue;
	};

	STDMETHOD(put_EnableSQLServerDebugging)(
		/*[in]*/ VARIANT_BOOL bEnableSQLServerDebugging)
	{
		VSL_DEFINE_MOCK_METHOD(put_EnableSQLServerDebugging)

		VSL_CHECK_VALIDVALUE(bEnableSQLServerDebugging);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_FileAlignmentValidValues
	{
		/*[out,retval]*/ DWORD* pdwFileAlignment;
		HRESULT retValue;
	};

	STDMETHOD(get_FileAlignment)(
		/*[out,retval]*/ DWORD* pdwFileAlignment)
	{
		VSL_DEFINE_MOCK_METHOD(get_FileAlignment)

		VSL_SET_VALIDVALUE(pdwFileAlignment);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_FileAlignmentValidValues
	{
		/*[in]*/ DWORD dwFileAlignment;
		HRESULT retValue;
	};

	STDMETHOD(put_FileAlignment)(
		/*[in]*/ DWORD dwFileAlignment)
	{
		VSL_DEFINE_MOCK_METHOD(put_FileAlignment)

		VSL_CHECK_VALIDVALUE(dwFileAlignment);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RegisterForComInteropValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pVal;
		HRESULT retValue;
	};

	STDMETHOD(get_RegisterForComInterop)(
		/*[out,retval]*/ VARIANT_BOOL* pVal)
	{
		VSL_DEFINE_MOCK_METHOD(get_RegisterForComInterop)

		VSL_SET_VALIDVALUE(pVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_RegisterForComInteropValidValues
	{
		/*[in]*/ VARIANT_BOOL val;
		HRESULT retValue;
	};

	STDMETHOD(put_RegisterForComInterop)(
		/*[in]*/ VARIANT_BOOL val)
	{
		VSL_DEFINE_MOCK_METHOD(put_RegisterForComInterop)

		VSL_CHECK_VALIDVALUE(val);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ConfigurationOverrideFileValidValues
	{
		/*[out,retval]*/ BSTR* pbstrConfigFile;
		HRESULT retValue;
	};

	STDMETHOD(get_ConfigurationOverrideFile)(
		/*[out,retval]*/ BSTR* pbstrConfigFile)
	{
		VSL_DEFINE_MOCK_METHOD(get_ConfigurationOverrideFile)

		VSL_SET_VALIDVALUE_BSTR(pbstrConfigFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_ConfigurationOverrideFileValidValues
	{
		/*[in]*/ BSTR bstrConfigFile;
		HRESULT retValue;
	};

	STDMETHOD(put_ConfigurationOverrideFile)(
		/*[in]*/ BSTR bstrConfigFile)
	{
		VSL_DEFINE_MOCK_METHOD(put_ConfigurationOverrideFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrConfigFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RemoteDebugEnabledValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbEnableRemoteLaunch;
		HRESULT retValue;
	};

	STDMETHOD(get_RemoteDebugEnabled)(
		/*[out,retval]*/ VARIANT_BOOL* pbEnableRemoteLaunch)
	{
		VSL_DEFINE_MOCK_METHOD(get_RemoteDebugEnabled)

		VSL_SET_VALIDVALUE(pbEnableRemoteLaunch);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_RemoteDebugEnabledValidValues
	{
		/*[in]*/ VARIANT_BOOL bEnableRemoteLaunch;
		HRESULT retValue;
	};

	STDMETHOD(put_RemoteDebugEnabled)(
		/*[in]*/ VARIANT_BOOL bEnableRemoteLaunch)
	{
		VSL_DEFINE_MOCK_METHOD(put_RemoteDebugEnabled)

		VSL_CHECK_VALIDVALUE(bEnableRemoteLaunch);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_RemoteDebugMachineValidValues
	{
		/*[out,retval]*/ BSTR* pbstrRemoteLaunchMach;
		HRESULT retValue;
	};

	STDMETHOD(get_RemoteDebugMachine)(
		/*[out,retval]*/ BSTR* pbstrRemoteLaunchMach)
	{
		VSL_DEFINE_MOCK_METHOD(get_RemoteDebugMachine)

		VSL_SET_VALIDVALUE_BSTR(pbstrRemoteLaunchMach);

		VSL_RETURN_VALIDVALUES();
	}
	struct put_RemoteDebugMachineValidValues
	{
		/*[in]*/ BSTR bstrRemoteLaunchMach;
		HRESULT retValue;
	};

	STDMETHOD(put_RemoteDebugMachine)(
		/*[in]*/ BSTR bstrRemoteLaunchMach)
	{
		VSL_DEFINE_MOCK_METHOD(put_RemoteDebugMachine)

		VSL_CHECK_VALIDVALUE_BSTR(bstrRemoteLaunchMach);

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

#endif // PROJECTCONFIGURATIONPROPERTIES2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
