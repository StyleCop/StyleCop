/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROGRAM3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROGRAM3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugProgram3NotImpl :
	public IDebugProgram3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgram3NotImpl)

public:

	typedef IDebugProgram3 Interface;

	STDMETHOD(ExecuteOnThread)(
		/*[in]*/ IDebugThread2* /*pThread*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumThreads)(
		/*[out]*/ IEnumDebugThreads2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProcess)(
		/*[out]*/ IDebugProcess2** /*ppProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Terminate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Attach)(
		/*[in]*/ IDebugEventCallback2* /*pCallback*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanDetach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Detach)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProgramId)(
		/*[out]*/ GUID* /*pguidProgramId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDebugProperty)(
		/*[out]*/ IDebugProperty2** /*ppProperty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Execute)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Continue)(
		/*[in]*/ IDebugThread2* /*pThread*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Step)(
		/*[in]*/ IDebugThread2* /*pThread*/,
		/*[in]*/ STEPKIND /*sk*/,
		/*[in]*/ STEPUNIT /*step*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CauseBreak)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEngineInfo)(
		/*[out]*/ BSTR* /*pbstrEngine*/,
		/*[out]*/ GUID* /*pguidEngine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumCodeContexts)(
		/*[in]*/ IDebugDocumentPosition2* /*pDocPos*/,
		/*[out]*/ IEnumDebugCodeContexts2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemoryBytes)(
		/*[out]*/ IDebugMemoryBytes2** /*ppMemoryBytes*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDisassemblyStream)(
		/*[in]*/ DISASSEMBLY_STREAM_SCOPE /*dwScope*/,
		/*[in]*/ IDebugCodeContext2* /*pCodeContext*/,
		/*[out]*/ IDebugDisassemblyStream2** /*ppDisassemblyStream*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumModules)(
		/*[out]*/ IEnumDebugModules2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetENCUpdate)(
		/*[out]*/ IDebugENCUpdate** /*ppUpdate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumCodePaths)(
		/*[in,ptr]*/ LPCOLESTR /*pszHint*/,
		/*[in]*/ IDebugCodeContext2* /*pStart*/,
		/*[in]*/ IDebugStackFrame2* /*pFrame*/,
		/*[in]*/ BOOL /*fSource*/,
		/*[out]*/ IEnumCodePaths2** /*ppEnum*/,
		/*[out]*/ IDebugCodeContext2** /*ppSafety*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteDump)(
		/*[in]*/ DUMPTYPE /*DumpType*/,
		/*[in]*/ LPCOLESTR /*pszDumpUrl*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProgram3MockImpl :
	public IDebugProgram3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgram3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProgram3MockImpl)

	typedef IDebugProgram3 Interface;
	struct ExecuteOnThreadValidValues
	{
		/*[in]*/ IDebugThread2* pThread;
		HRESULT retValue;
	};

	STDMETHOD(ExecuteOnThread)(
		/*[in]*/ IDebugThread2* pThread)
	{
		VSL_DEFINE_MOCK_METHOD(ExecuteOnThread)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pThread);

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
	struct GetProcessValidValues
	{
		/*[out]*/ IDebugProcess2** ppProcess;
		HRESULT retValue;
	};

	STDMETHOD(GetProcess)(
		/*[out]*/ IDebugProcess2** ppProcess)
	{
		VSL_DEFINE_MOCK_METHOD(GetProcess)

		VSL_SET_VALIDVALUE_INTERFACE(ppProcess);

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
		HRESULT retValue;
	};

	STDMETHOD(Attach)(
		/*[in]*/ IDebugEventCallback2* pCallback)
	{
		VSL_DEFINE_MOCK_METHOD(Attach)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

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
	struct GetProgramIdValidValues
	{
		/*[out]*/ GUID* pguidProgramId;
		HRESULT retValue;
	};

	STDMETHOD(GetProgramId)(
		/*[out]*/ GUID* pguidProgramId)
	{
		VSL_DEFINE_MOCK_METHOD(GetProgramId)

		VSL_SET_VALIDVALUE(pguidProgramId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDebugPropertyValidValues
	{
		/*[out]*/ IDebugProperty2** ppProperty;
		HRESULT retValue;
	};

	STDMETHOD(GetDebugProperty)(
		/*[out]*/ IDebugProperty2** ppProperty)
	{
		VSL_DEFINE_MOCK_METHOD(GetDebugProperty)

		VSL_SET_VALIDVALUE_INTERFACE(ppProperty);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecuteValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Execute)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Execute)

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
	struct CauseBreakValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CauseBreak)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CauseBreak)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEngineInfoValidValues
	{
		/*[out]*/ BSTR* pbstrEngine;
		/*[out]*/ GUID* pguidEngine;
		HRESULT retValue;
	};

	STDMETHOD(GetEngineInfo)(
		/*[out]*/ BSTR* pbstrEngine,
		/*[out]*/ GUID* pguidEngine)
	{
		VSL_DEFINE_MOCK_METHOD(GetEngineInfo)

		VSL_SET_VALIDVALUE_BSTR(pbstrEngine);

		VSL_SET_VALIDVALUE(pguidEngine);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumCodeContextsValidValues
	{
		/*[in]*/ IDebugDocumentPosition2* pDocPos;
		/*[out]*/ IEnumDebugCodeContexts2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumCodeContexts)(
		/*[in]*/ IDebugDocumentPosition2* pDocPos,
		/*[out]*/ IEnumDebugCodeContexts2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumCodeContexts)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDocPos);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMemoryBytesValidValues
	{
		/*[out]*/ IDebugMemoryBytes2** ppMemoryBytes;
		HRESULT retValue;
	};

	STDMETHOD(GetMemoryBytes)(
		/*[out]*/ IDebugMemoryBytes2** ppMemoryBytes)
	{
		VSL_DEFINE_MOCK_METHOD(GetMemoryBytes)

		VSL_SET_VALIDVALUE_INTERFACE(ppMemoryBytes);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDisassemblyStreamValidValues
	{
		/*[in]*/ DISASSEMBLY_STREAM_SCOPE dwScope;
		/*[in]*/ IDebugCodeContext2* pCodeContext;
		/*[out]*/ IDebugDisassemblyStream2** ppDisassemblyStream;
		HRESULT retValue;
	};

	STDMETHOD(GetDisassemblyStream)(
		/*[in]*/ DISASSEMBLY_STREAM_SCOPE dwScope,
		/*[in]*/ IDebugCodeContext2* pCodeContext,
		/*[out]*/ IDebugDisassemblyStream2** ppDisassemblyStream)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisassemblyStream)

		VSL_CHECK_VALIDVALUE(dwScope);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCodeContext);

		VSL_SET_VALIDVALUE_INTERFACE(ppDisassemblyStream);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumModulesValidValues
	{
		/*[out]*/ IEnumDebugModules2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumModules)(
		/*[out]*/ IEnumDebugModules2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumModules)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetENCUpdateValidValues
	{
		/*[out]*/ IDebugENCUpdate** ppUpdate;
		HRESULT retValue;
	};

	STDMETHOD(GetENCUpdate)(
		/*[out]*/ IDebugENCUpdate** ppUpdate)
	{
		VSL_DEFINE_MOCK_METHOD(GetENCUpdate)

		VSL_SET_VALIDVALUE_INTERFACE(ppUpdate);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumCodePathsValidValues
	{
		/*[in,ptr]*/ LPCOLESTR pszHint;
		/*[in]*/ IDebugCodeContext2* pStart;
		/*[in]*/ IDebugStackFrame2* pFrame;
		/*[in]*/ BOOL fSource;
		/*[out]*/ IEnumCodePaths2** ppEnum;
		/*[out]*/ IDebugCodeContext2** ppSafety;
		HRESULT retValue;
	};

	STDMETHOD(EnumCodePaths)(
		/*[in,ptr]*/ LPCOLESTR pszHint,
		/*[in]*/ IDebugCodeContext2* pStart,
		/*[in]*/ IDebugStackFrame2* pFrame,
		/*[in]*/ BOOL fSource,
		/*[out]*/ IEnumCodePaths2** ppEnum,
		/*[out]*/ IDebugCodeContext2** ppSafety)
	{
		VSL_DEFINE_MOCK_METHOD(EnumCodePaths)

		VSL_CHECK_VALIDVALUE_STRINGW(pszHint);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStart);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pFrame);

		VSL_CHECK_VALIDVALUE(fSource);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_SET_VALIDVALUE_INTERFACE(ppSafety);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteDumpValidValues
	{
		/*[in]*/ DUMPTYPE DumpType;
		/*[in]*/ LPCOLESTR pszDumpUrl;
		HRESULT retValue;
	};

	STDMETHOD(WriteDump)(
		/*[in]*/ DUMPTYPE DumpType,
		/*[in]*/ LPCOLESTR pszDumpUrl)
	{
		VSL_DEFINE_MOCK_METHOD(WriteDump)

		VSL_CHECK_VALIDVALUE(DumpType);

		VSL_CHECK_VALIDVALUE_STRINGW(pszDumpUrl);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROGRAM3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
