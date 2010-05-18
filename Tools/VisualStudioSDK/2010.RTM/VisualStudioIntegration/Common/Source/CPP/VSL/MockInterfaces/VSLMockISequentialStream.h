/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISEQUENTIALSTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISEQUENTIALSTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ISequentialStreamNotImpl :
	public ISequentialStream
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISequentialStreamNotImpl)

public:

	typedef ISequentialStream Interface;

	STDMETHOD(Read)(
		/*[out,size_is(cb),length_is(*pcbRead)]*/ void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbRead*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Write)(
		/*[in,size_is(cb)]*/ const void* /*pv*/,
		/*[in]*/ ULONG /*cb*/,
		/*[out]*/ ULONG* /*pcbWritten*/)VSL_STDMETHOD_NOTIMPL
};

class ISequentialStreamMockImpl :
	public ISequentialStream,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISequentialStreamMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISequentialStreamMockImpl)

	typedef ISequentialStream Interface;
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

#endif // ISEQUENTIALSTREAM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
