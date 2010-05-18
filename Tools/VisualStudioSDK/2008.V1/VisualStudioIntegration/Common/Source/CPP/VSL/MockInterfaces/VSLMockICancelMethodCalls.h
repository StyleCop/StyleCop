/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ICANCELMETHODCALLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ICANCELMETHODCALLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ICancelMethodCallsNotImpl :
	public ICancelMethodCalls
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICancelMethodCallsNotImpl)

public:

	typedef ICancelMethodCalls Interface;

	STDMETHOD(Cancel)(
		/*[in]*/ ULONG /*ulSeconds*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TestCancel)()VSL_STDMETHOD_NOTIMPL
};

class ICancelMethodCallsMockImpl :
	public ICancelMethodCalls,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ICancelMethodCallsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ICancelMethodCallsMockImpl)

	typedef ICancelMethodCalls Interface;
	struct CancelValidValues
	{
		/*[in]*/ ULONG ulSeconds;
		HRESULT retValue;
	};

	STDMETHOD(Cancel)(
		/*[in]*/ ULONG ulSeconds)
	{
		VSL_DEFINE_MOCK_METHOD(Cancel)

		VSL_CHECK_VALIDVALUE(ulSeconds);

		VSL_RETURN_VALIDVALUES();
	}
	struct TestCancelValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(TestCancel)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(TestCancel)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ICANCELMETHODCALLS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
