/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROGRAMPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROGRAMPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugProgramProvider2NotImpl :
	public IDebugProgramProvider2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramProvider2NotImpl)

public:

	typedef IDebugProgramProvider2 Interface;

	STDMETHOD(GetProviderProcessData)(
		/*[in]*/ PROVIDER_FLAGS /*Flags*/,
		/*[in]*/ IDebugDefaultPort2* /*pPort*/,
		/*[in]*/ AD_PROCESS_ID /*processId*/,
		/*[in]*/ CONST_GUID_ARRAY /*EngineFilter*/,
		/*[out]*/ PROVIDER_PROCESS_DATA* /*pProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProviderProgramNode)(
		/*[in]*/ PROVIDER_FLAGS /*Flags*/,
		/*[in]*/ IDebugDefaultPort2* /*pPort*/,
		/*[in]*/ AD_PROCESS_ID /*processId*/,
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ UINT64 /*programId*/,
		/*[out]*/ IDebugProgramNode2** /*ppProgramNode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WatchForProviderEvents)(
		/*[in]*/ PROVIDER_FLAGS /*Flags*/,
		/*[in]*/ IDebugDefaultPort2* /*pPort*/,
		/*[in]*/ AD_PROCESS_ID /*processId*/,
		/*[in]*/ CONST_GUID_ARRAY /*EngineFilter*/,
		/*[in]*/ REFGUID /*guidLaunchingEngine*/,
		/*[in]*/ IDebugPortNotify2* /*pEventCallback*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetLocale)(
		/*[in]*/ WORD /*wLangID*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProgramProvider2MockImpl :
	public IDebugProgramProvider2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramProvider2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProgramProvider2MockImpl)

	typedef IDebugProgramProvider2 Interface;
	struct GetProviderProcessDataValidValues
	{
		/*[in]*/ PROVIDER_FLAGS Flags;
		/*[in]*/ IDebugDefaultPort2* pPort;
		/*[in]*/ AD_PROCESS_ID processId;
		/*[in]*/ CONST_GUID_ARRAY EngineFilter;
		/*[out]*/ PROVIDER_PROCESS_DATA* pProcess;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderProcessData)(
		/*[in]*/ PROVIDER_FLAGS Flags,
		/*[in]*/ IDebugDefaultPort2* pPort,
		/*[in]*/ AD_PROCESS_ID processId,
		/*[in]*/ CONST_GUID_ARRAY EngineFilter,
		/*[out]*/ PROVIDER_PROCESS_DATA* pProcess)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderProcessData)

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPort);

		VSL_CHECK_VALIDVALUE(processId);

		VSL_CHECK_VALIDVALUE(EngineFilter);

		VSL_SET_VALIDVALUE(pProcess);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProviderProgramNodeValidValues
	{
		/*[in]*/ PROVIDER_FLAGS Flags;
		/*[in]*/ IDebugDefaultPort2* pPort;
		/*[in]*/ AD_PROCESS_ID processId;
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ UINT64 programId;
		/*[out]*/ IDebugProgramNode2** ppProgramNode;
		HRESULT retValue;
	};

	STDMETHOD(GetProviderProgramNode)(
		/*[in]*/ PROVIDER_FLAGS Flags,
		/*[in]*/ IDebugDefaultPort2* pPort,
		/*[in]*/ AD_PROCESS_ID processId,
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ UINT64 programId,
		/*[out]*/ IDebugProgramNode2** ppProgramNode)
	{
		VSL_DEFINE_MOCK_METHOD(GetProviderProgramNode)

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPort);

		VSL_CHECK_VALIDVALUE(processId);

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(programId);

		VSL_SET_VALIDVALUE_INTERFACE(ppProgramNode);

		VSL_RETURN_VALIDVALUES();
	}
	struct WatchForProviderEventsValidValues
	{
		/*[in]*/ PROVIDER_FLAGS Flags;
		/*[in]*/ IDebugDefaultPort2* pPort;
		/*[in]*/ AD_PROCESS_ID processId;
		/*[in]*/ CONST_GUID_ARRAY EngineFilter;
		/*[in]*/ REFGUID guidLaunchingEngine;
		/*[in]*/ IDebugPortNotify2* pEventCallback;
		HRESULT retValue;
	};

	STDMETHOD(WatchForProviderEvents)(
		/*[in]*/ PROVIDER_FLAGS Flags,
		/*[in]*/ IDebugDefaultPort2* pPort,
		/*[in]*/ AD_PROCESS_ID processId,
		/*[in]*/ CONST_GUID_ARRAY EngineFilter,
		/*[in]*/ REFGUID guidLaunchingEngine,
		/*[in]*/ IDebugPortNotify2* pEventCallback)
	{
		VSL_DEFINE_MOCK_METHOD(WatchForProviderEvents)

		VSL_CHECK_VALIDVALUE(Flags);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPort);

		VSL_CHECK_VALIDVALUE(processId);

		VSL_CHECK_VALIDVALUE(EngineFilter);

		VSL_CHECK_VALIDVALUE(guidLaunchingEngine);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEventCallback);

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
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROGRAMPROVIDER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
