/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDISASSEMBLYSTREAM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDISASSEMBLYSTREAM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugDisassemblyStream2NotImpl :
	public IDebugDisassemblyStream2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDisassemblyStream2NotImpl)

public:

	typedef IDebugDisassemblyStream2 Interface;

	STDMETHOD(Read)(
		/*[in]*/ DWORD /*dwInstructions*/,
		/*[in]*/ DISASSEMBLY_STREAM_FIELDS /*dwFields*/,
		/*[out]*/ DWORD* /*pdwInstructionsRead*/,
		/*[out,size_is(dwInstructions),length_is(*pdwInstructionsRead)]*/ DisassemblyData* /*prgDisassembly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Seek)(
		/*[in]*/ SEEK_START /*dwSeekStart*/,
		/*[in]*/ IDebugCodeContext2* /*pCodeContext*/,
		/*[in]*/ UINT64 /*uCodeLocationId*/,
		/*[in]*/ INT64 /*iInstructions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCodeLocationId)(
		/*[in]*/ IDebugCodeContext2* /*pCodeContext*/,
		/*[out]*/ UINT64* /*puCodeLocationId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCodeContext)(
		/*[in]*/ UINT64 /*uCodeLocationId*/,
		/*[out]*/ IDebugCodeContext2** /*ppCodeContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCurrentLocation)(
		/*[out]*/ UINT64* /*puCodeLocationId*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocument)(
		/*[in]*/ BSTR /*bstrDocumentUrl*/,
		/*[out]*/ IDebugDocument2** /*ppDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetScope)(
		/*[out]*/ DISASSEMBLY_STREAM_SCOPE* /*pdwScope*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSize)(
		/*[out]*/ UINT64* /*pnSize*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDisassemblyStream2MockImpl :
	public IDebugDisassemblyStream2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDisassemblyStream2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDisassemblyStream2MockImpl)

	typedef IDebugDisassemblyStream2 Interface;
	struct ReadValidValues
	{
		/*[in]*/ DWORD dwInstructions;
		/*[in]*/ DISASSEMBLY_STREAM_FIELDS dwFields;
		/*[out]*/ DWORD* pdwInstructionsRead;
		/*[out,size_is(dwInstructions),length_is(*pdwInstructionsRead)]*/ DisassemblyData* prgDisassembly;
		HRESULT retValue;
	};

	STDMETHOD(Read)(
		/*[in]*/ DWORD dwInstructions,
		/*[in]*/ DISASSEMBLY_STREAM_FIELDS dwFields,
		/*[out]*/ DWORD* pdwInstructionsRead,
		/*[out,size_is(dwInstructions),length_is(*pdwInstructionsRead)]*/ DisassemblyData* prgDisassembly)
	{
		VSL_DEFINE_MOCK_METHOD(Read)

		VSL_CHECK_VALIDVALUE(dwInstructions);

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(pdwInstructionsRead);

		VSL_SET_VALIDVALUE_MEMCPY(prgDisassembly, dwInstructions*sizeof(prgDisassembly[0]), *(validValues.pdwInstructionsRead)*sizeof(validValues.prgDisassembly[0]));

		VSL_RETURN_VALIDVALUES();
	}
	struct SeekValidValues
	{
		/*[in]*/ SEEK_START dwSeekStart;
		/*[in]*/ IDebugCodeContext2* pCodeContext;
		/*[in]*/ UINT64 uCodeLocationId;
		/*[in]*/ INT64 iInstructions;
		HRESULT retValue;
	};

	STDMETHOD(Seek)(
		/*[in]*/ SEEK_START dwSeekStart,
		/*[in]*/ IDebugCodeContext2* pCodeContext,
		/*[in]*/ UINT64 uCodeLocationId,
		/*[in]*/ INT64 iInstructions)
	{
		VSL_DEFINE_MOCK_METHOD(Seek)

		VSL_CHECK_VALIDVALUE(dwSeekStart);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCodeContext);

		VSL_CHECK_VALIDVALUE(uCodeLocationId);

		VSL_CHECK_VALIDVALUE(iInstructions);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCodeLocationIdValidValues
	{
		/*[in]*/ IDebugCodeContext2* pCodeContext;
		/*[out]*/ UINT64* puCodeLocationId;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeLocationId)(
		/*[in]*/ IDebugCodeContext2* pCodeContext,
		/*[out]*/ UINT64* puCodeLocationId)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeLocationId)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCodeContext);

		VSL_SET_VALIDVALUE(puCodeLocationId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCodeContextValidValues
	{
		/*[in]*/ UINT64 uCodeLocationId;
		/*[out]*/ IDebugCodeContext2** ppCodeContext;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeContext)(
		/*[in]*/ UINT64 uCodeLocationId,
		/*[out]*/ IDebugCodeContext2** ppCodeContext)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeContext)

		VSL_CHECK_VALIDVALUE(uCodeLocationId);

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCurrentLocationValidValues
	{
		/*[out]*/ UINT64* puCodeLocationId;
		HRESULT retValue;
	};

	STDMETHOD(GetCurrentLocation)(
		/*[out]*/ UINT64* puCodeLocationId)
	{
		VSL_DEFINE_MOCK_METHOD(GetCurrentLocation)

		VSL_SET_VALIDVALUE(puCodeLocationId);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentValidValues
	{
		/*[in]*/ BSTR bstrDocumentUrl;
		/*[out]*/ IDebugDocument2** ppDocument;
		HRESULT retValue;
	};

	STDMETHOD(GetDocument)(
		/*[in]*/ BSTR bstrDocumentUrl,
		/*[out]*/ IDebugDocument2** ppDocument)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocument)

		VSL_CHECK_VALIDVALUE_BSTR(bstrDocumentUrl);

		VSL_SET_VALIDVALUE_INTERFACE(ppDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetScopeValidValues
	{
		/*[out]*/ DISASSEMBLY_STREAM_SCOPE* pdwScope;
		HRESULT retValue;
	};

	STDMETHOD(GetScope)(
		/*[out]*/ DISASSEMBLY_STREAM_SCOPE* pdwScope)
	{
		VSL_DEFINE_MOCK_METHOD(GetScope)

		VSL_SET_VALIDVALUE(pdwScope);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeValidValues
	{
		/*[out]*/ UINT64* pnSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[out]*/ UINT64* pnSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(pnSize);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDISASSEMBLYSTREAM2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
