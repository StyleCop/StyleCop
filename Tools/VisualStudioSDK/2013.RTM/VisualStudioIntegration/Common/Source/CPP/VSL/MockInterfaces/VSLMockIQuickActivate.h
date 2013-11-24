/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IQUICKACTIVATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IQUICKACTIVATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OCIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IQuickActivateNotImpl :
	public IQuickActivate
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IQuickActivateNotImpl)

public:

	typedef IQuickActivate Interface;

	STDMETHOD(QuickActivate)(
		/*[in]*/ QACONTAINER* /*pQaContainer*/,
		/*[in,out]*/ QACONTROL* /*pQaControl*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetContentExtent)(
		/*[in]*/ LPSIZEL /*pSizel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetContentExtent)(
		/*[out]*/ LPSIZEL /*pSizel*/)VSL_STDMETHOD_NOTIMPL
};

class IQuickActivateMockImpl :
	public IQuickActivate,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IQuickActivateMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IQuickActivateMockImpl)

	typedef IQuickActivate Interface;
	struct QuickActivateValidValues
	{
		/*[in]*/ QACONTAINER* pQaContainer;
		/*[in,out]*/ QACONTROL* pQaControl;
		HRESULT retValue;
	};

	STDMETHOD(QuickActivate)(
		/*[in]*/ QACONTAINER* pQaContainer,
		/*[in,out]*/ QACONTROL* pQaControl)
	{
		VSL_DEFINE_MOCK_METHOD(QuickActivate)

		VSL_CHECK_VALIDVALUE_POINTER(pQaContainer);

		VSL_SET_VALIDVALUE(pQaControl);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetContentExtentValidValues
	{
		/*[in]*/ LPSIZEL pSizel;
		HRESULT retValue;
	};

	STDMETHOD(SetContentExtent)(
		/*[in]*/ LPSIZEL pSizel)
	{
		VSL_DEFINE_MOCK_METHOD(SetContentExtent)

		VSL_CHECK_VALIDVALUE(pSizel);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetContentExtentValidValues
	{
		/*[out]*/ LPSIZEL pSizel;
		HRESULT retValue;
	};

	STDMETHOD(GetContentExtent)(
		/*[out]*/ LPSIZEL pSizel)
	{
		VSL_DEFINE_MOCK_METHOD(GetContentExtent)

		VSL_SET_VALIDVALUE(pSizel);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IQUICKACTIVATE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
