/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGENGINELAUNCH2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGENGINELAUNCH2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugEngineLaunch2NotImpl :
	public IDebugEngineLaunch2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngineLaunch2NotImpl)

public:

	typedef IDebugEngineLaunch2 Interface;

	STDMETHOD(LaunchSuspended)(
		/*[in,ptr]*/ LPCOLESTR /*pszServer*/,
		/*[in]*/ IDebugPort2* /*pPort*/,
		/*[in,ptr]*/ LPCOLESTR /*pszExe*/,
		/*[in,ptr]*/ LPCOLESTR /*pszArgs*/,
		/*[in,ptr]*/ LPCOLESTR /*pszDir*/,
		/*[in,ptr]*/ BSTR /*bstrEnv*/,
		/*[in,ptr]*/ LPCOLESTR /*pszOptions*/,
		/*[in]*/ LAUNCH_FLAGS /*dwLaunchFlags*/,
		/*[in]*/ DWORD /*hStdInput*/,
		/*[in]*/ DWORD /*hStdOutput*/,
		/*[in]*/ DWORD /*hStdError*/,
		/*[in]*/ IDebugEventCallback2* /*pCallback*/,
		/*[out]*/ IDebugProcess2** /*ppProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ResumeProcess)(
		/*[in]*/ IDebugProcess2* /*pProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanTerminateProcess)(
		/*[in]*/ IDebugProcess2* /*pProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TerminateProcess)(
		/*[in]*/ IDebugProcess2* /*pProcess*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugEngineLaunch2MockImpl :
	public IDebugEngineLaunch2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngineLaunch2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugEngineLaunch2MockImpl)

	typedef IDebugEngineLaunch2 Interface;
	struct LaunchSuspendedValidValues
	{
		/*[in,ptr]*/ LPCOLESTR pszServer;
		/*[in]*/ IDebugPort2* pPort;
		/*[in,ptr]*/ LPCOLESTR pszExe;
		/*[in,ptr]*/ LPCOLESTR pszArgs;
		/*[in,ptr]*/ LPCOLESTR pszDir;
		/*[in,ptr]*/ BSTR bstrEnv;
		/*[in,ptr]*/ LPCOLESTR pszOptions;
		/*[in]*/ LAUNCH_FLAGS dwLaunchFlags;
		/*[in]*/ DWORD hStdInput;
		/*[in]*/ DWORD hStdOutput;
		/*[in]*/ DWORD hStdError;
		/*[in]*/ IDebugEventCallback2* pCallback;
		/*[out]*/ IDebugProcess2** ppProcess;
		HRESULT retValue;
	};

	STDMETHOD(LaunchSuspended)(
		/*[in,ptr]*/ LPCOLESTR pszServer,
		/*[in]*/ IDebugPort2* pPort,
		/*[in,ptr]*/ LPCOLESTR pszExe,
		/*[in,ptr]*/ LPCOLESTR pszArgs,
		/*[in,ptr]*/ LPCOLESTR pszDir,
		/*[in,ptr]*/ BSTR bstrEnv,
		/*[in,ptr]*/ LPCOLESTR pszOptions,
		/*[in]*/ LAUNCH_FLAGS dwLaunchFlags,
		/*[in]*/ DWORD hStdInput,
		/*[in]*/ DWORD hStdOutput,
		/*[in]*/ DWORD hStdError,
		/*[in]*/ IDebugEventCallback2* pCallback,
		/*[out]*/ IDebugProcess2** ppProcess)
	{
		VSL_DEFINE_MOCK_METHOD(LaunchSuspended)

		VSL_CHECK_VALIDVALUE_STRINGW(pszServer);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPort);

		VSL_CHECK_VALIDVALUE_STRINGW(pszExe);

		VSL_CHECK_VALIDVALUE_STRINGW(pszArgs);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDir);

		VSL_CHECK_VALIDVALUE_BSTR(bstrEnv);

		VSL_CHECK_VALIDVALUE_STRINGW(pszOptions);

		VSL_CHECK_VALIDVALUE(dwLaunchFlags);

		VSL_CHECK_VALIDVALUE(hStdInput);

		VSL_CHECK_VALIDVALUE(hStdOutput);

		VSL_CHECK_VALIDVALUE(hStdError);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_SET_VALIDVALUE_INTERFACE(ppProcess);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResumeProcessValidValues
	{
		/*[in]*/ IDebugProcess2* pProcess;
		HRESULT retValue;
	};

	STDMETHOD(ResumeProcess)(
		/*[in]*/ IDebugProcess2* pProcess)
	{
		VSL_DEFINE_MOCK_METHOD(ResumeProcess)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProcess);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanTerminateProcessValidValues
	{
		/*[in]*/ IDebugProcess2* pProcess;
		HRESULT retValue;
	};

	STDMETHOD(CanTerminateProcess)(
		/*[in]*/ IDebugProcess2* pProcess)
	{
		VSL_DEFINE_MOCK_METHOD(CanTerminateProcess)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProcess);

		VSL_RETURN_VALIDVALUES();
	}
	struct TerminateProcessValidValues
	{
		/*[in]*/ IDebugProcess2* pProcess;
		HRESULT retValue;
	};

	STDMETHOD(TerminateProcess)(
		/*[in]*/ IDebugProcess2* pProcess)
	{
		VSL_DEFINE_MOCK_METHOD(TerminateProcess)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProcess);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGENGINELAUNCH2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
