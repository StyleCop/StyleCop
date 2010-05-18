/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDOCUMENTCONTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDOCUMENTCONTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugDocumentContext2NotImpl :
	public IDebugDocumentContext2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentContext2NotImpl)

public:

	typedef IDebugDocumentContext2 Interface;

	STDMETHOD(GetDocument)(
		/*[out]*/ IDebugDocument2** /*ppDocument*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[in]*/ GETNAME_TYPE /*gnType*/,
		/*[out]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnumCodeContexts)(
		/*[out]*/ IEnumDebugCodeContexts2** /*ppEnumCodeCxts*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLanguageInfo)(
		/*[in,out,ptr]*/ BSTR* /*pbstrLanguage*/,
		/*[in,out,ptr]*/ GUID* /*pguidLanguage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStatementRange)(
		/*[in,out,ptr]*/ TEXT_POSITION* /*pBegPosition*/,
		/*[in,out,ptr]*/ TEXT_POSITION* /*pEndPosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSourceRange)(
		/*[in,out,ptr]*/ TEXT_POSITION* /*pBegPosition*/,
		/*[in,out,ptr]*/ TEXT_POSITION* /*pEndPosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Compare)(
		/*[in]*/ DOCCONTEXT_COMPARE /*compare*/,
		/*[in,size_is(dwDocContextSetLen),length_is(dwDocContextSetLen)]*/ IDebugDocumentContext2** /*rgpDocContextSet*/,
		/*[in]*/ DWORD /*dwDocContextSetLen*/,
		/*[out]*/ DWORD* /*pdwDocContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Seek)(
		/*[in]*/ int /*nCount*/,
		/*[out]*/ IDebugDocumentContext2** /*ppDocContext*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDocumentContext2MockImpl :
	public IDebugDocumentContext2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentContext2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDocumentContext2MockImpl)

	typedef IDebugDocumentContext2 Interface;
	struct GetDocumentValidValues
	{
		/*[out]*/ IDebugDocument2** ppDocument;
		HRESULT retValue;
	};

	STDMETHOD(GetDocument)(
		/*[out]*/ IDebugDocument2** ppDocument)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocument)

		VSL_SET_VALIDVALUE_INTERFACE(ppDocument);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetNameValidValues
	{
		/*[in]*/ GETNAME_TYPE gnType;
		/*[out]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetName)(
		/*[in]*/ GETNAME_TYPE gnType,
		/*[out]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetName)

		VSL_CHECK_VALIDVALUE(gnType);

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnumCodeContextsValidValues
	{
		/*[out]*/ IEnumDebugCodeContexts2** ppEnumCodeCxts;
		HRESULT retValue;
	};

	STDMETHOD(EnumCodeContexts)(
		/*[out]*/ IEnumDebugCodeContexts2** ppEnumCodeCxts)
	{
		VSL_DEFINE_MOCK_METHOD(EnumCodeContexts)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnumCodeCxts);

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
	struct GetStatementRangeValidValues
	{
		/*[in,out,ptr]*/ TEXT_POSITION* pBegPosition;
		/*[in,out,ptr]*/ TEXT_POSITION* pEndPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetStatementRange)(
		/*[in,out,ptr]*/ TEXT_POSITION* pBegPosition,
		/*[in,out,ptr]*/ TEXT_POSITION* pEndPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetStatementRange)

		VSL_SET_VALIDVALUE(pBegPosition);

		VSL_SET_VALIDVALUE(pEndPosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSourceRangeValidValues
	{
		/*[in,out,ptr]*/ TEXT_POSITION* pBegPosition;
		/*[in,out,ptr]*/ TEXT_POSITION* pEndPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetSourceRange)(
		/*[in,out,ptr]*/ TEXT_POSITION* pBegPosition,
		/*[in,out,ptr]*/ TEXT_POSITION* pEndPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetSourceRange)

		VSL_SET_VALIDVALUE(pBegPosition);

		VSL_SET_VALIDVALUE(pEndPosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct CompareValidValues
	{
		/*[in]*/ DOCCONTEXT_COMPARE compare;
		/*[in,size_is(dwDocContextSetLen),length_is(dwDocContextSetLen)]*/ IDebugDocumentContext2** rgpDocContextSet;
		/*[in]*/ DWORD dwDocContextSetLen;
		/*[out]*/ DWORD* pdwDocContext;
		HRESULT retValue;
	};

	STDMETHOD(Compare)(
		/*[in]*/ DOCCONTEXT_COMPARE compare,
		/*[in,size_is(dwDocContextSetLen),length_is(dwDocContextSetLen)]*/ IDebugDocumentContext2** rgpDocContextSet,
		/*[in]*/ DWORD dwDocContextSetLen,
		/*[out]*/ DWORD* pdwDocContext)
	{
		VSL_DEFINE_MOCK_METHOD(Compare)

		VSL_CHECK_VALIDVALUE(compare);

		VSL_CHECK_VALIDVALUE_ARRAY(rgpDocContextSet, dwDocContextSetLen, validValues.dwDocContextSetLen);

		VSL_CHECK_VALIDVALUE(dwDocContextSetLen);

		VSL_SET_VALIDVALUE(pdwDocContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct SeekValidValues
	{
		/*[in]*/ int nCount;
		/*[out]*/ IDebugDocumentContext2** ppDocContext;
		HRESULT retValue;
	};

	STDMETHOD(Seek)(
		/*[in]*/ int nCount,
		/*[out]*/ IDebugDocumentContext2** ppDocContext)
	{
		VSL_DEFINE_MOCK_METHOD(Seek)

		VSL_CHECK_VALIDVALUE(nCount);

		VSL_SET_VALIDVALUE_INTERFACE(ppDocContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDOCUMENTCONTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
