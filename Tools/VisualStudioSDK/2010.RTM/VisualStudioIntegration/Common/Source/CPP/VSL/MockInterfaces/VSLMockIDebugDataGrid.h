/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGDATAGRID_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGDATAGRID_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugDataGridNotImpl :
	public IDebugDataGrid
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDataGridNotImpl)

public:

	typedef IDebugDataGrid Interface;

	STDMETHOD(GetGridInfo)(
		/*[out]*/ ULONG* /*pX*/,
		/*[out]*/ ULONG* /*pY*/,
		/*[out]*/ BSTR* /*bpstrTitle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetGridPropertyInfo)(
		/*[in]*/ ULONG /*x*/,
		/*[in]*/ ULONG /*y*/,
		/*[in]*/ ULONG /*celtX*/,
		/*[in]*/ ULONG /*celtY*/,
		/*[in]*/ ULONG /*celtXtimesY*/,
		/*[in]*/ DEBUGPROP_INFO_FLAGS /*dwFields*/,
		/*[in]*/ DWORD /*dwRadix*/,
		/*[out,size_is(celtXtimesY),length_is(*pceltFetched)]*/ DEBUG_PROPERTY_INFO* /*rgelt*/,
		/*[out]*/ ULONG* /*pceltFetched*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugDataGridMockImpl :
	public IDebugDataGrid,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugDataGridMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugDataGridMockImpl)

	typedef IDebugDataGrid Interface;
	struct GetGridInfoValidValues
	{
		/*[out]*/ ULONG* pX;
		/*[out]*/ ULONG* pY;
		/*[out]*/ BSTR* bpstrTitle;
		HRESULT retValue;
	};

	STDMETHOD(GetGridInfo)(
		/*[out]*/ ULONG* pX,
		/*[out]*/ ULONG* pY,
		/*[out]*/ BSTR* bpstrTitle)
	{
		VSL_DEFINE_MOCK_METHOD(GetGridInfo)

		VSL_SET_VALIDVALUE(pX);

		VSL_SET_VALIDVALUE(pY);

		VSL_SET_VALIDVALUE_BSTR(bpstrTitle);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetGridPropertyInfoValidValues
	{
		/*[in]*/ ULONG x;
		/*[in]*/ ULONG y;
		/*[in]*/ ULONG celtX;
		/*[in]*/ ULONG celtY;
		/*[in]*/ ULONG celtXtimesY;
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields;
		/*[in]*/ DWORD dwRadix;
		/*[out,size_is(celtXtimesY),length_is(*pceltFetched)]*/ DEBUG_PROPERTY_INFO* rgelt;
		/*[out]*/ ULONG* pceltFetched;
		HRESULT retValue;
	};

	STDMETHOD(GetGridPropertyInfo)(
		/*[in]*/ ULONG x,
		/*[in]*/ ULONG y,
		/*[in]*/ ULONG celtX,
		/*[in]*/ ULONG celtY,
		/*[in]*/ ULONG celtXtimesY,
		/*[in]*/ DEBUGPROP_INFO_FLAGS dwFields,
		/*[in]*/ DWORD dwRadix,
		/*[out,size_is(celtXtimesY),length_is(*pceltFetched)]*/ DEBUG_PROPERTY_INFO* rgelt,
		/*[out]*/ ULONG* pceltFetched)
	{
		VSL_DEFINE_MOCK_METHOD(GetGridPropertyInfo)

		VSL_CHECK_VALIDVALUE(x);

		VSL_CHECK_VALIDVALUE(y);

		VSL_CHECK_VALIDVALUE(celtX);

		VSL_CHECK_VALIDVALUE(celtY);

		VSL_CHECK_VALIDVALUE(celtXtimesY);

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_CHECK_VALIDVALUE(dwRadix);

		VSL_SET_VALIDVALUE_MEMCPY(rgelt, celtXtimesY*sizeof(rgelt[0]), *(validValues.pceltFetched)*sizeof(validValues.rgelt[0]));

		VSL_SET_VALIDVALUE(pceltFetched);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGDATAGRID_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
