/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGCANSTOPEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGCANSTOPEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugCanStopEvent2NotImpl :
	public IDebugCanStopEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCanStopEvent2NotImpl)

public:

	typedef IDebugCanStopEvent2 Interface;

	STDMETHOD(GetReason)(
		/*[out]*/ CANSTOP_REASON* /*pcr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CanStop)(
		/*[in]*/ BOOL /*fCanStop*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** /*ppDocCxt*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCodeContext)(
		/*[out]*/ IDebugCodeContext2** /*ppCodeContext*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugCanStopEvent2MockImpl :
	public IDebugCanStopEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugCanStopEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugCanStopEvent2MockImpl)

	typedef IDebugCanStopEvent2 Interface;
	struct GetReasonValidValues
	{
		/*[out]*/ CANSTOP_REASON* pcr;
		HRESULT retValue;
	};

	STDMETHOD(GetReason)(
		/*[out]*/ CANSTOP_REASON* pcr)
	{
		VSL_DEFINE_MOCK_METHOD(GetReason)

		VSL_SET_VALIDVALUE(pcr);

		VSL_RETURN_VALIDVALUES();
	}
	struct CanStopValidValues
	{
		/*[in]*/ BOOL fCanStop;
		HRESULT retValue;
	};

	STDMETHOD(CanStop)(
		/*[in]*/ BOOL fCanStop)
	{
		VSL_DEFINE_MOCK_METHOD(CanStop)

		VSL_CHECK_VALIDVALUE(fCanStop);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDocumentContextValidValues
	{
		/*[out]*/ IDebugDocumentContext2** ppDocCxt;
		HRESULT retValue;
	};

	STDMETHOD(GetDocumentContext)(
		/*[out]*/ IDebugDocumentContext2** ppDocCxt)
	{
		VSL_DEFINE_MOCK_METHOD(GetDocumentContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppDocCxt);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCodeContextValidValues
	{
		/*[out]*/ IDebugCodeContext2** ppCodeContext;
		HRESULT retValue;
	};

	STDMETHOD(GetCodeContext)(
		/*[out]*/ IDebugCodeContext2** ppCodeContext)
	{
		VSL_DEFINE_MOCK_METHOD(GetCodeContext)

		VSL_SET_VALIDVALUE_INTERFACE(ppCodeContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGCANSTOPEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
