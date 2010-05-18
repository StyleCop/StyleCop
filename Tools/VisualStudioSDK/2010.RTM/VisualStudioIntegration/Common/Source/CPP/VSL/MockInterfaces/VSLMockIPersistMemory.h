/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERSISTMEMORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERSISTMEMORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPersistMemoryNotImpl :
	public IPersistMemory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistMemoryNotImpl)

public:

	typedef IPersistMemory Interface;

	STDMETHOD(IsDirty)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Load)(
		/*[in,size_is(cbSize)]*/ LPVOID /*pMem*/,
		/*[in]*/ ULONG /*cbSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Save)(
		/*[out,size_is(cbSize)]*/ LPVOID /*pMem*/,
		/*[in]*/ BOOL /*fClearDirty*/,
		/*[in]*/ ULONG /*cbSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSizeMax)(
		/*[out]*/ ULONG* /*pCbSize*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitNew)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* /*pClassID*/)VSL_STDMETHOD_NOTIMPL
};

class IPersistMemoryMockImpl :
	public IPersistMemory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistMemoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPersistMemoryMockImpl)

	typedef IPersistMemory Interface;
	struct IsDirtyValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(IsDirty)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(IsDirty)

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadValidValues
	{
		/*[in,size_is(cbSize)]*/ LPVOID pMem;
		/*[in]*/ ULONG cbSize;
		HRESULT retValue;
		size_t pMem_size_in_bytes;
	};

	STDMETHOD(Load)(
		/*[in,size_is(cbSize)]*/ LPVOID pMem,
		/*[in]*/ ULONG cbSize)
	{
		VSL_DEFINE_MOCK_METHOD(Load)

		VSL_CHECK_VALIDVALUE_MEMCMP(pMem, cbSize, validValues.cbSize);

		VSL_CHECK_VALIDVALUE(cbSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct SaveValidValues
	{
		/*[out,size_is(cbSize)]*/ LPVOID pMem;
		/*[in]*/ BOOL fClearDirty;
		/*[in]*/ ULONG cbSize;
		HRESULT retValue;
		size_t pMem_size_in_bytes;
	};

	STDMETHOD(Save)(
		/*[out,size_is(cbSize)]*/ LPVOID pMem,
		/*[in]*/ BOOL fClearDirty,
		/*[in]*/ ULONG cbSize)
	{
		VSL_DEFINE_MOCK_METHOD(Save)

		VSL_SET_VALIDVALUE_MEMCPY(pMem, cbSize, validValues.cbSize);

		VSL_CHECK_VALIDVALUE(fClearDirty);

		VSL_CHECK_VALIDVALUE(cbSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSizeMaxValidValues
	{
		/*[out]*/ ULONG* pCbSize;
		HRESULT retValue;
	};

	STDMETHOD(GetSizeMax)(
		/*[out]*/ ULONG* pCbSize)
	{
		VSL_DEFINE_MOCK_METHOD(GetSizeMax)

		VSL_SET_VALIDVALUE(pCbSize);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitNewValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(InitNew)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(InitNew)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetClassIDValidValues
	{
		/*[out]*/ CLSID* pClassID;
		HRESULT retValue;
	};

	STDMETHOD(GetClassID)(
		/*[out]*/ CLSID* pClassID)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassID)

		VSL_SET_VALIDVALUE(pClassID);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPERSISTMEMORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
