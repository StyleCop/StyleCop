/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISYNCHRONIZEMUTEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISYNCHRONIZEMUTEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ISynchronizeMutexNotImpl :
	public ISynchronizeMutex
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeMutexNotImpl)

public:

	typedef ISynchronizeMutex Interface;

	STDMETHOD(ReleaseMutex)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Wait)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ DWORD /*dwMilliseconds*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Signal)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Reset)()VSL_STDMETHOD_NOTIMPL
};

class ISynchronizeMutexMockImpl :
	public ISynchronizeMutex,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeMutexMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISynchronizeMutexMockImpl)

	typedef ISynchronizeMutex Interface;
	struct ReleaseMutexValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ReleaseMutex)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ReleaseMutex)

		VSL_RETURN_VALIDVALUES();
	}
	struct WaitValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ DWORD dwMilliseconds;
		HRESULT retValue;
	};

	STDMETHOD(Wait)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ DWORD dwMilliseconds)
	{
		VSL_DEFINE_MOCK_METHOD(Wait)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(dwMilliseconds);

		VSL_RETURN_VALIDVALUES();
	}
	struct SignalValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Signal)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Signal)

		VSL_RETURN_VALIDVALUES();
	}
	struct ResetValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Reset)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Reset)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISYNCHRONIZEMUTEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
