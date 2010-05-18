/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROCESSLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROCESSLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IProcessLockNotImpl :
	public IProcessLock
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProcessLockNotImpl)

public:

	typedef IProcessLock Interface;

	virtual ULONG STDMETHODCALLTYPE AddRefOnProcess(){ return ULONG(); }

	virtual ULONG STDMETHODCALLTYPE ReleaseRefOnProcess(){ return ULONG(); }
};

class IProcessLockMockImpl :
	public IProcessLock,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProcessLockMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProcessLockMockImpl)

	typedef IProcessLock Interface;
	struct AddRefOnProcessValidValues
	{
		ULONG retValue;
	};

	virtual ULONG _stdcall AddRefOnProcess()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(AddRefOnProcess)

		VSL_RETURN_VALIDVALUES();
	}
	struct ReleaseRefOnProcessValidValues
	{
		ULONG retValue;
	};

	virtual ULONG _stdcall ReleaseRefOnProcess()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ReleaseRefOnProcess)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROCESSLOCK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
