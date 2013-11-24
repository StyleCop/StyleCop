/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSEXPANSIONMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSEXPANSIONMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsExpansionManagerNotImpl :
	public IVsExpansionManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionManagerNotImpl)

public:

	typedef IVsExpansionManager Interface;

	STDMETHOD(EnumerateExpansions)(
		/*[in]*/ GUID /*guidLang*/,
		/*[in]*/ BOOL /*fShortCutOnly*/,
		/*[in,size_is(iCountTypes)]*/ BSTR* /*bstrTypes*/,
		/*[in]*/ long /*iCountTypes*/,
		/*[in]*/ BOOL /*fIncludeNULLType*/,
		/*[in]*/ BOOL /*fIncludeDuplicates*/,
		/*[out]*/ IVsExpansionEnumeration** /*pEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InvokeInsertionUI)(
		/*[in]*/ IVsTextView* /*pView*/,
		/*[in]*/ IVsExpansionClient* /*pClient*/,
		/*[in]*/ GUID /*guidLang*/,
		/*[in,size_is(iCountTypes)]*/ BSTR* /*bstrTypes*/,
		/*[in]*/ long /*iCountTypes*/,
		/*[in]*/ BOOL /*fIncludeNULLType*/,
		/*[in,size_is(iCountKinds)]*/ BSTR* /*bstrKinds*/,
		/*[in]*/ long /*iCountKinds*/,
		/*[in]*/ BOOL /*fIncludeNULLKind*/,
		/*[in]*/ BSTR /*bstrPrefixText*/,
		/*[in]*/ BSTR /*bstrCompletionChar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetExpansionByShortcut)(
		/*[in]*/ IVsExpansionClient* /*pClient*/,
		/*[in]*/ GUID /*guidLang*/,
		/*[in,string]*/ LPOLESTR /*szShortcut*/,
		/*[in]*/ IVsTextView* /*pView*/,
		/*[in]*/ TextSpan* /*pts*/,
		/*[in]*/ BOOL /*fShowUI*/,
		/*[out]*/ BSTR* /*pszExpansionPath*/,
		/*[out]*/ BSTR* /*pszTitle*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetTokenPath)(
		/*[in]*/ ExpansionToken /*token*/,
		/*[out]*/ BSTR* /*pbstrPath*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSnippetShortCutKeybindingState)(
		/*[out]*/ BOOL* /*fBound*/)VSL_STDMETHOD_NOTIMPL
};

class IVsExpansionManagerMockImpl :
	public IVsExpansionManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsExpansionManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsExpansionManagerMockImpl)

	typedef IVsExpansionManager Interface;
	struct EnumerateExpansionsValidValues
	{
		/*[in]*/ GUID guidLang;
		/*[in]*/ BOOL fShortCutOnly;
		/*[in,size_is(iCountTypes)]*/ BSTR* bstrTypes;
		/*[in]*/ long iCountTypes;
		/*[in]*/ BOOL fIncludeNULLType;
		/*[in]*/ BOOL fIncludeDuplicates;
		/*[out]*/ IVsExpansionEnumeration** pEnum;
		HRESULT retValue;
	};

	STDMETHOD(EnumerateExpansions)(
		/*[in]*/ GUID guidLang,
		/*[in]*/ BOOL fShortCutOnly,
		/*[in,size_is(iCountTypes)]*/ BSTR* bstrTypes,
		/*[in]*/ long iCountTypes,
		/*[in]*/ BOOL fIncludeNULLType,
		/*[in]*/ BOOL fIncludeDuplicates,
		/*[out]*/ IVsExpansionEnumeration** pEnum)
	{
		VSL_DEFINE_MOCK_METHOD(EnumerateExpansions)

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE(fShortCutOnly);

		VSL_CHECK_VALIDVALUE_MEMCMP(bstrTypes, iCountTypes*sizeof(bstrTypes[0]), validValues.iCountTypes*sizeof(validValues.bstrTypes[0]));

		VSL_CHECK_VALIDVALUE(iCountTypes);

		VSL_CHECK_VALIDVALUE(fIncludeNULLType);

		VSL_CHECK_VALIDVALUE(fIncludeDuplicates);

		VSL_SET_VALIDVALUE_INTERFACE(pEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct InvokeInsertionUIValidValues
	{
		/*[in]*/ IVsTextView* pView;
		/*[in]*/ IVsExpansionClient* pClient;
		/*[in]*/ GUID guidLang;
		/*[in,size_is(iCountTypes)]*/ BSTR* bstrTypes;
		/*[in]*/ long iCountTypes;
		/*[in]*/ BOOL fIncludeNULLType;
		/*[in,size_is(iCountKinds)]*/ BSTR* bstrKinds;
		/*[in]*/ long iCountKinds;
		/*[in]*/ BOOL fIncludeNULLKind;
		/*[in]*/ BSTR bstrPrefixText;
		/*[in]*/ BSTR bstrCompletionChar;
		HRESULT retValue;
	};

	STDMETHOD(InvokeInsertionUI)(
		/*[in]*/ IVsTextView* pView,
		/*[in]*/ IVsExpansionClient* pClient,
		/*[in]*/ GUID guidLang,
		/*[in,size_is(iCountTypes)]*/ BSTR* bstrTypes,
		/*[in]*/ long iCountTypes,
		/*[in]*/ BOOL fIncludeNULLType,
		/*[in,size_is(iCountKinds)]*/ BSTR* bstrKinds,
		/*[in]*/ long iCountKinds,
		/*[in]*/ BOOL fIncludeNULLKind,
		/*[in]*/ BSTR bstrPrefixText,
		/*[in]*/ BSTR bstrCompletionChar)
	{
		VSL_DEFINE_MOCK_METHOD(InvokeInsertionUI)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pClient);

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE_MEMCMP(bstrTypes, iCountTypes*sizeof(bstrTypes[0]), validValues.iCountTypes*sizeof(validValues.bstrTypes[0]));

		VSL_CHECK_VALIDVALUE(iCountTypes);

		VSL_CHECK_VALIDVALUE(fIncludeNULLType);

		VSL_CHECK_VALIDVALUE_MEMCMP(bstrKinds, iCountKinds*sizeof(bstrKinds[0]), validValues.iCountKinds*sizeof(validValues.bstrKinds[0]));

		VSL_CHECK_VALIDVALUE(iCountKinds);

		VSL_CHECK_VALIDVALUE(fIncludeNULLKind);

		VSL_CHECK_VALIDVALUE_BSTR(bstrPrefixText);

		VSL_CHECK_VALIDVALUE_BSTR(bstrCompletionChar);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetExpansionByShortcutValidValues
	{
		/*[in]*/ IVsExpansionClient* pClient;
		/*[in]*/ GUID guidLang;
		/*[in,string]*/ LPOLESTR szShortcut;
		/*[in]*/ IVsTextView* pView;
		/*[in]*/ TextSpan* pts;
		/*[in]*/ BOOL fShowUI;
		/*[out]*/ BSTR* pszExpansionPath;
		/*[out]*/ BSTR* pszTitle;
		HRESULT retValue;
	};

	STDMETHOD(GetExpansionByShortcut)(
		/*[in]*/ IVsExpansionClient* pClient,
		/*[in]*/ GUID guidLang,
		/*[in,string]*/ LPOLESTR szShortcut,
		/*[in]*/ IVsTextView* pView,
		/*[in]*/ TextSpan* pts,
		/*[in]*/ BOOL fShowUI,
		/*[out]*/ BSTR* pszExpansionPath,
		/*[out]*/ BSTR* pszTitle)
	{
		VSL_DEFINE_MOCK_METHOD(GetExpansionByShortcut)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pClient);

		VSL_CHECK_VALIDVALUE(guidLang);

		VSL_CHECK_VALIDVALUE_STRINGW(szShortcut);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pView);

		VSL_CHECK_VALIDVALUE_POINTER(pts);

		VSL_CHECK_VALIDVALUE(fShowUI);

		VSL_SET_VALIDVALUE_BSTR(pszExpansionPath);

		VSL_SET_VALIDVALUE_BSTR(pszTitle);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetTokenPathValidValues
	{
		/*[in]*/ ExpansionToken token;
		/*[out]*/ BSTR* pbstrPath;
		HRESULT retValue;
	};

	STDMETHOD(GetTokenPath)(
		/*[in]*/ ExpansionToken token,
		/*[out]*/ BSTR* pbstrPath)
	{
		VSL_DEFINE_MOCK_METHOD(GetTokenPath)

		VSL_CHECK_VALIDVALUE(token);

		VSL_SET_VALIDVALUE_BSTR(pbstrPath);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSnippetShortCutKeybindingStateValidValues
	{
		/*[out]*/ BOOL* fBound;
		HRESULT retValue;
	};

	STDMETHOD(GetSnippetShortCutKeybindingState)(
		/*[out]*/ BOOL* fBound)
	{
		VSL_DEFINE_MOCK_METHOD(GetSnippetShortCutKeybindingState)

		VSL_SET_VALIDVALUE(fBound);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSEXPANSIONMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
