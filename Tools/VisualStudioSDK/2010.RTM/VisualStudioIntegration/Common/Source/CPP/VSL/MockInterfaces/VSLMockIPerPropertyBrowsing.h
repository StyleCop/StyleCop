/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IPerPropertyBrowsingNotImpl :
	public IPerPropertyBrowsing
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPerPropertyBrowsingNotImpl)

public:

	typedef IPerPropertyBrowsing Interface;

	STDMETHOD(GetDisplayString)(
		/*[in]*/ DISPID /*dispID*/,
		/*[out]*/ BSTR* /*pBstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(MapPropertyToPage)(
		/*[in]*/ DISPID /*dispID*/,
		/*[out]*/ CLSID* /*pClsid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPredefinedStrings)(
		/*[in]*/ DISPID /*dispID*/,
		/*[out]*/ CALPOLESTR* /*pCaStringsOut*/,
		/*[out]*/ CADWORD* /*pCaCookiesOut*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPredefinedValue)(
		/*[in]*/ DISPID /*dispID*/,
		/*[in]*/ DWORD /*dwCookie*/,
		/*[out]*/ VARIANT* /*pVarOut*/)VSL_STDMETHOD_NOTIMPL
};

class IPerPropertyBrowsingMockImpl :
	public IPerPropertyBrowsing,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPerPropertyBrowsingMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPerPropertyBrowsingMockImpl)

	typedef IPerPropertyBrowsing Interface;
	struct GetDisplayStringValidValues
	{
		/*[in]*/ DISPID dispID;
		/*[out]*/ BSTR* pBstr;
		HRESULT retValue;
	};

	STDMETHOD(GetDisplayString)(
		/*[in]*/ DISPID dispID,
		/*[out]*/ BSTR* pBstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetDisplayString)

		VSL_CHECK_VALIDVALUE(dispID);

		VSL_SET_VALIDVALUE_BSTR(pBstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct MapPropertyToPageValidValues
	{
		/*[in]*/ DISPID dispID;
		/*[out]*/ CLSID* pClsid;
		HRESULT retValue;
	};

	STDMETHOD(MapPropertyToPage)(
		/*[in]*/ DISPID dispID,
		/*[out]*/ CLSID* pClsid)
	{
		VSL_DEFINE_MOCK_METHOD(MapPropertyToPage)

		VSL_CHECK_VALIDVALUE(dispID);

		VSL_SET_VALIDVALUE(pClsid);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPredefinedStringsValidValues
	{
		/*[in]*/ DISPID dispID;
		/*[out]*/ CALPOLESTR* pCaStringsOut;
		/*[out]*/ CADWORD* pCaCookiesOut;
		HRESULT retValue;
	};

	STDMETHOD(GetPredefinedStrings)(
		/*[in]*/ DISPID dispID,
		/*[out]*/ CALPOLESTR* pCaStringsOut,
		/*[out]*/ CADWORD* pCaCookiesOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetPredefinedStrings)

		VSL_CHECK_VALIDVALUE(dispID);

		VSL_SET_VALIDVALUE(pCaStringsOut);

		VSL_SET_VALIDVALUE(pCaCookiesOut);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPredefinedValueValidValues
	{
		/*[in]*/ DISPID dispID;
		/*[in]*/ DWORD dwCookie;
		/*[out]*/ VARIANT* pVarOut;
		HRESULT retValue;
	};

	STDMETHOD(GetPredefinedValue)(
		/*[in]*/ DISPID dispID,
		/*[in]*/ DWORD dwCookie,
		/*[out]*/ VARIANT* pVarOut)
	{
		VSL_DEFINE_MOCK_METHOD(GetPredefinedValue)

		VSL_CHECK_VALIDVALUE(dispID);

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_SET_VALIDVALUE_VARIANT(pVarOut);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPERPROPERTYBROWSING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
