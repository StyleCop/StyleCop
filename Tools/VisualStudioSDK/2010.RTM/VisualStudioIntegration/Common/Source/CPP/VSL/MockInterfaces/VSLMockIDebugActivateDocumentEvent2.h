/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGACTIVATEDOCUMENTEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGACTIVATEDOCUMENTEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugActivateDocumentEvent2NotImpl :
	public IDebugActivateDocumentEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugActivateDocumentEvent2NotImpl)

public:

	typedef IDebugActivateDocumentEvent2 Interface;

	STDMETHOD(GetDocument)(
		/*[out]*/ IDebugDocument2** /*ppDoc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** /*ppDocContext*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugActivateDocumentEvent2MockImpl :
	public IDebugActivateDocumentEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugActivateDocumentEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugActivateDocumentEvent2MockImpl)

	typedef IDebugActivateDocumentEvent2 Interface;
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
	struct GetDocumentContextValidValues
	{
		/*[out]*/ IDebugDocumentContext2** ppDocContext;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** ppDocContext)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppDocContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGACTIVATEDOCUMENTEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
