/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IASYNCMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IASYNCMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IAsyncManagerNotImpl :
	public IAsyncManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IAsyncManagerNotImpl)

public:

	typedef IAsyncManager Interface;

	STDMETHOD(CompleteCall)(
		/*[in]*/ HRESULT /*Result*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCallContext)(
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ void** /*pInterface*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetState)(
		/*[out]*/ ULONG* /*pulStateFlags*/)VSL_STDMETHOD_NOTIMPL
};

class IAsyncManagerMockImpl :
	public IAsyncManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IAsyncManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IAsyncManagerMockImpl)

	typedef IAsyncManager Interface;
	struct CompleteCallValidValues
	{
		/*[in]*/ HRESULT Result;
		HRESULT retValue;
	};

	STDMETHOD(CompleteCall)(
		/*[in]*/ HRESULT Result)
	{
		VSL_DEFINE_MOCK_METHOD(CompleteCall)

		VSL_CHECK_VALIDVALUE(Result);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCallContextValidValues
	{
		/*[in]*/ REFIID riid;
		/*[out]*/ void** pInterface;
		HRESULT retValue;
	};

	STDMETHOD(GetCallContext)(
		/*[in]*/ REFIID riid,
		/*[out]*/ void** pInterface)
	{
		VSL_DEFINE_MOCK_METHOD(GetCallContext)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(pInterface);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStateValidValues
	{
		/*[out]*/ ULONG* pulStateFlags;
		HRESULT retValue;
	};

	STDMETHOD(GetState)(
		/*[out]*/ ULONG* pulStateFlags)
	{
		VSL_DEFINE_MOCK_METHOD(GetState)

		VSL_SET_VALIDVALUE(pulStateFlags);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IASYNCMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
