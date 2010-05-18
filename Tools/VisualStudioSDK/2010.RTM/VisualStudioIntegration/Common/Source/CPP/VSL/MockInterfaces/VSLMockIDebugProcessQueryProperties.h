/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROCESSQUERYPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROCESSQUERYPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugProcessQueryPropertiesNotImpl :
	public IDebugProcessQueryProperties
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProcessQueryPropertiesNotImpl)

public:

	typedef IDebugProcessQueryProperties Interface;

	STDMETHOD(QueryProperty)(
		/*[in]*/ PROCESS_PROPERTY_TYPE /*dwPropType*/,
		/*[out]*/ VARIANT* /*pvarPropValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryProperties)(
		/*[in]*/ ULONG /*celt*/,
		/*[in,size_is(celt)]*/ PROCESS_PROPERTY_TYPE* /*rgdwPropTypes*/,
		/*[out,size_is(celt)]*/ VARIANT* /*rgtPropValues*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugProcessQueryPropertiesMockImpl :
	public IDebugProcessQueryProperties,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugProcessQueryPropertiesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugProcessQueryPropertiesMockImpl)

	typedef IDebugProcessQueryProperties Interface;
	struct QueryPropertyValidValues
	{
		/*[in]*/ PROCESS_PROPERTY_TYPE dwPropType;
		/*[out]*/ VARIANT* pvarPropValue;
		HRESULT retValue;
	};

	STDMETHOD(QueryProperty)(
		/*[in]*/ PROCESS_PROPERTY_TYPE dwPropType,
		/*[out]*/ VARIANT* pvarPropValue)
	{
		VSL_DEFINE_MOCK_METHOD(QueryProperty)

		VSL_CHECK_VALIDVALUE(dwPropType);

		VSL_SET_VALIDVALUE_VARIANT(pvarPropValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryPropertiesValidValues
	{
		/*[in]*/ ULONG celt;
		/*[in,size_is(celt)]*/ PROCESS_PROPERTY_TYPE* rgdwPropTypes;
		/*[out,size_is(celt)]*/ VARIANT* rgtPropValues;
		HRESULT retValue;
	};

	STDMETHOD(QueryProperties)(
		/*[in]*/ ULONG celt,
		/*[in,size_is(celt)]*/ PROCESS_PROPERTY_TYPE* rgdwPropTypes,
		/*[out,size_is(celt)]*/ VARIANT* rgtPropValues)
	{
		VSL_DEFINE_MOCK_METHOD(QueryProperties)

		VSL_CHECK_VALIDVALUE(celt);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgdwPropTypes, celt*sizeof(rgdwPropTypes[0]), validValues.celt*sizeof(validValues.rgdwPropTypes[0]));

		VSL_SET_VALIDVALUE_MEMCPY(rgtPropValues, celt*sizeof(rgtPropValues[0]), validValues.celt*sizeof(validValues.rgtPropValues[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROCESSQUERYPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
