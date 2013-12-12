/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDOCUMENTPOSITION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDOCUMENTPOSITION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugDocumentPosition2NotImpl :
	public IDebugDocumentPosition2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentPosition2NotImpl)

public:

	typedef IDebugDocumentPosition2 Interface;

	STDMETHOD(GetFileName)(
		/*[out]*/ BSTR* /*pbstrFileName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocument)(
		/*[out]*/ IDebugDocument2** /*ppDoc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsPositionInDocument)(
		/*[in]*/ IDebugDocument2* /*pDoc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRange)(
		/*[in,out,ptr]*/ TEXT_POSITION* /*pBegPosition*/,
		/*[in,out,ptr]*/ TEXT_POSITION* /*pEndPosition*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDocumentPosition2MockImpl :
	public IDebugDocumentPosition2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDocumentPosition2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDocumentPosition2MockImpl)

	typedef IDebugDocumentPosition2 Interface;
	struct GetFileNameValidValues
	{
		/*[out]*/ BSTR* pbstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(GetFileName)(
		/*[out]*/ BSTR* pbstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(GetFileName)

		VSL_SET_VALIDVALUE_BSTR(pbstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentValidValues
	{
		/*[out]*/ IDebugDocument2** ppDoc;
		HRESULT retValue;
	};

	STDMETHOD(GetDocument)(
		/*[out]*/ IDebugDocument2** ppDoc)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocument)

		VSL_SET_VALIDVALUE_INTERFACE(ppDoc);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsPositionInDocumentValidValues
	{
		/*[in]*/ IDebugDocument2* pDoc;
		HRESULT retValue;
	};

	STDMETHOD(IsPositionInDocument)(
		/*[in]*/ IDebugDocument2* pDoc)
	{
		VSL_DEFINE_MOCK_METHOD(IsPositionInDocument)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDoc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRangeValidValues
	{
		/*[in,out,ptr]*/ TEXT_POSITION* pBegPosition;
		/*[in,out,ptr]*/ TEXT_POSITION* pEndPosition;
		HRESULT retValue;
	};

	STDMETHOD(GetRange)(
		/*[in,out,ptr]*/ TEXT_POSITION* pBegPosition,
		/*[in,out,ptr]*/ TEXT_POSITION* pEndPosition)
	{
		VSL_DEFINE_MOCK_METHOD(GetRange)

		VSL_SET_VALIDVALUE(pBegPosition);

		VSL_SET_VALIDVALUE(pEndPosition);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDOCUMENTPOSITION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
