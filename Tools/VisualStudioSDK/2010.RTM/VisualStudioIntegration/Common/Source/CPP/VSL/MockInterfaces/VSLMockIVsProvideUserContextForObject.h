/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROVIDEUSERCONTEXTFOROBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROVIDEUSERCONTEXTFOROBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsProvideUserContextForObjectNotImpl :
	public IVsProvideUserContextForObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProvideUserContextForObjectNotImpl)

public:

	typedef IVsProvideUserContextForObject Interface;

	STDMETHOD(GetObjectContext)(
		/*[in]*/ IUnknown* /*punk*/,
		/*[out,retval]*/ IVsUserContext** /*ppctx*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProvideUserContextForObjectMockImpl :
	public IVsProvideUserContextForObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProvideUserContextForObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProvideUserContextForObjectMockImpl)

	typedef IVsProvideUserContextForObject Interface;
	struct GetObjectContextValidValues
	{
		/*[in]*/ IUnknown* punk;
		/*[out,retval]*/ IVsUserContext** ppctx;
		HRESULT retValue;
	};

	STDMETHOD(GetObjectContext)(
		/*[in]*/ IUnknown* punk,
		/*[out,retval]*/ IVsUserContext** ppctx)
	{
		VSL_DEFINE_MOCK_METHOD(GetObjectContext)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punk);

		VSL_SET_VALIDVALUE_INTERFACE(ppctx);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROVIDEUSERCONTEXTFOROBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
