/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFINDSYMBOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFINDSYMBOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFindSymbolNotImpl :
	public IVsFindSymbol
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindSymbolNotImpl)

public:

	typedef IVsFindSymbol Interface;

	STDMETHOD(GetUserOptions)(
		/*[out]*/ GUID* /*pguidScope*/,
		/*[out]*/ VSOBSEARCHCRITERIA2* /*pobSrch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetUserOptions)(
		/*[in]*/ REFGUID /*guidScope*/,
		/*[in]*/ const VSOBSEARCHCRITERIA2* /*pobSrch*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(DoSearch)(
		/*[in]*/ REFGUID /*guidSymbolScope*/,
		/*[in]*/ const VSOBSEARCHCRITERIA2* /*pobSrch*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFindSymbolMockImpl :
	public IVsFindSymbol,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFindSymbolMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFindSymbolMockImpl)

	typedef IVsFindSymbol Interface;
	struct GetUserOptionsValidValues
	{
		/*[out]*/ GUID* pguidScope;
		/*[out]*/ VSOBSEARCHCRITERIA2* pobSrch;
		HRESULT retValue;
	};

	STDMETHOD(GetUserOptions)(
		/*[out]*/ GUID* pguidScope,
		/*[out]*/ VSOBSEARCHCRITERIA2* pobSrch)
	{
		VSL_DEFINE_MOCK_METHOD(GetUserOptions)

		VSL_SET_VALIDVALUE(pguidScope);

		VSL_SET_VALIDVALUE(pobSrch);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetUserOptionsValidValues
	{
		/*[in]*/ REFGUID guidScope;
		/*[in]*/ VSOBSEARCHCRITERIA2* pobSrch;
		HRESULT retValue;
	};

	STDMETHOD(SetUserOptions)(
		/*[in]*/ REFGUID guidScope,
		/*[in]*/ const VSOBSEARCHCRITERIA2* pobSrch)
	{
		VSL_DEFINE_MOCK_METHOD(SetUserOptions)

		VSL_CHECK_VALIDVALUE(guidScope);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_RETURN_VALIDVALUES();
	}
	struct DoSearchValidValues
	{
		/*[in]*/ REFGUID guidSymbolScope;
		/*[in]*/ VSOBSEARCHCRITERIA2* pobSrch;
		HRESULT retValue;
	};

	STDMETHOD(DoSearch)(
		/*[in]*/ REFGUID guidSymbolScope,
		/*[in]*/ const VSOBSEARCHCRITERIA2* pobSrch)
	{
		VSL_DEFINE_MOCK_METHOD(DoSearch)

		VSL_CHECK_VALIDVALUE(guidSymbolScope);

		VSL_CHECK_VALIDVALUE_POINTER(pobSrch);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFINDSYMBOL_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
