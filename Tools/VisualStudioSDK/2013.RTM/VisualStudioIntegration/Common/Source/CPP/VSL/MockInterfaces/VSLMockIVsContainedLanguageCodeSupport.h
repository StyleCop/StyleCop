/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTAINEDLANGUAGECODESUPPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTAINEDLANGUAGECODESUPPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "singlefileeditor.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsContainedLanguageCodeSupportNotImpl :
	public IVsContainedLanguageCodeSupport
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageCodeSupportNotImpl)

public:

	typedef IVsContainedLanguageCodeSupport Interface;

	STDMETHOD(CreateUniqueEventName)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszObjectName*/,
		/*[in]*/ LPCWSTR /*pszNameOfEvent*/,
		/*[out]*/ BSTR* /*pbstrEventHandlerName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnsureEventHandler)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszObjectTypeName*/,
		/*[in]*/ LPCWSTR /*pszNameOfEvent*/,
		/*[in]*/ LPCWSTR /*pszEventHandlerName*/,
		/*[in]*/ VSITEMID /*itemidInsertionPoint*/,
		/*[out]*/ BSTR* /*pbstrUniqueMemberID*/,
		/*[out]*/ BSTR* /*pbstrEventBody*/,
		/*[out]*/ TextSpan* /*pSpanInsertionPoint*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMemberNavigationPoint)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszUniqueMemberID*/,
		/*[out]*/ TextSpan* /*pSpanNavPoint*/,
		/*[out]*/ VSITEMID* /*pItemID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetMembers)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ DWORD /*dwFlags*/,
		/*[out]*/ int* /*pcMembers*/,
		/*[out]*/ BSTR** /*ppbstrDisplayNames*/,
		/*[out]*/ BSTR** /*ppbstrMemberIDs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnRenamed)(
		/*[in]*/ ContainedLanguageRenameType /*clrt*/,
		/*[in]*/ BSTR /*bstrOldID*/,
		/*[in]*/ BSTR /*bstrNewID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsValidID)(
		/*[in]*/ BSTR /*bstrID*/,
		/*[out]*/ VARIANT_BOOL* /*pfIsValidID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetBaseClassName)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[out]*/ BSTR* /*pbstrBaseClassName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetEventHandlerMemberID)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszObjectTypeName*/,
		/*[in]*/ LPCWSTR /*pszNameOfEvent*/,
		/*[in]*/ LPCWSTR /*pszEventHandlerName*/,
		/*[out]*/ BSTR* /*pbstrUniqueMemberID*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCompatibleEventHandlers)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszObjectTypeName*/,
		/*[in]*/ LPCWSTR /*pszNameOfEvent*/,
		/*[out]*/ int* /*pcMembers*/,
		/*[out]*/ BSTR** /*ppbstrEventHandlerNames*/,
		/*[out]*/ BSTR** /*ppbstrMemberIDs*/)VSL_STDMETHOD_NOTIMPL
};

class IVsContainedLanguageCodeSupportMockImpl :
	public IVsContainedLanguageCodeSupport,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageCodeSupportMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContainedLanguageCodeSupportMockImpl)

	typedef IVsContainedLanguageCodeSupport Interface;
	struct CreateUniqueEventNameValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszObjectName;
		/*[in]*/ LPCWSTR pszNameOfEvent;
		/*[out]*/ BSTR* pbstrEventHandlerName;
		HRESULT retValue;
	};

	STDMETHOD(CreateUniqueEventName)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszObjectName,
		/*[in]*/ LPCWSTR pszNameOfEvent,
		/*[out]*/ BSTR* pbstrEventHandlerName)
	{
		VSL_DEFINE_MOCK_METHOD(CreateUniqueEventName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameOfEvent);

		VSL_SET_VALIDVALUE_BSTR(pbstrEventHandlerName);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnsureEventHandlerValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszObjectTypeName;
		/*[in]*/ LPCWSTR pszNameOfEvent;
		/*[in]*/ LPCWSTR pszEventHandlerName;
		/*[in]*/ VSITEMID itemidInsertionPoint;
		/*[out]*/ BSTR* pbstrUniqueMemberID;
		/*[out]*/ BSTR* pbstrEventBody;
		/*[out]*/ TextSpan* pSpanInsertionPoint;
		HRESULT retValue;
	};

	STDMETHOD(EnsureEventHandler)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszObjectTypeName,
		/*[in]*/ LPCWSTR pszNameOfEvent,
		/*[in]*/ LPCWSTR pszEventHandlerName,
		/*[in]*/ VSITEMID itemidInsertionPoint,
		/*[out]*/ BSTR* pbstrUniqueMemberID,
		/*[out]*/ BSTR* pbstrEventBody,
		/*[out]*/ TextSpan* pSpanInsertionPoint)
	{
		VSL_DEFINE_MOCK_METHOD(EnsureEventHandler)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectTypeName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameOfEvent);

		VSL_CHECK_VALIDVALUE_STRINGW(pszEventHandlerName);

		VSL_CHECK_VALIDVALUE(itemidInsertionPoint);

		VSL_SET_VALIDVALUE_BSTR(pbstrUniqueMemberID);

		VSL_SET_VALIDVALUE_BSTR(pbstrEventBody);

		VSL_SET_VALIDVALUE(pSpanInsertionPoint);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMemberNavigationPointValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszUniqueMemberID;
		/*[out]*/ TextSpan* pSpanNavPoint;
		/*[out]*/ VSITEMID* pItemID;
		HRESULT retValue;
	};

	STDMETHOD(GetMemberNavigationPoint)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszUniqueMemberID,
		/*[out]*/ TextSpan* pSpanNavPoint,
		/*[out]*/ VSITEMID* pItemID)
	{
		VSL_DEFINE_MOCK_METHOD(GetMemberNavigationPoint)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszUniqueMemberID);

		VSL_SET_VALIDVALUE(pSpanNavPoint);

		VSL_SET_VALIDVALUE(pItemID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetMembersValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ DWORD dwFlags;
		/*[out]*/ int* pcMembers;
		/*[out]*/ BSTR** ppbstrDisplayNames;
		/*[out]*/ BSTR** ppbstrMemberIDs;
		HRESULT retValue;
	};

	STDMETHOD(GetMembers)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ DWORD dwFlags,
		/*[out]*/ int* pcMembers,
		/*[out]*/ BSTR** ppbstrDisplayNames,
		/*[out]*/ BSTR** ppbstrMemberIDs)
	{
		VSL_DEFINE_MOCK_METHOD(GetMembers)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE(dwFlags);

		VSL_SET_VALIDVALUE(pcMembers);

		VSL_SET_VALIDVALUE(ppbstrDisplayNames);

		VSL_SET_VALIDVALUE(ppbstrMemberIDs);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnRenamedValidValues
	{
		/*[in]*/ ContainedLanguageRenameType clrt;
		/*[in]*/ BSTR bstrOldID;
		/*[in]*/ BSTR bstrNewID;
		HRESULT retValue;
	};

	STDMETHOD(OnRenamed)(
		/*[in]*/ ContainedLanguageRenameType clrt,
		/*[in]*/ BSTR bstrOldID,
		/*[in]*/ BSTR bstrNewID)
	{
		VSL_DEFINE_MOCK_METHOD(OnRenamed)

		VSL_CHECK_VALIDVALUE(clrt);

		VSL_CHECK_VALIDVALUE_BSTR(bstrOldID);

		VSL_CHECK_VALIDVALUE_BSTR(bstrNewID);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsValidIDValidValues
	{
		/*[in]*/ BSTR bstrID;
		/*[out]*/ VARIANT_BOOL* pfIsValidID;
		HRESULT retValue;
	};

	STDMETHOD(IsValidID)(
		/*[in]*/ BSTR bstrID,
		/*[out]*/ VARIANT_BOOL* pfIsValidID)
	{
		VSL_DEFINE_MOCK_METHOD(IsValidID)

		VSL_CHECK_VALIDVALUE_BSTR(bstrID);

		VSL_SET_VALIDVALUE(pfIsValidID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetBaseClassNameValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[out]*/ BSTR* pbstrBaseClassName;
		HRESULT retValue;
	};

	STDMETHOD(GetBaseClassName)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[out]*/ BSTR* pbstrBaseClassName)
	{
		VSL_DEFINE_MOCK_METHOD(GetBaseClassName)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_SET_VALIDVALUE_BSTR(pbstrBaseClassName);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetEventHandlerMemberIDValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszObjectTypeName;
		/*[in]*/ LPCWSTR pszNameOfEvent;
		/*[in]*/ LPCWSTR pszEventHandlerName;
		/*[out]*/ BSTR* pbstrUniqueMemberID;
		HRESULT retValue;
	};

	STDMETHOD(GetEventHandlerMemberID)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszObjectTypeName,
		/*[in]*/ LPCWSTR pszNameOfEvent,
		/*[in]*/ LPCWSTR pszEventHandlerName,
		/*[out]*/ BSTR* pbstrUniqueMemberID)
	{
		VSL_DEFINE_MOCK_METHOD(GetEventHandlerMemberID)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectTypeName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameOfEvent);

		VSL_CHECK_VALIDVALUE_STRINGW(pszEventHandlerName);

		VSL_SET_VALIDVALUE_BSTR(pbstrUniqueMemberID);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCompatibleEventHandlersValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszObjectTypeName;
		/*[in]*/ LPCWSTR pszNameOfEvent;
		/*[out]*/ int* pcMembers;
		/*[out]*/ BSTR** ppbstrEventHandlerNames;
		/*[out]*/ BSTR** ppbstrMemberIDs;
		HRESULT retValue;
	};

	STDMETHOD(GetCompatibleEventHandlers)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszObjectTypeName,
		/*[in]*/ LPCWSTR pszNameOfEvent,
		/*[out]*/ int* pcMembers,
		/*[out]*/ BSTR** ppbstrEventHandlerNames,
		/*[out]*/ BSTR** ppbstrMemberIDs)
	{
		VSL_DEFINE_MOCK_METHOD(GetCompatibleEventHandlers)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectTypeName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameOfEvent);

		VSL_SET_VALIDVALUE(pcMembers);

		VSL_SET_VALIDVALUE(ppbstrEventHandlerNames);

		VSL_SET_VALIDVALUE(ppbstrMemberIDs);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTAINEDLANGUAGECODESUPPORT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
