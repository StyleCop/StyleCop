/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTSHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTSHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsTshellNotImpl :
	public IVsTshell
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTshellNotImpl)

public:

	typedef IVsTshell Interface;

	STDMETHOD(DebOutputStringW)(
		/*[in]*/ LPCOLESTR /*pwsz*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DebOutputStringA)(
		/*[in]*/ LPSTR /*psz*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddCmdTable)(
		/*[in]*/ UINT /*cCmd*/,
		/*[in,size_is(cCmd)]*/ const TSHELL_CMD[] /*rgpCmd*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetValue)(
		/*[in]*/ LPSTR /*pszKey*/,
		/*[out]*/ UINT* /*piVal*/,
		/*[out]*/ LPSTR* /*ppszVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetValue)(
		/*[in]*/ LPSTR /*pszKey*/,
		/*[in]*/ UINT /*iVal*/,
		/*[in]*/ LPSTR /*pszVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DeleteValue)(
		/*[in]*/ LPSTR /*pszKey*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsExecutingScript)(
		/*[out]*/ BOOL* /*pfRunScript*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExecuteTestCommand)(
		/*[in]*/ LPSTR /*szCommandLine*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetVSLoggingInterface)(
		/*[in]*/ IVsTestLog* /*pVsTestLog*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTestData)(
		/*[in]*/ VSTDTYPE /*dwType*/,
		/*[in,out]*/ GUID* /*pguidData*/,
		/*[in,out]*/ DWORD* /*pdwData*/,
		/*[in,out]*/ void** /*ppvData*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetBreakTransitionComplete)(
		/*[in]*/ BOOL /*bTransitionComplete*/)VSL_STDMETHOD_NOTIMPL
};

class IVsTshellMockImpl :
	public IVsTshell,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsTshellMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsTshellMockImpl)

	typedef IVsTshell Interface;
	struct DebOutputStringWValidValues
	{
		/*[in]*/ LPCOLESTR pwsz;
		HRESULT retValue;
	};

	STDMETHOD(DebOutputStringW)(
		/*[in]*/ LPCOLESTR pwsz)
	{
		VSL_DEFINE_MOCK_METHOD(DebOutputStringW)

		VSL_CHECK_VALIDVALUE_STRINGW(pwsz);

		VSL_RETURN_VALIDVALUES();
	}
	struct DebOutputStringAValidValues
	{
		/*[in]*/ LPSTR psz;
		HRESULT retValue;
	};

	STDMETHOD(DebOutputStringA)(
		/*[in]*/ LPSTR psz)
	{
		VSL_DEFINE_MOCK_METHOD(DebOutputStringA)

		VSL_CHECK_VALIDVALUE_STRINGA(psz);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddCmdTableValidValues
	{
		/*[in]*/ UINT cCmd;
		/*[in,size_is(cCmd)]*/ TSHELL_CMD* rgpCmd;
		HRESULT retValue;
	};

	STDMETHOD(AddCmdTable)(
		/*[in]*/ UINT cCmd,
		/*[in,size_is(cCmd)]*/ const TSHELL_CMD rgpCmd[])
	{
		VSL_DEFINE_MOCK_METHOD(AddCmdTable)

		VSL_CHECK_VALIDVALUE(cCmd);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgpCmd, cCmd*sizeof(rgpCmd[0]), validValues.cCmd*sizeof(validValues.rgpCmd[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct GetValueValidValues
	{
		/*[in]*/ LPSTR pszKey;
		/*[out]*/ UINT* piVal;
		/*[out]*/ LPSTR* ppszVal;
		HRESULT retValue;
	};

	STDMETHOD(GetValue)(
		/*[in]*/ LPSTR pszKey,
		/*[out]*/ UINT* piVal,
		/*[out]*/ LPSTR* ppszVal)
	{
		VSL_DEFINE_MOCK_METHOD(GetValue)

		VSL_CHECK_VALIDVALUE_STRINGA(pszKey);

		VSL_SET_VALIDVALUE(piVal);

		VSL_SET_VALIDVALUE(ppszVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetValueValidValues
	{
		/*[in]*/ LPSTR pszKey;
		/*[in]*/ UINT iVal;
		/*[in]*/ LPSTR pszVal;
		HRESULT retValue;
	};

	STDMETHOD(SetValue)(
		/*[in]*/ LPSTR pszKey,
		/*[in]*/ UINT iVal,
		/*[in]*/ LPSTR pszVal)
	{
		VSL_DEFINE_MOCK_METHOD(SetValue)

		VSL_CHECK_VALIDVALUE_STRINGA(pszKey);

		VSL_CHECK_VALIDVALUE(iVal);

		VSL_CHECK_VALIDVALUE_STRINGA(pszVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct DeleteValueValidValues
	{
		/*[in]*/ LPSTR pszKey;
		HRESULT retValue;
	};

	STDMETHOD(DeleteValue)(
		/*[in]*/ LPSTR pszKey)
	{
		VSL_DEFINE_MOCK_METHOD(DeleteValue)

		VSL_CHECK_VALIDVALUE_STRINGA(pszKey);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsExecutingScriptValidValues
	{
		/*[out]*/ BOOL* pfRunScript;
		HRESULT retValue;
	};

	STDMETHOD(IsExecutingScript)(
		/*[out]*/ BOOL* pfRunScript)
	{
		VSL_DEFINE_MOCK_METHOD(IsExecutingScript)

		VSL_SET_VALIDVALUE(pfRunScript);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecuteTestCommandValidValues
	{
		/*[in]*/ LPSTR szCommandLine;
		HRESULT retValue;
	};

	STDMETHOD(ExecuteTestCommand)(
		/*[in]*/ LPSTR szCommandLine)
	{
		VSL_DEFINE_MOCK_METHOD(ExecuteTestCommand)

		VSL_CHECK_VALIDVALUE_STRINGA(szCommandLine);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetVSLoggingInterfaceValidValues
	{
		/*[in]*/ IVsTestLog* pVsTestLog;
		HRESULT retValue;
	};

	STDMETHOD(SetVSLoggingInterface)(
		/*[in]*/ IVsTestLog* pVsTestLog)
	{
		VSL_DEFINE_MOCK_METHOD(SetVSLoggingInterface)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pVsTestLog);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTestDataValidValues
	{
		/*[in]*/ VSTDTYPE dwType;
		/*[in,out]*/ GUID* pguidData;
		/*[in,out]*/ DWORD* pdwData;
		/*[in,out]*/ void** ppvData;
		HRESULT retValue;
	};

	STDMETHOD(GetTestData)(
		/*[in]*/ VSTDTYPE dwType,
		/*[in,out]*/ GUID* pguidData,
		/*[in,out]*/ DWORD* pdwData,
		/*[in,out]*/ void** ppvData)
	{
		VSL_DEFINE_MOCK_METHOD(GetTestData)

		VSL_CHECK_VALIDVALUE(dwType);

		VSL_SET_VALIDVALUE(pguidData);

		VSL_SET_VALIDVALUE(pdwData);

		VSL_SET_VALIDVALUE(ppvData);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetBreakTransitionCompleteValidValues
	{
		/*[in]*/ BOOL bTransitionComplete;
		HRESULT retValue;
	};

	STDMETHOD(SetBreakTransitionComplete)(
		/*[in]*/ BOOL bTransitionComplete)
	{
		VSL_DEFINE_MOCK_METHOD(SetBreakTransitionComplete)

		VSL_CHECK_VALIDVALUE(bTransitionComplete);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTSHELL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
