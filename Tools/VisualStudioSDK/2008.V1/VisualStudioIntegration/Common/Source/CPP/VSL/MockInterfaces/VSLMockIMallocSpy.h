/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IMALLOCSPY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IMALLOCSPY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IMallocSpyNotImpl :
	public IMallocSpy
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMallocSpyNotImpl)

public:

	typedef IMallocSpy Interface;

	virtual SIZE_T STDMETHODCALLTYPE PreAlloc(
		/*[in]*/ SIZE_T /*cbRequest*/){ return SIZE_T(); }

	virtual void* STDMETHODCALLTYPE PostAlloc(
		/*[in]*/ void* /*pActual*/){ return NULL; }

	virtual void* STDMETHODCALLTYPE PreFree(
		/*[in]*/ void* /*pRequest*/,
		/*[in]*/ BOOL /*fSpyed*/){ return NULL; }

	virtual void STDMETHODCALLTYPE PostFree(
		/*[in]*/ BOOL /*fSpyed*/){ return ; }

	virtual SIZE_T STDMETHODCALLTYPE PreRealloc(
		/*[in]*/ void* /*pRequest*/,
		/*[in]*/ SIZE_T /*cbRequest*/,
		/*[out]*/ void** /*ppNewRequest*/,
		/*[in]*/ BOOL /*fSpyed*/){ return SIZE_T(); }

	virtual void* STDMETHODCALLTYPE PostRealloc(
		/*[in]*/ void* /*pActual*/,
		/*[in]*/ BOOL /*fSpyed*/){ return NULL; }

	virtual void* STDMETHODCALLTYPE PreGetSize(
		/*[in]*/ void* /*pRequest*/,
		/*[in]*/ BOOL /*fSpyed*/){ return NULL; }

	virtual SIZE_T STDMETHODCALLTYPE PostGetSize(
		/*[in]*/ SIZE_T /*cbActual*/,
		/*[in]*/ BOOL /*fSpyed*/){ return SIZE_T(); }

	virtual void* STDMETHODCALLTYPE PreDidAlloc(
		/*[in]*/ void* /*pRequest*/,
		/*[in]*/ BOOL /*fSpyed*/){ return NULL; }

	virtual int STDMETHODCALLTYPE PostDidAlloc(
		/*[in]*/ void* /*pRequest*/,
		/*[in]*/ BOOL /*fSpyed*/,
		/*[in]*/ int /*fActual*/){ return int(); }

	virtual void STDMETHODCALLTYPE PreHeapMinimize(){ return ; }

	virtual void STDMETHODCALLTYPE PostHeapMinimize(){ return ; }
};

class IMallocSpyMockImpl :
	public IMallocSpy,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IMallocSpyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IMallocSpyMockImpl)

	typedef IMallocSpy Interface;
	struct PreAllocValidValues
	{
		/*[in]*/ SIZE_T cbRequest;
		SIZE_T retValue;
	};

	virtual SIZE_T _stdcall PreAlloc(
		/*[in]*/ SIZE_T cbRequest)
	{
		VSL_DEFINE_MOCK_METHOD(PreAlloc)

		VSL_CHECK_VALIDVALUE(cbRequest);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostAllocValidValues
	{
		/*[in]*/ void* pActual;
		void* retValue;
		size_t pActual_size_in_bytes;
	};

	virtual void* _stdcall PostAlloc(
		/*[in]*/ void* pActual)
	{
		VSL_DEFINE_MOCK_METHOD(PostAlloc)

		VSL_CHECK_VALIDVALUE_PVOID(pActual);

		VSL_RETURN_VALIDVALUES();
	}
	struct PreFreeValidValues
	{
		/*[in]*/ void* pRequest;
		/*[in]*/ BOOL fSpyed;
		void* retValue;
		size_t pRequest_size_in_bytes;
	};

	virtual void* _stdcall PreFree(
		/*[in]*/ void* pRequest,
		/*[in]*/ BOOL fSpyed)
	{
		VSL_DEFINE_MOCK_METHOD(PreFree)

		VSL_CHECK_VALIDVALUE_PVOID(pRequest);

		VSL_CHECK_VALIDVALUE(fSpyed);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostFreeValidValues
	{
		/*[in]*/ BOOL fSpyed;
	};

	virtual void _stdcall PostFree(
		/*[in]*/ BOOL fSpyed)
	{
		VSL_DEFINE_MOCK_METHOD(PostFree)

		VSL_CHECK_VALIDVALUE(fSpyed);

	}
	struct PreReallocValidValues
	{
		/*[in]*/ void* pRequest;
		/*[in]*/ SIZE_T cbRequest;
		/*[out]*/ void** ppNewRequest;
		/*[in]*/ BOOL fSpyed;
		SIZE_T retValue;
		size_t pRequest_size_in_bytes;
	};

	virtual SIZE_T _stdcall PreRealloc(
		/*[in]*/ void* pRequest,
		/*[in]*/ SIZE_T cbRequest,
		/*[out]*/ void** ppNewRequest,
		/*[in]*/ BOOL fSpyed)
	{
		VSL_DEFINE_MOCK_METHOD(PreRealloc)

		VSL_CHECK_VALIDVALUE_PVOID(pRequest);

		VSL_CHECK_VALIDVALUE(cbRequest);

		VSL_SET_VALIDVALUE(ppNewRequest);

		VSL_CHECK_VALIDVALUE(fSpyed);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostReallocValidValues
	{
		/*[in]*/ void* pActual;
		/*[in]*/ BOOL fSpyed;
		void* retValue;
		size_t pActual_size_in_bytes;
	};

	virtual void* _stdcall PostRealloc(
		/*[in]*/ void* pActual,
		/*[in]*/ BOOL fSpyed)
	{
		VSL_DEFINE_MOCK_METHOD(PostRealloc)

		VSL_CHECK_VALIDVALUE_PVOID(pActual);

		VSL_CHECK_VALIDVALUE(fSpyed);

		VSL_RETURN_VALIDVALUES();
	}
	struct PreGetSizeValidValues
	{
		/*[in]*/ void* pRequest;
		/*[in]*/ BOOL fSpyed;
		void* retValue;
		size_t pRequest_size_in_bytes;
	};

	virtual void* _stdcall PreGetSize(
		/*[in]*/ void* pRequest,
		/*[in]*/ BOOL fSpyed)
	{
		VSL_DEFINE_MOCK_METHOD(PreGetSize)

		VSL_CHECK_VALIDVALUE_PVOID(pRequest);

		VSL_CHECK_VALIDVALUE(fSpyed);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostGetSizeValidValues
	{
		/*[in]*/ SIZE_T cbActual;
		/*[in]*/ BOOL fSpyed;
		SIZE_T retValue;
	};

	virtual SIZE_T _stdcall PostGetSize(
		/*[in]*/ SIZE_T cbActual,
		/*[in]*/ BOOL fSpyed)
	{
		VSL_DEFINE_MOCK_METHOD(PostGetSize)

		VSL_CHECK_VALIDVALUE(cbActual);

		VSL_CHECK_VALIDVALUE(fSpyed);

		VSL_RETURN_VALIDVALUES();
	}
	struct PreDidAllocValidValues
	{
		/*[in]*/ void* pRequest;
		/*[in]*/ BOOL fSpyed;
		void* retValue;
		size_t pRequest_size_in_bytes;
	};

	virtual void* _stdcall PreDidAlloc(
		/*[in]*/ void* pRequest,
		/*[in]*/ BOOL fSpyed)
	{
		VSL_DEFINE_MOCK_METHOD(PreDidAlloc)

		VSL_CHECK_VALIDVALUE_PVOID(pRequest);

		VSL_CHECK_VALIDVALUE(fSpyed);

		VSL_RETURN_VALIDVALUES();
	}
	struct PostDidAllocValidValues
	{
		/*[in]*/ void* pRequest;
		/*[in]*/ BOOL fSpyed;
		/*[in]*/ int fActual;
		int retValue;
		size_t pRequest_size_in_bytes;
	};

	virtual int _stdcall PostDidAlloc(
		/*[in]*/ void* pRequest,
		/*[in]*/ BOOL fSpyed,
		/*[in]*/ int fActual)
	{
		VSL_DEFINE_MOCK_METHOD(PostDidAlloc)

		VSL_CHECK_VALIDVALUE_PVOID(pRequest);

		VSL_CHECK_VALIDVALUE(fSpyed);

		VSL_CHECK_VALIDVALUE(fActual);

		VSL_RETURN_VALIDVALUES();
	}

	virtual void _stdcall PreHeapMinimize()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(PreHeapMinimize)

	}

	virtual void _stdcall PostHeapMinimize()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS_NORETURN(PostHeapMinimize)

	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IMALLOCSPY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
