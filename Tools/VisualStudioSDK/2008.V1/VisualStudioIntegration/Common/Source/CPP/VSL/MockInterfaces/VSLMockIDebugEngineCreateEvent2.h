/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGENGINECREATEEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGENGINECREATEEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugEngineCreateEvent2NotImpl :
	public IDebugEngineCreateEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngineCreateEvent2NotImpl)

public:

	typedef IDebugEngineCreateEvent2 Interface;

	STDMETHOD(GetEngine)(
		/*[out]*/ IDebugEngine2** /*pEngine*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugEngineCreateEvent2MockImpl :
	public IDebugEngineCreateEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEngineCreateEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugEngineCreateEvent2MockImpl)

	typedef IDebugEngineCreateEvent2 Interface;
	struct GetEngineValidValues
	{
		/*[out]*/ IDebugEngine2** pEngine;
		HRESULT retValue;
	};

	STDMETHOD(GetEngine)(
		/*[out]*/ IDebugEngine2** pEngine)
	{
		VSL_DEFINE_MOCK_METHOD(GetEngine)

		VSL_SET_VALIDVALUE_INTERFACE(pEngine);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGENGINECREATEEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
