/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBURLMRU_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBURLMRU_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsbrowse.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebURLMRUNotImpl :
	public IVsWebURLMRU
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebURLMRUNotImpl)

public:

	typedef IVsWebURLMRU Interface;

	STDMETHOD(AddURL)(
		/*[in]*/ BSTR /*bstrURL*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetURLArray)(
		/*[out,retval]*/ VARIANT* /*pvarURLs*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebURLMRUMockImpl :
	public IVsWebURLMRU,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebURLMRUMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebURLMRUMockImpl)

	typedef IVsWebURLMRU Interface;
	struct AddURLValidValues
	{
		/*[in]*/ BSTR bstrURL;
		HRESULT retValue;
	};

	STDMETHOD(AddURL)(
		/*[in]*/ BSTR bstrURL)
	{
		VSL_DEFINE_MOCK_METHOD(AddURL)

		VSL_CHECK_VALIDVALUE_BSTR(bstrURL);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetURLArrayValidValues
	{
		/*[out,retval]*/ VARIANT* pvarURLs;
		HRESULT retValue;
	};

	STDMETHOD(GetURLArray)(
		/*[out,retval]*/ VARIANT* pvarURLs)
	{
		VSL_DEFINE_MOCK_METHOD(GetURLArray)

		VSL_SET_VALIDVALUE_VARIANT(pvarURLs);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBURLMRU_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
