/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROGRAMNODE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROGRAMNODE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugProgramNode2NotImpl :
	public IDebugProgramNode2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramNode2NotImpl)

public:

	typedef IDebugProgramNode2 Interface;

	STDMETHOD(GetProgramName)(
		/*[out]*/ BSTR* /*pbstrProgramName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostName)(
		/*[in]*/ GETHOSTNAME_TYPE /*dwHostNameType*/,
		/*[out]*/ BSTR* /*pbstrHostName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostPid)(
		/*[out]*/ AD_PROCESS_ID* /*pHostProcessId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHostMachineName_V7)(
		/*[out]*/ BSTR* /*pbstrHostMachineName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Attach_V7)(
		/*[in]*/ IDebugProgram2* /*pMDMProgram*/,
		/*[in]*/ IDebugEventCallback2* /*pCallback*/,
		/*[in]*/ DWORD /*dwReason*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEngineInfo)(
		/*[out]*/ BSTR* /*pbstrEngine*/,
		/*[out]*/ GUID* /*pguidEngine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DetachDebugger_V7)()VSL_STDMETHOD_NOTIMPL
};

class IDebugProgramNode2MockImpl :
	public IDebugProgramNode2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProgramNode2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProgramNode2MockImpl)

	typedef IDebugProgramNode2 Interface;
	struct GetProgramNameValidValues
	{
		/*[out]*/ BSTR* pbstrProgramName;
		HRESULT retValue;
	};

	STDMETHOD(GetProgramName)(
		/*[out]*/ BSTR* pbstrProgramName)
	{
		VSL_DEFINE_MOCK_METHOD(GetProgramName)

		VSL_SET_VALIDVALUE_BSTR(pbstrProgramName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostNameValidValues
	{
		/*[in]*/ GETHOSTNAME_TYPE dwHostNameType;
		/*[out]*/ BSTR* pbstrHostName;
		HRESULT retValue;
	};

	STDMETHOD(GetHostName)(
		/*[in]*/ GETHOSTNAME_TYPE dwHostNameType,
		/*[out]*/ BSTR* pbstrHostName)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostName)

		VSL_CHECK_VALIDVALUE(dwHostNameType);

		VSL_SET_VALIDVALUE_BSTR(pbstrHostName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostPidValidValues
	{
		/*[out]*/ AD_PROCESS_ID* pHostProcessId;
		HRESULT retValue;
	};

	STDMETHOD(GetHostPid)(
		/*[out]*/ AD_PROCESS_ID* pHostProcessId)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostPid)

		VSL_SET_VALIDVALUE(pHostProcessId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHostMachineName_V7ValidValues
	{
		/*[out]*/ BSTR* pbstrHostMachineName;
		HRESULT retValue;
	};

	STDMETHOD(GetHostMachineName_V7)(
		/*[out]*/ BSTR* pbstrHostMachineName)
	{
		VSL_DEFINE_MOCK_METHOD(GetHostMachineName_V7)

		VSL_SET_VALIDVALUE_BSTR(pbstrHostMachineName);

		VSL_RETURN_VALIDVALUES();
	}
	struct Attach_V7ValidValues
	{
		/*[in]*/ IDebugProgram2* pMDMProgram;
		/*[in]*/ IDebugEventCallback2* pCallback;
		/*[in]*/ DWORD dwReason;
		HRESULT retValue;
	};

	STDMETHOD(Attach_V7)(
		/*[in]*/ IDebugProgram2* pMDMProgram,
		/*[in]*/ IDebugEventCallback2* pCallback,
		/*[in]*/ DWORD dwReason)
	{
		VSL_DEFINE_MOCK_METHOD(Attach_V7)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pMDMProgram);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_CHECK_VALIDVALUE(dwReason);

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
	struct DetachDebugger_V7ValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(DetachDebugger_V7)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(DetachDebugger_V7)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROGRAMNODE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
