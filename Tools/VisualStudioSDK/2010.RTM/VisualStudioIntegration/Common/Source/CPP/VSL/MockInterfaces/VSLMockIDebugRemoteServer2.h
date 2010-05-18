/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGREMOTESERVER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGREMOTESERVER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugRemoteServer2NotImpl :
	public IDebugRemoteServer2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugRemoteServer2NotImpl)

public:

	typedef IDebugRemoteServer2 Interface;

	STDMETHOD(GetRemoteServerName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRemoteComputerInfo)(
		/*[out]*/ COMPUTER_INFO* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumRemoteProcesses)(
		/*[out]*/ ENUMERATED_PROCESS_ARRAY* /*pProcessArray*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRemoteProcessInfo)(
		/*[in]*/ DWORD /*dwProcessId*/,
		/*[in]*/ REMOTE_PROCESS_INFO_FIELDS /*Fields*/,
		/*[out]*/ REMOTE_PROCESS_INFO* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateRemoteInstance)(
		/*[in,ptr]*/ LPCWSTR /*szDll*/,
		/*[in]*/ WORD /*wLangId*/,
		/*[in]*/ REFCLSID /*clsidObject*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WatchForRemoteProcessDestroy)(
		/*[in]*/ IDebugPortEvents2* /*pCallback*/,
		/*[in]*/ IDebugProcess2* /*pProcess*/,
		/*[out]*/ WATCH_COOKIE* /*pWatchCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseRemoteWatchCookie)(
		/*[in]*/ WATCH_COOKIE /*WatchCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TerminateRemoteProcess)(
		/*[in]*/ DWORD /*dwProcessId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LaunchRemoteProcess)(
		/*[in]*/ PROCESS_LAUNCH_INFO /*LaunchInfo*/,
		/*[out]*/ DWORD* /*pdwProcessId*/,
		/*[out]*/ RESUME_COOKIE* /*pResumeCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CloseRemoteResumeCookie)(
		/*[in]*/ RESUME_COOKIE /*ResumeCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DiagnoseRemoteWebDebuggingError)(
		/*[in,ptr]*/ LPCWSTR /*szUrl*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugRemoteServer2MockImpl :
	public IDebugRemoteServer2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugRemoteServer2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugRemoteServer2MockImpl)

	typedef IDebugRemoteServer2 Interface;
	struct GetRemoteServerNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetRemoteServerName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetRemoteServerName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRemoteComputerInfoValidValues
	{
		/*[out]*/ COMPUTER_INFO* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetRemoteComputerInfo)(
		/*[out]*/ COMPUTER_INFO* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetRemoteComputerInfo)

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumRemoteProcessesValidValues
	{
		/*[out]*/ ENUMERATED_PROCESS_ARRAY* pProcessArray;
		HRESULT retValue;
	};

	STDMETHOD(EnumRemoteProcesses)(
		/*[out]*/ ENUMERATED_PROCESS_ARRAY* pProcessArray)
	{
		VSL_DEFINE_MOCK_METHOD(EnumRemoteProcesses)

		VSL_SET_VALIDVALUE(pProcessArray);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRemoteProcessInfoValidValues
	{
		/*[in]*/ DWORD dwProcessId;
		/*[in]*/ REMOTE_PROCESS_INFO_FIELDS Fields;
		/*[out]*/ REMOTE_PROCESS_INFO* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetRemoteProcessInfo)(
		/*[in]*/ DWORD dwProcessId,
		/*[in]*/ REMOTE_PROCESS_INFO_FIELDS Fields,
		/*[out]*/ REMOTE_PROCESS_INFO* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetRemoteProcessInfo)

		VSL_CHECK_VALIDVALUE(dwProcessId);

		VSL_CHECK_VALIDVALUE(Fields);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateRemoteInstanceValidValues
	{
		/*[in,ptr]*/ LPCWSTR szDll;
		/*[in]*/ WORD wLangId;
		/*[in]*/ REFCLSID clsidObject;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvObject;
		HRESULT retValue;
	};

	STDMETHOD(CreateRemoteInstance)(
		/*[in,ptr]*/ LPCWSTR szDll,
		/*[in]*/ WORD wLangId,
		/*[in]*/ REFCLSID clsidObject,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvObject)
	{
		VSL_DEFINE_MOCK_METHOD(CreateRemoteInstance)

		VSL_CHECK_VALIDVALUE_STRINGW(szDll);

		VSL_CHECK_VALIDVALUE(wLangId);

		VSL_CHECK_VALIDVALUE(clsidObject);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct WatchForRemoteProcessDestroyValidValues
	{
		/*[in]*/ IDebugPortEvents2* pCallback;
		/*[in]*/ IDebugProcess2* pProcess;
		/*[out]*/ WATCH_COOKIE* pWatchCookie;
		HRESULT retValue;
	};

	STDMETHOD(WatchForRemoteProcessDestroy)(
		/*[in]*/ IDebugPortEvents2* pCallback,
		/*[in]*/ IDebugProcess2* pProcess,
		/*[out]*/ WATCH_COOKIE* pWatchCookie)
	{
		VSL_DEFINE_MOCK_METHOD(WatchForRemoteProcessDestroy)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProcess);

		VSL_SET_VALIDVALUE(pWatchCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseRemoteWatchCookieValidValues
	{
		/*[in]*/ WATCH_COOKIE WatchCookie;
		HRESULT retValue;
	};

	STDMETHOD(CloseRemoteWatchCookie)(
		/*[in]*/ WATCH_COOKIE WatchCookie)
	{
		VSL_DEFINE_MOCK_METHOD(CloseRemoteWatchCookie)

		VSL_CHECK_VALIDVALUE(WatchCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct TerminateRemoteProcessValidValues
	{
		/*[in]*/ DWORD dwProcessId;
		HRESULT retValue;
	};

	STDMETHOD(TerminateRemoteProcess)(
		/*[in]*/ DWORD dwProcessId)
	{
		VSL_DEFINE_MOCK_METHOD(TerminateRemoteProcess)

		VSL_CHECK_VALIDVALUE(dwProcessId);

		VSL_RETURN_VALIDVALUES();
	}
	struct LaunchRemoteProcessValidValues
	{
		/*[in]*/ PROCESS_LAUNCH_INFO LaunchInfo;
		/*[out]*/ DWORD* pdwProcessId;
		/*[out]*/ RESUME_COOKIE* pResumeCookie;
		HRESULT retValue;
	};

	STDMETHOD(LaunchRemoteProcess)(
		/*[in]*/ PROCESS_LAUNCH_INFO LaunchInfo,
		/*[out]*/ DWORD* pdwProcessId,
		/*[out]*/ RESUME_COOKIE* pResumeCookie)
	{
		VSL_DEFINE_MOCK_METHOD(LaunchRemoteProcess)

		VSL_CHECK_VALIDVALUE(LaunchInfo);

		VSL_SET_VALIDVALUE(pdwProcessId);

		VSL_SET_VALIDVALUE(pResumeCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseRemoteResumeCookieValidValues
	{
		/*[in]*/ RESUME_COOKIE ResumeCookie;
		HRESULT retValue;
	};

	STDMETHOD(CloseRemoteResumeCookie)(
		/*[in]*/ RESUME_COOKIE ResumeCookie)
	{
		VSL_DEFINE_MOCK_METHOD(CloseRemoteResumeCookie)

		VSL_CHECK_VALIDVALUE(ResumeCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct DiagnoseRemoteWebDebuggingErrorValidValues
	{
		/*[in,ptr]*/ LPCWSTR szUrl;
		HRESULT retValue;
	};

	STDMETHOD(DiagnoseRemoteWebDebuggingError)(
		/*[in,ptr]*/ LPCWSTR szUrl)
	{
		VSL_DEFINE_MOCK_METHOD(DiagnoseRemoteWebDebuggingError)

		VSL_CHECK_VALIDVALUE_STRINGW(szUrl);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGREMOTESERVER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
