/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICONNECTIONPOINTCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICONNECTIONPOINTCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IConnectionPointContainerNotImpl :
	public IConnectionPointContainer
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IConnectionPointContainerNotImpl)

public:

	typedef IConnectionPointContainer Interface;

	STDMETHOD(EnumConnectionPoints)(
		/*[out]*/ IEnumConnectionPoints** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(FindConnectionPoint)(
		/*[in]*/ REFIID /*riid*/,
		/*[out]*/ IConnectionPoint** /*ppCP*/)VSL_STDMETHOD_NOTIMPL
};

class IConnectionPointContainerMockImpl :
	public IConnectionPointContainer,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IConnectionPointContainerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IConnectionPointContainerMockImpl)

	typedef IConnectionPointContainer Interface;
	struct EnumConnectionPointsValidValues
	{
		/*[out]*/ IEnumConnectionPoints** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumConnectionPoints)(
		/*[out]*/ IEnumConnectionPoints** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumConnectionPoints)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct FindConnectionPointValidValues
	{
		/*[in]*/ REFIID riid;
		/*[out]*/ IConnectionPoint** ppCP;
		HRESULT retValue;
	};

	STDMETHOD(FindConnectionPoint)(
		/*[in]*/ REFIID riid,
		/*[out]*/ IConnectionPoint** ppCP)
	{
		VSL_DEFINE_MOCK_METHOD(FindConnectionPoint)

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE_INTERFACE(ppCP);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICONNECTIONPOINTCONTAINER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
