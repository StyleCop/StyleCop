/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEBUGGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEBUGGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDebuggerNotImpl :
	public IVsDebugger
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebuggerNotImpl)

public:

	typedef IVsDebugger Interface;

	STDMETHOD(GetMode)(
		/*[out]*/ DBGMODE* /*pdbgmode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseDebuggerEvents)(
		/*[in]*/ IVsDebuggerEvents* /*psink*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseDebuggerEvents)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDataTipValue)(
		/*[in]*/ IVsTextLines* /*pTextBuf*/,
		/*[in]*/ const TextSpan* /*pTS*/,
		/*[in]*/ WCHAR* /*pszExpression*/,
		/*[out]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryStatusForTextPos)(
		/*[in]*/ VsTextPos* /*pTextPos*/,
		/*[unique,in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ ULONG /*cCmds*/,
		/*[out,in,size_is(cCmds)]*/ OLECMD[] /*prgCmds*/,
		/*[unique,out,in]*/ OLECMDTEXT* /*pCmdText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExecCmdForTextPos)(
		/*[in]*/ VsTextPos* /*pTextPos*/,
		/*[unique,in]*/ const GUID* /*pguidCmdGroup*/,
		/*[in]*/ DWORD /*nCmdID*/,
		/*[in]*/ DWORD /*nCmdexecopt*/,
		/*[unique,in]*/ VARIANT* /*pvaIn*/,
		/*[unique,out,in]*/ VARIANT* /*pvaOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AdviseDebugEventCallback)(
		/*[in]*/ IUnknown* /*punkDebuggerEvents*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseDebugEventCallback)(
		/*[in]*/ IUnknown* /*punkDebuggerEvents*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LaunchDebugTargets)(
		/*[in]*/ ULONG /*cTargets*/,
		/*[in,out,size_is(cTargets)]*/ VsDebugTargetInfo* /*rgDebugTargetInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InsertBreakpointByName)(
		/*[in]*/ REFGUID /*guidLanguage*/,
		/*[in]*/ LPCOLESTR /*pszCodeLocationText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveBreakpointsByName)(
		/*[in]*/ REFGUID /*guidLanguage*/,
		/*[in]*/ LPCOLESTR /*pszCodeLocationText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ToggleBreakpointByName)(
		/*[in]*/ REFGUID /*guidLanguage*/,
		/*[in]*/ LPCOLESTR /*pszCodeLocationText*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsBreakpointOnName)(
		/*[in]*/ REFGUID /*guidLanguage*/,
		/*[in]*/ LPCOLESTR /*pszCodeLocationText*/,
		/*[out]*/ BOOL* /*pfIsBreakpoint*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ParseFileRedirection)(
		/*[in]*/ LPOLESTR /*pszArgs*/,
		/*[out]*/ BSTR* /*pbstrArgsProcessed*/,
		/*[out]*/ HANDLE* /*phStdInput*/,
		/*[out]*/ HANDLE* /*phStdOutput*/,
		/*[out]*/ HANDLE* /*phStdError*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetENCUpdate)(
		/*[out]*/ IUnknown** /*ppUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AllowEditsWhileDebugging)(
		/*[in]*/ REFGUID /*guidLanguageService*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDebuggerMockImpl :
	public IVsDebugger,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDebuggerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDebuggerMockImpl)

	typedef IVsDebugger Interface;
	struct GetModeValidValues
	{
		/*[out]*/ DBGMODE* pdbgmode;
		HRESULT retValue;
	};

	STDMETHOD(GetMode)(
		/*[out]*/ DBGMODE* pdbgmode)
	{
		VSL_DEFINE_MOCK_METHOD(GetMode)

		VSL_SET_VALIDVALUE(pdbgmode);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseDebuggerEventsValidValues
	{
		/*[in]*/ IVsDebuggerEvents* psink;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseDebuggerEvents)(
		/*[in]*/ IVsDebuggerEvents* psink,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseDebuggerEvents)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(psink);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseDebuggerEventsValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseDebuggerEvents)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseDebuggerEvents)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDataTipValueValidValues
	{
		/*[in]*/ IVsTextLines* pTextBuf;
		/*[in]*/ TextSpan* pTS;
		/*[in]*/ WCHAR* pszExpression;
		/*[out]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetDataTipValue)(
		/*[in]*/ IVsTextLines* pTextBuf,
		/*[in]*/ const TextSpan* pTS,
		/*[in]*/ WCHAR* pszExpression,
		/*[out]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetDataTipValue)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTextBuf);

		VSL_CHECK_VALIDVALUE_POINTER(pTS);

		VSL_CHECK_VALIDVALUE_STRINGW(pszExpression);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryStatusForTextPosValidValues
	{
		/*[in]*/ VsTextPos* pTextPos;
		/*[unique,in]*/ GUID* pguidCmdGroup;
		/*[in]*/ ULONG cCmds;
		/*[out,in,size_is(cCmds)]*/ OLECMD* prgCmds;
		/*[unique,out,in]*/ OLECMDTEXT* pCmdText;
		HRESULT retValue;
	};

	STDMETHOD(QueryStatusForTextPos)(
		/*[in]*/ VsTextPos* pTextPos,
		/*[unique,in]*/ const GUID* pguidCmdGroup,
		/*[in]*/ ULONG cCmds,
		/*[out,in,size_is(cCmds)]*/ OLECMD prgCmds[],
		/*[unique,out,in]*/ OLECMDTEXT* pCmdText)
	{
		VSL_DEFINE_MOCK_METHOD(QueryStatusForTextPos)

		VSL_CHECK_VALIDVALUE_POINTER(pTextPos);

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(cCmds);

		VSL_SET_VALIDVALUE_MEMCPY(prgCmds, cCmds*sizeof(prgCmds[0]), validValues.cCmds*sizeof(validValues.prgCmds[0]));

		VSL_SET_VALIDVALUE(pCmdText);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecCmdForTextPosValidValues
	{
		/*[in]*/ VsTextPos* pTextPos;
		/*[unique,in]*/ GUID* pguidCmdGroup;
		/*[in]*/ DWORD nCmdID;
		/*[in]*/ DWORD nCmdexecopt;
		/*[unique,in]*/ VARIANT* pvaIn;
		/*[unique,out,in]*/ VARIANT* pvaOut;
		HRESULT retValue;
	};

	STDMETHOD(ExecCmdForTextPos)(
		/*[in]*/ VsTextPos* pTextPos,
		/*[unique,in]*/ const GUID* pguidCmdGroup,
		/*[in]*/ DWORD nCmdID,
		/*[in]*/ DWORD nCmdexecopt,
		/*[unique,in]*/ VARIANT* pvaIn,
		/*[unique,out,in]*/ VARIANT* pvaOut)
	{
		VSL_DEFINE_MOCK_METHOD(ExecCmdForTextPos)

		VSL_CHECK_VALIDVALUE_POINTER(pTextPos);

		VSL_CHECK_VALIDVALUE_POINTER(pguidCmdGroup);

		VSL_CHECK_VALIDVALUE(nCmdID);

		VSL_CHECK_VALIDVALUE(nCmdexecopt);

		VSL_CHECK_VALIDVALUE_POINTER(pvaIn);

		VSL_SET_VALIDVALUE_VARIANT(pvaOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct AdviseDebugEventCallbackValidValues
	{
		/*[in]*/ IUnknown* punkDebuggerEvents;
		HRESULT retValue;
	};

	STDMETHOD(AdviseDebugEventCallback)(
		/*[in]*/ IUnknown* punkDebuggerEvents)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseDebugEventCallback)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDebuggerEvents);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseDebugEventCallbackValidValues
	{
		/*[in]*/ IUnknown* punkDebuggerEvents;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseDebugEventCallback)(
		/*[in]*/ IUnknown* punkDebuggerEvents)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseDebugEventCallback)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkDebuggerEvents);

		VSL_RETURN_VALIDVALUES();
	}
	struct LaunchDebugTargetsValidValues
	{
		/*[in]*/ ULONG cTargets;
		/*[in,out,size_is(cTargets)]*/ VsDebugTargetInfo* rgDebugTargetInfo;
		HRESULT retValue;
	};

	STDMETHOD(LaunchDebugTargets)(
		/*[in]*/ ULONG cTargets,
		/*[in,out,size_is(cTargets)]*/ VsDebugTargetInfo* rgDebugTargetInfo)
	{
		VSL_DEFINE_MOCK_METHOD(LaunchDebugTargets)

		VSL_CHECK_VALIDVALUE(cTargets);

		VSL_SET_VALIDVALUE_MEMCPY(rgDebugTargetInfo, cTargets*sizeof(rgDebugTargetInfo[0]), validValues.cTargets*sizeof(validValues.rgDebugTargetInfo[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct InsertBreakpointByNameValidValues
	{
		/*[in]*/ REFGUID guidLanguage;
		/*[in]*/ LPCOLESTR pszCodeLocationText;
		HRESULT retValue;
	};

	STDMETHOD(InsertBreakpointByName)(
		/*[in]*/ REFGUID guidLanguage,
		/*[in]*/ LPCOLESTR pszCodeLocationText)
	{
		VSL_DEFINE_MOCK_METHOD(InsertBreakpointByName)

		VSL_CHECK_VALIDVALUE(guidLanguage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCodeLocationText);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveBreakpointsByNameValidValues
	{
		/*[in]*/ REFGUID guidLanguage;
		/*[in]*/ LPCOLESTR pszCodeLocationText;
		HRESULT retValue;
	};

	STDMETHOD(RemoveBreakpointsByName)(
		/*[in]*/ REFGUID guidLanguage,
		/*[in]*/ LPCOLESTR pszCodeLocationText)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveBreakpointsByName)

		VSL_CHECK_VALIDVALUE(guidLanguage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCodeLocationText);

		VSL_RETURN_VALIDVALUES();
	}
	struct ToggleBreakpointByNameValidValues
	{
		/*[in]*/ REFGUID guidLanguage;
		/*[in]*/ LPCOLESTR pszCodeLocationText;
		HRESULT retValue;
	};

	STDMETHOD(ToggleBreakpointByName)(
		/*[in]*/ REFGUID guidLanguage,
		/*[in]*/ LPCOLESTR pszCodeLocationText)
	{
		VSL_DEFINE_MOCK_METHOD(ToggleBreakpointByName)

		VSL_CHECK_VALIDVALUE(guidLanguage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCodeLocationText);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsBreakpointOnNameValidValues
	{
		/*[in]*/ REFGUID guidLanguage;
		/*[in]*/ LPCOLESTR pszCodeLocationText;
		/*[out]*/ BOOL* pfIsBreakpoint;
		HRESULT retValue;
	};

	STDMETHOD(IsBreakpointOnName)(
		/*[in]*/ REFGUID guidLanguage,
		/*[in]*/ LPCOLESTR pszCodeLocationText,
		/*[out]*/ BOOL* pfIsBreakpoint)
	{
		VSL_DEFINE_MOCK_METHOD(IsBreakpointOnName)

		VSL_CHECK_VALIDVALUE(guidLanguage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszCodeLocationText);

		VSL_SET_VALIDVALUE(pfIsBreakpoint);

		VSL_RETURN_VALIDVALUES();
	}
	struct ParseFileRedirectionValidValues
	{
		/*[in]*/ LPOLESTR pszArgs;
		/*[out]*/ BSTR* pbstrArgsProcessed;
		/*[out]*/ HANDLE* phStdInput;
		/*[out]*/ HANDLE* phStdOutput;
		/*[out]*/ HANDLE* phStdError;
		HRESULT retValue;
	};

	STDMETHOD(ParseFileRedirection)(
		/*[in]*/ LPOLESTR pszArgs,
		/*[out]*/ BSTR* pbstrArgsProcessed,
		/*[out]*/ HANDLE* phStdInput,
		/*[out]*/ HANDLE* phStdOutput,
		/*[out]*/ HANDLE* phStdError)
	{
		VSL_DEFINE_MOCK_METHOD(ParseFileRedirection)

		VSL_CHECK_VALIDVALUE_STRINGW(pszArgs);

		VSL_SET_VALIDVALUE_BSTR(pbstrArgsProcessed);

		VSL_SET_VALIDVALUE(phStdInput);

		VSL_SET_VALIDVALUE(phStdOutput);

		VSL_SET_VALIDVALUE(phStdError);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetENCUpdateValidValues
	{
		/*[out]*/ IUnknown** ppUpdate;
		HRESULT retValue;
	};

	STDMETHOD(GetENCUpdate)(
		/*[out]*/ IUnknown** ppUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(GetENCUpdate)

		VSL_SET_VALIDVALUE_INTERFACE(ppUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct AllowEditsWhileDebuggingValidValues
	{
		/*[in]*/ REFGUID guidLanguageService;
		HRESULT retValue;
	};

	STDMETHOD(AllowEditsWhileDebugging)(
		/*[in]*/ REFGUID guidLanguageService)
	{
		VSL_DEFINE_MOCK_METHOD(AllowEditsWhileDebugging)

		VSL_CHECK_VALIDVALUE(guidLanguageService);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEBUGGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
