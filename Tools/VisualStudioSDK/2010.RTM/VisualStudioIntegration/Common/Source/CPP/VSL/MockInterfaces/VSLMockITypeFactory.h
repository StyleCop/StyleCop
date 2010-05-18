/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITYPEFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITYPEFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OAIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ITypeFactoryNotImpl :
	public ITypeFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeFactoryNotImpl)

public:

	typedef ITypeFactory Interface;

	STDMETHOD(CreateFromTypeInfo)(
		/*[in]*/ ITypeInfo* /*pTypeInfo*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ IUnknown** /*ppv*/)VSL_STDMETHOD_NOTIMPL
};

class ITypeFactoryMockImpl :
	public ITypeFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITypeFactoryMockImpl)

	typedef ITypeFactory Interface;
	struct CreateFromTypeInfoValidValues
	{
		/*[in]*/ ITypeInfo* pTypeInfo;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ IUnknown** ppv;
		HRESULT retValue;
	};

	STDMETHOD(CreateFromTypeInfo)(
		/*[in]*/ ITypeInfo* pTypeInfo,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ IUnknown** ppv)
	{
		VSL_DEFINE_MOCK_METHOD(CreateFromTypeInfo)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTypeInfo);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE_INTERFACE(ppv);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITYPEFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
