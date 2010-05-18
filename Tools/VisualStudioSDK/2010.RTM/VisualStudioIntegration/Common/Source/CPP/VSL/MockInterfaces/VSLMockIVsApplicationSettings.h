/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSAPPLICATIONSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSAPPLICATIONSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsApplicationSettingsNotImpl :
	public IVsApplicationSettings
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsApplicationSettingsNotImpl)

public:

	typedef IVsApplicationSettings Interface;

	STDMETHOD(GetPropertyInfo)(
		/*[in]*/ LPCWSTR /*pszWebServiceName*/,
		/*[out]*/ BSTR* /*pbstrAppSettingsObjectName*/,
		/*[out]*/ BSTR* /*pbstrPropertyName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAppSettingsPropertyExpression)(
		/*[in]*/ LPCWSTR /*pszAppSettingsObjectName*/,
		/*[in]*/ LPCWSTR /*pszPropertyName*/,
		/*[out,retval]*/ IUnknown** /*ppUnkExpression*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnsureWebServiceUrlPropertyExpression)(
		/*[in]*/ LPCWSTR /*pszAppSettingsObjectName*/,
		/*[in]*/ LPCWSTR /*pszPropertyName*/,
		/*[in]*/ VARIANT /*varPropertyValue*/,
		/*[out,retval]*/ IUnknown** /*ppUnkExpression*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPropertyInfo)(
		/*[in]*/ LPCWSTR /*pszAppSettingsObjectName*/,
		/*[in]*/ LPCWSTR /*pszPropertyName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsApplicationSettingsMockImpl :
	public IVsApplicationSettings,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsApplicationSettingsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsApplicationSettingsMockImpl)

	typedef IVsApplicationSettings Interface;
	struct GetPropertyInfoValidValues
	{
		/*[in]*/ LPCWSTR pszWebServiceName;
		/*[out]*/ BSTR* pbstrAppSettingsObjectName;
		/*[out]*/ BSTR* pbstrPropertyName;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyInfo)(
		/*[in]*/ LPCWSTR pszWebServiceName,
		/*[out]*/ BSTR* pbstrAppSettingsObjectName,
		/*[out]*/ BSTR* pbstrPropertyName)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyInfo)

		VSL_CHECK_VALIDVALUE_STRINGW(pszWebServiceName);

		VSL_SET_VALIDVALUE_BSTR(pbstrAppSettingsObjectName);

		VSL_SET_VALIDVALUE_BSTR(pbstrPropertyName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAppSettingsPropertyExpressionValidValues
	{
		/*[in]*/ LPCWSTR pszAppSettingsObjectName;
		/*[in]*/ LPCWSTR pszPropertyName;
		/*[out,retval]*/ IUnknown** ppUnkExpression;
		HRESULT retValue;
	};

	STDMETHOD(GetAppSettingsPropertyExpression)(
		/*[in]*/ LPCWSTR pszAppSettingsObjectName,
		/*[in]*/ LPCWSTR pszPropertyName,
		/*[out,retval]*/ IUnknown** ppUnkExpression)
	{
		VSL_DEFINE_MOCK_METHOD(GetAppSettingsPropertyExpression)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAppSettingsObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropertyName);

		VSL_SET_VALIDVALUE_INTERFACE(ppUnkExpression);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnsureWebServiceUrlPropertyExpressionValidValues
	{
		/*[in]*/ LPCWSTR pszAppSettingsObjectName;
		/*[in]*/ LPCWSTR pszPropertyName;
		/*[in]*/ VARIANT varPropertyValue;
		/*[out,retval]*/ IUnknown** ppUnkExpression;
		HRESULT retValue;
	};

	STDMETHOD(EnsureWebServiceUrlPropertyExpression)(
		/*[in]*/ LPCWSTR pszAppSettingsObjectName,
		/*[in]*/ LPCWSTR pszPropertyName,
		/*[in]*/ VARIANT varPropertyValue,
		/*[out,retval]*/ IUnknown** ppUnkExpression)
	{
		VSL_DEFINE_MOCK_METHOD(EnsureWebServiceUrlPropertyExpression)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAppSettingsObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropertyName);

		VSL_CHECK_VALIDVALUE(varPropertyValue);

		VSL_SET_VALIDVALUE_INTERFACE(ppUnkExpression);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyInfoValidValues
	{
		/*[in]*/ LPCWSTR pszAppSettingsObjectName;
		/*[in]*/ LPCWSTR pszPropertyName;
		HRESULT retValue;
	};

	STDMETHOD(SetPropertyInfo)(
		/*[in]*/ LPCWSTR pszAppSettingsObjectName,
		/*[in]*/ LPCWSTR pszPropertyName)
	{
		VSL_DEFINE_MOCK_METHOD(SetPropertyInfo)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAppSettingsObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropertyName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSAPPLICATIONSETTINGS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
