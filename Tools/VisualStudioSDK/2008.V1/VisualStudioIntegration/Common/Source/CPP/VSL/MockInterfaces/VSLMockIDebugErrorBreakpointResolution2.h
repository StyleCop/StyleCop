/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGERRORBREAKPOINTRESOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGERRORBREAKPOINTRESOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugErrorBreakpointResolution2NotImpl :
	public IDebugErrorBreakpointResolution2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugErrorBreakpointResolution2NotImpl)

public:

	typedef IDebugErrorBreakpointResolution2 Interface;

	STDMETHOD(GetBreakpointType)(
		/*[out]*/ BP_TYPE* /*pBPType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetResolutionInfo)(
		/*[in]*/ BPERESI_FIELDS /*dwFields*/,
		/*[out]*/ BP_ERROR_RESOLUTION_INFO* /*pErrorResolutionInfo*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugErrorBreakpointResolution2MockImpl :
	public IDebugErrorBreakpointResolution2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugErrorBreakpointResolution2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugErrorBreakpointResolution2MockImpl)

	typedef IDebugErrorBreakpointResolution2 Interface;
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
		/*[in]*/ BPERESI_FIELDS dwFields;
		/*[out]*/ BP_ERROR_RESOLUTION_INFO* pErrorResolutionInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetResolutionInfo)(
		/*[in]*/ BPERESI_FIELDS dwFields,
		/*[out]*/ BP_ERROR_RESOLUTION_INFO* pErrorResolutionInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetResolutionInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(pErrorResolutionInfo);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGERRORBREAKPOINTRESOLUTION2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
