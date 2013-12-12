/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPROPERTYSAFETYWRAPPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPROPERTYSAFETYWRAPPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugPropertySafetyWrapperNotImpl :
	public IDebugPropertySafetyWrapper
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPropertySafetyWrapperNotImpl)

public:

	typedef IDebugPropertySafetyWrapper Interface;

	STDMETHOD(BeforePropertyCall)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AfterPropertyCall)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetRawProperty)(
		/*[out]*/ IDebugProperty3** /*ppProperty*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugPropertySafetyWrapperMockImpl :
	public IDebugPropertySafetyWrapper,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPropertySafetyWrapperMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugPropertySafetyWrapperMockImpl)

	typedef IDebugPropertySafetyWrapper Interface;
	struct BeforePropertyCallValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(BeforePropertyCall)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(BeforePropertyCall)

		VSL_RETURN_VALIDVALUES();
	}
	struct AfterPropertyCallValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(AfterPropertyCall)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(AfterPropertyCall)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetRawPropertyValidValues
	{
		/*[out]*/ IDebugProperty3** ppProperty;
		HRESULT retValue;
	};

	STDMETHOD(GetRawProperty)(
		/*[out]*/ IDebugProperty3** ppProperty)
	{
		VSL_DEFINE_MOCK_METHOD(GetRawProperty)

		VSL_SET_VALIDVALUE_INTERFACE(ppProperty);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPROPERTYSAFETYWRAPPER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
