/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROPERTYBAG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROPERTYBAG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IPropertyBag2NotImpl :
	public IPropertyBag2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyBag2NotImpl)

public:

	typedef IPropertyBag2 Interface;

	STDMETHOD(Read)(
		/*[in]*/ ULONG /*cProperties*/,
		/*[in]*/ PROPBAG2* /*pPropBag*/,
		/*[in]*/ IErrorLog* /*pErrLog*/,
		/*[out]*/ VARIANT* /*pvarValue*/,
		/*[out]*/ HRESULT* /*phrError*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Write)(
		/*[in]*/ ULONG /*cProperties*/,
		/*[in]*/ PROPBAG2* /*pPropBag*/,
		/*[in]*/ VARIANT* /*pvarValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CountProperties)(
		/*[out]*/ ULONG* /*pcProperties*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetPropertyInfo)(
		/*[in]*/ ULONG /*iProperty*/,
		/*[in]*/ ULONG /*cProperties*/,
		/*[out]*/ PROPBAG2* /*pPropBag*/,
		/*[out]*/ ULONG* /*pcProperties*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadObject)(
		/*[in]*/ LPCOLESTR /*pstrName*/,
		/*[in]*/ DWORD /*dwHint*/,
		/*[in]*/ IUnknown* /*pUnkObject*/,
		/*[in]*/ IErrorLog* /*pErrLog*/)VSL_STDMETHOD_NOTIMPL
};

class IPropertyBag2MockImpl :
	public IPropertyBag2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyBag2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPropertyBag2MockImpl)

	typedef IPropertyBag2 Interface;
	struct ReadValidValues
	{
		/*[in]*/ ULONG cProperties;
		/*[in]*/ PROPBAG2* pPropBag;
		/*[in]*/ IErrorLog* pErrLog;
		/*[out]*/ VARIANT* pvarValue;
		/*[out]*/ HRESULT* phrError;
		HRESULT retValue;
	};

	STDMETHOD(Read)(
		/*[in]*/ ULONG cProperties,
		/*[in]*/ PROPBAG2* pPropBag,
		/*[in]*/ IErrorLog* pErrLog,
		/*[out]*/ VARIANT* pvarValue,
		/*[out]*/ HRESULT* phrError)
	{
		VSL_DEFINE_MOCK_METHOD(Read)

		VSL_CHECK_VALIDVALUE(cProperties);

		VSL_CHECK_VALIDVALUE_POINTER(pPropBag);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pErrLog);

		VSL_SET_VALIDVALUE_VARIANT(pvarValue);

		VSL_SET_VALIDVALUE(phrError);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteValidValues
	{
		/*[in]*/ ULONG cProperties;
		/*[in]*/ PROPBAG2* pPropBag;
		/*[in]*/ VARIANT* pvarValue;
		HRESULT retValue;
	};

	STDMETHOD(Write)(
		/*[in]*/ ULONG cProperties,
		/*[in]*/ PROPBAG2* pPropBag,
		/*[in]*/ VARIANT* pvarValue)
	{
		VSL_DEFINE_MOCK_METHOD(Write)

		VSL_CHECK_VALIDVALUE(cProperties);

		VSL_CHECK_VALIDVALUE_POINTER(pPropBag);

		VSL_CHECK_VALIDVALUE_POINTER(pvarValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct CountPropertiesValidValues
	{
		/*[out]*/ ULONG* pcProperties;
		HRESULT retValue;
	};

	STDMETHOD(CountProperties)(
		/*[out]*/ ULONG* pcProperties)
	{
		VSL_DEFINE_MOCK_METHOD(CountProperties)

		VSL_SET_VALIDVALUE(pcProperties);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetPropertyInfoValidValues
	{
		/*[in]*/ ULONG iProperty;
		/*[in]*/ ULONG cProperties;
		/*[out]*/ PROPBAG2* pPropBag;
		/*[out]*/ ULONG* pcProperties;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyInfo)(
		/*[in]*/ ULONG iProperty,
		/*[in]*/ ULONG cProperties,
		/*[out]*/ PROPBAG2* pPropBag,
		/*[out]*/ ULONG* pcProperties)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyInfo)

		VSL_CHECK_VALIDVALUE(iProperty);

		VSL_CHECK_VALIDVALUE(cProperties);

		VSL_SET_VALIDVALUE(pPropBag);

		VSL_SET_VALIDVALUE(pcProperties);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadObjectValidValues
	{
		/*[in]*/ LPCOLESTR pstrName;
		/*[in]*/ DWORD dwHint;
		/*[in]*/ IUnknown* pUnkObject;
		/*[in]*/ IErrorLog* pErrLog;
		HRESULT retValue;
	};

	STDMETHOD(LoadObject)(
		/*[in]*/ LPCOLESTR pstrName,
		/*[in]*/ DWORD dwHint,
		/*[in]*/ IUnknown* pUnkObject,
		/*[in]*/ IErrorLog* pErrLog)
	{
		VSL_DEFINE_MOCK_METHOD(LoadObject)

		VSL_CHECK_VALIDVALUE_STRINGW(pstrName);

		VSL_CHECK_VALIDVALUE(dwHint);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkObject);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pErrLog);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROPERTYBAG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
