/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITYPEMARSHAL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITYPEMARSHAL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OAIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ITypeMarshalNotImpl :
	public ITypeMarshal
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeMarshalNotImpl)

public:

	typedef ITypeMarshal Interface;

	STDMETHOD(Size)(
		/*[in]*/ PVOID /*pvType*/,
		/*[in]*/ DWORD /*dwDestContext*/,
		/*[in]*/ PVOID /*pvDestContext*/,
		/*[out]*/ ULONG* /*pSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Marshal)(
		/*[in]*/ PVOID /*pvType*/,
		/*[in]*/ DWORD /*dwDestContext*/,
		/*[in]*/ PVOID /*pvDestContext*/,
		/*[in]*/ ULONG /*cbBufferLength*/,
		/*[out]*/ BYTE* /*pBuffer*/,
		/*[out]*/ ULONG* /*pcbWritten*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unmarshal)(
		/*[out]*/ PVOID /*pvType*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ ULONG /*cbBufferLength*/,
		/*[in]*/ BYTE* /*pBuffer*/,
		/*[out]*/ ULONG* /*pcbRead*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Free)(
		/*[in]*/ PVOID /*pvType*/)VSL_STDMETHOD_NOTIMPL
};

class ITypeMarshalMockImpl :
	public ITypeMarshal,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeMarshalMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITypeMarshalMockImpl)

	typedef ITypeMarshal Interface;
	struct SizeValidValues
	{
		/*[in]*/ PVOID pvType;
		/*[in]*/ DWORD dwDestContext;
		/*[in]*/ PVOID pvDestContext;
		/*[out]*/ ULONG* pSize;
		HRESULT retValue;
		size_t pvType_size_in_bytes;
		size_t pvDestContext_size_in_bytes;
	};

	STDMETHOD(Size)(
		/*[in]*/ PVOID pvType,
		/*[in]*/ DWORD dwDestContext,
		/*[in]*/ PVOID pvDestContext,
		/*[out]*/ ULONG* pSize)
	{
		VSL_DEFINE_MOCK_METHOD(Size)

		VSL_CHECK_VALIDVALUE_PVOID(pvType);

		VSL_CHECK_VALIDVALUE(dwDestContext);

		VSL_CHECK_VALIDVALUE_PVOID(pvDestContext);

		VSL_SET_VALIDVALUE(pSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct MarshalValidValues
	{
		/*[in]*/ PVOID pvType;
		/*[in]*/ DWORD dwDestContext;
		/*[in]*/ PVOID pvDestContext;
		/*[in]*/ ULONG cbBufferLength;
		/*[out]*/ BYTE* pBuffer;
		/*[out]*/ ULONG* pcbWritten;
		HRESULT retValue;
		size_t pvType_size_in_bytes;
		size_t pvDestContext_size_in_bytes;
	};

	STDMETHOD(Marshal)(
		/*[in]*/ PVOID pvType,
		/*[in]*/ DWORD dwDestContext,
		/*[in]*/ PVOID pvDestContext,
		/*[in]*/ ULONG cbBufferLength,
		/*[out]*/ BYTE* pBuffer,
		/*[out]*/ ULONG* pcbWritten)
	{
		VSL_DEFINE_MOCK_METHOD(Marshal)

		VSL_CHECK_VALIDVALUE_PVOID(pvType);

		VSL_CHECK_VALIDVALUE(dwDestContext);

		VSL_CHECK_VALIDVALUE_PVOID(pvDestContext);

		VSL_CHECK_VALIDVALUE(cbBufferLength);

		VSL_SET_VALIDVALUE(pBuffer);

		VSL_SET_VALIDVALUE(pcbWritten);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnmarshalValidValues
	{
		/*[out]*/ PVOID pvType;
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ ULONG cbBufferLength;
		/*[in]*/ BYTE* pBuffer;
		/*[out]*/ ULONG* pcbRead;
		HRESULT retValue;
		size_t pvType_size_in_bytes;
	};

	STDMETHOD(Unmarshal)(
		/*[out]*/ PVOID pvType,
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ ULONG cbBufferLength,
		/*[in]*/ BYTE* pBuffer,
		/*[out]*/ ULONG* pcbRead)
	{
		VSL_DEFINE_MOCK_METHOD(Unmarshal)

		VSL_SET_VALIDVALUE_PVOID(pvType);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(cbBufferLength);

		VSL_CHECK_VALIDVALUE_POINTER(pBuffer);

		VSL_SET_VALIDVALUE(pcbRead);

		VSL_RETURN_VALIDVALUES();
	}
	struct FreeValidValues
	{
		/*[in]*/ PVOID pvType;
		HRESULT retValue;
		size_t pvType_size_in_bytes;
	};

	STDMETHOD(Free)(
		/*[in]*/ PVOID pvType)
	{
		VSL_DEFINE_MOCK_METHOD(Free)

		VSL_CHECK_VALIDVALUE_PVOID(pvType);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITYPEMARSHAL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
