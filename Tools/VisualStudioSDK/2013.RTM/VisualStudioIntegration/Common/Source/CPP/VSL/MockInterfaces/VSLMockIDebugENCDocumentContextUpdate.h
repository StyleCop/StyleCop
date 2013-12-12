/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGENCDOCUMENTCONTEXTUPDATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGENCDOCUMENTCONTEXTUPDATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugENCDocumentContextUpdateNotImpl :
	public IDebugENCDocumentContextUpdate
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugENCDocumentContextUpdateNotImpl)

public:

	typedef IDebugENCDocumentContextUpdate Interface;

	STDMETHOD(UpdateDocumentContext)(
		/*[in]*/ IDebugCodeContext2* /*pContext*/,
		/*[in]*/ IDebugDocumentContext2* /*pDocContext*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateStatementPosition)(
		/*[in]*/ TEXT_POSITION /*posBegStatement*/,
		/*[in]*/ TEXT_POSITION /*posEndStatement*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugENCDocumentContextUpdateMockImpl :
	public IDebugENCDocumentContextUpdate,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugENCDocumentContextUpdateMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugENCDocumentContextUpdateMockImpl)

	typedef IDebugENCDocumentContextUpdate Interface;
	struct UpdateDocumentContextValidValues
	{
		/*[in]*/ IDebugCodeContext2* pContext;
		/*[in]*/ IDebugDocumentContext2* pDocContext;
		HRESULT retValue;
	};

	STDMETHOD(UpdateDocumentContext)(
		/*[in]*/ IDebugCodeContext2* pContext,
		/*[in]*/ IDebugDocumentContext2* pDocContext)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateDocumentContext)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pContext);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pDocContext);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateStatementPositionValidValues
	{
		/*[in]*/ TEXT_POSITION posBegStatement;
		/*[in]*/ TEXT_POSITION posEndStatement;
		HRESULT retValue;
	};

	STDMETHOD(UpdateStatementPosition)(
		/*[in]*/ TEXT_POSITION posBegStatement,
		/*[in]*/ TEXT_POSITION posEndStatement)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateStatementPosition)

		VSL_CHECK_VALIDVALUE(posBegStatement);

		VSL_CHECK_VALIDVALUE(posEndStatement);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGENCDOCUMENTCONTEXTUPDATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
