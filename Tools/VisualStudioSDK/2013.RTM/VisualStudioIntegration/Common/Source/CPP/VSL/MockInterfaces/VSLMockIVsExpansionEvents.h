/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXPANSIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXPANSIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsExpansionEventsNotImpl :
	public IVsExpansionEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionEventsNotImpl)

public:

	typedef IVsExpansionEvents Interface;

	STDMETHOD(OnAfterSnippetsUpdate)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAfterSnippetsKeyBindingChange)(
		/*[in]*/ DWORD /*dwCmdGuid*/,
		/*[in]*/ DWORD /*dwCmdId*/,
		/*[in]*/ BOOL /*fBound*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExpansionEventsMockImpl :
	public IVsExpansionEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExpansionEventsMockImpl)

	typedef IVsExpansionEvents Interface;
	struct OnAfterSnippetsUpdateValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnAfterSnippetsUpdate)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnAfterSnippetsUpdate)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAfterSnippetsKeyBindingChangeValidValues
	{
		/*[in]*/ DWORD dwCmdGuid;
		/*[in]*/ DWORD dwCmdId;
		/*[in]*/ BOOL fBound;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterSnippetsKeyBindingChange)(
		/*[in]*/ DWORD dwCmdGuid,
		/*[in]*/ DWORD dwCmdId,
		/*[in]*/ BOOL fBound)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterSnippetsKeyBindingChange)

		VSL_CHECK_VALIDVALUE(dwCmdGuid);

		VSL_CHECK_VALIDVALUE(dwCmdId);

		VSL_CHECK_VALIDVALUE(fBound);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXPANSIONEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
