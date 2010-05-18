/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDOCUMENTTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDOCUMENTTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugDocumentText2NotImpl :
	public IDebugDocumentText2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentText2NotImpl)

public:

	typedef IDebugDocumentText2 Interface;

	STDMETHOD(GetSize)(
		/*[in,out,ptr]*/ ULONG* /*pcNumLines*/,
		/*[in,out,ptr]*/ ULONG* /*pcNumChars*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetText)(
		/*[in]*/ TEXT_POSITION /*pos*/,
		/*[in]*/ ULONG /*cMaxChars*/,
		/*[out,length_is(*pcNumChars),size_is(cMaxChars)]*/ WCHAR* /*pText*/,
		/*[out]*/ ULONG* /*pcNumChars*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetName)(
		/*[in]*/ GETNAME_TYPE /*gnType*/,
		/*[out]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentClassId)(
		/*[out]*/ CLSID* /*pclsid*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDocumentText2MockImpl :
	public IDebugDocumentText2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentText2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDocumentText2MockImpl)

	typedef IDebugDocumentText2 Interface;
	struct GetSizeValidValues
	{
		/*[in,out,ptr]*/ ULONG* pcNumLines;
		/*[in,out,ptr]*/ ULONG* pcNumChars;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[in,out,ptr]*/ ULONG* pcNumLines,
		/*[in,out,ptr]*/ ULONG* pcNumChars)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(pcNumLines);

		VSL_SET_VALIDVALUE(pcNumChars);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTextValidValues
	{
		/*[in]*/ TEXT_POSITION pos;
		/*[in]*/ ULONG cMaxChars;
		/*[out,length_is(*pcNumChars),size_is(cMaxChars)]*/ WCHAR* pText;
		/*[out]*/ ULONG* pcNumChars;
		HRESULT retValue;
	};

	STDMETHOD(GetText)(
		/*[in]*/ TEXT_POSITION pos,
		/*[in]*/ ULONG cMaxChars,
		/*[out,length_is(*pcNumChars),size_is(cMaxChars)]*/ WCHAR* pText,
		/*[out]*/ ULONG* pcNumChars)
	{
		VSL_DEFINE_MOCK_METHOD(GetText)

		VSL_CHECK_VALIDVALUE(pos);

		VSL_CHECK_VALIDVALUE(cMaxChars);

		VSL_SET_VALIDVALUE_STRINGW(pText, cMaxChars);

		VSL_SET_VALIDVALUE(pcNumChars);

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
	struct GetDocumentClassIdValidValues
	{
		/*[out]*/ CLSID* pclsid;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentClassId)(
		/*[out]*/ CLSID* pclsid)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentClassId)

		VSL_SET_VALIDVALUE(pclsid);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDOCUMENTTEXT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
