/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCODEWINDOWMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCODEWINDOWMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCodeWindowManagerNotImpl :
	public IVsCodeWindowManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowManagerNotImpl)

public:

	typedef IVsCodeWindowManager Interface;

	STDMETHOD(AddAdornments)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveAdornments)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnNewView)(
		/*[in]*/ IVsTextView* /*pView*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCodeWindowManagerMockImpl :
	public IVsCodeWindowManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCodeWindowManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCodeWindowManagerMockImpl)

	typedef IVsCodeWindowManager Interface;
	struct AddAdornmentsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(AddAdornments)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(AddAdornments)

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveAdornmentsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RemoveAdornments)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RemoveAdornments)

		VSL_RETURN_VALIDVALUES();
	}
	struct OnNewViewValidValues
	{
		/*[in]*/ IVsTextView* pView;
		HRESULT retValue;
	};

	STDMETHOD(OnNewView)(
		/*[in]*/ IVsTextView* pView)
	{
		VSL_DEFINE_MOCK_METHOD(OnNewView)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCODEWINDOWMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
