/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICHANNELHOOK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICHANNELHOOK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IChannelHookNotImpl :
	public IChannelHook
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IChannelHookNotImpl)

public:

	typedef IChannelHook Interface;

	virtual void STDMETHODCALLTYPE ClientGetSize(
		/*[in]*/ REFGUID /*uExtent*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ ULONG* /*pDataSize*/){ return ; }

	virtual void STDMETHODCALLTYPE ClientFillBuffer(
		/*[in]*/ REFGUID /*uExtent*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in,out]*/ ULONG* /*pDataSize*/,
		/*[in]*/ void* /*pDataBuffer*/){ return ; }

	virtual void STDMETHODCALLTYPE ClientNotify(
		/*[in]*/ REFGUID /*uExtent*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ ULONG /*cbDataSize*/,
		/*[in]*/ void* /*pDataBuffer*/,
		/*[in]*/ DWORD /*lDataRep*/,
		/*[in]*/ HRESULT /*hrFault*/){ return ; }

	virtual void STDMETHODCALLTYPE ServerNotify(
		/*[in]*/ REFGUID /*uExtent*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ ULONG /*cbDataSize*/,
		/*[in]*/ void* /*pDataBuffer*/,
		/*[in]*/ DWORD /*lDataRep*/){ return ; }

	virtual void STDMETHODCALLTYPE ServerGetSize(
		/*[in]*/ REFGUID /*uExtent*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in]*/ HRESULT /*hrFault*/,
		/*[out]*/ ULONG* /*pDataSize*/){ return ; }

	virtual void STDMETHODCALLTYPE ServerFillBuffer(
		/*[in]*/ REFGUID /*uExtent*/,
		/*[in]*/ REFIID /*riid*/,
		/*[in,out]*/ ULONG* /*pDataSize*/,
		/*[in]*/ void* /*pDataBuffer*/,
		/*[in]*/ HRESULT /*hrFault*/){ return ; }
};

class IChannelHookMockImpl :
	public IChannelHook,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IChannelHookMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IChannelHookMockImpl)

	typedef IChannelHook Interface;
	struct ClientGetSizeValidValues
	{
		/*[in]*/ REFGUID uExtent;
		/*[in]*/ REFIID riid;
		/*[out]*/ ULONG* pDataSize;
	};

	virtual void _stdcall ClientGetSize(
		/*[in]*/ REFGUID uExtent,
		/*[in]*/ REFIID riid,
		/*[out]*/ ULONG* pDataSize)
	{
		VSL_DEFINE_MOCK_METHOD(ClientGetSize)

		VSL_CHECK_VALIDVALUE(uExtent);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(pDataSize);

	}
	struct ClientFillBufferValidValues
	{
		/*[in]*/ REFGUID uExtent;
		/*[in]*/ REFIID riid;
		/*[in,out]*/ ULONG* pDataSize;
		/*[in]*/ void* pDataBuffer;
		size_t pDataBuffer_size_in_bytes;
	};

	virtual void _stdcall ClientFillBuffer(
		/*[in]*/ REFGUID uExtent,
		/*[in]*/ REFIID riid,
		/*[in,out]*/ ULONG* pDataSize,
		/*[in]*/ void* pDataBuffer)
	{
		VSL_DEFINE_MOCK_METHOD(ClientFillBuffer)

		VSL_CHECK_VALIDVALUE(uExtent);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(pDataSize);

		VSL_CHECK_VALIDVALUE_PVOID(pDataBuffer);

	}
	struct ClientNotifyValidValues
	{
		/*[in]*/ REFGUID uExtent;
		/*[in]*/ REFIID riid;
		/*[in]*/ ULONG cbDataSize;
		/*[in]*/ void* pDataBuffer;
		/*[in]*/ DWORD lDataRep;
		/*[in]*/ HRESULT hrFault;
		size_t pDataBuffer_size_in_bytes;
	};

	virtual void _stdcall ClientNotify(
		/*[in]*/ REFGUID uExtent,
		/*[in]*/ REFIID riid,
		/*[in]*/ ULONG cbDataSize,
		/*[in]*/ void* pDataBuffer,
		/*[in]*/ DWORD lDataRep,
		/*[in]*/ HRESULT hrFault)
	{
		VSL_DEFINE_MOCK_METHOD(ClientNotify)

		VSL_CHECK_VALIDVALUE(uExtent);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(cbDataSize);

		VSL_CHECK_VALIDVALUE_PVOID(pDataBuffer);

		VSL_CHECK_VALIDVALUE(lDataRep);

		VSL_CHECK_VALIDVALUE(hrFault);

	}
	struct ServerNotifyValidValues
	{
		/*[in]*/ REFGUID uExtent;
		/*[in]*/ REFIID riid;
		/*[in]*/ ULONG cbDataSize;
		/*[in]*/ void* pDataBuffer;
		/*[in]*/ DWORD lDataRep;
		size_t pDataBuffer_size_in_bytes;
	};

	virtual void _stdcall ServerNotify(
		/*[in]*/ REFGUID uExtent,
		/*[in]*/ REFIID riid,
		/*[in]*/ ULONG cbDataSize,
		/*[in]*/ void* pDataBuffer,
		/*[in]*/ DWORD lDataRep)
	{
		VSL_DEFINE_MOCK_METHOD(ServerNotify)

		VSL_CHECK_VALIDVALUE(uExtent);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(cbDataSize);

		VSL_CHECK_VALIDVALUE_PVOID(pDataBuffer);

		VSL_CHECK_VALIDVALUE(lDataRep);

	}
	struct ServerGetSizeValidValues
	{
		/*[in]*/ REFGUID uExtent;
		/*[in]*/ REFIID riid;
		/*[in]*/ HRESULT hrFault;
		/*[out]*/ ULONG* pDataSize;
	};

	virtual void _stdcall ServerGetSize(
		/*[in]*/ REFGUID uExtent,
		/*[in]*/ REFIID riid,
		/*[in]*/ HRESULT hrFault,
		/*[out]*/ ULONG* pDataSize)
	{
		VSL_DEFINE_MOCK_METHOD(ServerGetSize)

		VSL_CHECK_VALIDVALUE(uExtent);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_CHECK_VALIDVALUE(hrFault);

		VSL_SET_VALIDVALUE(pDataSize);

	}
	struct ServerFillBufferValidValues
	{
		/*[in]*/ REFGUID uExtent;
		/*[in]*/ REFIID riid;
		/*[in,out]*/ ULONG* pDataSize;
		/*[in]*/ void* pDataBuffer;
		/*[in]*/ HRESULT hrFault;
		size_t pDataBuffer_size_in_bytes;
	};

	virtual void _stdcall ServerFillBuffer(
		/*[in]*/ REFGUID uExtent,
		/*[in]*/ REFIID riid,
		/*[in,out]*/ ULONG* pDataSize,
		/*[in]*/ void* pDataBuffer,
		/*[in]*/ HRESULT hrFault)
	{
		VSL_DEFINE_MOCK_METHOD(ServerFillBuffer)

		VSL_CHECK_VALIDVALUE(uExtent);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(pDataSize);

		VSL_CHECK_VALIDVALUE_PVOID(pDataBuffer);

		VSL_CHECK_VALIDVALUE(hrFault);

	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICHANNELHOOK_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
