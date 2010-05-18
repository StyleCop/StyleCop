/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPERPROPERTYBROWSING2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPERPROPERTYBROWSING2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ocdesign.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPerPropertyBrowsing2NotImpl :
	public IPerPropertyBrowsing2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPerPropertyBrowsing2NotImpl)

public:

	typedef IPerPropertyBrowsing2 Interface;

	STDMETHOD(MapPropertyToBuilder)(
		/*[in]*/ DISPID /*dispid*/,
		/*[out]*/ GUID* /*pguidBuilder*/,
		/*[out]*/ DWORD* /*pdwType*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExecuteBuilder)(
		/*[in]*/ DISPID /*dispid*/,
		/*[in]*/ REFGUID /*rguidBuilder*/,
		/*[in]*/ IDispatch* /*pdispApp*/,
		/*[in]*/ HWND /*hwndBuilderOwner*/,
		/*[in,out]*/ VARIANT* /*pvarValue*/)VSL_STDMETHOD_NOTIMPL
};

class IPerPropertyBrowsing2MockImpl :
	public IPerPropertyBrowsing2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPerPropertyBrowsing2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPerPropertyBrowsing2MockImpl)

	typedef IPerPropertyBrowsing2 Interface;
	struct MapPropertyToBuilderValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[out]*/ GUID* pguidBuilder;
		/*[out]*/ DWORD* pdwType;
		HRESULT retValue;
	};

	STDMETHOD(MapPropertyToBuilder)(
		/*[in]*/ DISPID dispid,
		/*[out]*/ GUID* pguidBuilder,
		/*[out]*/ DWORD* pdwType)
	{
		VSL_DEFINE_MOCK_METHOD(MapPropertyToBuilder)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(pguidBuilder);

		VSL_SET_VALIDVALUE(pdwType);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecuteBuilderValidValues
	{
		/*[in]*/ DISPID dispid;
		/*[in]*/ REFGUID rguidBuilder;
		/*[in]*/ IDispatch* pdispApp;
		/*[in]*/ HWND hwndBuilderOwner;
		/*[in,out]*/ VARIANT* pvarValue;
		HRESULT retValue;
	};

	STDMETHOD(ExecuteBuilder)(
		/*[in]*/ DISPID dispid,
		/*[in]*/ REFGUID rguidBuilder,
		/*[in]*/ IDispatch* pdispApp,
		/*[in]*/ HWND hwndBuilderOwner,
		/*[in,out]*/ VARIANT* pvarValue)
	{
		VSL_DEFINE_MOCK_METHOD(ExecuteBuilder)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_CHECK_VALIDVALUE(rguidBuilder);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pdispApp);

		VSL_CHECK_VALIDVALUE(hwndBuilderOwner);

		VSL_SET_VALIDVALUE_VARIANT(pvarValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPERPROPERTYBROWSING2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
