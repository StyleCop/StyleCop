/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IBLOCKINGLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IBLOCKINGLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IBlockingLockNotImpl :
	public IBlockingLock
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IBlockingLockNotImpl)

public:

	typedef IBlockingLock Interface;

	STDMETHOD(Lock)(
		/*[in]*/ DWORD /*dwTimeout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unlock)()VSL_STDMETHOD_NOTIMPL
};

class IBlockingLockMockImpl :
	public IBlockingLock,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IBlockingLockMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IBlockingLockMockImpl)

	typedef IBlockingLock Interface;
	struct LockValidValues
	{
		/*[in]*/ DWORD dwTimeout;
		HRESULT retValue;
	};

	STDMETHOD(Lock)(
		/*[in]*/ DWORD dwTimeout)
	{
		VSL_DEFINE_MOCK_METHOD(Lock)

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnlockValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Unlock)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Unlock)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IBLOCKINGLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
