/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDISPATCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDISPATCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsdisp.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsDispatchNotImpl :
	public IVsDispatch
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDispatchNotImpl)

public:

	typedef IVsDispatch Interface;

	STDMETHOD(Do)(
		/*[in]*/ VSDISPID /*vsdispid*/,
		/*[in]*/ long /*celIn*/,
		/*[in,size_is(celIn)]*/ VARIANT* /*rgvaIn*/,
		/*[in]*/ long /*celOut*/,
		/*[in,out,size_is(celOut)]*/ VARIANT* /*rgvaOut*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDispatchMockImpl :
	public IVsDispatch,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDispatchMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDispatchMockImpl)

	typedef IVsDispatch Interface;
	struct DoValidValues
	{
		/*[in]*/ VSDISPID vsdispid;
		/*[in]*/ long celIn;
		/*[in,size_is(celIn)]*/ VARIANT* rgvaIn;
		/*[in]*/ long celOut;
		/*[in,out,size_is(celOut)]*/ VARIANT* rgvaOut;
		HRESULT retValue;
	};

	STDMETHOD(Do)(
		/*[in]*/ VSDISPID vsdispid,
		/*[in]*/ long celIn,
		/*[in,size_is(celIn)]*/ VARIANT* rgvaIn,
		/*[in]*/ long celOut,
		/*[in,out,size_is(celOut)]*/ VARIANT* rgvaOut)
	{
		VSL_DEFINE_MOCK_METHOD(Do)

		VSL_CHECK_VALIDVALUE(vsdispid);

		VSL_CHECK_VALIDVALUE(celIn);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgvaIn, celIn*sizeof(rgvaIn[0]), validValues.celIn*sizeof(validValues.rgvaIn[0]));

		VSL_CHECK_VALIDVALUE(celOut);

		VSL_SET_VALIDVALUE_MEMCPY(rgvaOut, celOut*sizeof(rgvaOut[0]), validValues.celOut*sizeof(validValues.rgvaOut[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDISPATCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
