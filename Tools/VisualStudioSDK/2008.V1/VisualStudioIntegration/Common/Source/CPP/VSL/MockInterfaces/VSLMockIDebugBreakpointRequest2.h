/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGBREAKPOINTREQUEST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGBREAKPOINTREQUEST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugBreakpointRequest2NotImpl :
	public IDebugBreakpointRequest2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBreakpointRequest2NotImpl)

public:

	typedef IDebugBreakpointRequest2 Interface;

	STDMETHOD(GetLocationType)(
		/*[out]*/ BP_LOCATION_TYPE* /*pBPLocationType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRequestInfo)(
		/*[in]*/ BPREQI_FIELDS /*dwFields*/,
		/*[out]*/ BP_REQUEST_INFO* /*pBPRequestInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugBreakpointRequest2MockImpl :
	public IDebugBreakpointRequest2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBreakpointRequest2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugBreakpointRequest2MockImpl)

	typedef IDebugBreakpointRequest2 Interface;
	struct GetLocationTypeValidValues
	{
		/*[out]*/ BP_LOCATION_TYPE* pBPLocationType;
		HRESULT retValue;
	};

	STDMETHOD(GetLocationType)(
		/*[out]*/ BP_LOCATION_TYPE* pBPLocationType)
	{
		VSL_DEFINE_MOCK_METHOD(GetLocationType)

		VSL_SET_VALIDVALUE(pBPLocationType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRequestInfoValidValues
	{
		/*[in]*/ BPREQI_FIELDS dwFields;
		/*[out]*/ BP_REQUEST_INFO* pBPRequestInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetRequestInfo)(
		/*[in]*/ BPREQI_FIELDS dwFields,
		/*[out]*/ BP_REQUEST_INFO* pBPRequestInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetRequestInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(pBPRequestInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGBREAKPOINTREQUEST2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
