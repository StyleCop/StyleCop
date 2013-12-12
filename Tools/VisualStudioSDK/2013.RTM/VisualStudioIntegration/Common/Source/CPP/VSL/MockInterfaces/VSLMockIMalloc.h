/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IMALLOC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IMALLOC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IMallocNotImpl :
	public IMalloc
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMallocNotImpl)

public:

	typedef IMalloc Interface;

	virtual void* STDMETHODCALLTYPE Alloc(
		/*[in]*/ SIZE_T /*cb*/){ return NULL; }

	virtual void* STDMETHODCALLTYPE Realloc(
		/*[in]*/ void* /*pv*/,
		/*[in]*/ SIZE_T /*cb*/){ return NULL; }

	virtual void STDMETHODCALLTYPE Free(
		/*[in]*/ void* /*pv*/){ return ; }

	virtual SIZE_T STDMETHODCALLTYPE GetSize(
		/*[in]*/ void* /*pv*/){ return SIZE_T(); }

	virtual int STDMETHODCALLTYPE DidAlloc(
		/*[in]*/ void* /*pv*/){ return int(); }

	virtual void STDMETHODCALLTYPE HeapMinimize(){ return ; }
};

class IMallocMockImpl :
	public IMalloc,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMallocMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IMallocMockImpl)

	typedef IMalloc Interface;
	struct AllocValidValues
	{
		/*[in]*/ SIZE_T cb;
		void* retValue;
	};

	virtual void* _stdcall Alloc(
		/*[in]*/ SIZE_T cb)
	{
		VSL_DEFINE_MOCK_METHOD(Alloc)

		VSL_CHECK_VALIDVALUE(cb);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReallocValidValues
	{
		/*[in]*/ void* pv;
		/*[in]*/ SIZE_T cb;
		void* retValue;
		size_t pv_size_in_bytes;
	};

	virtual void* _stdcall Realloc(
		/*[in]*/ void* pv,
		/*[in]*/ SIZE_T cb)
	{
		VSL_DEFINE_MOCK_METHOD(Realloc)

		VSL_CHECK_VALIDVALUE_PVOID(pv);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreeValidValues
	{
		/*[in]*/ void* pv;
		size_t pv_size_in_bytes;
	};

	virtual void _stdcall Free(
		/*[in]*/ void* pv)
	{
		VSL_DEFINE_MOCK_METHOD(Free)

		VSL_CHECK_VALIDVALUE_PVOID(pv);

	}
	struct GetSizeValidValues
	{
		/*[in]*/ void* pv;
		SIZE_T retValue;
		size_t pv_size_in_bytes;
	};

	virtual SIZE_T _stdcall GetSize(
		/*[in]*/ void* pv)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_CHECK_VALIDVALUE_PVOID(pv);

		VSL_RETURN_VALIDVALUES();
	}
	struct DidAllocValidValues
	{
		/*[in]*/ void* pv;
		int retValue;
		size_t pv_size_in_bytes;
	};

	virtual int _stdcall DidAlloc(
		/*[in]*/ void* pv)
	{
		VSL_DEFINE_MOCK_METHOD(DidAlloc)

		VSL_CHECK_VALIDVALUE_PVOID(pv);

		VSL_RETURN_VALIDVALUES();
	}

	virtual void _stdcall HeapMinimize()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(HeapMinimize)

	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IMALLOC_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
