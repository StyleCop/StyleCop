/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSUSERCONTEXTITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSUSERCONTEXTITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "context.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsUserContextItemNotImpl :
	public IVsUserContextItem
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextItemNotImpl)

public:

	typedef IVsUserContextItem Interface;

	STDMETHOD(get_Name)(
		/*[out,retval]*/ BSTR* /*pbstrName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_Command)(
		/*[out,retval]*/ BSTR* /*pbstrCommand*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CountAttributes)(
		/*[in]*/ LPCOLESTR /*pszAttrName*/,
		/*[out,retval]*/ int* /*pc*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAttribute)(
		/*[in]*/ LPCOLESTR /*pszAttrName*/,
		/*[in]*/ int /*index*/,
		/*[out,optional]*/ BSTR* /*pbstrName*/,
		/*[out,optional,retval]*/ BSTR* /*pbstrValue*/)VSL_STDMETHOD_NOTIMPL
};

class IVsUserContextItemMockImpl :
	public IVsUserContextItem,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsUserContextItemMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsUserContextItemMockImpl)

	typedef IVsUserContextItem Interface;
	struct get_NameValidValues
	{
		/*[out,retval]*/ BSTR* pbstrName;
		HRESULT retValue;
	};

	STDMETHOD(get_Name)(
		/*[out,retval]*/ BSTR* pbstrName)
	{
		VSL_DEFINE_MOCK_METHOD(get_Name)

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_CommandValidValues
	{
		/*[out,retval]*/ BSTR* pbstrCommand;
		HRESULT retValue;
	};

	STDMETHOD(get_Command)(
		/*[out,retval]*/ BSTR* pbstrCommand)
	{
		VSL_DEFINE_MOCK_METHOD(get_Command)

		VSL_SET_VALIDVALUE_BSTR(pbstrCommand);

		VSL_RETURN_VALIDVALUES();
	}
	struct CountAttributesValidValues
	{
		/*[in]*/ LPCOLESTR pszAttrName;
		/*[out,retval]*/ int* pc;
		HRESULT retValue;
	};

	STDMETHOD(CountAttributes)(
		/*[in]*/ LPCOLESTR pszAttrName,
		/*[out,retval]*/ int* pc)
	{
		VSL_DEFINE_MOCK_METHOD(CountAttributes)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAttrName);

		VSL_SET_VALIDVALUE(pc);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAttributeValidValues
	{
		/*[in]*/ LPCOLESTR pszAttrName;
		/*[in]*/ int index;
		/*[out,optional]*/ BSTR* pbstrName;
		/*[out,optional,retval]*/ BSTR* pbstrValue;
		HRESULT retValue;
	};

	STDMETHOD(GetAttribute)(
		/*[in]*/ LPCOLESTR pszAttrName,
		/*[in]*/ int index,
		/*[out,optional]*/ BSTR* pbstrName,
		/*[out,optional,retval]*/ BSTR* pbstrValue)
	{
		VSL_DEFINE_MOCK_METHOD(GetAttribute)

		VSL_CHECK_VALIDVALUE_STRINGW(pszAttrName);

		VSL_CHECK_VALIDVALUE(index);

		VSL_SET_VALIDVALUE_BSTR(pbstrName);

		VSL_SET_VALIDVALUE_BSTR(pbstrValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSUSERCONTEXTITEM_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
