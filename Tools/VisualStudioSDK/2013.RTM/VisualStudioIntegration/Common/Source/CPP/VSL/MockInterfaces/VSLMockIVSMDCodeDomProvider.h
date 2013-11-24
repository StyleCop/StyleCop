/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDCODEDOMPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDCODEDOMPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVSMDCodeDomProviderNotImpl :
	public IVSMDCodeDomProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDCodeDomProviderNotImpl)

public:

	typedef IVSMDCodeDomProvider Interface;

	STDMETHOD(get_CodeDomProvider)(
		/*[out,retval]*/ IDispatch** /*ppProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVSMDCodeDomProviderMockImpl :
	public IVSMDCodeDomProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDCodeDomProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDCodeDomProviderMockImpl)

	typedef IVSMDCodeDomProvider Interface;
	struct get_CodeDomProviderValidValues
	{
		/*[out,retval]*/ IDispatch** ppProvider;
		HRESULT retValue;
	};

	STDMETHOD(get_CodeDomProvider)(
		/*[out,retval]*/ IDispatch** ppProvider)
	{
		VSL_DEFINE_MOCK_METHOD(get_CodeDomProvider)

		VSL_SET_VALIDVALUE_INTERFACE(ppProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDCODEDOMPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
