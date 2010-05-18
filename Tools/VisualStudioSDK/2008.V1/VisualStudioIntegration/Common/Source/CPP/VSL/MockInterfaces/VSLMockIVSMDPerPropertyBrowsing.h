/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsmanaged.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVSMDPerPropertyBrowsingNotImpl :
	public IVSMDPerPropertyBrowsing
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDPerPropertyBrowsingNotImpl)

public:

	typedef IVSMDPerPropertyBrowsing Interface;

	STDMETHOD(GetPropertyAttributes)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out]*/ UINT* /*pceltAttrs*/,
		/*[out,size_is(,*pceltAttrs)]*/ BSTR** /*ppbstrTypeNames*/,
		/*[out,size_is(,*pceltAttrs)]*/ VARIANT** /*ppvarAttrValues*/)VSL_STDMETHOD_NOTIMPL
};

class IVSMDPerPropertyBrowsingMockImpl :
	public IVSMDPerPropertyBrowsing,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDPerPropertyBrowsingMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDPerPropertyBrowsingMockImpl)

	typedef IVSMDPerPropertyBrowsing Interface;
	struct GetPropertyAttributesValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out]*/ UINT* pceltAttrs;
		/*[out,size_is(,*pceltAttrs)]*/ BSTR** ppbstrTypeNames;
		/*[out,size_is(,*pceltAttrs)]*/ VARIANT** ppvarAttrValues;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyAttributes)(
		/*[in]*/ DISPID dispid,
		/*[out]*/ UINT* pceltAttrs,
		/*[out,size_is(,*pceltAttrs)]*/ BSTR** ppbstrTypeNames,
		/*[out,size_is(,*pceltAttrs)]*/ VARIANT** ppvarAttrValues)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyAttributes)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(pceltAttrs);

		VSL_SET_VALIDVALUE_MEMCPY(ppbstrTypeNames, *pceltAttrs*sizeof(ppbstrTypeNames[0]), *(validValues.pceltAttrs)*sizeof(validValues.ppbstrTypeNames[0]));

		VSL_SET_VALIDVALUE_MEMCPY(ppvarAttrValues, *pceltAttrs*sizeof(ppvarAttrValues[0]), *(validValues.pceltAttrs)*sizeof(validValues.ppvarAttrValues[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
