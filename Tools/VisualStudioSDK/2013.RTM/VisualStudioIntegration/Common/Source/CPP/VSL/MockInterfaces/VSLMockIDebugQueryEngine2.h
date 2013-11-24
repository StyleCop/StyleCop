/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGQUERYENGINE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGQUERYENGINE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugQueryEngine2NotImpl :
	public IDebugQueryEngine2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugQueryEngine2NotImpl)

public:

	typedef IDebugQueryEngine2 Interface;

	STDMETHOD(GetEngineInterface)(
		/*[out]*/ IUnknown** /*ppUnk*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugQueryEngine2MockImpl :
	public IDebugQueryEngine2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugQueryEngine2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugQueryEngine2MockImpl)

	typedef IDebugQueryEngine2 Interface;
	struct GetEngineInterfaceValidValues
	{
		/*[out]*/ IUnknown** ppUnk;
		HRESULT retValue;
	};

	STDMETHOD(GetEngineInterface)(
		/*[out]*/ IUnknown** ppUnk)
	{
		VSL_DEFINE_MOCK_METHOD(GetEngineInterface)

		VSL_SET_VALIDVALUE_INTERFACE(ppUnk);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGQUERYENGINE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
