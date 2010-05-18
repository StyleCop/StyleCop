/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROPERTYPAGENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROPERTYPAGENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsPropertyPageNotifyNotImpl :
	public IVsPropertyPageNotify
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPageNotifyNotImpl)

public:

	typedef IVsPropertyPageNotify Interface;

	STDMETHOD(OnShowPage)(
		/*[in]*/ BOOL /*fPageActivated*/)VSL_STDMETHOD_NOTIMPL
};

class IVsPropertyPageNotifyMockImpl :
	public IVsPropertyPageNotify,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsPropertyPageNotifyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsPropertyPageNotifyMockImpl)

	typedef IVsPropertyPageNotify Interface;
	struct OnShowPageValidValues
	{
		/*[in]*/ BOOL fPageActivated;
		HRESULT retValue;
	};

	STDMETHOD(OnShowPage)(
		/*[in]*/ BOOL fPageActivated)
	{
		VSL_DEFINE_MOCK_METHOD(OnShowPage)

		VSL_CHECK_VALIDVALUE(fPageActivated);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROPERTYPAGENOTIFY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
