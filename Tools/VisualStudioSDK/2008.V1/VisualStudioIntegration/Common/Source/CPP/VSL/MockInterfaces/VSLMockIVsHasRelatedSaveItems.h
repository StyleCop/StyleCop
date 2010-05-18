/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHASRELATEDSAVEITEMS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHASRELATEDSAVEITEMS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsHasRelatedSaveItemsNotImpl :
	public IVsHasRelatedSaveItems
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHasRelatedSaveItemsNotImpl)

public:

	typedef IVsHasRelatedSaveItems Interface;

	STDMETHOD(GetRelatedSaveTreeItems)(
		/*[in]*/ VSSAVETREEITEM /*saveItem*/,
		/*[in]*/ ULONG /*celt*/,
		/*[in,out,size_is(celt)]*/ VSSAVETREEITEM[] /*rgSaveTreeItems*/,
		/*[out]*/ ULONG* /*pcActual*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHasRelatedSaveItemsMockImpl :
	public IVsHasRelatedSaveItems,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHasRelatedSaveItemsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHasRelatedSaveItemsMockImpl)

	typedef IVsHasRelatedSaveItems Interface;
	struct GetRelatedSaveTreeItemsValidValues
	{
		/*[in]*/ VSSAVETREEITEM saveItem;
		/*[in]*/ ULONG celt;
		/*[in,out,size_is(celt)]*/ VSSAVETREEITEM* rgSaveTreeItems;
		/*[out]*/ ULONG* pcActual;
		HRESULT retValue;
	};

	STDMETHOD(GetRelatedSaveTreeItems)(
		/*[in]*/ VSSAVETREEITEM saveItem,
		/*[in]*/ ULONG celt,
		/*[in,out,size_is(celt)]*/ VSSAVETREEITEM rgSaveTreeItems[],
		/*[out]*/ ULONG* pcActual)
	{
		VSL_DEFINE_MOCK_METHOD(GetRelatedSaveTreeItems)

		VSL_CHECK_VALIDVALUE(saveItem);

		VSL_CHECK_VALIDVALUE(celt);

		VSL_SET_VALIDVALUE_MEMCPY(rgSaveTreeItems, celt*sizeof(rgSaveTreeItems[0]), validValues.celt*sizeof(validValues.rgSaveTreeItems[0]));

		VSL_SET_VALIDVALUE(pcActual);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHASRELATEDSAVEITEMS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
