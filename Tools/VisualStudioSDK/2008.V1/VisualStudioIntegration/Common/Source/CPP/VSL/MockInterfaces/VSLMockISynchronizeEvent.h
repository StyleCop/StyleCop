/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ISYNCHRONIZEEVENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ISYNCHRONIZEEVENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ISynchronizeEventNotImpl :
	public ISynchronizeEvent
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeEventNotImpl)

public:

	typedef ISynchronizeEvent Interface;

	STDMETHOD(SetEventHandle)(
		/*[in]*/ HANDLE* /*ph*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHandle)(
		/*[out]*/ HANDLE* /*ph*/)VSL_STDMETHOD_NOTIMPL
};

class ISynchronizeEventMockImpl :
	public ISynchronizeEvent,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ISynchronizeEventMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ISynchronizeEventMockImpl)

	typedef ISynchronizeEvent Interface;
	struct SetEventHandleValidValues
	{
		/*[in]*/ HANDLE* ph;
		HRESULT retValue;
	};

	STDMETHOD(SetEventHandle)(
		/*[in]*/ HANDLE* ph)
	{
		VSL_DEFINE_MOCK_METHOD(SetEventHandle)

		VSL_CHECK_VALIDVALUE_POINTER(ph);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHandleValidValues
	{
		/*[out]*/ HANDLE* ph;
		HRESULT retValue;
	};

	STDMETHOD(GetHandle)(
		/*[out]*/ HANDLE* ph)
	{
		VSL_DEFINE_MOCK_METHOD(GetHandle)

		VSL_SET_VALIDVALUE(ph);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ISYNCHRONIZEEVENT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
