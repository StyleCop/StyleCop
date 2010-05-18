/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSREGISTERSCCIPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSREGISTERSCCIPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "IVsRegisterScciProvider.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsRegisterScciProviderNotImpl :
	public IVsRegisterScciProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterScciProviderNotImpl)

public:

	typedef IVsRegisterScciProvider Interface;

	STDMETHOD(RegisterSourceControlProvider)(
		/*[in]*/ GUID /*guidProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRegisterScciProviderMockImpl :
	public IVsRegisterScciProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterScciProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRegisterScciProviderMockImpl)

	typedef IVsRegisterScciProvider Interface;
	struct RegisterSourceControlProviderValidValues
	{
		/*[in]*/ GUID guidProvider;
		HRESULT retValue;
	};

	STDMETHOD(RegisterSourceControlProvider)(
		/*[in]*/ GUID guidProvider)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterSourceControlProvider)

		VSL_CHECK_VALIDVALUE(guidProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSREGISTERSCCIPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
