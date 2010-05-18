/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ILOCKBYTES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ILOCKBYTES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ILockBytesNotImpl :
	public ILockBytes
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILockBytesNotImpl)

public:

	typedef ILockBytes Interface;

	STDMETHOD(ReadAt)(
		/*[in]*/ ULARGE_INTEGER /*ulOffset*/,
		/*[out,size_is(cb),length_is(*pcbRead)]*/ void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbRead*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WriteAt)(
		/*[in]*/ ULARGE_INTEGER /*ulOffset*/,
		/*[in,size_is(cb)]*/ const void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbWritten*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Flush)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSize)(
		/*[in]*/ ULARGE_INTEGER /*cb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockRegion)(
		/*[in]*/ ULARGE_INTEGER /*libOffset*/,
		/*[in]*/ ULARGE_INTEGER /*cb*/,
		/*[in]*/ DWORD /*dwLockType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnlockRegion)(
		/*[in]*/ ULARGE_INTEGER /*libOffset*/,
		/*[in]*/ ULARGE_INTEGER /*cb*/,
		/*[in]*/ DWORD /*dwLockType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Stat)(
		/*[out]*/ STATSTG* /*pstatstg*/,
		/*[in]*/ DWORD /*grfStatFlag*/)VSL_STDMETHOD_NOTIMPL
};

class ILockBytesMockImpl :
	public ILockBytes,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILockBytesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ILockBytesMockImpl)

	typedef ILockBytes Interface;
	struct ReadAtValidValues
	{
		/*[in]*/ ULARGE_INTEGER ulOffset;
		/*[out,size_is(cb),length_is(*pcbRead)]*/ void* pv;
		/*[in]*/ ULONG cb;
		/*[out]*/ ULONG* pcbRead;
		HRESULT retValue;
		size_t pv_size_in_bytes;
	};

	STDMETHOD(ReadAt)(
		/*[in]*/ ULARGE_INTEGER ulOffset,
		/*[out,size_is(cb),length_is(*pcbRead)]*/ void* pv,
		/*[in]*/ ULONG cb,
		/*[out]*/ ULONG* pcbRead)
	{
		VSL_DEFINE_MOCK_METHOD(ReadAt)

		VSL_CHECK_VALIDVALUE(ulOffset);

		VSL_SET_VALIDVALUE_MEMCPY(pv, cb, *(validValues.pcbRead));

		VSL_CHECK_VALIDVALUE(cb);

		VSL_SET_VALIDVALUE(pcbRead);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteAtValidValues
	{
		/*[in]*/ ULARGE_INTEGER ulOffset;
		/*[in,size_is(cb)]*/ void* pv;
		/*[in]*/ ULONG cb;
		/*[out]*/ ULONG* pcbWritten;
		HRESULT retValue;
		size_t pv_size_in_bytes;
	};

	STDMETHOD(WriteAt)(
		/*[in]*/ ULARGE_INTEGER ulOffset,
		/*[in,size_is(cb)]*/ const void* pv,
		/*[in]*/ ULONG cb,
		/*[out]*/ ULONG* pcbWritten)
	{
		VSL_DEFINE_MOCK_METHOD(WriteAt)

		VSL_CHECK_VALIDVALUE(ulOffset);

		VSL_CHECK_VALIDVALUE_MEMCMP(pv, cb, validValues.cb);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_SET_VALIDVALUE(pcbWritten);

		VSL_RETURN_VALIDVALUES();
	}
	struct FlushValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Flush)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Flush)

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSizeValidValues
	{
		/*[in]*/ ULARGE_INTEGER cb;
		HRESULT retValue;
	};

	STDMETHOD(SetSize)(
		/*[in]*/ ULARGE_INTEGER cb)
	{
		VSL_DEFINE_MOCK_METHOD(SetSize)

		VSL_CHECK_VALIDVALUE(cb);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockRegionValidValues
	{
		/*[in]*/ ULARGE_INTEGER libOffset;
		/*[in]*/ ULARGE_INTEGER cb;
		/*[in]*/ DWORD dwLockType;
		HRESULT retValue;
	};

	STDMETHOD(LockRegion)(
		/*[in]*/ ULARGE_INTEGER libOffset,
		/*[in]*/ ULARGE_INTEGER cb,
		/*[in]*/ DWORD dwLockType)
	{
		VSL_DEFINE_MOCK_METHOD(LockRegion)

		VSL_CHECK_VALIDVALUE(libOffset);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_CHECK_VALIDVALUE(dwLockType);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnlockRegionValidValues
	{
		/*[in]*/ ULARGE_INTEGER libOffset;
		/*[in]*/ ULARGE_INTEGER cb;
		/*[in]*/ DWORD dwLockType;
		HRESULT retValue;
	};

	STDMETHOD(UnlockRegion)(
		/*[in]*/ ULARGE_INTEGER libOffset,
		/*[in]*/ ULARGE_INTEGER cb,
		/*[in]*/ DWORD dwLockType)
	{
		VSL_DEFINE_MOCK_METHOD(UnlockRegion)

		VSL_CHECK_VALIDVALUE(libOffset);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_CHECK_VALIDVALUE(dwLockType);

		VSL_RETURN_VALIDVALUES();
	}
	struct StatValidValues
	{
		/*[out]*/ STATSTG* pstatstg;
		/*[in]*/ DWORD grfStatFlag;
		HRESULT retValue;
	};

	STDMETHOD(Stat)(
		/*[out]*/ STATSTG* pstatstg,
		/*[in]*/ DWORD grfStatFlag)
	{
		VSL_DEFINE_MOCK_METHOD(Stat)

		VSL_SET_VALIDVALUE(pstatstg);

		VSL_CHECK_VALIDVALUE(grfStatFlag);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ILOCKBYTES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
