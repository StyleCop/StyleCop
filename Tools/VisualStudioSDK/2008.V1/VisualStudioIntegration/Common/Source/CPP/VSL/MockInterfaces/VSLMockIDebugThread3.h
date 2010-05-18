/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGTHREAD3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGTHREAD3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugThread3NotImpl :
	public IDebugThread3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugThread3NotImpl)

public:

	typedef IDebugThread3 Interface;

	STDMETHOD(IsCurrentException)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanRemapLeafFrame)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemapLeafFrame)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumFrameInfo)(
		/*[in]*/ FRAMEINFO_FLAGS /*dwFieldSpec*/,
		/*[in]*/ UINT /*nRadix*/,
		/*[out]*/ IEnumDebugFrameInfo2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetThreadName)(
		/*[in]*/ LPCOLESTR /*pszName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProgram)(
		/*[out]*/ IDebugProgram2** /*ppProgram*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanSetNextStatement)(
		/*[in]*/ IDebugStackFrame2* /*pStackFrame*/,
		/*[in]*/ IDebugCodeContext2* /*pCodeContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetNextStatement)(
		/*[in]*/ IDebugStackFrame2* /*pStackFrame*/,
		/*[in]*/ IDebugCodeContext2* /*pCodeContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetThreadId)(
		/*[out]*/ DWORD* /*pdwThreadId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Suspend)(
		/*[out]*/ DWORD* /*pdwSuspendCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Resume)(
		/*[out]*/ DWORD* /*pdwSuspendCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetThreadProperties)(
		/*[in]*/ THREADPROPERTY_FIELDS /*dwFields*/,
		/*[out]*/ THREADPROPERTIES* /*ptp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLogicalThread)(
		/*[in]*/ IDebugStackFrame2* /*pStackFrame*/,
		/*[out]*/ IDebugLogicalThread2** /*ppLogicalThread*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugThread3MockImpl :
	public IDebugThread3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugThread3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugThread3MockImpl)

	typedef IDebugThread3 Interface;
	struct IsCurrentExceptionValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsCurrentException)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsCurrentException)

		VSL_RETURN_VALIDVALUES();
	}
	struct CanRemapLeafFrameValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(CanRemapLeafFrame)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(CanRemapLeafFrame)

		VSL_RETURN_VALIDVALUES();
	}
	struct RemapLeafFrameValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemapLeafFrame)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemapLeafFrame)

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumFrameInfoValidValues
	{
		/*[in]*/ FRAMEINFO_FLAGS dwFieldSpec;
		/*[in]*/ UINT nRadix;
		/*[out]*/ IEnumDebugFrameInfo2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumFrameInfo)(
		/*[in]*/ FRAMEINFO_FLAGS dwFieldSpec,
		/*[in]*/ UINT nRadix,
		/*[out]*/ IEnumDebugFrameInfo2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumFrameInfo)

		VSL_CHECK_VALIDVALUE(dwFieldSpec);

		VSL_CHECK_VALIDVALUE(nRadix);

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
	struct SetThreadNameValidValues
	{
		/*[in]*/ LPCOLESTR pszName;
		HRESULT retValue;
	};

	STDMETHOD(SetThreadName)(
		/*[in]*/ LPCOLESTR pszName)
	{
		VSL_DEFINE_MOCK_METHOD(SetThreadName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProgramValidValues
	{
		/*[out]*/ IDebugProgram2** ppProgram;
		HRESULT retValue;
	};

	STDMETHOD(GetProgram)(
		/*[out]*/ IDebugProgram2** ppProgram)
	{
		VSL_DEFINE_MOCK_METHOD(GetProgram)

		VSL_SET_VALIDVALUE_INTERFACE(ppProgram);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanSetNextStatementValidValues
	{
		/*[in]*/ IDebugStackFrame2* pStackFrame;
		/*[in]*/ IDebugCodeContext2* pCodeContext;
		HRESULT retValue;
	};

	STDMETHOD(CanSetNextStatement)(
		/*[in]*/ IDebugStackFrame2* pStackFrame,
		/*[in]*/ IDebugCodeContext2* pCodeContext)
	{
		VSL_DEFINE_MOCK_METHOD(CanSetNextStatement)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStackFrame);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCodeContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetNextStatementValidValues
	{
		/*[in]*/ IDebugStackFrame2* pStackFrame;
		/*[in]*/ IDebugCodeContext2* pCodeContext;
		HRESULT retValue;
	};

	STDMETHOD(SetNextStatement)(
		/*[in]*/ IDebugStackFrame2* pStackFrame,
		/*[in]*/ IDebugCodeContext2* pCodeContext)
	{
		VSL_DEFINE_MOCK_METHOD(SetNextStatement)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStackFrame);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCodeContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetThreadIdValidValues
	{
		/*[out]*/ DWORD* pdwThreadId;
		HRESULT retValue;
	};

	STDMETHOD(GetThreadId)(
		/*[out]*/ DWORD* pdwThreadId)
	{
		VSL_DEFINE_MOCK_METHOD(GetThreadId)

		VSL_SET_VALIDVALUE(pdwThreadId);

		VSL_RETURN_VALIDVALUES();
	}
	struct SuspendValidValues
	{
		/*[out]*/ DWORD* pdwSuspendCount;
		HRESULT retValue;
	};

	STDMETHOD(Suspend)(
		/*[out]*/ DWORD* pdwSuspendCount)
	{
		VSL_DEFINE_MOCK_METHOD(Suspend)

		VSL_SET_VALIDVALUE(pdwSuspendCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct ResumeValidValues
	{
		/*[out]*/ DWORD* pdwSuspendCount;
		HRESULT retValue;
	};

	STDMETHOD(Resume)(
		/*[out]*/ DWORD* pdwSuspendCount)
	{
		VSL_DEFINE_MOCK_METHOD(Resume)

		VSL_SET_VALIDVALUE(pdwSuspendCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetThreadPropertiesValidValues
	{
		/*[in]*/ THREADPROPERTY_FIELDS dwFields;
		/*[out]*/ THREADPROPERTIES* ptp;
		HRESULT retValue;
	};

	STDMETHOD(GetThreadProperties)(
		/*[in]*/ THREADPROPERTY_FIELDS dwFields,
		/*[out]*/ THREADPROPERTIES* ptp)
	{
		VSL_DEFINE_MOCK_METHOD(GetThreadProperties)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(ptp);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLogicalThreadValidValues
	{
		/*[in]*/ IDebugStackFrame2* pStackFrame;
		/*[out]*/ IDebugLogicalThread2** ppLogicalThread;
		HRESULT retValue;
	};

	STDMETHOD(GetLogicalThread)(
		/*[in]*/ IDebugStackFrame2* pStackFrame,
		/*[out]*/ IDebugLogicalThread2** ppLogicalThread)
	{
		VSL_DEFINE_MOCK_METHOD(GetLogicalThread)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pStackFrame);

		VSL_SET_VALIDVALUE_INTERFACE(ppLogicalThread);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGTHREAD3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
