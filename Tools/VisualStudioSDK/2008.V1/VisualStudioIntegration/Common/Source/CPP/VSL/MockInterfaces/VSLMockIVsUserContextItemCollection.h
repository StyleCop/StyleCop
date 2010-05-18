/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERCONTEXTITEMCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERCONTEXTITEMCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsUserContextItemCollectionNotImpl :
	public IVsUserContextItemCollection
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextItemCollectionNotImpl)

public:

	typedef IVsUserContextItemCollection Interface;

	STDMETHOD(get_Item)(
		/*[in]*/ VARIANT /*index*/,
		/*[out,retval]*/ IVsUserContextItem** /*ppItem*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get__NewEnum)(
		/*[out,retval]*/ IUnknown** /*pEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Count)(
		/*[out,retval]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_ItemAt)(
		/*[in]*/ long /*index*/,
		/*[out,retval]*/ IVsUserContextItem** /*ppItem*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserContextItemCollectionMockImpl :
	public IVsUserContextItemCollection,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextItemCollectionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserContextItemCollectionMockImpl)

	typedef IVsUserContextItemCollection Interface;
	struct get_ItemValidValues
	{
		/*[in]*/ VARIANT index;
		/*[out,retval]*/ IVsUserContextItem** ppItem;
		HRESULT retValue;
	};

	STDMETHOD(get_Item)(
		/*[in]*/ VARIANT index,
		/*[out,retval]*/ IVsUserContextItem** ppItem)
	{
		VSL_DEFINE_MOCK_METHOD(get_Item)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_INTERFACE(ppItem);

		VSL_RETURN_VALIDVALUES();
	}
	struct get__NewEnumValidValues
	{
		/*[out,retval]*/ IUnknown** pEnum;
		HRESULT retValue;
	};

	STDMETHOD(get__NewEnum)(
		/*[out,retval]*/ IUnknown** pEnum)
	{
		VSL_DEFINE_MOCK_METHOD(get__NewEnum)

		VSL_SET_VALIDVALUE_INTERFACE(pEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CountValidValues
	{
		/*[out,retval]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(get_Count)(
		/*[out,retval]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(get_Count)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_ItemAtValidValues
	{
		/*[in]*/ long index;
		/*[out,retval]*/ IVsUserContextItem** ppItem;
		HRESULT retValue;
	};

	STDMETHOD(get_ItemAt)(
		/*[in]*/ long index,
		/*[out,retval]*/ IVsUserContextItem** ppItem)
	{
		VSL_DEFINE_MOCK_METHOD(get_ItemAt)

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_INTERFACE(ppItem);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERCONTEXTITEMCOLLECTION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
