/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEXTENDEDOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEXTENDEDOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "designer.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IExtendedObjectNotImpl :
	public IExtendedObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IExtendedObjectNotImpl)

public:

	typedef IExtendedObject Interface;

	STDMETHOD(GetInnerObject)(
		/*[in]*/ REFIID /*iid*/,
		/*[out,iid_is(iid)]*/ void** /*ppvObject*/)VSL_STDMETHOD_NOTIMPL
};

class IExtendedObjectMockImpl :
	public IExtendedObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IExtendedObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IExtendedObjectMockImpl)

	typedef IExtendedObject Interface;
	struct GetInnerObjectValidValues
	{
		/*[in]*/ REFIID iid;
		/*[out,iid_is(iid)]*/ void** ppvObject;
		HRESULT retValue;
	};

	STDMETHOD(GetInnerObject)(
		/*[in]*/ REFIID iid,
		/*[out,iid_is(iid)]*/ void** ppvObject)
	{
		VSL_DEFINE_MOCK_METHOD(GetInnerObject)

		VSL_CHECK_VALIDVALUE(iid);

		VSL_SET_VALIDVALUE(ppvObject);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEXTENDEDOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
