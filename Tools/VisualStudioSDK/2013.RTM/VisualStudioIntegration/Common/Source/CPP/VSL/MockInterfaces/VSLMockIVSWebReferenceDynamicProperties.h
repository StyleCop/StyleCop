/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBREFERENCEDYNAMICPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBREFERENCEDYNAMICPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vslangproj.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVSWebReferenceDynamicPropertiesNotImpl :
	public IVSWebReferenceDynamicProperties
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSWebReferenceDynamicPropertiesNotImpl)

public:

	typedef IVSWebReferenceDynamicProperties Interface;

	STDMETHOD(GetDynamicPropertyName)(
		/*[in]*/ LPCWSTR /*pszWebServiceName*/,
		/*[out,retval]*/ BSTR* /*pbstrPropertyName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetDynamicProperty)(
		/*[in]*/ LPCWSTR /*pszUrl*/,
		/*[in]*/ LPCWSTR /*pszPropertyName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SupportsDynamicProperties)(
		/*[out,retval]*/ VARIANT_BOOL* /*pbSupportsDynamicProperties*/)VSL_STDMETHOD_NOTIMPL
};

class IVSWebReferenceDynamicPropertiesMockImpl :
	public IVSWebReferenceDynamicProperties,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSWebReferenceDynamicPropertiesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSWebReferenceDynamicPropertiesMockImpl)

	typedef IVSWebReferenceDynamicProperties Interface;
	struct GetDynamicPropertyNameValidValues
	{
		/*[in]*/ LPCWSTR pszWebServiceName;
		/*[out,retval]*/ BSTR* pbstrPropertyName;
		HRESULT retValue;
	};

	STDMETHOD(GetDynamicPropertyName)(
		/*[in]*/ LPCWSTR pszWebServiceName,
		/*[out,retval]*/ BSTR* pbstrPropertyName)
	{
		VSL_DEFINE_MOCK_METHOD(GetDynamicPropertyName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszWebServiceName);

		VSL_SET_VALIDVALUE_BSTR(pbstrPropertyName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetDynamicPropertyValidValues
	{
		/*[in]*/ LPCWSTR pszUrl;
		/*[in]*/ LPCWSTR pszPropertyName;
		HRESULT retValue;
	};

	STDMETHOD(SetDynamicProperty)(
		/*[in]*/ LPCWSTR pszUrl,
		/*[in]*/ LPCWSTR pszPropertyName)
	{
		VSL_DEFINE_MOCK_METHOD(SetDynamicProperty)

		VSL_CHECK_VALIDVALUE_STRINGW(pszUrl);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropertyName);

		VSL_RETURN_VALIDVALUES();
	}
	struct SupportsDynamicPropertiesValidValues
	{
		/*[out,retval]*/ VARIANT_BOOL* pbSupportsDynamicProperties;
		HRESULT retValue;
	};

	STDMETHOD(SupportsDynamicProperties)(
		/*[out,retval]*/ VARIANT_BOOL* pbSupportsDynamicProperties)
	{
		VSL_DEFINE_MOCK_METHOD(SupportsDynamicProperties)

		VSL_SET_VALIDVALUE(pbSupportsDynamicProperties);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBREFERENCEDYNAMICPROPERTIES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
