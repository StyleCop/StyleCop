/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICLASSFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICLASSFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "Unknwn.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IClassFactoryNotImpl :
	public IClassFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClassFactoryNotImpl)

public:

	typedef IClassFactory Interface;

	STDMETHOD(CreateInstance)(
		/*[in,unique]*/ IUnknown* /*pUnkOuter*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppvObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LockServer)(
		/*[in]*/ BOOL /*fLock*/)VSL_STDMETHOD_NOTIMPL
};

class IClassFactoryMockImpl :
	public IClassFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClassFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IClassFactoryMockImpl)

	typedef IClassFactory Interface;
	struct CreateInstanceValidValues
	{
		/*[in,unique]*/ IUnknown* pUnkOuter;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppvObject;
		HRESULT retValue;
	};

	STDMETHOD(CreateInstance)(
		/*[in,unique]*/ IUnknown* pUnkOuter,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppvObject)
	{
		VSL_DEFINE_MOCK_METHOD(CreateInstance)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkOuter);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppvObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct LockServerValidValues
	{
		/*[in]*/ BOOL fLock;
		HRESULT retValue;
	};

	STDMETHOD(LockServer)(
		/*[in]*/ BOOL fLock)
	{
		VSL_DEFINE_MOCK_METHOD(LockServer)

		VSL_CHECK_VALIDVALUE(fLock);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICLASSFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
