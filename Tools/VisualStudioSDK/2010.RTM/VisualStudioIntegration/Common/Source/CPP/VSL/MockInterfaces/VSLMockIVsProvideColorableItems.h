/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROVIDECOLORABLEITEMS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROVIDECOLORABLEITEMS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsProvideColorableItemsNotImpl :
	public IVsProvideColorableItems
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProvideColorableItemsNotImpl)

public:

	typedef IVsProvideColorableItems Interface;

	STDMETHOD(GetItemCount)(
		/*[out]*/ int* /*piCount*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetColorableItem)(
		/*[in]*/ int /*iIndex*/,
		/*[out]*/ IVsColorableItem** /*ppItem*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProvideColorableItemsMockImpl :
	public IVsProvideColorableItems,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProvideColorableItemsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProvideColorableItemsMockImpl)

	typedef IVsProvideColorableItems Interface;
	struct GetItemCountValidValues
	{
		/*[out]*/ int* piCount;
		HRESULT retValue;
	};

	STDMETHOD(GetItemCount)(
		/*[out]*/ int* piCount)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemCount)

		VSL_SET_VALIDVALUE(piCount);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetColorableItemValidValues
	{
		/*[in]*/ int iIndex;
		/*[out]*/ IVsColorableItem** ppItem;
		HRESULT retValue;
	};

	STDMETHOD(GetColorableItem)(
		/*[in]*/ int iIndex,
		/*[out]*/ IVsColorableItem** ppItem)
	{
		VSL_DEFINE_MOCK_METHOD(GetColorableItem)

		VSL_CHECK_VALIDVALUE(iIndex);

		VSL_SET_VALIDVALUE_INTERFACE(ppItem);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROVIDECOLORABLEITEMS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
