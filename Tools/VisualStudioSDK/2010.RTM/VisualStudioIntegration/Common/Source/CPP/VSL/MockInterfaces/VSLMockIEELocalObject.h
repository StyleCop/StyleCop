/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IEELOCALOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IEELOCALOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IEELocalObjectNotImpl :
	public IEELocalObject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEELocalObjectNotImpl)

public:

	typedef IEELocalObject Interface;

	STDMETHOD(SetCallback)(
		/*[in]*/ IDebugSettingsCallback2* /*pCallback*/)VSL_STDMETHOD_NOTIMPL
};

class IEELocalObjectMockImpl :
	public IEELocalObject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IEELocalObjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IEELocalObjectMockImpl)

	typedef IEELocalObject Interface;
	struct SetCallbackValidValues
	{
		/*[in]*/ IDebugSettingsCallback2* pCallback;
		HRESULT retValue;
	};

	STDMETHOD(SetCallback)(
		/*[in]*/ IDebugSettingsCallback2* pCallback)
	{
		VSL_DEFINE_MOCK_METHOD(SetCallback)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallback);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IEELOCALOBJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
