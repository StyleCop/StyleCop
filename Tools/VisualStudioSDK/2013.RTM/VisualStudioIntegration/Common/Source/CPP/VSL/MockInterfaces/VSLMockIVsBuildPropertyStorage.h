/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBUILDPROPERTYSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBUILDPROPERTYSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsBuildPropertyStorageNotImpl :
	public IVsBuildPropertyStorage
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildPropertyStorageNotImpl)

public:

	typedef IVsBuildPropertyStorage Interface;

	STDMETHOD(GetPropertyValue)(
		/*[in]*/ LPCOLESTR /*pszPropName*/,
		/*[in]*/ LPCOLESTR /*pszConfigName*/,
		/*[in]*/ PersistStorageType /*storage*/,
		/*[out,retval]*/ BSTR* /*pbstrPropValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetPropertyValue)(
		/*[in]*/ LPCOLESTR /*pszPropName*/,
		/*[in]*/ LPCOLESTR /*pszConfigName*/,
		/*[in]*/ PersistStorageType /*storage*/,
		/*[in]*/ LPCOLESTR /*pszPropValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveProperty)(
		/*[in]*/ LPCOLESTR /*pszPropName*/,
		/*[in]*/ LPCOLESTR /*pszConfigName*/,
		/*[in]*/ PersistStorageType /*storage*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetItemAttribute)(
		/*[in]*/ VSITEMID /*item*/,
		/*[in]*/ LPCOLESTR /*pszAttributeName*/,
		/*[out]*/ BSTR* /*pbstrAttributeValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetItemAttribute)(
		/*[in]*/ VSITEMID /*item*/,
		/*[in]*/ LPCOLESTR /*pszAttributeName*/,
		/*[in]*/ LPCOLESTR /*pszAttributeValue*/)VSL_STDMETHOD_NOTIMPL
};

class IVsBuildPropertyStorageMockImpl :
	public IVsBuildPropertyStorage,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildPropertyStorageMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsBuildPropertyStorageMockImpl)

	typedef IVsBuildPropertyStorage Interface;
	struct GetPropertyValueValidValues
	{
		/*[in]*/ LPCOLESTR pszPropName;
		/*[in]*/ LPCOLESTR pszConfigName;
		/*[in]*/ PersistStorageType storage;
		/*[out,retval]*/ BSTR* pbstrPropValue;
		HRESULT retValue;
	};

	STDMETHOD(GetPropertyValue)(
		/*[in]*/ LPCOLESTR pszPropName,
		/*[in]*/ LPCOLESTR pszConfigName,
		/*[in]*/ PersistStorageType storage,
		/*[out,retval]*/ BSTR* pbstrPropValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetPropertyValue)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszConfigName);

		VSL_CHECK_VALIDVALUE(storage);

		VSL_SET_VALIDVALUE_BSTR(pbstrPropValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetPropertyValueValidValues
	{
		/*[in]*/ LPCOLESTR pszPropName;
		/*[in]*/ LPCOLESTR pszConfigName;
		/*[in]*/ PersistStorageType storage;
		/*[in]*/ LPCOLESTR pszPropValue;
		HRESULT retValue;
	};

	STDMETHOD(SetPropertyValue)(
		/*[in]*/ LPCOLESTR pszPropName,
		/*[in]*/ LPCOLESTR pszConfigName,
		/*[in]*/ PersistStorageType storage,
		/*[in]*/ LPCOLESTR pszPropValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetPropertyValue)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszConfigName);

		VSL_CHECK_VALIDVALUE(storage);

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemovePropertyValidValues
	{
		/*[in]*/ LPCOLESTR pszPropName;
		/*[in]*/ LPCOLESTR pszConfigName;
		/*[in]*/ PersistStorageType storage;
		HRESULT retValue;
	};

	STDMETHOD(RemoveProperty)(
		/*[in]*/ LPCOLESTR pszPropName,
		/*[in]*/ LPCOLESTR pszConfigName,
		/*[in]*/ PersistStorageType storage)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveProperty)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszConfigName);

		VSL_CHECK_VALIDVALUE(storage);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetItemAttributeValidValues
	{
		/*[in]*/ VSITEMID item;
		/*[in]*/ LPCOLESTR pszAttributeName;
		/*[out]*/ BSTR* pbstrAttributeValue;
		HRESULT retValue;
	};

	STDMETHOD(GetItemAttribute)(
		/*[in]*/ VSITEMID item,
		/*[in]*/ LPCOLESTR pszAttributeName,
		/*[out]*/ BSTR* pbstrAttributeValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetItemAttribute)

		VSL_CHECK_VALIDVALUE(item);

		VSL_CHECK_VALIDVALUE_STRINGW(pszAttributeName);

		VSL_SET_VALIDVALUE_BSTR(pbstrAttributeValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetItemAttributeValidValues
	{
		/*[in]*/ VSITEMID item;
		/*[in]*/ LPCOLESTR pszAttributeName;
		/*[in]*/ LPCOLESTR pszAttributeValue;
		HRESULT retValue;
	};

	STDMETHOD(SetItemAttribute)(
		/*[in]*/ VSITEMID item,
		/*[in]*/ LPCOLESTR pszAttributeName,
		/*[in]*/ LPCOLESTR pszAttributeValue)
	{
		VSL_DEFINE_MOCK_METHOD(SetItemAttribute)

		VSL_CHECK_VALIDVALUE(item);

		VSL_CHECK_VALIDVALUE_STRINGW(pszAttributeName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszAttributeValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBUILDPROPERTYSTORAGE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
