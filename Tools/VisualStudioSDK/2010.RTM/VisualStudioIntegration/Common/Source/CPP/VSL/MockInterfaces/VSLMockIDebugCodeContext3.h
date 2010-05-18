/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGCODECONTEXT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGCODECONTEXT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugCodeContext3NotImpl :
	public IDebugCodeContext3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCodeContext3NotImpl)

public:

	typedef IDebugCodeContext3 Interface;

	STDMETHOD(GetModule)(
		/*[out]*/ IDebugModule2** /*ppModule*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProcess)(
		/*[out]*/ IDebugProcess2** /*ppProcess*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** /*ppSrcCxt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLanguageInfo)(
		/*[in,out,ptr]*/ BSTR* /*pbstrLanguage*/,
		/*[in,out,ptr]*/ GUID* /*pguidLanguage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[out]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInfo)(
		/*[in]*/ CONTEXT_INFO_FIELDS /*dwFields*/,
		/*[out]*/ CONTEXT_INFO* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Add)(
		/*[in]*/ UINT64 /*dwCount*/,
		/*[out]*/ IDebugMemoryContext2** /*ppMemCxt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Subtract)(
		/*[in]*/ UINT64 /*dwCount*/,
		/*[out]*/ IDebugMemoryContext2** /*ppMemCxt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Compare)(
		/*[in]*/ CONTEXT_COMPARE /*compare*/,
		/*[in,size_is(dwMemoryContextSetLen),length_is(dwMemoryContextSetLen)]*/ IDebugMemoryContext2** /*rgpMemoryContextSet*/,
		/*[in]*/ DWORD /*dwMemoryContextSetLen*/,
		/*[out]*/ DWORD* /*pdwMemoryContext*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugCodeContext3MockImpl :
	public IDebugCodeContext3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCodeContext3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugCodeContext3MockImpl)

	typedef IDebugCodeContext3 Interface;
	struct GetModuleValidValues
	{
		/*[out]*/ IDebugModule2** ppModule;
		HRESULT retValue;
	};

	STDMETHOD(GetModule)(
		/*[out]*/ IDebugModule2** ppModule)
	{
		VSL_DEFINE_MOCK_METHOD(GetModule)

		VSL_SET_VALIDVALUE_INTERFACE(ppModule);

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
	struct GetDocumentContextValidValues
	{
		/*[out]*/ IDebugDocumentContext2** ppSrcCxt;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** ppSrcCxt)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppSrcCxt);

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
		/*[in]*/ CONTEXT_INFO_FIELDS dwFields;
		/*[out]*/ CONTEXT_INFO* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetInfo)(
		/*[in]*/ CONTEXT_INFO_FIELDS dwFields,
		/*[out]*/ CONTEXT_INFO* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddValidValues
	{
		/*[in]*/ UINT64 dwCount;
		/*[out]*/ IDebugMemoryContext2** ppMemCxt;
		HRESULT retValue;
	};

	STDMETHOD(Add)(
		/*[in]*/ UINT64 dwCount,
		/*[out]*/ IDebugMemoryContext2** ppMemCxt)
	{
		VSL_DEFINE_MOCK_METHOD(Add)

		VSL_CHECK_VALIDVALUE(dwCount);

		VSL_SET_VALIDVALUE_INTERFACE(ppMemCxt);

		VSL_RETURN_VALIDVALUES();
	}
	struct SubtractValidValues
	{
		/*[in]*/ UINT64 dwCount;
		/*[out]*/ IDebugMemoryContext2** ppMemCxt;
		HRESULT retValue;
	};

	STDMETHOD(Subtract)(
		/*[in]*/ UINT64 dwCount,
		/*[out]*/ IDebugMemoryContext2** ppMemCxt)
	{
		VSL_DEFINE_MOCK_METHOD(Subtract)

		VSL_CHECK_VALIDVALUE(dwCount);

		VSL_SET_VALIDVALUE_INTERFACE(ppMemCxt);

		VSL_RETURN_VALIDVALUES();
	}
	struct CompareValidValues
	{
		/*[in]*/ CONTEXT_COMPARE compare;
		/*[in,size_is(dwMemoryContextSetLen),length_is(dwMemoryContextSetLen)]*/ IDebugMemoryContext2** rgpMemoryContextSet;
		/*[in]*/ DWORD dwMemoryContextSetLen;
		/*[out]*/ DWORD* pdwMemoryContext;
		HRESULT retValue;
	};

	STDMETHOD(Compare)(
		/*[in]*/ CONTEXT_COMPARE compare,
		/*[in,size_is(dwMemoryContextSetLen),length_is(dwMemoryContextSetLen)]*/ IDebugMemoryContext2** rgpMemoryContextSet,
		/*[in]*/ DWORD dwMemoryContextSetLen,
		/*[out]*/ DWORD* pdwMemoryContext)
	{
		VSL_DEFINE_MOCK_METHOD(Compare)

		VSL_CHECK_VALIDVALUE(compare);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpMemoryContextSet, dwMemoryContextSetLen, validValues.dwMemoryContextSetLen);

		VSL_CHECK_VALIDVALUE(dwMemoryContextSetLen);

		VSL_SET_VALIDVALUE(pdwMemoryContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGCODECONTEXT3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
