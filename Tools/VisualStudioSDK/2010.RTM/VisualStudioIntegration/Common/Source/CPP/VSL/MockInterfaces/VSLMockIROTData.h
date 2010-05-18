/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IROTDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IROTDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IROTDataNotImpl :
	public IROTData
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IROTDataNotImpl)

public:

	typedef IROTData Interface;

	STDMETHOD(GetComparisonData)(
		/*[out,size_is(cbMax)]*/ byte* /*pbData*/,
		/*[in]*/ ULONG /*cbMax*/,
		/*[out]*/ ULONG* /*pcbData*/)VSL_STDMETHOD_NOTIMPL
};

class IROTDataMockImpl :
	public IROTData,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IROTDataMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IROTDataMockImpl)

	typedef IROTData Interface;
	struct GetComparisonDataValidValues
	{
		/*[out,size_is(cbMax)]*/ byte* pbData;
		/*[in]*/ ULONG cbMax;
		/*[out]*/ ULONG* pcbData;
		HRESULT retValue;
	};

	STDMETHOD(GetComparisonData)(
		/*[out,size_is(cbMax)]*/ byte* pbData,
		/*[in]*/ ULONG cbMax,
		/*[out]*/ ULONG* pcbData)
	{
		VSL_DEFINE_MOCK_METHOD(GetComparisonData)

		VSL_SET_VALIDVALUE_MEMCPY(pbData, cbMax*sizeof(pbData[0]), validValues.cbMax*sizeof(validValues.pbData[0]));

		VSL_CHECK_VALIDVALUE(cbMax);

		VSL_SET_VALIDVALUE(pcbData);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IROTDATA_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
