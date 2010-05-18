/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDTYPERESOLUTIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDTYPERESOLUTIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVSMDTypeResolutionServiceNotImpl :
	public IVSMDTypeResolutionService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDTypeResolutionServiceNotImpl)

public:

	typedef IVSMDTypeResolutionService Interface;

	STDMETHOD(get_TypeResolutionService)(
		/*[out,retval]*/ IDispatch** /*ppTrs*/)VSL_STDMETHOD_NOTIMPL
};

class IVSMDTypeResolutionServiceMockImpl :
	public IVSMDTypeResolutionService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDTypeResolutionServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDTypeResolutionServiceMockImpl)

	typedef IVSMDTypeResolutionService Interface;
	struct get_TypeResolutionServiceValidValues
	{
		/*[out,retval]*/ IDispatch** ppTrs;
		HRESULT retValue;
	};

	STDMETHOD(get_TypeResolutionService)(
		/*[out,retval]*/ IDispatch** ppTrs)
	{
		VSL_DEFINE_MOCK_METHOD(get_TypeResolutionService)

		VSL_SET_VALIDVALUE_INTERFACE(ppTrs);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDTYPERESOLUTIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
