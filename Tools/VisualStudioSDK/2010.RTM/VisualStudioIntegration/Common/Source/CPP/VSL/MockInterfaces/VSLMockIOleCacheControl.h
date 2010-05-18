/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IOLECACHECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IOLECACHECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OleIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IOleCacheControlNotImpl :
	public IOleCacheControl
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCacheControlNotImpl)

public:

	typedef IOleCacheControl Interface;

	STDMETHOD(OnRun)(
		/*[in]*/ LPDATAOBJECT /*pDataObject*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnStop)()VSL_STDMETHOD_NOTIMPL
};

class IOleCacheControlMockImpl :
	public IOleCacheControl,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IOleCacheControlMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IOleCacheControlMockImpl)

	typedef IOleCacheControl Interface;
	struct OnRunValidValues
	{
		/*[in]*/ LPDATAOBJECT pDataObject;
		HRESULT retValue;
	};

	STDMETHOD(OnRun)(
		/*[in]*/ LPDATAOBJECT pDataObject)
	{
		VSL_DEFINE_MOCK_METHOD(OnRun)

		VSL_CHECK_VALIDVALUE(pDataObject);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnStopValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnStop)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnStop)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IOLECACHECONTROL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
