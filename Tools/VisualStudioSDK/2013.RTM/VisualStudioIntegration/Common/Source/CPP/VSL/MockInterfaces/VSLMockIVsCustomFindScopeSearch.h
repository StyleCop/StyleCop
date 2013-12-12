/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCUSTOMFINDSCOPESEARCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCUSTOMFINDSCOPESEARCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "customfind.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCustomFindScopeSearchNotImpl :
	public IVsCustomFindScopeSearch
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCustomFindScopeSearchNotImpl)

public:

	typedef IVsCustomFindScopeSearch Interface;

	STDMETHOD(Find)(
		/*[in]*/ VSBROWSESCOPEW /*VsBrowseScope*/,
		/*[in]*/ LPCOLESTR /*pszFind*/,
		/*[in]*/ LPCOLESTR /*pszFilter*/,
		/*[in]*/ VSFINDOPTIONS /*grfOptions*/,
		/*[in]*/ IVsCustomFindScopeNotify* /*pBatchFindNotify*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Replace)(
		/*[in]*/ VSBROWSESCOPEW /*VsBrowseScope*/,
		/*[in]*/ LPCOLESTR /*pszFind*/,
		/*[in]*/ LPCOLESTR /*pszReplace*/,
		/*[in]*/ LPCOLESTR /*pszFilter*/,
		/*[in]*/ VSFINDOPTIONS /*grfOptions*/,
		/*[in]*/ IVsCustomFindScopeNotify* /*pBatchFindNotify*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetStatus)(
		/*[out]*/ BSTR* /*pbstrStatus*/,
		/*[out,retval]*/ VSCUSTOMFINDSTATUS* /*pdwStatus*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Cancel)()VSL_STDMETHOD_NOTIMPL
};

class IVsCustomFindScopeSearchMockImpl :
	public IVsCustomFindScopeSearch,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCustomFindScopeSearchMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCustomFindScopeSearchMockImpl)

	typedef IVsCustomFindScopeSearch Interface;
	struct FindValidValues
	{
		/*[in]*/ VSBROWSESCOPEW VsBrowseScope;
		/*[in]*/ LPCOLESTR pszFind;
		/*[in]*/ LPCOLESTR pszFilter;
		/*[in]*/ VSFINDOPTIONS grfOptions;
		/*[in]*/ IVsCustomFindScopeNotify* pBatchFindNotify;
		HRESULT retValue;
	};

	STDMETHOD(Find)(
		/*[in]*/ VSBROWSESCOPEW VsBrowseScope,
		/*[in]*/ LPCOLESTR pszFind,
		/*[in]*/ LPCOLESTR pszFilter,
		/*[in]*/ VSFINDOPTIONS grfOptions,
		/*[in]*/ IVsCustomFindScopeNotify* pBatchFindNotify)
	{
		VSL_DEFINE_MOCK_METHOD(Find)

		VSL_CHECK_VALIDVALUE(VsBrowseScope);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFind);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilter);

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBatchFindNotify);

		VSL_RETURN_VALIDVALUES();
	}
	struct ReplaceValidValues
	{
		/*[in]*/ VSBROWSESCOPEW VsBrowseScope;
		/*[in]*/ LPCOLESTR pszFind;
		/*[in]*/ LPCOLESTR pszReplace;
		/*[in]*/ LPCOLESTR pszFilter;
		/*[in]*/ VSFINDOPTIONS grfOptions;
		/*[in]*/ IVsCustomFindScopeNotify* pBatchFindNotify;
		HRESULT retValue;
	};

	STDMETHOD(Replace)(
		/*[in]*/ VSBROWSESCOPEW VsBrowseScope,
		/*[in]*/ LPCOLESTR pszFind,
		/*[in]*/ LPCOLESTR pszReplace,
		/*[in]*/ LPCOLESTR pszFilter,
		/*[in]*/ VSFINDOPTIONS grfOptions,
		/*[in]*/ IVsCustomFindScopeNotify* pBatchFindNotify)
	{
		VSL_DEFINE_MOCK_METHOD(Replace)

		VSL_CHECK_VALIDVALUE(VsBrowseScope);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFind);

		VSL_CHECK_VALIDVALUE_STRINGW(pszReplace);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilter);

		VSL_CHECK_VALIDVALUE(grfOptions);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBatchFindNotify);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetStatusValidValues
	{
		/*[out]*/ BSTR* pbstrStatus;
		/*[out,retval]*/ VSCUSTOMFINDSTATUS* pdwStatus;
		HRESULT retValue;
	};

	STDMETHOD(GetStatus)(
		/*[out]*/ BSTR* pbstrStatus,
		/*[out,retval]*/ VSCUSTOMFINDSTATUS* pdwStatus)
	{
		VSL_DEFINE_MOCK_METHOD(GetStatus)

		VSL_SET_VALIDVALUE_BSTR(pbstrStatus);

		VSL_SET_VALIDVALUE(pdwStatus);

		VSL_RETURN_VALIDVALUES();
	}
	struct CancelValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Cancel)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Cancel)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCUSTOMFINDSCOPESEARCH_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
