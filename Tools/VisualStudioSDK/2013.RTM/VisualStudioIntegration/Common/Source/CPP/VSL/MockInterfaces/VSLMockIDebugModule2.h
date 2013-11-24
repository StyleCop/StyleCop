/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IDEBUGMODULE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IDEBUGMODULE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IDebugModule2NotImpl :
	public IDebugModule2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugModule2NotImpl)

public:

	typedef IDebugModule2 Interface;

	STDMETHOD(GetInfo)(
		/*[in]*/ MODULE_INFO_FIELDS /*dwFields*/,
		/*[out]*/ MODULE_INFO* /*pInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ReloadSymbols_Deprecated)(
		/*[in,ptr]*/ LPCOLESTR /*pszUrlToSymbols*/,
		/*[out]*/ BSTR* /*pbstrDebugMessage*/)VSL_STDMETHOD_NOTIMPL
};

class IDebugModule2MockImpl :
	public IDebugModule2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IDebugModule2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IDebugModule2MockImpl)

	typedef IDebugModule2 Interface;
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

#endif // IDEBUGMODULE2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
