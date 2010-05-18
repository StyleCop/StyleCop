/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDIRECTWRITERLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDIRECTWRITERLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDirectWriterLockNotImpl :
	public IDirectWriterLock
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDirectWriterLockNotImpl)

public:

	typedef IDirectWriterLock Interface;

	STDMETHOD(WaitForWriteAccess)(
		/*[in]*/ DWORD /*dwTimeout*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReleaseWriteAccess)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HaveWriteAccess)()VSL_STDMETHOD_NOTIMPL
};

class IDirectWriterLockMockImpl :
	public IDirectWriterLock,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDirectWriterLockMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDirectWriterLockMockImpl)

	typedef IDirectWriterLock Interface;
	struct WaitForWriteAccessValidValues
	{
		/*[in]*/ DWORD dwTimeout;
		HRESULT retValue;
	};

	STDMETHOD(WaitForWriteAccess)(
		/*[in]*/ DWORD dwTimeout)
	{
		VSL_DEFINE_MOCK_METHOD(WaitForWriteAccess)

		VSL_CHECK_VALIDVALUE(dwTimeout);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseWriteAccessValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ReleaseWriteAccess)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ReleaseWriteAccess)

		VSL_RETURN_VALIDVALUES();
	}
	struct HaveWriteAccessValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HaveWriteAccess)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HaveWriteAccess)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDIRECTWRITERLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
