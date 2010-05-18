/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEEDATASTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEEDATASTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IEEDataStorageNotImpl :
	public IEEDataStorage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEDataStorageNotImpl)

public:

	typedef IEEDataStorage Interface;

	STDMETHOD(GetSize)(
		/*[out]*/ ULONG* /*size*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetData)(
		/*[in]*/ ULONG /*dataSize*/,
		/*[out]*/ ULONG* /*sizeGotten*/,
		/*[out,size_is(dataSize),length_is(*sizeGotten)]*/ BYTE* /*data*/)VSL_STDMETHOD_NOTIMPL
};

class IEEDataStorageMockImpl :
	public IEEDataStorage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEEDataStorageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEEDataStorageMockImpl)

	typedef IEEDataStorage Interface;
	struct GetSizeValidValues
	{
		/*[out]*/ ULONG* size;
		HRESULT retValue;
	};

	STDMETHOD(GetSize)(
		/*[out]*/ ULONG* size)
	{
		VSL_DEFINE_MOCK_METHOD(GetSize)

		VSL_SET_VALIDVALUE(size);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetDataValidValues
	{
		/*[in]*/ ULONG dataSize;
		/*[out]*/ ULONG* sizeGotten;
		/*[out,size_is(dataSize),length_is(*sizeGotten)]*/ BYTE* data;
		HRESULT retValue;
	};

	STDMETHOD(GetData)(
		/*[in]*/ ULONG dataSize,
		/*[out]*/ ULONG* sizeGotten,
		/*[out,size_is(dataSize),length_is(*sizeGotten)]*/ BYTE* data)
	{
		VSL_DEFINE_MOCK_METHOD(GetData)

		VSL_CHECK_VALIDVALUE(dataSize);

		VSL_SET_VALIDVALUE(sizeGotten);

		VSL_SET_VALIDVALUE_MEMCPY(data, dataSize*sizeof(data[0]), *(validValues.sizeGotten)*sizeof(validValues.data[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEEDATASTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
