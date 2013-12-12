/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLWINDOWFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLWINDOWFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsToolWindowFactoryNotImpl :
	public IVsToolWindowFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolWindowFactoryNotImpl)

public:

	typedef IVsToolWindowFactory Interface;

	STDMETHOD(CreateToolWindow)(
		/*[in]*/ REFGUID /*rguidPersistenceSlot*/,
		/*[in]*/ DWORD /*dwToolWindowId*/)VSL_STDMETHOD_NOTIMPL
};

class IVsToolWindowFactoryMockImpl :
	public IVsToolWindowFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolWindowFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolWindowFactoryMockImpl)

	typedef IVsToolWindowFactory Interface;
	struct CreateToolWindowValidValues
	{
		/*[in]*/ REFGUID rguidPersistenceSlot;
		/*[in]*/ DWORD dwToolWindowId;
		HRESULT retValue;
	};

	STDMETHOD(CreateToolWindow)(
		/*[in]*/ REFGUID rguidPersistenceSlot,
		/*[in]*/ DWORD dwToolWindowId)
	{
		VSL_DEFINE_MOCK_METHOD(CreateToolWindow)

		VSL_CHECK_VALIDVALUE(rguidPersistenceSlot);

		VSL_CHECK_VALIDVALUE(dwToolWindowId);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLWINDOWFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
