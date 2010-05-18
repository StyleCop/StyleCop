/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGMDMUTIL2_V7_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGMDMUTIL2_V7_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugMDMUtil2_V7NotImpl :
	public IDebugMDMUtil2_V7
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugMDMUtil2_V7NotImpl)

public:

	typedef IDebugMDMUtil2_V7 Interface;

	STDMETHOD(AddPIDToIgnore)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ DWORD /*dwPid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemovePIDToIgnore)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ DWORD /*dwPid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddPIDToDebug)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ DWORD /*dwPid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemovePIDToDebug)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ DWORD /*dwPid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDynamicDebuggingFlags)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ DYNDEBUGFLAGS /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDynamicDebuggingFlags)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[out]*/ DYNDEBUGFLAGS* /*pdwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDefaultJITServer)(
		/*[in]*/ REFCLSID /*clsidJITServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDefaultJITServer)(
		/*[out]*/ CLSID* /*pClsidJITServer*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RegisterJITDebugEngines)(
		/*[in]*/ REFCLSID /*clsidJITServer*/,
		/*[in,size_is(celtEngs)]*/ GUID* /*arrguidEngines*/,
		/*[in,ptr,size_is(celtEngs)]*/ BOOL* /*arrRemoteFlags*/,
		/*[in]*/ DWORD /*celtEngs*/,
		/*[in]*/ BOOL /*fRegister*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanDebugPID)(
		/*[in]*/ REFGUID /*guidEngine*/,
		/*[in]*/ DWORD /*pid*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugMDMUtil2_V7MockImpl :
	public IDebugMDMUtil2_V7,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugMDMUtil2_V7MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugMDMUtil2_V7MockImpl)

	typedef IDebugMDMUtil2_V7 Interface;
	struct AddPIDToIgnoreValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ DWORD dwPid;
		HRESULT retValue;
	};

	STDMETHOD(AddPIDToIgnore)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ DWORD dwPid)
	{
		VSL_DEFINE_MOCK_METHOD(AddPIDToIgnore)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(dwPid);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemovePIDToIgnoreValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ DWORD dwPid;
		HRESULT retValue;
	};

	STDMETHOD(RemovePIDToIgnore)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ DWORD dwPid)
	{
		VSL_DEFINE_MOCK_METHOD(RemovePIDToIgnore)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(dwPid);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddPIDToDebugValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ DWORD dwPid;
		HRESULT retValue;
	};

	STDMETHOD(AddPIDToDebug)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ DWORD dwPid)
	{
		VSL_DEFINE_MOCK_METHOD(AddPIDToDebug)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(dwPid);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemovePIDToDebugValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ DWORD dwPid;
		HRESULT retValue;
	};

	STDMETHOD(RemovePIDToDebug)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ DWORD dwPid)
	{
		VSL_DEFINE_MOCK_METHOD(RemovePIDToDebug)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(dwPid);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDynamicDebuggingFlagsValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ DYNDEBUGFLAGS dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(SetDynamicDebuggingFlags)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ DYNDEBUGFLAGS dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(SetDynamicDebuggingFlags)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDynamicDebuggingFlagsValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[out]*/ DYNDEBUGFLAGS* pdwFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetDynamicDebuggingFlags)(
		/*[in]*/ REFGUID guidEngine,
		/*[out]*/ DYNDEBUGFLAGS* pdwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetDynamicDebuggingFlags)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_SET_VALIDVALUE(pdwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDefaultJITServerValidValues
	{
		/*[in]*/ REFCLSID clsidJITServer;
		HRESULT retValue;
	};

	STDMETHOD(SetDefaultJITServer)(
		/*[in]*/ REFCLSID clsidJITServer)
	{
		VSL_DEFINE_MOCK_METHOD(SetDefaultJITServer)

		VSL_CHECK_VALIDVALUE(clsidJITServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDefaultJITServerValidValues
	{
		/*[out]*/ CLSID* pClsidJITServer;
		HRESULT retValue;
	};

	STDMETHOD(GetDefaultJITServer)(
		/*[out]*/ CLSID* pClsidJITServer)
	{
		VSL_DEFINE_MOCK_METHOD(GetDefaultJITServer)

		VSL_SET_VALIDVALUE(pClsidJITServer);

		VSL_RETURN_VALIDVALUES();
	}
	struct RegisterJITDebugEnginesValidValues
	{
		/*[in]*/ REFCLSID clsidJITServer;
		/*[in,size_is(celtEngs)]*/ GUID* arrguidEngines;
		/*[in,ptr,size_is(celtEngs)]*/ BOOL* arrRemoteFlags;
		/*[in]*/ DWORD celtEngs;
		/*[in]*/ BOOL fRegister;
		HRESULT retValue;
	};

	STDMETHOD(RegisterJITDebugEngines)(
		/*[in]*/ REFCLSID clsidJITServer,
		/*[in,size_is(celtEngs)]*/ GUID* arrguidEngines,
		/*[in,ptr,size_is(celtEngs)]*/ BOOL* arrRemoteFlags,
		/*[in]*/ DWORD celtEngs,
		/*[in]*/ BOOL fRegister)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterJITDebugEngines)

		VSL_CHECK_VALIDVALUE(clsidJITServer);

		VSL_CHECK_VALIDVALUE_MEMCMP(arrguidEngines, celtEngs*sizeof(arrguidEngines[0]), validValues.celtEngs*sizeof(validValues.arrguidEngines[0]));

		VSL_CHECK_VALIDVALUE_MEMCMP(arrRemoteFlags, celtEngs*sizeof(arrRemoteFlags[0]), validValues.celtEngs*sizeof(validValues.arrRemoteFlags[0]));

		VSL_CHECK_VALIDVALUE(celtEngs);

		VSL_CHECK_VALIDVALUE(fRegister);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanDebugPIDValidValues
	{
		/*[in]*/ REFGUID guidEngine;
		/*[in]*/ DWORD pid;
		HRESULT retValue;
	};

	STDMETHOD(CanDebugPID)(
		/*[in]*/ REFGUID guidEngine,
		/*[in]*/ DWORD pid)
	{
		VSL_DEFINE_MOCK_METHOD(CanDebugPID)

		VSL_CHECK_VALIDVALUE(guidEngine);

		VSL_CHECK_VALIDVALUE(pid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGMDMUTIL2_V7_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
