/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCUSTOMFINDSCOPENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCUSTOMFINDSCOPENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "customfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCustomFindScopeNotifyNotImpl :
	public IVsCustomFindScopeNotify
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCustomFindScopeNotifyNotImpl)

public:

	typedef IVsCustomFindScopeNotify Interface;

	STDMETHOD(Notify)(
		/*[in]*/ VSCUSTOMFINDSTATUS /*grfStatus*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCustomFindScopeNotifyMockImpl :
	public IVsCustomFindScopeNotify,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCustomFindScopeNotifyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCustomFindScopeNotifyMockImpl)

	typedef IVsCustomFindScopeNotify Interface;
	struct NotifyValidValues
	{
		/*[in]*/ VSCUSTOMFINDSTATUS grfStatus;
		HRESULT retValue;
	};

	STDMETHOD(Notify)(
		/*[in]*/ VSCUSTOMFINDSTATUS grfStatus)
	{
		VSL_DEFINE_MOCK_METHOD(Notify)

		VSL_CHECK_VALIDVALUE(grfStatus);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCUSTOMFINDSCOPENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
