/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICLASSACTIVATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICLASSACTIVATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IClassActivatorNotImpl :
	public IClassActivator
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClassActivatorNotImpl)

public:

	typedef IClassActivator Interface;

	STDMETHOD(GetClassObject)(
		/*[in]*/ REFCLSID /*rclsid*/,
		/*[in]*/ DWORD /*dwClassContext*/,
		/*[in]*/ LCID /*locale*/,
		/*[in]*/ REFIID /*riid*/,
		/*[out,iid_is(riid)]*/ void** /*ppv*/)VSL_STDMETHOD_NOTIMPL
};

class IClassActivatorMockImpl :
	public IClassActivator,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IClassActivatorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IClassActivatorMockImpl)

	typedef IClassActivator Interface;
	struct GetClassObjectValidValues
	{
		/*[in]*/ REFCLSID rclsid;
		/*[in]*/ DWORD dwClassContext;
		/*[in]*/ LCID locale;
		/*[in]*/ REFIID riid;
		/*[out,iid_is(riid)]*/ void** ppv;
		HRESULT retValue;
	};

	STDMETHOD(GetClassObject)(
		/*[in]*/ REFCLSID rclsid,
		/*[in]*/ DWORD dwClassContext,
		/*[in]*/ LCID locale,
		/*[in]*/ REFIID riid,
		/*[out,iid_is(riid)]*/ void** ppv)
	{
		VSL_DEFINE_MOCK_METHOD(GetClassObject)

		VSL_CHECK_VALIDVALUE(rclsid);

		VSL_CHECK_VALIDVALUE(dwClassContext);

		VSL_CHECK_VALIDVALUE(locale);

		VSL_CHECK_VALIDVALUE(riid);

		VSL_SET_VALIDVALUE(ppv);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICLASSACTIVATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
