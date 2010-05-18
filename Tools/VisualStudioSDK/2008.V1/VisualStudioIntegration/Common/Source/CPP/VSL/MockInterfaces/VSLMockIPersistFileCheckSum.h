/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERSISTFILECHECKSUM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERSISTFILECHECKSUM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPersistFileCheckSumNotImpl :
	public IPersistFileCheckSum
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistFileCheckSumNotImpl)

public:

	typedef IPersistFileCheckSum Interface;

	STDMETHOD(CalculateCheckSum)(
		/*[in]*/ REFGUID /*guidCheckSumAlgorithm*/,
		/*[in]*/ DWORD /*cbBufferSize*/,
		/*[out,size_is(cbBufferSize)]*/ BYTE* /*pbHash*/,
		/*[out]*/ DWORD* /*pcbActualSize*/)VSL_STDMETHOD_NOTIMPL
};

class IPersistFileCheckSumMockImpl :
	public IPersistFileCheckSum,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPersistFileCheckSumMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPersistFileCheckSumMockImpl)

	typedef IPersistFileCheckSum Interface;
	struct CalculateCheckSumValidValues
	{
		/*[in]*/ REFGUID guidCheckSumAlgorithm;
		/*[in]*/ DWORD cbBufferSize;
		/*[out,size_is(cbBufferSize)]*/ BYTE* pbHash;
		/*[out]*/ DWORD* pcbActualSize;
		HRESULT retValue;
	};

	STDMETHOD(CalculateCheckSum)(
		/*[in]*/ REFGUID guidCheckSumAlgorithm,
		/*[in]*/ DWORD cbBufferSize,
		/*[out,size_is(cbBufferSize)]*/ BYTE* pbHash,
		/*[out]*/ DWORD* pcbActualSize)
	{
		VSL_DEFINE_MOCK_METHOD(CalculateCheckSum)

		VSL_CHECK_VALIDVALUE(guidCheckSumAlgorithm);

		VSL_CHECK_VALIDVALUE(cbBufferSize);

		VSL_SET_VALIDVALUE_MEMCPY(pbHash, cbBufferSize*sizeof(pbHash[0]), validValues.cbBufferSize*sizeof(validValues.pbHash[0]));

		VSL_SET_VALIDVALUE(pcbActualSize);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPERSISTFILECHECKSUM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
