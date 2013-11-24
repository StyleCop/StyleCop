/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IFILLLOCKBYTES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IFILLLOCKBYTES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IFillLockBytesNotImpl :
	public IFillLockBytes
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IFillLockBytesNotImpl)

public:

	typedef IFillLockBytes Interface;

	STDMETHOD(FillAppend)(
		/*[in,size_is(cb)]*/ const void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbWritten*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FillAt)(
		/*[in]*/ ULARGE_INTEGER /*ulOffset*/,
		/*[in,size_is(cb)]*/ const void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbWritten*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetFillSize)(
		/*[in]*/ ULARGE_INTEGER /*ulSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Terminate)(
		/*[in]*/ BOOL /*bCanceled*/)VSL_STDMETHOD_NOTIMPL
};

class IFillLockBytesMockImpl :
	public IFillLockBytes,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IFillLockBytesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IFillLockBytesMockImpl)

	typedef IFillLockBytes Interface;
	struct FillAppendValidValues
	{
		/*[in,size_is(cb)]*/ void* pv;
		/*[in]*/ ULONG cb;
		/*[out]*/ ULONG* pcbWritten;
		HRESULT retValue;
		size_t pv_size_in_bytes;
	};

	STDMETHOD(FillAppend)(
		/*[in,size_is(cb)]*/ const void* pv,
		/*[in]*/ ULONG cb,
		/*[out]*/ ULONG* pcbWritten)
	{
		VSL_DEFINE_MOCK_METHOD(FillAppend)

		VSL_CHECK_VALIDVALUE_MEMCMP(pv, cb, validValues.cb);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_SET_VALIDVALUE(pcbWritten);

		VSL_RETURN_VALIDVALUES();
	}
	struct FillAtValidValues
	{
		/*[in]*/ ULARGE_INTEGER ulOffset;
		/*[in,size_is(cb)]*/ void* pv;
		/*[in]*/ ULONG cb;
		/*[out]*/ ULONG* pcbWritten;
		HRESULT retValue;
		size_t pv_size_in_bytes;
	};

	STDMETHOD(FillAt)(
		/*[in]*/ ULARGE_INTEGER ulOffset,
		/*[in,size_is(cb)]*/ const void* pv,
		/*[in]*/ ULONG cb,
		/*[out]*/ ULONG* pcbWritten)
	{
		VSL_DEFINE_MOCK_METHOD(FillAt)

		VSL_CHECK_VALIDVALUE(ulOffset);

		VSL_CHECK_VALIDVALUE_MEMCMP(pv, cb, validValues.cb);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_SET_VALIDVALUE(pcbWritten);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetFillSizeValidValues
	{
		/*[in]*/ ULARGE_INTEGER ulSize;
		HRESULT retValue;
	};

	STDMETHOD(SetFillSize)(
		/*[in]*/ ULARGE_INTEGER ulSize)
	{
		VSL_DEFINE_MOCK_METHOD(SetFillSize)

		VSL_CHECK_VALIDVALUE(ulSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct TerminateValidValues
	{
		/*[in]*/ BOOL bCanceled;
		HRESULT retValue;
	};

	STDMETHOD(Terminate)(
		/*[in]*/ BOOL bCanceled)
	{
		VSL_DEFINE_MOCK_METHOD(Terminate)

		VSL_CHECK_VALIDVALUE(bCanceled);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IFILLLOCKBYTES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
