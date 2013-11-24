/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IMESSAGEFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IMESSAGEFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IMessageFilterNotImpl :
	public IMessageFilter
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMessageFilterNotImpl)

public:

	typedef IMessageFilter Interface;

	virtual DWORD STDMETHODCALLTYPE HandleInComingCall(
		/*[in]*/ DWORD /*dwCallType*/,
		/*[in]*/ HTASK /*htaskCaller*/,
		/*[in]*/ DWORD /*dwTickCount*/,
		/*[in]*/ LPINTERFACEINFO /*lpInterfaceInfo*/){ return DWORD(); }

	virtual DWORD STDMETHODCALLTYPE RetryRejectedCall(
		/*[in]*/ HTASK /*htaskCallee*/,
		/*[in]*/ DWORD /*dwTickCount*/,
		/*[in]*/ DWORD /*dwRejectType*/){ return DWORD(); }

	virtual DWORD STDMETHODCALLTYPE MessagePending(
		/*[in]*/ HTASK /*htaskCallee*/,
		/*[in]*/ DWORD /*dwTickCount*/,
		/*[in]*/ DWORD /*dwPendingType*/){ return DWORD(); }
};

class IMessageFilterMockImpl :
	public IMessageFilter,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMessageFilterMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IMessageFilterMockImpl)

	typedef IMessageFilter Interface;
	struct HandleInComingCallValidValues
	{
		/*[in]*/ DWORD dwCallType;
		/*[in]*/ HTASK htaskCaller;
		/*[in]*/ DWORD dwTickCount;
		/*[in]*/ LPINTERFACEINFO lpInterfaceInfo;
		DWORD retValue;
	};

	virtual DWORD _stdcall HandleInComingCall(
		/*[in]*/ DWORD dwCallType,
		/*[in]*/ HTASK htaskCaller,
		/*[in]*/ DWORD dwTickCount,
		/*[in]*/ LPINTERFACEINFO lpInterfaceInfo)
	{
		VSL_DEFINE_MOCK_METHOD(HandleInComingCall)

		VSL_CHECK_VALIDVALUE(dwCallType);

		VSL_CHECK_VALIDVALUE(htaskCaller);

		VSL_CHECK_VALIDVALUE(dwTickCount);

		VSL_CHECK_VALIDVALUE(lpInterfaceInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct RetryRejectedCallValidValues
	{
		/*[in]*/ HTASK htaskCallee;
		/*[in]*/ DWORD dwTickCount;
		/*[in]*/ DWORD dwRejectType;
		DWORD retValue;
	};

	virtual DWORD _stdcall RetryRejectedCall(
		/*[in]*/ HTASK htaskCallee,
		/*[in]*/ DWORD dwTickCount,
		/*[in]*/ DWORD dwRejectType)
	{
		VSL_DEFINE_MOCK_METHOD(RetryRejectedCall)

		VSL_CHECK_VALIDVALUE(htaskCallee);

		VSL_CHECK_VALIDVALUE(dwTickCount);

		VSL_CHECK_VALIDVALUE(dwRejectType);

		VSL_RETURN_VALIDVALUES();
	}
	struct MessagePendingValidValues
	{
		/*[in]*/ HTASK htaskCallee;
		/*[in]*/ DWORD dwTickCount;
		/*[in]*/ DWORD dwPendingType;
		DWORD retValue;
	};

	virtual DWORD _stdcall MessagePending(
		/*[in]*/ HTASK htaskCallee,
		/*[in]*/ DWORD dwTickCount,
		/*[in]*/ DWORD dwPendingType)
	{
		VSL_DEFINE_MOCK_METHOD(MessagePending)

		VSL_CHECK_VALIDVALUE(htaskCallee);

		VSL_CHECK_VALIDVALUE(dwTickCount);

		VSL_CHECK_VALIDVALUE(dwPendingType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IMESSAGEFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
