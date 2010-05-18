/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROCESS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROCESS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugProcess3NotImpl :
	public IDebugProcess3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProcess3NotImpl)

public:

	typedef IDebugProcess3 Interface;

	STDMETHOD(Execute)(
		/*[in]*/ IDebugThread2* /*pThread*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Continue)(
		/*[in]*/ IDebugThread2* /*pThread*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Step)(
		/*[in]*/ IDebugThread2* /*pThread*/,
		/*[in]*/ STEPKIND /*sk*/,
		/*[in]*/ STEPUNIT /*step*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDebugReason)(
		/*[out]*/ DEBUG_REASON* /*pReason*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetHostingProcessLanguage)(
		/*[in]*/ REFGUID /*guidLang*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostingProcessLanguage)(
		/*[out]*/ GUID* /*pguidLang*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DisableENC)(
		/*[in]*/ EncUnavailableReason /*reason*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetENCAvailableState)(
		/*[out]*/ EncUnavailableReason* /*preason*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEngineFilter)(
		/*[out]*/ GUID_ARRAY* /*pEngineArray*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInfo)(
		/*[in]*/ PROCESS_INFO_FIELDS /*Fields*/,
		/*[out]*/ PROCESS_INFO* /*pProcessInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPrograms)(
		/*[out]*/ IEnumDebugPrograms2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[in]*/ GETNAME_TYPE /*gnType*/,
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetServer)(
		/*[out]*/ IDebugCoreServer2** /*ppServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Terminate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Attach)(
		/*[in]*/ IDebugEventCallback2* /*pCallback*/,
		/*[in,size_is(celtSpecificEngines)]*/ GUID* /*rgguidSpecificEngines*/,
		/*[in]*/ DWORD /*celtSpecificEngines*/,
		/*[out,size_is(celtSpecificEngines),length_is(celtSpecificEngines)]*/ HRESULT* /*rghrEngineAttach*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanDetach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Detach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPhysicalProcessId)(
		/*[out]*/ AD_PROCESS_ID* /*pProcessId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProcessId)(
		/*[out]*/ GUID* /*pguidProcessId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttachedSessionName)(
		/*[out]*/ BSTR* /*pbstrSessionName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumThreads)(
		/*[out]*/ IEnumDebugThreads2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CauseBreak)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPort)(
		/*[out]*/ IDebugPort2** /*ppPort*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProcess3MockImpl :
	public IDebugProcess3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProcess3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProcess3MockImpl)

	typedef IDebugProcess3 Interface;
	struct ExecuteValidValues
	{
		/*[in]*/ IDebugThread2* pThread;
		HRESULT retValue;
	};

	STDMETHOD(Execute)(
		/*[in]*/ IDebugThread2* pThread)
	{
		VSL_DEFINE_MOCK_METHOD(Execute)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pThread);

		VSL_RETURN_VALIDVALUES();
	}
	struct ContinueValidValues
	{
		/*[in]*/ IDebugThread2* pThread;
		HRESULT retValue;
	};

	STDMETHOD(Continue)(
		/*[in]*/ IDebugThread2* pThread)
	{
		VSL_DEFINE_MOCK_METHOD(Continue)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pThread);

		VSL_RETURN_VALIDVALUES();
	}
	struct StepValidValues
	{
		/*[in]*/ IDebugThread2* pThread;
		/*[in]*/ STEPKIND sk;
		/*[in]*/ STEPUNIT step;
		HRESULT retValue;
	};

	STDMETHOD(Step)(
		/*[in]*/ IDebugThread2* pThread,
		/*[in]*/ STEPKIND sk,
		/*[in]*/ STEPUNIT step)
	{
		VSL_DEFINE_MOCK_METHOD(Step)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pThread);

		VSL_CHECK_VALIDVALUE(sk);

		VSL_CHECK_VALIDVALUE(step);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDebugReasonValidValues
	{
		/*[out]*/ DEBUG_REASON* pReason;
		HRESULT retValue;
	};

	STDMETHOD(GetDebugReason)(
		/*[out]*/ DEBUG_REASON* pReason)
	{
		VSL_DEFINE_MOCK_METHOD(GetDebugReason)

		VSL_SET_VALIDVALUE(pReason);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetHostingProcessLanguageValidValues
	{
		/*[in]*/ REFGUID guidLang;
		HRESULT retValue;
	};

	STDMETHOD(SetHostingProcessLanguage)(
		/*[in]*/ REFGUID guidLang)
	{
		VSL_DEFINE_MOCK_METHOD(SetHostingProcessLanguage)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostingProcessLanguageValidValues
	{
		/*[out]*/ GUID* pguidLang;
		HRESULT retValue;
	};

	STDMETHOD(GetHostingProcessLanguage)(
		/*[out]*/ GUID* pguidLang)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostingProcessLanguage)

		VSL_SET_VALIDVALUE(pguidLang);

		VSL_RETURN_VALIDVALUES();
	}
	struct DisableENCValidValues
	{
		/*[in]*/ EncUnavailableReason reason;
		HRESULT retValue;
	};

	STDMETHOD(DisableENC)(
		/*[in]*/ EncUnavailableReason reason)
	{
		VSL_DEFINE_MOCK_METHOD(DisableENC)

		VSL_CHECK_VALIDVALUE(reason);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetENCAvailableStateValidValues
	{
		/*[out]*/ EncUnavailableReason* preason;
		HRESULT retValue;
	};

	STDMETHOD(GetENCAvailableState)(
		/*[out]*/ EncUnavailableReason* preason)
	{
		VSL_DEFINE_MOCK_METHOD(GetENCAvailableState)

		VSL_SET_VALIDVALUE(preason);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEngineFilterValidValues
	{
		/*[out]*/ GUID_ARRAY* pEngineArray;
		HRESULT retValue;
	};

	STDMETHOD(GetEngineFilter)(
		/*[out]*/ GUID_ARRAY* pEngineArray)
	{
		VSL_DEFINE_MOCK_METHOD(GetEngineFilter)

		VSL_SET_VALIDVALUE(pEngineArray);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInfoValidValues
	{
		/*[in]*/ PROCESS_INFO_FIELDS Fields;
		/*[out]*/ PROCESS_INFO* pProcessInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetInfo)(
		/*[in]*/ PROCESS_INFO_FIELDS Fields,
		/*[out]*/ PROCESS_INFO* pProcessInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetInfo)

		VSL_CHECK_VALIDVALUE(Fields);

		VSL_SET_VALIDVALUE(pProcessInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumProgramsValidValues
	{
		/*[out]*/ IEnumDebugPrograms2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumPrograms)(
		/*[out]*/ IEnumDebugPrograms2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumPrograms)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameValidValues
	{
		/*[in]*/ GETNAME_TYPE gnType;
		/*[out]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[in]*/ GETNAME_TYPE gnType,
		/*[out]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_CHECK_VALIDVALUE(gnType);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetServerValidValues
	{
		/*[out]*/ IDebugCoreServer2** ppServer;
		HRESULT retValue;
	};

	STDMETHOD(GetServer)(
		/*[out]*/ IDebugCoreServer2** ppServer)
	{
		VSL_DEFINE_MOCK_METHOD(GetServer)

		VSL_SET_VALIDVALUE_INTERFACE(ppServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct TerminateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Terminate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Terminate)

		VSL_RETURN_VALIDVALUES();
	}
	struct AttachValidValues
	{
		/*[in]*/ IDebugEventCallback2* pCallback;
		/*[in,size_is(celtSpecificEngines)]*/ GUID* rgguidSpecificEngines;
		/*[in]*/ DWORD celtSpecificEngines;
		/*[out,size_is(celtSpecificEngines),length_is(celtSpecificEngines)]*/ HRESULT* rghrEngineAttach;
		HRESULT retValue;
	};

	STDMETHOD(Attach)(
		/*[in]*/ IDebugEventCallback2* pCallback,
		/*[in,size_is(celtSpecificEngines)]*/ GUID* rgguidSpecificEngines,
		/*[in]*/ DWORD celtSpecificEngines,
		/*[out,size_is(celtSpecificEngines),length_is(celtSpecificEngines)]*/ HRESULT* rghrEngineAttach)
	{
		VSL_DEFINE_MOCK_METHOD(Attach)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgguidSpecificEngines, celtSpecificEngines*sizeof(rgguidSpecificEngines[0]), validValues.celtSpecificEngines*sizeof(validValues.rgguidSpecificEngines[0]));

		VSL_CHECK_VALIDVALUE(celtSpecificEngines);

		VSL_SET_VALIDVALUE_MEMCPY(rghrEngineAttach, celtSpecificEngines*sizeof(rghrEngineAttach[0]), validValues.celtSpecificEngines*sizeof(validValues.rghrEngineAttach[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct CanDetachValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanDetach)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanDetach)

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
	struct GetPhysicalProcessIdValidValues
	{
		/*[out]*/ AD_PROCESS_ID* pProcessId;
		HRESULT retValue;
	};

	STDMETHOD(GetPhysicalProcessId)(
		/*[out]*/ AD_PROCESS_ID* pProcessId)
	{
		VSL_DEFINE_MOCK_METHOD(GetPhysicalProcessId)

		VSL_SET_VALIDVALUE(pProcessId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProcessIdValidValues
	{
		/*[out]*/ GUID* pguidProcessId;
		HRESULT retValue;
	};

	STDMETHOD(GetProcessId)(
		/*[out]*/ GUID* pguidProcessId)
	{
		VSL_DEFINE_MOCK_METHOD(GetProcessId)

		VSL_SET_VALIDVALUE(pguidProcessId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttachedSessionNameValidValues
	{
		/*[out]*/ BSTR* pbstrSessionName;
		HRESULT retValue;
	};

	STDMETHOD(GetAttachedSessionName)(
		/*[out]*/ BSTR* pbstrSessionName)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttachedSessionName)

		VSL_SET_VALIDVALUE_BSTR(pbstrSessionName);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumThreadsValidValues
	{
		/*[out]*/ IEnumDebugThreads2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumThreads)(
		/*[out]*/ IEnumDebugThreads2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumThreads)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

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
	struct GetPortValidValues
	{
		/*[out]*/ IDebugPort2** ppPort;
		HRESULT retValue;
	};

	STDMETHOD(GetPort)(
		/*[out]*/ IDebugPort2** ppPort)
	{
		VSL_DEFINE_MOCK_METHOD(GetPort)

		VSL_SET_VALIDVALUE_INTERFACE(ppPort);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROCESS3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
