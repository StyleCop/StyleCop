/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGBREAKPOINTRESOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGBREAKPOINTRESOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugBreakpointResolution2NotImpl :
	public IDebugBreakpointResolution2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBreakpointResolution2NotImpl)

public:

	typedef IDebugBreakpointResolution2 Interface;

	STDMETHOD(GetBreakpointType)(
		/*[out]*/ BP_TYPE* /*pBPType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetResolutionInfo)(
		/*[in]*/ BPRESI_FIELDS /*dwFields*/,
		/*[out]*/ BP_RESOLUTION_INFO* /*pBPResolutionInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugBreakpointResolution2MockImpl :
	public IDebugBreakpointResolution2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugBreakpointResolution2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugBreakpointResolution2MockImpl)

	typedef IDebugBreakpointResolution2 Interface;
	struct GetBreakpointTypeValidValues
	{
		/*[out]*/ BP_TYPE* pBPType;
		HRESULT retValue;
	};

	STDMETHOD(GetBreakpointType)(
		/*[out]*/ BP_TYPE* pBPType)
	{
		VSL_DEFINE_MOCK_METHOD(GetBreakpointType)

		VSL_SET_VALIDVALUE(pBPType);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetResolutionInfoValidValues
	{
		/*[in]*/ BPRESI_FIELDS dwFields;
		/*[out]*/ BP_RESOLUTION_INFO* pBPResolutionInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetResolutionInfo)(
		/*[in]*/ BPRESI_FIELDS dwFields,
		/*[out]*/ BP_RESOLUTION_INFO* pBPResolutionInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetResolutionInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(pBPResolutionInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGBREAKPOINTRESOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
