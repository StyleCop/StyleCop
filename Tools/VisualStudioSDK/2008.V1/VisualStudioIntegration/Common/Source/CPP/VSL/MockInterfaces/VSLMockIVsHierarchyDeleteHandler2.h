/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIERARCHYDELETEHANDLER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIERARCHYDELETEHANDLER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsHierarchyDeleteHandler2NotImpl :
	public IVsHierarchyDeleteHandler2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDeleteHandler2NotImpl)

public:

	typedef IVsHierarchyDeleteHandler2 Interface;

	STDMETHOD(ShowSpecificDeleteRemoveMessage)(
		/*[in]*/ DWORD /*dwDelItemOps*/,
		/*[in]*/ ULONG /*cDelItems*/,
		/*[in,size_is(cDelItems)]*/ VSITEMID[] /*rgDelItems*/,
		/*[out]*/ BOOL* /*pfShowStandardMessage*/,
		/*[out]*/ VSDELETEITEMOPERATION* /*pdwDelItemOp*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowMultiSelDeleteOrRemoveMessage)(
		/*[in]*/ VSDELETEITEMOPERATION /*dwDelItemOp*/,
		/*[in]*/ ULONG /*cDelItems*/,
		/*[in,size_is(cDelItems)]*/ VSITEMID[] /*rgDelItems*/,
		/*[out]*/ BOOL* /*pfCancelOperation*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHierarchyDeleteHandler2MockImpl :
	public IVsHierarchyDeleteHandler2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHierarchyDeleteHandler2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHierarchyDeleteHandler2MockImpl)

	typedef IVsHierarchyDeleteHandler2 Interface;
	struct ShowSpecificDeleteRemoveMessageValidValues
	{
		/*[in]*/ DWORD dwDelItemOps;
		/*[in]*/ ULONG cDelItems;
		/*[in,size_is(cDelItems)]*/ VSITEMID* rgDelItems;
		/*[out]*/ BOOL* pfShowStandardMessage;
		/*[out]*/ VSDELETEITEMOPERATION* pdwDelItemOp;
		HRESULT retValue;
	};

	STDMETHOD(ShowSpecificDeleteRemoveMessage)(
		/*[in]*/ DWORD dwDelItemOps,
		/*[in]*/ ULONG cDelItems,
		/*[in,size_is(cDelItems)]*/ VSITEMID rgDelItems[],
		/*[out]*/ BOOL* pfShowStandardMessage,
		/*[out]*/ VSDELETEITEMOPERATION* pdwDelItemOp)
	{
		VSL_DEFINE_MOCK_METHOD(ShowSpecificDeleteRemoveMessage)

		VSL_CHECK_VALIDVALUE(dwDelItemOps);

		VSL_CHECK_VALIDVALUE(cDelItems);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgDelItems, cDelItems*sizeof(rgDelItems[0]), validValues.cDelItems*sizeof(validValues.rgDelItems[0]));

		VSL_SET_VALIDVALUE(pfShowStandardMessage);

		VSL_SET_VALIDVALUE(pdwDelItemOp);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowMultiSelDeleteOrRemoveMessageValidValues
	{
		/*[in]*/ VSDELETEITEMOPERATION dwDelItemOp;
		/*[in]*/ ULONG cDelItems;
		/*[in,size_is(cDelItems)]*/ VSITEMID* rgDelItems;
		/*[out]*/ BOOL* pfCancelOperation;
		HRESULT retValue;
	};

	STDMETHOD(ShowMultiSelDeleteOrRemoveMessage)(
		/*[in]*/ VSDELETEITEMOPERATION dwDelItemOp,
		/*[in]*/ ULONG cDelItems,
		/*[in,size_is(cDelItems)]*/ VSITEMID rgDelItems[],
		/*[out]*/ BOOL* pfCancelOperation)
	{
		VSL_DEFINE_MOCK_METHOD(ShowMultiSelDeleteOrRemoveMessage)

		VSL_CHECK_VALIDVALUE(dwDelItemOp);

		VSL_CHECK_VALIDVALUE(cDelItems);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgDelItems, cDelItems*sizeof(rgDelItems[0]), validValues.cDelItems*sizeof(validValues.rgDelItems[0]));

		VSL_SET_VALIDVALUE(pfCancelOperation);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIERARCHYDELETEHANDLER2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
