/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IRPCOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IRPCOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "ObjIdl.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IRpcOptionsNotImpl :
	public IRpcOptions
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRpcOptionsNotImpl)

public:

	typedef IRpcOptions Interface;

	STDMETHOD(Set)(
		/*[in]*/ IUnknown* /*pPrx*/,
		/*[in]*/ DWORD /*dwProperty*/,
		/*[in]*/ ULONG_PTR /*dwValue*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Query)(
		/*[in]*/ IUnknown* /*pPrx*/,
		/*[in]*/ DWORD /*dwProperty*/,
		/*[out]*/ ULONG_PTR* /*pdwValue*/)VSL_STDMETHOD_NOTIMPL
};

class IRpcOptionsMockImpl :
	public IRpcOptions,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IRpcOptionsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IRpcOptionsMockImpl)

	typedef IRpcOptions Interface;
	struct SetValidValues
	{
		/*[in]*/ IUnknown* pPrx;
		/*[in]*/ DWORD dwProperty;
		/*[in]*/ ULONG_PTR dwValue;
		HRESULT retValue;
	};

	STDMETHOD(Set)(
		/*[in]*/ IUnknown* pPrx,
		/*[in]*/ DWORD dwProperty,
		/*[in]*/ ULONG_PTR dwValue)
	{
		VSL_DEFINE_MOCK_METHOD(Set)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPrx);

		VSL_CHECK_VALIDVALUE(dwProperty);

		VSL_CHECK_VALIDVALUE(dwValue);

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryValidValues
	{
		/*[in]*/ IUnknown* pPrx;
		/*[in]*/ DWORD dwProperty;
		/*[out]*/ ULONG_PTR* pdwValue;
		HRESULT retValue;
	};

	STDMETHOD(Query)(
		/*[in]*/ IUnknown* pPrx,
		/*[in]*/ DWORD dwProperty,
		/*[out]*/ ULONG_PTR* pdwValue)
	{
		VSL_DEFINE_MOCK_METHOD(Query)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPrx);

		VSL_CHECK_VALIDVALUE(dwProperty);

		VSL_SET_VALIDVALUE(pdwValue);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IRPCOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
