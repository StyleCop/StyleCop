/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGPORTEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGPORTEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugPortEvents2NotImpl :
	public IDebugPortEvents2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPortEvents2NotImpl)

public:

	typedef IDebugPortEvents2 Interface;

	STDMETHOD(Event)(
		/*[in]*/ IDebugCoreServer2* /*pServer*/,
		/*[in]*/ IDebugPort2* /*pPort*/,
		/*[in]*/ IDebugProcess2* /*pProcess*/,
		/*[in]*/ IDebugProgram2* /*pProgram*/,
		/*[in]*/ IDebugEvent2* /*pEvent*/,
		/*[in]*/ REFIID /*riidEvent*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugPortEvents2MockImpl :
	public IDebugPortEvents2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugPortEvents2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugPortEvents2MockImpl)

	typedef IDebugPortEvents2 Interface;
	struct EventValidValues
	{
		/*[in]*/ IDebugCoreServer2* pServer;
		/*[in]*/ IDebugPort2* pPort;
		/*[in]*/ IDebugProcess2* pProcess;
		/*[in]*/ IDebugProgram2* pProgram;
		/*[in]*/ IDebugEvent2* pEvent;
		/*[in]*/ REFIID riidEvent;
		HRESULT retValue;
	};

	STDMETHOD(Event)(
		/*[in]*/ IDebugCoreServer2* pServer,
		/*[in]*/ IDebugPort2* pPort,
		/*[in]*/ IDebugProcess2* pProcess,
		/*[in]*/ IDebugProgram2* pProgram,
		/*[in]*/ IDebugEvent2* pEvent,
		/*[in]*/ REFIID riidEvent)
	{
		VSL_DEFINE_MOCK_METHOD(Event)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pServer);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPort);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProcess);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProgram);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pEvent);

		VSL_CHECK_VALIDVALUE(riidEvent);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGPORTEVENTS2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
