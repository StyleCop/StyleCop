/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROVIDEPROPERTYBUILDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROVIDEPROPERTYBUILDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IProvidePropertyBuilderNotImpl :
	public IProvidePropertyBuilder
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvidePropertyBuilderNotImpl)

public:

	typedef IProvidePropertyBuilder Interface;

	STDMETHOD(MapPropertyToBuilder)(
		/*[in]*/ LONG /*dispid*/,
		/*[in,out]*/ LONG* /*pdwCtlBldType*/,
		/*[in,out]*/ BSTR* /*pbstrGuidBldr*/,
		/*[out,retval]*/ VARIANT_BOOL* /*pfRetVal*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ExecuteBuilder)(
		/*[in]*/ LONG /*dispid*/,
		/*[in]*/ BSTR /*bstrGuidBldr*/,
		/*[in]*/ IDispatch* /*pdispApp*/,
		/*[in]*/ LONG_PTR /*hwndBldrOwner*/,
		/*[in,out]*/ VARIANT* /*pvarValue*/,
		/*[out,retval]*/ VARIANT_BOOL* /*pfRetVal*/)VSL_STDMETHOD_NOTIMPL
};

class IProvidePropertyBuilderMockImpl :
	public IProvidePropertyBuilder,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IProvidePropertyBuilderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IProvidePropertyBuilderMockImpl)

	typedef IProvidePropertyBuilder Interface;
	struct MapPropertyToBuilderValidValues
	{
		/*[in]*/ LONG dispid;
		/*[in,out]*/ LONG* pdwCtlBldType;
		/*[in,out]*/ BSTR* pbstrGuidBldr;
		/*[out,retval]*/ VARIANT_BOOL* pfRetVal;
		HRESULT retValue;
	};

	STDMETHOD(MapPropertyToBuilder)(
		/*[in]*/ LONG dispid,
		/*[in,out]*/ LONG* pdwCtlBldType,
		/*[in,out]*/ BSTR* pbstrGuidBldr,
		/*[out,retval]*/ VARIANT_BOOL* pfRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(MapPropertyToBuilder)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_SET_VALIDVALUE(pdwCtlBldType);

		VSL_SET_VALIDVALUE_BSTR(pbstrGuidBldr);

		VSL_SET_VALIDVALUE(pfRetVal);

		VSL_RETURN_VALIDVALUES();
	}
	struct ExecuteBuilderValidValues
	{
		/*[in]*/ LONG dispid;
		/*[in]*/ BSTR bstrGuidBldr;
		/*[in]*/ IDispatch* pdispApp;
		/*[in]*/ LONG_PTR hwndBldrOwner;
		/*[in,out]*/ VARIANT* pvarValue;
		/*[out,retval]*/ VARIANT_BOOL* pfRetVal;
		HRESULT retValue;
	};

	STDMETHOD(ExecuteBuilder)(
		/*[in]*/ LONG dispid,
		/*[in]*/ BSTR bstrGuidBldr,
		/*[in]*/ IDispatch* pdispApp,
		/*[in]*/ LONG_PTR hwndBldrOwner,
		/*[in,out]*/ VARIANT* pvarValue,
		/*[out,retval]*/ VARIANT_BOOL* pfRetVal)
	{
		VSL_DEFINE_MOCK_METHOD(ExecuteBuilder)

		VSL_CHECK_VALIDVALUE(dispid);

		VSL_CHECK_VALIDVALUE_BSTR(bstrGuidBldr);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pdispApp);

		VSL_CHECK_VALIDVALUE(hwndBldrOwner);

		VSL_SET_VALIDVALUE_VARIANT(pvarValue);

		VSL_SET_VALIDVALUE(pfRetVal);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROVIDEPROPERTYBUILDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
