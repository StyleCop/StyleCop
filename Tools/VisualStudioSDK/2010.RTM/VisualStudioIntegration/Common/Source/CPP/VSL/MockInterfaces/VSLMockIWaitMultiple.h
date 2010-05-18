/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IWAITMULTIPLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IWAITMULTIPLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IWaitMultipleNotImpl :
	public IWaitMultiple
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IWaitMultipleNotImpl)

public:

	typedef IWaitMultiple Interface;

	STDMETHOD(WaitMultiple)(
		/*[in]*/ DWORD /*timeout*/,
		/*[out]*/ ISynchronize** /*pSync*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddSynchronize)(
		/*[in]*/ ISynchronize* /*pSync*/)VSL_STDMETHOD_NOTIMPL
};

class IWaitMultipleMockImpl :
	public IWaitMultiple,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IWaitMultipleMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IWaitMultipleMockImpl)

	typedef IWaitMultiple Interface;
	struct WaitMultipleValidValues
	{
		/*[in]*/ DWORD timeout;
		/*[out]*/ ISynchronize** pSync;
		HRESULT retValue;
	};

	STDMETHOD(WaitMultiple)(
		/*[in]*/ DWORD timeout,
		/*[out]*/ ISynchronize** pSync)
	{
		VSL_DEFINE_MOCK_METHOD(WaitMultiple)

		VSL_CHECK_VALIDVALUE(timeout);

		VSL_SET_VALIDVALUE_INTERFACE(pSync);

		VSL_RETURN_VALIDVALUES();
	}
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
};


} // namespace VSL

#pragma warning(pop)

#endif // IWAITMULTIPLE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
