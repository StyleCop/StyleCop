/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDISCOVERYCLIENTRESULTCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDISCOVERYCLIENTRESULTCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "DiscoveryService80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDiscoveryClientResultCollectionNotImpl :
	public IDiscoveryClientResultCollection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryClientResultCollectionNotImpl)

public:

	typedef IDiscoveryClientResultCollection Interface;

	STDMETHOD(GetResultCount)(
		/*[out,retval]*/ int* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetResult)(
		/*[in]*/ int /*pIndex*/,
		/*[out,retval]*/ IDiscoveryClientResult** /*ppIDiscoveryClientResult*/)VSL_STDMETHOD_NOTIMPL
};

class IDiscoveryClientResultCollectionMockImpl :
	public IDiscoveryClientResultCollection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDiscoveryClientResultCollectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDiscoveryClientResultCollectionMockImpl)

	typedef IDiscoveryClientResultCollection Interface;
	struct GetResultCountValidValues
	{
		/*[out,retval]*/ int* pCount;
		HRESULT retValue;
	};

	STDMETHOD(GetResultCount)(
		/*[out,retval]*/ int* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetResultCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetResultValidValues
	{
		/*[in]*/ int pIndex;
		/*[out,retval]*/ IDiscoveryClientResult** ppIDiscoveryClientResult;
		HRESULT retValue;
	};

	STDMETHOD(GetResult)(
		/*[in]*/ int pIndex,
		/*[out,retval]*/ IDiscoveryClientResult** ppIDiscoveryClientResult)
	{
		VSL_DEFINE_MOCK_METHOD(GetResult)

		VSL_CHECK_VALIDVALUE(pIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppIDiscoveryClientResult);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDISCOVERYCLIENTRESULTCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
