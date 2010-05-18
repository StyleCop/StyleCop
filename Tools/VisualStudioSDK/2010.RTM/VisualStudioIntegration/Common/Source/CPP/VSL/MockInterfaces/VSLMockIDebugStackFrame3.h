/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGSTACKFRAME3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGSTACKFRAME3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugStackFrame3NotImpl :
	public IDebugStackFrame3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugStackFrame3NotImpl)

public:

	typedef IDebugStackFrame3 Interface;

	STDMETHOD(InterceptCurrentException)(
		/*[in]*/ INTERCEPT_EXCEPTION_ACTION /*dwFlags*/,
		/*[out]*/ UINT64* /*pqwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetUnwindCodeContext)(
		/*[out]*/ IDebugCodeContext2** /*ppCodeContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCodeContext)(
		/*[out]*/ IDebugCodeContext2** /*ppCodeCxt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** /*ppCxt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInfo)(
		/*[in]*/ FRAMEINFO_FLAGS /*dwFieldSpec*/,
		/*[in]*/ UINT /*nRadix*/,
		/*[out]*/ FRAMEINFO* /*pFrameInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPhysicalStackRange)(
		/*[out]*/ UINT64* /*paddrMin*/,
		/*[out]*/ UINT64* /*paddrMax*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpressionContext)(
		/*[out]*/ IDebugExpressionContext2** /*ppExprCxt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLanguageInfo)(
		/*[in,out,ptr]*/ BSTR* /*pbstrLanguage*/,
		/*[in,out,ptr]*/ GUID* /*pguidLanguage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDebugProperty)(
		/*[out]*/ IDebugProperty2** /*ppProperty*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumProperties)(
		/*[in]*/ DEBUGPROP_INFO_FLAGS /*dwFields*/,
		/*[in]*/ UINT /*nRadix*/,
		/*[in]*/ REFGUID /*guidFilter*/,
		/*[in]*/ DWORD /*dwTimeout*/,
		/*[out]*/ ULONG* /*pcelt*/,
		/*[out]*/ IEnumDebugPropertyInfo2** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetThread)(
		/*[out]*/ IDebugThread2** /*ppThread*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugStackFrame3MockImpl :
	public IDebugStackFrame3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugStackFrame3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugStackFrame3MockImpl)

	typedef IDebugStackFrame3 Interface;
	struct InterceptCurrentExceptionValidValues
	{
		/*[in]*/ INTERCEPT_EXCEPTION_ACTION dwFlags;
		/*[out]*/ UINT64* pqwCookie;
		HRESULT retValue;
	};

	STDMETHOD(InterceptCurrentException)(
		/*[in]*/ INTERCEPT_EXCEPTION_ACTION dwFlags,
		/*[out]*/ UINT64* pqwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(InterceptCurrentException)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE(pqwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetUnwindCodeContextValidValues
	{
		/*[out]*/ IDebugCodeContext2** ppCodeContext;
		HRESULT retValue;
	};

	STDMETHOD(GetUnwindCodeContext)(
		/*[out]*/ IDebugCodeContext2** ppCodeContext)
	{
		VSL_DEFINE_MOCK_METHOD(GetUnwindCodeContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCodeContextValidValues
	{
		/*[out]*/ IDebugCodeContext2** ppCodeCxt;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeContext)(
		/*[out]*/ IDebugCodeContext2** ppCodeCxt)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeCxt);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentContextValidValues
	{
		/*[out]*/ IDebugDocumentContext2** ppCxt;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** ppCxt)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppCxt);

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
	struct GetInfoValidValues
	{
		/*[in]*/ FRAMEINFO_FLAGS dwFieldSpec;
		/*[in]*/ UINT nRadix;
		/*[out]*/ FRAMEINFO* pFrameInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetInfo)(
		/*[in]*/ FRAMEINFO_FLAGS dwFieldSpec,
		/*[in]*/ UINT nRadix,
		/*[out]*/ FRAMEINFO* pFrameInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetInfo)

		VSL_CHECK_VALIDVALUE(dwFieldSpec);

		VSL_CHECK_VALIDVALUE(nRadix);

		VSL_SET_VALIDVALUE(pFrameInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPhysicalStackRangeValidValues
	{
		/*[out]*/ UINT64* paddrMin;
		/*[out]*/ UINT64* paddrMax;
		HRESULT retValue;
	};

	STDMETHOD(GetPhysicalStackRange)(
		/*[out]*/ UINT64* paddrMin,
		/*[out]*/ UINT64* paddrMax)
	{
		VSL_DEFINE_MOCK_METHOD(GetPhysicalStackRange)

		VSL_SET_VALIDVALUE(paddrMin);

		VSL_SET_VALIDVALUE(paddrMax);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpressionContextValidValues
	{
		/*[out]*/ IDebugExpressionContext2** ppExprCxt;
		HRESULT retValue;
	};

	STDMETHOD(GetExpressionContext)(
		/*[out]*/ IDebugExpressionContext2** ppExprCxt)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpressionContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppExprCxt);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLanguageInfoValidValues
	{
		/*[in,out,ptr]*/ BSTR* pbstrLanguage;
		/*[in,out,ptr]*/ GUID* pguidLanguage;
		HRESULT retValue;
	};

	STDMETHOD(GetLanguageInfo)(
		/*[in,out,ptr]*/ BSTR* pbstrLanguage,
		/*[in,out,ptr]*/ GUID* pguidLanguage)
	{
		VSL_DEFINE_MOCK_METHOD(GetLanguageInfo)

		VSL_SET_VALIDVALUE_BSTR(pbstrLanguage);

		VSL_SET_VALIDVALUE(pguidLanguage);

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
	struct EnumPropertiesValidValues
	{
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields;
		/*[in]*/ UINT nRadix;
		/*[in]*/ REFGUID guidFilter;
		/*[in]*/ DWORD dwTimeout;
		/*[out]*/ ULONG* pcelt;
		/*[out]*/ IEnumDebugPropertyInfo2** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumProperties)(
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields,
		/*[in]*/ UINT nRadix,
		/*[in]*/ REFGUID guidFilter,
		/*[in]*/ DWORD dwTimeout,
		/*[out]*/ ULONG* pcelt,
		/*[out]*/ IEnumDebugPropertyInfo2** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumProperties)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_CHECK_VALIDVALUE(nRadix);

		VSL_CHECK_VALIDVALUE(guidFilter);

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_SET_VALIDVALUE(pcelt);

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetThreadValidValues
	{
		/*[out]*/ IDebugThread2** ppThread;
		HRESULT retValue;
	};

	STDMETHOD(GetThread)(
		/*[out]*/ IDebugThread2** ppThread)
	{
		VSL_DEFINE_MOCK_METHOD(GetThread)

		VSL_SET_VALIDVALUE_INTERFACE(ppThread);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGSTACKFRAME3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
