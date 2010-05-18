/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEBUGGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEBUGGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDebugger2NotImpl :
	public IVsDebugger2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebugger2NotImpl)

public:

	typedef IVsDebugger2 Interface;

	STDMETHOD(LaunchDebugTargets2)(
		/*[in]*/ ULONG /*DebugTargetCount*/,
		/*[in,out,size_is(DebugTargetCount)]*/ VsDebugTargetInfo2* /*pDebugTargets*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ConfirmStopDebugging)(
		/*[in]*/ LPCOLESTR /*pszMessage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumDebugEngines)(
		/*[out]*/ IVsEnumGUID** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEngineName)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsEngineCompatible)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ ULONG /*EngineCount*/,
		/*[in,size_is(EngineCount)]*/ GUID* /*pEngineGUIDs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetConsoleHandlesForProcess)(
		/*[in]*/ DWORD /*dwPid*/,
		/*[out]*/ ULONG64* /*pdwStdInput*/,
		/*[out]*/ ULONG64* /*pdwStdOutput*/,
		/*[out]*/ ULONG64* /*pdwStdError*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowSource)(
		/*[in]*/ IUnknown* /*pUnkDebugDocContext*/,
		/*[in]*/ BOOL /*fMakeActive*/,
		/*[in]*/ BOOL /*fAlwaysMoveCaret*/,
		/*[in]*/ BOOL /*fPromptToFindSource*/,
		/*[in]*/ BOOL /*fIgnoreIfNotFound*/,
		/*[out]*/ IVsTextView** /*ppTextView*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateDataTip)(
		/*[in]*/ BSTR /*bstrExpression*/,
		/*[in]*/ VSEDT_STYLE /*dwStyle*/,
		/*[out]*/ IVsEnhancedDataTip** /*ppDataTip*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSymbolPath)(
		/*[out]*/ BSTR* /*pbstrSymbolPath*/,
		/*[out]*/ BSTR* /*pbstrSymbolCachePath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetOutputHandleForProcess)(
		/*[in]*/ DWORD /*dwPid*/,
		/*[out]*/ ULONG64* /*pOutputHandle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertBreakpointByName)(
		/*[in]*/ REFGUID /*guidLanguage*/,
		/*[in]*/ LPCOLESTR /*pszCodeLocationText*/,
		/*[in]*/ BOOL /*bUseIntellisense*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToggleUseQuickConsoleOption)(
		/*[in]*/ BOOL /*fOnOff*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUseQuickConsoleOptionSetting)(
		/*[out]*/ BOOL* /*pfValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInternalDebugMode)(
		/*[out]*/ DBGMODE* /*pdbgmode*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDebugger2MockImpl :
	public IVsDebugger2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebugger2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDebugger2MockImpl)

	typedef IVsDebugger2 Interface;
	struct LaunchDebugTargets2ValidValues
	{
		/*[in]*/ ULONG DebugTargetCount;
		/*[in,out,size_is(DebugTargetCount)]*/ VsDebugTargetInfo2* pDebugTargets;
		HRESULT retValue;
	};

	STDMETHOD(LaunchDebugTargets2)(
		/*[in]*/ ULONG DebugTargetCount,
		/*[in,out,size_is(DebugTargetCount)]*/ VsDebugTargetInfo2* pDebugTargets)
	{
		VSL_DEFINE_MOCK_METHOD(LaunchDebugTargets2)

		VSL_CHECK_VALIDVALUE(DebugTargetCount);

		VSL_SET_VALIDVALUE_MEMCPY(pDebugTargets, DebugTargetCount*sizeof(pDebugTargets[0]), validValues.DebugTargetCount*sizeof(validValues.pDebugTargets[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct ConfirmStopDebuggingValidValues
	{
		/*[in]*/ LPCOLESTR pszMessage;
		HRESULT retValue;
	};

	STDMETHOD(ConfirmStopDebugging)(
		/*[in]*/ LPCOLESTR pszMessage)
	{
		VSL_DEFINE_MOCK_METHOD(ConfirmStopDebugging)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMessage);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumDebugEnginesValidValues
	{
		/*[out]*/ IVsEnumGUID** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumDebugEngines)(
		/*[out]*/ IVsEnumGUID** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumDebugEngines)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEngineNameValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetEngineName)(
		/*[in]*/ REFGUID guidEngine,
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetEngineName)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsEngineCompatibleValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ ULONG EngineCount;
		/*[in,size_is(EngineCount)]*/ GUID* pEngineGUIDs;
		HRESULT retValue;
	};

	STDMETHOD(IsEngineCompatible)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ ULONG EngineCount,
		/*[in,size_is(EngineCount)]*/ GUID* pEngineGUIDs)
	{
		VSL_DEFINE_MOCK_METHOD(IsEngineCompatible)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(EngineCount);

		VSL_CHECK_VALIDVALUE_MEMCMP(pEngineGUIDs, EngineCount*sizeof(pEngineGUIDs[0]), validValues.EngineCount*sizeof(validValues.pEngineGUIDs[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct GetConsoleHandlesForProcessValidValues
	{
		/*[in]*/ DWORD dwPid;
		/*[out]*/ ULONG64* pdwStdInput;
		/*[out]*/ ULONG64* pdwStdOutput;
		/*[out]*/ ULONG64* pdwStdError;
		HRESULT retValue;
	};

	STDMETHOD(GetConsoleHandlesForProcess)(
		/*[in]*/ DWORD dwPid,
		/*[out]*/ ULONG64* pdwStdInput,
		/*[out]*/ ULONG64* pdwStdOutput,
		/*[out]*/ ULONG64* pdwStdError)
	{
		VSL_DEFINE_MOCK_METHOD(GetConsoleHandlesForProcess)

		VSL_CHECK_VALIDVALUE(dwPid);

		VSL_SET_VALIDVALUE(pdwStdInput);

		VSL_SET_VALIDVALUE(pdwStdOutput);

		VSL_SET_VALIDVALUE(pdwStdError);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowSourceValidValues
	{
		/*[in]*/ IUnknown* pUnkDebugDocContext;
		/*[in]*/ BOOL fMakeActive;
		/*[in]*/ BOOL fAlwaysMoveCaret;
		/*[in]*/ BOOL fPromptToFindSource;
		/*[in]*/ BOOL fIgnoreIfNotFound;
		/*[out]*/ IVsTextView** ppTextView;
		HRESULT retValue;
	};

	STDMETHOD(ShowSource)(
		/*[in]*/ IUnknown* pUnkDebugDocContext,
		/*[in]*/ BOOL fMakeActive,
		/*[in]*/ BOOL fAlwaysMoveCaret,
		/*[in]*/ BOOL fPromptToFindSource,
		/*[in]*/ BOOL fIgnoreIfNotFound,
		/*[out]*/ IVsTextView** ppTextView)
	{
		VSL_DEFINE_MOCK_METHOD(ShowSource)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkDebugDocContext);

		VSL_CHECK_VALIDVALUE(fMakeActive);

		VSL_CHECK_VALIDVALUE(fAlwaysMoveCaret);

		VSL_CHECK_VALIDVALUE(fPromptToFindSource);

		VSL_CHECK_VALIDVALUE(fIgnoreIfNotFound);

		VSL_SET_VALIDVALUE_INTERFACE(ppTextView);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateDataTipValidValues
	{
		/*[in]*/ BSTR bstrExpression;
		/*[in]*/ VSEDT_STYLE dwStyle;
		/*[out]*/ IVsEnhancedDataTip** ppDataTip;
		HRESULT retValue;
	};

	STDMETHOD(CreateDataTip)(
		/*[in]*/ BSTR bstrExpression,
		/*[in]*/ VSEDT_STYLE dwStyle,
		/*[out]*/ IVsEnhancedDataTip** ppDataTip)
	{
		VSL_DEFINE_MOCK_METHOD(CreateDataTip)

		VSL_CHECK_VALIDVALUE_BSTR(bstrExpression);

		VSL_CHECK_VALIDVALUE(dwStyle);

		VSL_SET_VALIDVALUE_INTERFACE(ppDataTip);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSymbolPathValidValues
	{
		/*[out]*/ BSTR* pbstrSymbolPath;
		/*[out]*/ BSTR* pbstrSymbolCachePath;
		HRESULT retValue;
	};

	STDMETHOD(GetSymbolPath)(
		/*[out]*/ BSTR* pbstrSymbolPath,
		/*[out]*/ BSTR* pbstrSymbolCachePath)
	{
		VSL_DEFINE_MOCK_METHOD(GetSymbolPath)

		VSL_SET_VALIDVALUE_BSTR(pbstrSymbolPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrSymbolCachePath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetOutputHandleForProcessValidValues
	{
		/*[in]*/ DWORD dwPid;
		/*[out]*/ ULONG64* pOutputHandle;
		HRESULT retValue;
	};

	STDMETHOD(GetOutputHandleForProcess)(
		/*[in]*/ DWORD dwPid,
		/*[out]*/ ULONG64* pOutputHandle)
	{
		VSL_DEFINE_MOCK_METHOD(GetOutputHandleForProcess)

		VSL_CHECK_VALIDVALUE(dwPid);

		VSL_SET_VALIDVALUE(pOutputHandle);

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertBreakpointByNameValidValues
	{
		/*[in]*/ REFGUID guidLanguage;
		/*[in]*/ LPCOLESTR pszCodeLocationText;
		/*[in]*/ BOOL bUseIntellisense;
		HRESULT retValue;
	};

	STDMETHOD(InsertBreakpointByName)(
		/*[in]*/ REFGUID guidLanguage,
		/*[in]*/ LPCOLESTR pszCodeLocationText,
		/*[in]*/ BOOL bUseIntellisense)
	{
		VSL_DEFINE_MOCK_METHOD(InsertBreakpointByName)

		VSL_CHECK_VALIDVALUE(guidLanguage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCodeLocationText);

		VSL_CHECK_VALIDVALUE(bUseIntellisense);

		VSL_RETURN_VALIDVALUES();
	}
	struct ToggleUseQuickConsoleOptionValidValues
	{
		/*[in]*/ BOOL fOnOff;
		HRESULT retValue;
	};

	STDMETHOD(ToggleUseQuickConsoleOption)(
		/*[in]*/ BOOL fOnOff)
	{
		VSL_DEFINE_MOCK_METHOD(ToggleUseQuickConsoleOption)

		VSL_CHECK_VALIDVALUE(fOnOff);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUseQuickConsoleOptionSettingValidValues
	{
		/*[out]*/ BOOL* pfValue;
		HRESULT retValue;
	};

	STDMETHOD(GetUseQuickConsoleOptionSetting)(
		/*[out]*/ BOOL* pfValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetUseQuickConsoleOptionSetting)

		VSL_SET_VALIDVALUE(pfValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInternalDebugModeValidValues
	{
		/*[out]*/ DBGMODE* pdbgmode;
		HRESULT retValue;
	};

	STDMETHOD(GetInternalDebugMode)(
		/*[out]*/ DBGMODE* pdbgmode)
	{
		VSL_DEFINE_MOCK_METHOD(GetInternalDebugMode)

		VSL_SET_VALIDVALUE(pdbgmode);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEBUGGER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
