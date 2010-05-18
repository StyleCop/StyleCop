/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGENGINE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGENGINE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugEngine3NotImpl :
	public IDebugEngine3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngine3NotImpl)

public:

	typedef IDebugEngine3 Interface;

	STDMETHOD(SetSymbolPath)(
		/*[in]*/ LPCOLESTR /*szSymbolSearchPath*/,
		/*[in]*/ LPCOLESTR /*szSymbolCachePath*/,
		/*[in]*/ LOAD_SYMBOLS_FLAGS /*Flags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadSymbols)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetJustMyCodeState)(
		/*[in]*/ BOOL /*fUpdate*/,
		/*[in]*/ DWORD /*dwModules*/,
		/*[in,size_is(dwModules),ptr]*/ JMC_CODE_SPEC* /*rgJMCSpec*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetEngineGuid)(
		/*[in]*/ GUID* /*guidEngine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetAllExceptions)(
		/*[in]*/ EXCEPTION_STATE /*dwState*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumPrograms)(
		/*[out]*/ IEnumDebugPrograms2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Attach)(
		/*[in,size_is(celtPrograms),length_is(celtPrograms)]*/ IDebugProgram2** /*rgpPrograms*/,
		/*[in,size_is(celtPrograms),length_is(celtPrograms)]*/ IDebugProgramNode2** /*rgpProgramNodes*/,
		/*[in]*/ DWORD /*celtPrograms*/,
		/*[in]*/ IDebugEventCallback2* /*pCallback*/,
		/*[in]*/ ATTACH_REASON /*dwReason*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreatePendingBreakpoint)(
		/*[in]*/ IDebugBreakpointRequest2* /*pBPRequest*/,
		/*[out]*/ IDebugPendingBreakpoint2** /*ppPendingBP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetException)(
		/*[in]*/ EXCEPTION_INFO* /*pException*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveSetException)(
		/*[in]*/ EXCEPTION_INFO* /*pException*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAllSetExceptions)(
		/*[in]*/ REFGUID /*guidType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEngineId)(
		/*[out]*/ GUID* /*pguidEngine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DestroyProgram)(
		/*[in]*/ IDebugProgram2* /*pProgram*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ContinueFromSynchronousEvent)(
		/*[in]*/ IDebugEvent2* /*pEvent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLocale)(
		/*[in]*/ WORD /*wLangID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetRegistryRoot)(
		/*[in,ptr]*/ LPCOLESTR /*pszRegistryRoot*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetMetric)(
		/*[in]*/ LPCOLESTR /*pszMetric*/,
		/*[in]*/ VARIANT /*varValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CauseBreak)()VSL_STDMETHOD_NOTIMPL
};

class IDebugEngine3MockImpl :
	public IDebugEngine3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngine3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugEngine3MockImpl)

	typedef IDebugEngine3 Interface;
	struct SetSymbolPathValidValues
	{
		/*[in]*/ LPCOLESTR szSymbolSearchPath;
		/*[in]*/ LPCOLESTR szSymbolCachePath;
		/*[in]*/ LOAD_SYMBOLS_FLAGS Flags;
		HRESULT retValue;
	};

	STDMETHOD(SetSymbolPath)(
		/*[in]*/ LPCOLESTR szSymbolSearchPath,
		/*[in]*/ LPCOLESTR szSymbolCachePath,
		/*[in]*/ LOAD_SYMBOLS_FLAGS Flags)
	{
		VSL_DEFINE_MOCK_METHOD(SetSymbolPath)

		VSL_CHECK_VALIDVALUE_STRINGW(szSymbolSearchPath);

		VSL_CHECK_VALIDVALUE_STRINGW(szSymbolCachePath);

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadSymbolsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(LoadSymbols)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(LoadSymbols)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetJustMyCodeStateValidValues
	{
		/*[in]*/ BOOL fUpdate;
		/*[in]*/ DWORD dwModules;
		/*[in,size_is(dwModules),ptr]*/ JMC_CODE_SPEC* rgJMCSpec;
		HRESULT retValue;
	};

	STDMETHOD(SetJustMyCodeState)(
		/*[in]*/ BOOL fUpdate,
		/*[in]*/ DWORD dwModules,
		/*[in,size_is(dwModules),ptr]*/ JMC_CODE_SPEC* rgJMCSpec)
	{
		VSL_DEFINE_MOCK_METHOD(SetJustMyCodeState)

		VSL_CHECK_VALIDVALUE(fUpdate);

		VSL_CHECK_VALIDVALUE(dwModules);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgJMCSpec, dwModules*sizeof(rgJMCSpec[0]), validValues.dwModules*sizeof(validValues.rgJMCSpec[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct SetEngineGuidValidValues
	{
		/*[in]*/ GUID* guidEngine;
		HRESULT retValue;
	};

	STDMETHOD(SetEngineGuid)(
		/*[in]*/ GUID* guidEngine)
	{
		VSL_DEFINE_MOCK_METHOD(SetEngineGuid)

		VSL_CHECK_VALIDVALUE_POINTER(guidEngine);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetAllExceptionsValidValues
	{
		/*[in]*/ EXCEPTION_STATE dwState;
		HRESULT retValue;
	};

	STDMETHOD(SetAllExceptions)(
		/*[in]*/ EXCEPTION_STATE dwState)
	{
		VSL_DEFINE_MOCK_METHOD(SetAllExceptions)

		VSL_CHECK_VALIDVALUE(dwState);

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
	struct AttachValidValues
	{
		/*[in,size_is(celtPrograms),length_is(celtPrograms)]*/ IDebugProgram2** rgpPrograms;
		/*[in,size_is(celtPrograms),length_is(celtPrograms)]*/ IDebugProgramNode2** rgpProgramNodes;
		/*[in]*/ DWORD celtPrograms;
		/*[in]*/ IDebugEventCallback2* pCallback;
		/*[in]*/ ATTACH_REASON dwReason;
		HRESULT retValue;
	};

	STDMETHOD(Attach)(
		/*[in,size_is(celtPrograms),length_is(celtPrograms)]*/ IDebugProgram2** rgpPrograms,
		/*[in,size_is(celtPrograms),length_is(celtPrograms)]*/ IDebugProgramNode2** rgpProgramNodes,
		/*[in]*/ DWORD celtPrograms,
		/*[in]*/ IDebugEventCallback2* pCallback,
		/*[in]*/ ATTACH_REASON dwReason)
	{
		VSL_DEFINE_MOCK_METHOD(Attach)

		VSL_CHECK_VALIDVALUE_ARRAY(rgpPrograms, celtPrograms, validValues.celtPrograms);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpProgramNodes, celtPrograms, validValues.celtPrograms);

		VSL_CHECK_VALIDVALUE(celtPrograms);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_CHECK_VALIDVALUE(dwReason);

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
	struct GetEngineIdValidValues
	{
		/*[out]*/ GUID* pguidEngine;
		HRESULT retValue;
	};

	STDMETHOD(GetEngineId)(
		/*[out]*/ GUID* pguidEngine)
	{
		VSL_DEFINE_MOCK_METHOD(GetEngineId)

		VSL_SET_VALIDVALUE(pguidEngine);

		VSL_RETURN_VALIDVALUES();
	}
	struct DestroyProgramValidValues
	{
		/*[in]*/ IDebugProgram2* pProgram;
		HRESULT retValue;
	};

	STDMETHOD(DestroyProgram)(
		/*[in]*/ IDebugProgram2* pProgram)
	{
		VSL_DEFINE_MOCK_METHOD(DestroyProgram)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgram);

		VSL_RETURN_VALIDVALUES();
	}
	struct ContinueFromSynchronousEventValidValues
	{
		/*[in]*/ IDebugEvent2* pEvent;
		HRESULT retValue;
	};

	STDMETHOD(ContinueFromSynchronousEvent)(
		/*[in]*/ IDebugEvent2* pEvent)
	{
		VSL_DEFINE_MOCK_METHOD(ContinueFromSynchronousEvent)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEvent);

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
	struct SetMetricValidValues
	{
		/*[in]*/ LPCOLESTR pszMetric;
		/*[in]*/ VARIANT varValue;
		HRESULT retValue;
	};

	STDMETHOD(SetMetric)(
		/*[in]*/ LPCOLESTR pszMetric,
		/*[in]*/ VARIANT varValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetMetric)

		VSL_CHECK_VALIDVALUE_STRINGW(pszMetric);

		VSL_CHECK_VALIDVALUE(varValue);

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
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGENGINE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
