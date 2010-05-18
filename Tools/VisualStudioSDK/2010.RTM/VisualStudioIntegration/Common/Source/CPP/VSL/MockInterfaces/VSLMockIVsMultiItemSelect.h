/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMULTIITEMSELECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMULTIITEMSELECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsMultiItemSelectNotImpl :
	public IVsMultiItemSelect
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMultiItemSelectNotImpl)

public:

	typedef IVsMultiItemSelect Interface;

	STDMETHOD(GetSelectionInfo)(
		/*[out]*/ ULONG* /*pcItems*/,
		/*[out]*/ BOOL* /*pfSingleHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSelectedItems)(
		/*[in]*/ VSGSIFLAGS /*grfGSI*/,
		/*[in]*/ ULONG /*cItems*/,
		/*[out,size_is(cItems)]*/ VSITEMSELECTION[] /*rgItemSel*/)VSL_STDMETHOD_NOTIMPL
};

class IVsMultiItemSelectMockImpl :
	public IVsMultiItemSelect,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsMultiItemSelectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsMultiItemSelectMockImpl)

	typedef IVsMultiItemSelect Interface;
	struct GetSelectionInfoValidValues
	{
		/*[out]*/ ULONG* pcItems;
		/*[out]*/ BOOL* pfSingleHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(GetSelectionInfo)(
		/*[out]*/ ULONG* pcItems,
		/*[out]*/ BOOL* pfSingleHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(GetSelectionInfo)

		VSL_SET_VALIDVALUE(pcItems);

		VSL_SET_VALIDVALUE(pfSingleHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSelectedItemsValidValues
	{
		/*[in]*/ VSGSIFLAGS grfGSI;
		/*[in]*/ ULONG cItems;
		/*[out,size_is(cItems)]*/ VSITEMSELECTION* rgItemSel;
		HRESULT retValue;
	};

	STDMETHOD(GetSelectedItems)(
		/*[in]*/ VSGSIFLAGS grfGSI,
		/*[in]*/ ULONG cItems,
		/*[out,size_is(cItems)]*/ VSITEMSELECTION rgItemSel[])
	{
		VSL_DEFINE_MOCK_METHOD(GetSelectedItems)

		VSL_CHECK_VALIDVALUE(grfGSI);

		VSL_CHECK_VALIDVALUE(cItems);

		VSL_SET_VALIDVALUE_MEMCPY(rgItemSel, cItems*sizeof(rgItemSel[0]), validValues.cItems*sizeof(validValues.rgItemSel[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMULTIITEMSELECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
