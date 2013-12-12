/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGENCNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGENCNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugEncNotifyNotImpl :
	public IDebugEncNotify
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEncNotifyNotImpl)

public:

	typedef IDebugEncNotify Interface;

	STDMETHOD(NotifyEncIsUnavailable)(
		/*[in]*/ EncUnavailableReason /*reason*/,
		/*[in]*/ BOOL /*fEditWasApplied*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyEncUpdateCurrentStatement)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyEncEditAttemptedAtInvalidStopState)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(NotifyEncEditDisallowedByProject)(
		/*[in]*/ IUnknown* /*pProject*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugEncNotifyMockImpl :
	public IDebugEncNotify,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugEncNotifyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugEncNotifyMockImpl)

	typedef IDebugEncNotify Interface;
	struct NotifyEncIsUnavailableValidValues
	{
		/*[in]*/ EncUnavailableReason reason;
		/*[in]*/ BOOL fEditWasApplied;
		HRESULT retValue;
	};

	STDMETHOD(NotifyEncIsUnavailable)(
		/*[in]*/ EncUnavailableReason reason,
		/*[in]*/ BOOL fEditWasApplied)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyEncIsUnavailable)

		VSL_CHECK_VALIDVALUE(reason);

		VSL_CHECK_VALIDVALUE(fEditWasApplied);

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyEncUpdateCurrentStatementValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(NotifyEncUpdateCurrentStatement)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(NotifyEncUpdateCurrentStatement)

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyEncEditAttemptedAtInvalidStopStateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(NotifyEncEditAttemptedAtInvalidStopState)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(NotifyEncEditAttemptedAtInvalidStopState)

		VSL_RETURN_VALIDVALUES();
	}
	struct NotifyEncEditDisallowedByProjectValidValues
	{
		/*[in]*/ IUnknown* pProject;
		HRESULT retValue;
	};

	STDMETHOD(NotifyEncEditDisallowedByProject)(
		/*[in]*/ IUnknown* pProject)
	{
		VSL_DEFINE_MOCK_METHOD(NotifyEncEditDisallowedByProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProject);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGENCNOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
