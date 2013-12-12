/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGTHREADDESTROYEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGTHREADDESTROYEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugThreadDestroyEvent2NotImpl :
	public IDebugThreadDestroyEvent2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugThreadDestroyEvent2NotImpl)

public:

	typedef IDebugThreadDestroyEvent2 Interface;

	STDMETHOD(GetExitCode)(
		/*[out]*/ DWORD* /*pdwExit*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugThreadDestroyEvent2MockImpl :
	public IDebugThreadDestroyEvent2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugThreadDestroyEvent2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugThreadDestroyEvent2MockImpl)

	typedef IDebugThreadDestroyEvent2 Interface;
	struct GetExitCodeValidValues
	{
		/*[out]*/ DWORD* pdwExit;
		HRESULT retValue;
	};

	STDMETHOD(GetExitCode)(
		/*[out]*/ DWORD* pdwExit)
	{
		VSL_DEFINE_MOCK_METHOD(GetExitCode)

		VSL_SET_VALIDVALUE(pdwExit);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGTHREADDESTROYEVENT2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
