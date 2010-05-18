/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGSESSION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGSESSION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugSession2NotImpl :
	public IDebugSession2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugSession2NotImpl)

public:

	typedef IDebugSession2 Interface;

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetName)(
		/*[in]*/ LPCOLESTR /*pszName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumProcesses)(
		/*[out]*/ IEnumDebugProcesses2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Launch)(
		/*[in,ptr]*/ LPCOLESTR /*pszMachine*/,
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
		/*[in]*/ REFGUID /*guidLaunchingEngine*/,
		/*[in]*/ IDebugEventCallback2* /*pCallback*/,
		/*[in,size_is(celtSpecificEngines)]*/ GUID* /*rgguidSpecificEngines*/,
		/*[in]*/ DWORD /*celtSpecificEngines*/,
		/*[out]*/ IDebugProcess2** /*ppProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterJITServer)(
		/*[in]*/ REFCLSID /*clsidJITServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Terminate)(
		/*[in]*/ BOOL /*fForce*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Detach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CauseBreak)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreatePendingBreakpoint)(
		/*[in]*/ IDebugBreakpointRequest2* /*pBPRequest*/,
		/*[out]*/ IDebugPendingBreakpoint2** /*ppPendingBP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPendingBreakpoints)(
		/*[in]*/ IDebugProgram2* /*pProgram*/,
		/*[in,ptr]*/ LPCOLESTR /*pszProgram*/,
		/*[out]*/ IEnumDebugPendingBreakpoints2** /*ppEnumBPs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumMachines__deprecated)(
		/*[out]*/ IEnumDebugMachines2__deprecated** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ConnectToServer)(
		/*[in,ptr]*/ LPCOLESTR /*szServerName*/,
		/*[out]*/ IDebugCoreServer2** /*ppServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisconnectServer)(
		/*[in]*/ IDebugCoreServer2* /*pServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShutdownSession)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumCodeContexts)(
		/*[in]*/ IDebugProgram2* /*pProgram*/,
		/*[in]*/ IDebugDocumentPosition2* /*pDocPos*/,
		/*[out]*/ IEnumDebugCodeContexts2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetException)(
		/*[in]*/ EXCEPTION_INFO* /*pException*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumSetExceptions)(
		/*[in]*/ IDebugProgram2* /*pProgram*/,
		/*[in,ptr]*/ LPCOLESTR /*pszProgram*/,
		/*[in]*/ REFGUID /*guidType*/,
		/*[out]*/ IEnumDebugExceptionInfo2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveSetException)(
		/*[in]*/ EXCEPTION_INFO* /*pException*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAllSetExceptions)(
		/*[in]*/ REFGUID /*guidType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumDefaultExceptions)(
		/*[in,ptr]*/ EXCEPTION_INFO* /*pParentException*/,
		/*[out]*/ IEnumDebugExceptionInfo2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetENCUpdate)(
		/*[in]*/ IDebugProgram2* /*pProgram*/,
		/*[out]*/ IDebugENCUpdate** /*ppUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLocale)(
		/*[in]*/ WORD /*wLangID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRegistryRoot)(
		/*[in,ptr]*/ LPCOLESTR /*pszRegistryRoot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsAlive)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ClearAllSessionThreadStackFrames)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(__deprecated_GetSessionId)(
		/*[in]*/ IDebugEventCallback2* /*pCallback*/,
		/*[in,size_is(celtSpecificEngines),ptr]*/ GUID* /*rgguidSpecificEngines*/,
		/*[in]*/ DWORD /*celtSpecificEngines*/,
		/*[in,ptr]*/ LPCOLESTR /*pszStartPageUrl*/,
		/*[out]*/ BSTR* /*pbstrSessionId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEngineMetric)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ LPCOLESTR /*pszMetric*/,
		/*[in]*/ VARIANT /*varValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetStoppingModel)(
		/*[in]*/ STOPPING_MODEL /*dwStoppingModel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStoppingModel)(
		/*[out]*/ STOPPING_MODEL* /*pdwStoppingModel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(__deprecated_RegisterSessionWithServer)(
		/*[in]*/ LPCOLESTR /*pwszServerName*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugSession2MockImpl :
	public IDebugSession2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugSession2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugSession2MockImpl)

	typedef IDebugSession2 Interface;
	struct GetNameValidValues
	{
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetNameValidValues
	{
		/*[in]*/ LPCOLESTR pszName;
		HRESULT retValue;
	};

	STDMETHOD(SetName)(
		/*[in]*/ LPCOLESTR pszName)
	{
		VSL_DEFINE_MOCK_METHOD(SetName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumProcessesValidValues
	{
		/*[out]*/ IEnumDebugProcesses2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumProcesses)(
		/*[out]*/ IEnumDebugProcesses2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumProcesses)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct LaunchValidValues
	{
		/*[in,ptr]*/ LPCOLESTR pszMachine;
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
		/*[in]*/ REFGUID guidLaunchingEngine;
		/*[in]*/ IDebugEventCallback2* pCallback;
		/*[in,size_is(celtSpecificEngines)]*/ GUID* rgguidSpecificEngines;
		/*[in]*/ DWORD celtSpecificEngines;
		/*[out]*/ IDebugProcess2** ppProcess;
		HRESULT retValue;
	};

	STDMETHOD(Launch)(
		/*[in,ptr]*/ LPCOLESTR pszMachine,
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
		/*[in]*/ REFGUID guidLaunchingEngine,
		/*[in]*/ IDebugEventCallback2* pCallback,
		/*[in,size_is(celtSpecificEngines)]*/ GUID* rgguidSpecificEngines,
		/*[in]*/ DWORD celtSpecificEngines,
		/*[out]*/ IDebugProcess2** ppProcess)
	{
		VSL_DEFINE_MOCK_METHOD(Launch)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMachine);

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

		VSL_CHECK_VALIDVALUE(guidLaunchingEngine);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidSpecificEngines, celtSpecificEngines*sizeof(rgguidSpecificEngines[0]), validValues.celtSpecificEngines*sizeof(validValues.rgguidSpecificEngines[0]));

		VSL_CHECK_VALIDVALUE(celtSpecificEngines);

		VSL_SET_VALIDVALUE_INTERFACE(ppProcess);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterJITServerValidValues
	{
		/*[in]*/ REFCLSID clsidJITServer;
		HRESULT retValue;
	};

	STDMETHOD(RegisterJITServer)(
		/*[in]*/ REFCLSID clsidJITServer)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterJITServer)

		VSL_CHECK_VALIDVALUE(clsidJITServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct TerminateValidValues
	{
		/*[in]*/ BOOL fForce;
		HRESULT retValue;
	};

	STDMETHOD(Terminate)(
		/*[in]*/ BOOL fForce)
	{
		VSL_DEFINE_MOCK_METHOD(Terminate)

		VSL_CHECK_VALIDVALUE(fForce);

		VSL_RETURN_VALIDVALUES();
	}
	struct DetachValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Detach)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Detach)

		VSL_RETURN_VALIDVALUES();
	}
	struct CauseBreakValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CauseBreak)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CauseBreak)

		VSL_RETURN_VALIDVALUES();
	}
	struct CreatePendingBreakpointValidValues
	{
		/*[in]*/ IDebugBreakpointRequest2* pBPRequest;
		/*[out]*/ IDebugPendingBreakpoint2** ppPendingBP;
		HRESULT retValue;
	};

	STDMETHOD(CreatePendingBreakpoint)(
		/*[in]*/ IDebugBreakpointRequest2* pBPRequest,
		/*[out]*/ IDebugPendingBreakpoint2** ppPendingBP)
	{
		VSL_DEFINE_MOCK_METHOD(CreatePendingBreakpoint)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBPRequest);

		VSL_SET_VALIDVALUE_INTERFACE(ppPendingBP);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumPendingBreakpointsValidValues
	{
		/*[in]*/ IDebugProgram2* pProgram;
		/*[in,ptr]*/ LPCOLESTR pszProgram;
		/*[out]*/ IEnumDebugPendingBreakpoints2** ppEnumBPs;
		HRESULT retValue;
	};

	STDMETHOD(EnumPendingBreakpoints)(
		/*[in]*/ IDebugProgram2* pProgram,
		/*[in,ptr]*/ LPCOLESTR pszProgram,
		/*[out]*/ IEnumDebugPendingBreakpoints2** ppEnumBPs)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPendingBreakpoints)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgram);

		VSL_CHECK_VALIDVALUE_STRINGW(pszProgram);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumBPs);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumMachines__deprecatedValidValues
	{
		/*[out]*/ IEnumDebugMachines2__deprecated** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumMachines__deprecated)(
		/*[out]*/ IEnumDebugMachines2__deprecated** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumMachines__deprecated)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct ConnectToServerValidValues
	{
		/*[in,ptr]*/ LPCOLESTR szServerName;
		/*[out]*/ IDebugCoreServer2** ppServer;
		HRESULT retValue;
	};

	STDMETHOD(ConnectToServer)(
		/*[in,ptr]*/ LPCOLESTR szServerName,
		/*[out]*/ IDebugCoreServer2** ppServer)
	{
		VSL_DEFINE_MOCK_METHOD(ConnectToServer)

		VSL_CHECK_VALIDVALUE_STRINGW(szServerName);

		VSL_SET_VALIDVALUE_INTERFACE(ppServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisconnectServerValidValues
	{
		/*[in]*/ IDebugCoreServer2* pServer;
		HRESULT retValue;
	};

	STDMETHOD(DisconnectServer)(
		/*[in]*/ IDebugCoreServer2* pServer)
	{
		VSL_DEFINE_MOCK_METHOD(DisconnectServer)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShutdownSessionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ShutdownSession)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ShutdownSession)

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumCodeContextsValidValues
	{
		/*[in]*/ IDebugProgram2* pProgram;
		/*[in]*/ IDebugDocumentPosition2* pDocPos;
		/*[out]*/ IEnumDebugCodeContexts2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumCodeContexts)(
		/*[in]*/ IDebugProgram2* pProgram,
		/*[in]*/ IDebugDocumentPosition2* pDocPos,
		/*[out]*/ IEnumDebugCodeContexts2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumCodeContexts)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgram);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDocPos);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetExceptionValidValues
	{
		/*[in]*/ EXCEPTION_INFO* pException;
		HRESULT retValue;
	};

	STDMETHOD(SetException)(
		/*[in]*/ EXCEPTION_INFO* pException)
	{
		VSL_DEFINE_MOCK_METHOD(SetException)

		VSL_CHECK_VALIDVALUE_POINTER(pException);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumSetExceptionsValidValues
	{
		/*[in]*/ IDebugProgram2* pProgram;
		/*[in,ptr]*/ LPCOLESTR pszProgram;
		/*[in]*/ REFGUID guidType;
		/*[out]*/ IEnumDebugExceptionInfo2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumSetExceptions)(
		/*[in]*/ IDebugProgram2* pProgram,
		/*[in,ptr]*/ LPCOLESTR pszProgram,
		/*[in]*/ REFGUID guidType,
		/*[out]*/ IEnumDebugExceptionInfo2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumSetExceptions)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgram);

		VSL_CHECK_VALIDVALUE_STRINGW(pszProgram);

		VSL_CHECK_VALIDVALUE(guidType);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveSetExceptionValidValues
	{
		/*[in]*/ EXCEPTION_INFO* pException;
		HRESULT retValue;
	};

	STDMETHOD(RemoveSetException)(
		/*[in]*/ EXCEPTION_INFO* pException)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveSetException)

		VSL_CHECK_VALIDVALUE_POINTER(pException);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAllSetExceptionsValidValues
	{
		/*[in]*/ REFGUID guidType;
		HRESULT retValue;
	};

	STDMETHOD(RemoveAllSetExceptions)(
		/*[in]*/ REFGUID guidType)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveAllSetExceptions)

		VSL_CHECK_VALIDVALUE(guidType);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumDefaultExceptionsValidValues
	{
		/*[in,ptr]*/ EXCEPTION_INFO* pParentException;
		/*[out]*/ IEnumDebugExceptionInfo2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumDefaultExceptions)(
		/*[in,ptr]*/ EXCEPTION_INFO* pParentException,
		/*[out]*/ IEnumDebugExceptionInfo2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumDefaultExceptions)

		VSL_CHECK_VALIDVALUE_POINTER(pParentException);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetENCUpdateValidValues
	{
		/*[in]*/ IDebugProgram2* pProgram;
		/*[out]*/ IDebugENCUpdate** ppUpdate;
		HRESULT retValue;
	};

	STDMETHOD(GetENCUpdate)(
		/*[in]*/ IDebugProgram2* pProgram,
		/*[out]*/ IDebugENCUpdate** ppUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(GetENCUpdate)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgram);

		VSL_SET_VALIDVALUE_INTERFACE(ppUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetLocaleValidValues
	{
		/*[in]*/ WORD wLangID;
		HRESULT retValue;
	};

	STDMETHOD(SetLocale)(
		/*[in]*/ WORD wLangID)
	{
		VSL_DEFINE_MOCK_METHOD(SetLocale)

		VSL_CHECK_VALIDVALUE(wLangID);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetRegistryRootValidValues
	{
		/*[in,ptr]*/ LPCOLESTR pszRegistryRoot;
		HRESULT retValue;
	};

	STDMETHOD(SetRegistryRoot)(
		/*[in,ptr]*/ LPCOLESTR pszRegistryRoot)
	{
		VSL_DEFINE_MOCK_METHOD(SetRegistryRoot)

		VSL_CHECK_VALIDVALUE_STRINGW(pszRegistryRoot);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsAliveValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsAlive)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsAlive)

		VSL_RETURN_VALIDVALUES();
	}
	struct ClearAllSessionThreadStackFramesValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ClearAllSessionThreadStackFrames)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ClearAllSessionThreadStackFrames)

		VSL_RETURN_VALIDVALUES();
	}
	struct __deprecated_GetSessionIdValidValues
	{
		/*[in]*/ IDebugEventCallback2* pCallback;
		/*[in,size_is(celtSpecificEngines),ptr]*/ GUID* rgguidSpecificEngines;
		/*[in]*/ DWORD celtSpecificEngines;
		/*[in,ptr]*/ LPCOLESTR pszStartPageUrl;
		/*[out]*/ BSTR* pbstrSessionId;
		HRESULT retValue;
	};

	STDMETHOD(__deprecated_GetSessionId)(
		/*[in]*/ IDebugEventCallback2* pCallback,
		/*[in,size_is(celtSpecificEngines),ptr]*/ GUID* rgguidSpecificEngines,
		/*[in]*/ DWORD celtSpecificEngines,
		/*[in,ptr]*/ LPCOLESTR pszStartPageUrl,
		/*[out]*/ BSTR* pbstrSessionId)
	{
		VSL_DEFINE_MOCK_METHOD(__deprecated_GetSessionId)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidSpecificEngines, celtSpecificEngines*sizeof(rgguidSpecificEngines[0]), validValues.celtSpecificEngines*sizeof(validValues.rgguidSpecificEngines[0]));

		VSL_CHECK_VALIDVALUE(celtSpecificEngines);

		VSL_CHECK_VALIDVALUE_STRINGW(pszStartPageUrl);

		VSL_SET_VALIDVALUE_BSTR(pbstrSessionId);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEngineMetricValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ LPCOLESTR pszMetric;
		/*[in]*/ VARIANT varValue;
		HRESULT retValue;
	};

	STDMETHOD(SetEngineMetric)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ LPCOLESTR pszMetric,
		/*[in]*/ VARIANT varValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetEngineMetric)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_CHECK_VALIDVALUE(varValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetStoppingModelValidValues
	{
		/*[in]*/ STOPPING_MODEL dwStoppingModel;
		HRESULT retValue;
	};

	STDMETHOD(SetStoppingModel)(
		/*[in]*/ STOPPING_MODEL dwStoppingModel)
	{
		VSL_DEFINE_MOCK_METHOD(SetStoppingModel)

		VSL_CHECK_VALIDVALUE(dwStoppingModel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStoppingModelValidValues
	{
		/*[out]*/ STOPPING_MODEL* pdwStoppingModel;
		HRESULT retValue;
	};

	STDMETHOD(GetStoppingModel)(
		/*[out]*/ STOPPING_MODEL* pdwStoppingModel)
	{
		VSL_DEFINE_MOCK_METHOD(GetStoppingModel)

		VSL_SET_VALIDVALUE(pdwStoppingModel);

		VSL_RETURN_VALIDVALUES();
	}
	struct __deprecated_RegisterSessionWithServerValidValues
	{
		/*[in]*/ LPCOLESTR pwszServerName;
		HRESULT retValue;
	};

	STDMETHOD(__deprecated_RegisterSessionWithServer)(
		/*[in]*/ LPCOLESTR pwszServerName)
	{
		VSL_DEFINE_MOCK_METHOD(__deprecated_RegisterSessionWithServer)

		VSL_CHECK_VALIDVALUE_STRINGW(pwszServerName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGSESSION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
