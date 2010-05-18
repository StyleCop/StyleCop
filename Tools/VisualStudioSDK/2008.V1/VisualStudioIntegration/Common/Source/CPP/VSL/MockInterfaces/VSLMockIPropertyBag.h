/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IPROPERTYBAG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IPROPERTYBAG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "OAIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IPropertyBagNotImpl :
	public IPropertyBag
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyBagNotImpl)

public:

	typedef IPropertyBag Interface;

	STDMETHOD(Read)(
		/*[in]*/ LPCOLESTR /*pszPropName*/,
		/*[in,out]*/ VARIANT* /*pVar*/,
		/*[in]*/ IErrorLog* /*pErrorLog*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Write)(
		/*[in]*/ LPCOLESTR /*pszPropName*/,
		/*[in]*/ VARIANT* /*pVar*/)VSL_STDMETHOD_NOTIMPL
};

class IPropertyBagMockImpl :
	public IPropertyBag,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IPropertyBagMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IPropertyBagMockImpl)

	typedef IPropertyBag Interface;
	struct ReadValidValues
	{
		/*[in]*/ LPCOLESTR pszPropName;
		/*[in,out]*/ VARIANT* pVar;
		/*[in]*/ IErrorLog* pErrorLog;
		HRESULT retValue;
	};

	STDMETHOD(Read)(
		/*[in]*/ LPCOLESTR pszPropName,
		/*[in,out]*/ VARIANT* pVar,
		/*[in]*/ IErrorLog* pErrorLog)
	{
		VSL_DEFINE_MOCK_METHOD(Read)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropName);

		VSL_SET_VALIDVALUE_VARIANT(pVar);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pErrorLog);

		VSL_RETURN_VALIDVALUES();
	}
	struct WriteValidValues
	{
		/*[in]*/ LPCOLESTR pszPropName;
		/*[in]*/ VARIANT* pVar;
		HRESULT retValue;
	};

	STDMETHOD(Write)(
		/*[in]*/ LPCOLESTR pszPropName,
		/*[in]*/ VARIANT* pVar)
	{
		VSL_DEFINE_MOCK_METHOD(Write)

		VSL_CHECK_VALIDVALUE_STRINGW(pszPropName);

		VSL_CHECK_VALIDVALUE_POINTER(pVar);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IPROPERTYBAG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
