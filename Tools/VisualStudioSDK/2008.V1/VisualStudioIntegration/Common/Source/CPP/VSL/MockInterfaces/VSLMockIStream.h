/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IStreamNotImpl :
	public IStream
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IStreamNotImpl)

public:

	typedef IStream Interface;

	STDMETHOD(Seek)(
		/*[in]*/ LARGE_INTEGER /*dlibMove*/,
		/*[in]*/ DWORD /*dwOrigin*/,
		/*[out]*/ ULARGE_INTEGER* /*plibNewPosition*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSize)(
		/*[in]*/ ULARGE_INTEGER /*libNewSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CopyTo)(
		/*[in,unique]*/ IStream* /*pstm*/,
		/*[in]*/ ULARGE_INTEGER /*cb*/,
		/*[out]*/ ULARGE_INTEGER* /*pcbRead*/,
		/*[out]*/ ULARGE_INTEGER* /*pcbWritten*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Commit)(
		/*[in]*/ DWORD /*grfCommitFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Revert)()VSL_STDMETHOD_NOTIMPL

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

	STDMETHOD(Clone)(
		/*[out]*/ IStream** /*ppstm*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Read)(
		/*[out,size_is(cb),length_is(*pcbRead)]*/ void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbRead*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Write)(
		/*[in,size_is(cb)]*/ const void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbWritten*/)VSL_STDMETHOD_NOTIMPL
};

class IStreamMockImpl :
	public IStream,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IStreamMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IStreamMockImpl)

	typedef IStream Interface;
	struct SeekValidValues
	{
		/*[in]*/ LARGE_INTEGER dlibMove;
		/*[in]*/ DWORD dwOrigin;
		/*[out]*/ ULARGE_INTEGER* plibNewPosition;
		HRESULT retValue;
	};

	STDMETHOD(Seek)(
		/*[in]*/ LARGE_INTEGER dlibMove,
		/*[in]*/ DWORD dwOrigin,
		/*[out]*/ ULARGE_INTEGER* plibNewPosition)
	{
		VSL_DEFINE_MOCK_METHOD(Seek)

		VSL_CHECK_VALIDVALUE(dlibMove);

		VSL_CHECK_VALIDVALUE(dwOrigin);

		VSL_SET_VALIDVALUE(plibNewPosition);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSizeValidValues
	{
		/*[in]*/ ULARGE_INTEGER libNewSize;
		HRESULT retValue;
	};

	STDMETHOD(SetSize)(
		/*[in]*/ ULARGE_INTEGER libNewSize)
	{
		VSL_DEFINE_MOCK_METHOD(SetSize)

		VSL_CHECK_VALIDVALUE(libNewSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct CopyToValidValues
	{
		/*[in,unique]*/ IStream* pstm;
		/*[in]*/ ULARGE_INTEGER cb;
		/*[out]*/ ULARGE_INTEGER* pcbRead;
		/*[out]*/ ULARGE_INTEGER* pcbWritten;
		HRESULT retValue;
	};

	STDMETHOD(CopyTo)(
		/*[in,unique]*/ IStream* pstm,
		/*[in]*/ ULARGE_INTEGER cb,
		/*[out]*/ ULARGE_INTEGER* pcbRead,
		/*[out]*/ ULARGE_INTEGER* pcbWritten)
	{
		VSL_DEFINE_MOCK_METHOD(CopyTo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pstm);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_SET_VALIDVALUE(pcbRead);

		VSL_SET_VALIDVALUE(pcbWritten);

		VSL_RETURN_VALIDVALUES();
	}
	struct CommitValidValues
	{
		/*[in]*/ DWORD grfCommitFlags;
		HRESULT retValue;
	};

	STDMETHOD(Commit)(
		/*[in]*/ DWORD grfCommitFlags)
	{
		VSL_DEFINE_MOCK_METHOD(Commit)

		VSL_CHECK_VALIDVALUE(grfCommitFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct RevertValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Revert)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Revert)

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
	struct CloneValidValues
	{
		/*[out]*/ IStream** ppstm;
		HRESULT retValue;
	};

	STDMETHOD(Clone)(
		/*[out]*/ IStream** ppstm)
	{
		VSL_DEFINE_MOCK_METHOD(Clone)

		VSL_SET_VALIDVALUE_INTERFACE(ppstm);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReadValidValues
	{
		/*[out,size_is(cb),length_is(*pcbRead)]*/ void* pv;
		/*[in]*/ ULONG cb;
		/*[out]*/ ULONG* pcbRead;
		HRESULT retValue;
		size_t pv_size_in_bytes;
	};

	STDMETHOD(Read)(
		/*[out,size_is(cb),length_is(*pcbRead)]*/ void* pv,
		/*[in]*/ ULONG cb,
		/*[out]*/ ULONG* pcbRead)
	{
		VSL_DEFINE_MOCK_METHOD(Read)

		VSL_SET_VALIDVALUE_MEMCPY(pv, cb, *(validValues.pcbRead));

		VSL_CHECK_VALIDVALUE(cb);

		VSL_SET_VALIDVALUE(pcbRead);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteValidValues
	{
		/*[in,size_is(cb)]*/ void* pv;
		/*[in]*/ ULONG cb;
		/*[out]*/ ULONG* pcbWritten;
		HRESULT retValue;
		size_t pv_size_in_bytes;
	};

	STDMETHOD(Write)(
		/*[in,size_is(cb)]*/ const void* pv,
		/*[in]*/ ULONG cb,
		/*[out]*/ ULONG* pcbWritten)
	{
		VSL_DEFINE_MOCK_METHOD(Write)

		VSL_CHECK_VALIDVALUE_MEMCMP(pv, cb, validValues.cb);

		VSL_CHECK_VALIDVALUE(cb);

		VSL_SET_VALIDVALUE(pcbWritten);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
