/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISYNCHRONIZECONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISYNCHRONIZECONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ISynchronizeContainerNotImpl :
	public ISynchronizeContainer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeContainerNotImpl)

public:

	typedef ISynchronizeContainer Interface;

	STDMETHOD(AddSynchronize)(
		/*[in]*/ ISynchronize* /*pSync*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(WaitMultiple)(
		/*[in]*/ DWORD /*dwFlags*/,
		/*[in]*/ DWORD /*dwTimeOut*/,
		/*[out]*/ ISynchronize** /*ppSync*/)VSL_STDMETHOD_NOTIMPL
};

class ISynchronizeContainerMockImpl :
	public ISynchronizeContainer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeContainerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISynchronizeContainerMockImpl)

	typedef ISynchronizeContainer Interface;
	struct AddSynchronizeValidValues
	{
		/*[in]*/ ISynchronize* pSync;
		HRESULT retValue;
	};

	STDMETHOD(AddSynchronize)(
		/*[in]*/ ISynchronize* pSync)
	{
		VSL_DEFINE_MOCK_METHOD(AddSynchronize)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSync);

		VSL_RETURN_VALIDVALUES();
	}
	struct WaitMultipleValidValues
	{
		/*[in]*/ DWORD dwFlags;
		/*[in]*/ DWORD dwTimeOut;
		/*[out]*/ ISynchronize** ppSync;
		HRESULT retValue;
	};

	STDMETHOD(WaitMultiple)(
		/*[in]*/ DWORD dwFlags,
		/*[in]*/ DWORD dwTimeOut,
		/*[out]*/ ISynchronize** ppSync)
	{
		VSL_DEFINE_MOCK_METHOD(WaitMultiple)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_CHECK_VALIDVALUE(dwTimeOut);

		VSL_SET_VALIDVALUE_INTERFACE(ppSync);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISYNCHRONIZECONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
