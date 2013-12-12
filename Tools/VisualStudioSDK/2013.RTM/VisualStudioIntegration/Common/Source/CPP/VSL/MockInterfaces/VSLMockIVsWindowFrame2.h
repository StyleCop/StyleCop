/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWINDOWFRAME2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWINDOWFRAME2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWindowFrame2NotImpl :
	public IVsWindowFrame2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrame2NotImpl)

public:

	typedef IVsWindowFrame2 Interface;

	STDMETHOD(Advise)(
		/*[in]*/ IVsWindowFrameNotify* /*pNotify*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Unadvise)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ActivateOwnerDockedWindow)()VSL_STDMETHOD_NOTIMPL
};

class IVsWindowFrame2MockImpl :
	public IVsWindowFrame2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWindowFrame2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWindowFrame2MockImpl)

	typedef IVsWindowFrame2 Interface;
	struct AdviseValidValues
	{
		/*[in]*/ IVsWindowFrameNotify* pNotify;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(Advise)(
		/*[in]*/ IVsWindowFrameNotify* pNotify,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Advise)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pNotify);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(Unadvise)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(Unadvise)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct ActivateOwnerDockedWindowValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(ActivateOwnerDockedWindow)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(ActivateOwnerDockedWindow)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWINDOWFRAME2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
