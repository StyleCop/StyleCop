/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROPERTYPAGESITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROPERTYPAGESITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IPropertyPageSiteNotImpl :
	public IPropertyPageSite
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyPageSiteNotImpl)

public:

	typedef IPropertyPageSite Interface;

	STDMETHOD(OnStatusChange)(
		/*[in]*/ DWORD /*dwFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetLocaleID)(
		/*[out]*/ LCID* /*pLocaleID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPageContainer)(
		/*[out]*/ IUnknown** /*ppUnk*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ MSG* /*pMsg*/)VSL_STDMETHOD_NOTIMPL
};

class IPropertyPageSiteMockImpl :
	public IPropertyPageSite,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyPageSiteMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPropertyPageSiteMockImpl)

	typedef IPropertyPageSite Interface;
	struct OnStatusChangeValidValues
	{
		/*[in]*/ DWORD dwFlags;
		HRESULT retValue;
	};

	STDMETHOD(OnStatusChange)(
		/*[in]*/ DWORD dwFlags)
	{
		VSL_DEFINE_MOCK_METHOD(OnStatusChange)

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetLocaleIDValidValues
	{
		/*[out]*/ LCID* pLocaleID;
		HRESULT retValue;
	};

	STDMETHOD(GetLocaleID)(
		/*[out]*/ LCID* pLocaleID)
	{
		VSL_DEFINE_MOCK_METHOD(GetLocaleID)

		VSL_SET_VALIDVALUE(pLocaleID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPageContainerValidValues
	{
		/*[out]*/ IUnknown** ppUnk;
		HRESULT retValue;
	};

	STDMETHOD(GetPageContainer)(
		/*[out]*/ IUnknown** ppUnk)
	{
		VSL_DEFINE_MOCK_METHOD(GetPageContainer)

		VSL_SET_VALIDVALUE_INTERFACE(ppUnk);

		VSL_RETURN_VALIDVALUES();
	}
	struct TranslateAcceleratorValidValues
	{
		/*[in]*/ MSG* pMsg;
		HRESULT retValue;
	};

	STDMETHOD(TranslateAccelerator)(
		/*[in]*/ MSG* pMsg)
	{
		VSL_DEFINE_MOCK_METHOD(TranslateAccelerator)

		VSL_CHECK_VALIDVALUE_POINTER(pMsg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROPERTYPAGESITE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
