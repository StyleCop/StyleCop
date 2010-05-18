/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGMODULE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGMODULE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "msdbg.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IDebugModule3NotImpl :
	public IDebugModule3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugModule3NotImpl)

public:

	typedef IDebugModule3 Interface;

	STDMETHOD(GetSymbolInfo)(
		/*[in]*/ SYMBOL_SEARCH_INFO_FIELDS /*dwFields*/,
		/*[out]*/ MODULE_SYMBOL_SEARCH_INFO* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadSymbols)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsUserCode)(
		/*[out]*/ BOOL* /*pfUser*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetJustMyCodeState)(
		/*[in]*/ BOOL /*fIsUserCode*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetInfo)(
		/*[in]*/ MODULE_INFO_FIELDS /*dwFields*/,
		/*[out]*/ MODULE_INFO* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReloadSymbols_Deprecated)(
		/*[in,ptr]*/ LPCOLESTR /*pszUrlToSymbols*/,
		/*[out]*/ BSTR* /*pbstrDebugMessage*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugModule3MockImpl :
	public IDebugModule3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugModule3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugModule3MockImpl)

	typedef IDebugModule3 Interface;
	struct GetSymbolInfoValidValues
	{
		/*[in]*/ SYMBOL_SEARCH_INFO_FIELDS dwFields;
		/*[out]*/ MODULE_SYMBOL_SEARCH_INFO* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetSymbolInfo)(
		/*[in]*/ SYMBOL_SEARCH_INFO_FIELDS dwFields,
		/*[out]*/ MODULE_SYMBOL_SEARCH_INFO* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetSymbolInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadSymbolsValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(LoadSymbols)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(LoadSymbols)

		VSL_RETURN_VALIDVALUES();
	}
	struct IsUserCodeValidValues
	{
		/*[out]*/ BOOL* pfUser;
		HRESULT retValue;
	};

	STDMETHOD(IsUserCode)(
		/*[out]*/ BOOL* pfUser)
	{
		VSL_DEFINE_MOCK_METHOD(IsUserCode)

		VSL_SET_VALIDVALUE(pfUser);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetJustMyCodeStateValidValues
	{
		/*[in]*/ BOOL fIsUserCode;
		HRESULT retValue;
	};

	STDMETHOD(SetJustMyCodeState)(
		/*[in]*/ BOOL fIsUserCode)
	{
		VSL_DEFINE_MOCK_METHOD(SetJustMyCodeState)

		VSL_CHECK_VALIDVALUE(fIsUserCode);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetInfoValidValues
	{
		/*[in]*/ MODULE_INFO_FIELDS dwFields;
		/*[out]*/ MODULE_INFO* pInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetInfo)(
		/*[in]*/ MODULE_INFO_FIELDS dwFields,
		/*[out]*/ MODULE_INFO* pInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetInfo)

		VSL_CHECK_VALIDVALUE(dwFields);

		VSL_SET_VALIDVALUE(pInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReloadSymbols_DeprecatedValidValues
	{
		/*[in,ptr]*/ LPCOLESTR pszUrlToSymbols;
		/*[out]*/ BSTR* pbstrDebugMessage;
		HRESULT retValue;
	};

	STDMETHOD(ReloadSymbols_Deprecated)(
		/*[in,ptr]*/ LPCOLESTR pszUrlToSymbols,
		/*[out]*/ BSTR* pbstrDebugMessage)
	{
		VSL_DEFINE_MOCK_METHOD(ReloadSymbols_Deprecated)

		VSL_CHECK_VALIDVALUE_STRINGW(pszUrlToSymbols);

		VSL_SET_VALIDVALUE_BSTR(pbstrDebugMessage);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IDEBUGMODULE3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
