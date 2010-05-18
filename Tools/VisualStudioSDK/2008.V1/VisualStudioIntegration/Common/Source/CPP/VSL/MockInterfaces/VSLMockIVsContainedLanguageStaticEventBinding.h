/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTAINEDLANGUAGESTATICEVENTBINDING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTAINEDLANGUAGESTATICEVENTBINDING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsContainedLanguageStaticEventBindingNotImpl :
	public IVsContainedLanguageStaticEventBinding
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageStaticEventBindingNotImpl)

public:

	typedef IVsContainedLanguageStaticEventBinding Interface;

	STDMETHOD(GetStaticEventBindingsForObject)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszObjectName*/,
		/*[out]*/ int* /*pcMembers*/,
		/*[out]*/ BSTR** /*ppbstrEventNames*/,
		/*[out]*/ BSTR** /*ppbstrDisplayNames*/,
		/*[out]*/ BSTR** /*ppbstrMemberIDs*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RemoveStaticEventBinding)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszUniqueMemberID*/,
		/*[in]*/ LPCWSTR /*pszObjectName*/,
		/*[in]*/ LPCWSTR /*pszNameOfEvent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AddStaticEventBinding)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszUniqueMemberID*/,
		/*[in]*/ LPCWSTR /*pszObjectName*/,
		/*[in]*/ LPCWSTR /*pszNameOfEvent*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(EnsureStaticEventHandler)(
		/*[in]*/ LPCWSTR /*pszClassName*/,
		/*[in]*/ LPCWSTR /*pszObjectTypeName*/,
		/*[in]*/ LPCWSTR /*pszObjectName*/,
		/*[in]*/ LPCWSTR /*pszNameOfEvent*/,
		/*[in]*/ LPCWSTR /*pszEventHandlerName*/,
		/*[in]*/ VSITEMID /*itemidInsertionPoint*/,
		/*[out]*/ BSTR* /*pbstrUniqueMemberID*/,
		/*[out]*/ BSTR* /*pbstrEventBody*/,
		/*[out]*/ TextSpan* /*pSpanInsertionPoint*/)VSL_STDMETHOD_NOTIMPL
};

class IVsContainedLanguageStaticEventBindingMockImpl :
	public IVsContainedLanguageStaticEventBinding,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContainedLanguageStaticEventBindingMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContainedLanguageStaticEventBindingMockImpl)

	typedef IVsContainedLanguageStaticEventBinding Interface;
	struct GetStaticEventBindingsForObjectValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszObjectName;
		/*[out]*/ int* pcMembers;
		/*[out]*/ BSTR** ppbstrEventNames;
		/*[out]*/ BSTR** ppbstrDisplayNames;
		/*[out]*/ BSTR** ppbstrMemberIDs;
		HRESULT retValue;
	};

	STDMETHOD(GetStaticEventBindingsForObject)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszObjectName,
		/*[out]*/ int* pcMembers,
		/*[out]*/ BSTR** ppbstrEventNames,
		/*[out]*/ BSTR** ppbstrDisplayNames,
		/*[out]*/ BSTR** ppbstrMemberIDs)
	{
		VSL_DEFINE_MOCK_METHOD(GetStaticEventBindingsForObject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectName);

		VSL_SET_VALIDVALUE(pcMembers);

		VSL_SET_VALIDVALUE(ppbstrEventNames);

		VSL_SET_VALIDVALUE(ppbstrDisplayNames);

		VSL_SET_VALIDVALUE(ppbstrMemberIDs);

		VSL_RETURN_VALIDVALUES();
	}
	struct RemoveStaticEventBindingValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszUniqueMemberID;
		/*[in]*/ LPCWSTR pszObjectName;
		/*[in]*/ LPCWSTR pszNameOfEvent;
		HRESULT retValue;
	};

	STDMETHOD(RemoveStaticEventBinding)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszUniqueMemberID,
		/*[in]*/ LPCWSTR pszObjectName,
		/*[in]*/ LPCWSTR pszNameOfEvent)
	{
		VSL_DEFINE_MOCK_METHOD(RemoveStaticEventBinding)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszUniqueMemberID);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameOfEvent);

		VSL_RETURN_VALIDVALUES();
	}
	struct AddStaticEventBindingValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszUniqueMemberID;
		/*[in]*/ LPCWSTR pszObjectName;
		/*[in]*/ LPCWSTR pszNameOfEvent;
		HRESULT retValue;
	};

	STDMETHOD(AddStaticEventBinding)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszUniqueMemberID,
		/*[in]*/ LPCWSTR pszObjectName,
		/*[in]*/ LPCWSTR pszNameOfEvent)
	{
		VSL_DEFINE_MOCK_METHOD(AddStaticEventBinding)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszUniqueMemberID);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameOfEvent);

		VSL_RETURN_VALIDVALUES();
	}
	struct EnsureStaticEventHandlerValidValues
	{
		/*[in]*/ LPCWSTR pszClassName;
		/*[in]*/ LPCWSTR pszObjectTypeName;
		/*[in]*/ LPCWSTR pszObjectName;
		/*[in]*/ LPCWSTR pszNameOfEvent;
		/*[in]*/ LPCWSTR pszEventHandlerName;
		/*[in]*/ VSITEMID itemidInsertionPoint;
		/*[out]*/ BSTR* pbstrUniqueMemberID;
		/*[out]*/ BSTR* pbstrEventBody;
		/*[out]*/ TextSpan* pSpanInsertionPoint;
		HRESULT retValue;
	};

	STDMETHOD(EnsureStaticEventHandler)(
		/*[in]*/ LPCWSTR pszClassName,
		/*[in]*/ LPCWSTR pszObjectTypeName,
		/*[in]*/ LPCWSTR pszObjectName,
		/*[in]*/ LPCWSTR pszNameOfEvent,
		/*[in]*/ LPCWSTR pszEventHandlerName,
		/*[in]*/ VSITEMID itemidInsertionPoint,
		/*[out]*/ BSTR* pbstrUniqueMemberID,
		/*[out]*/ BSTR* pbstrEventBody,
		/*[out]*/ TextSpan* pSpanInsertionPoint)
	{
		VSL_DEFINE_MOCK_METHOD(EnsureStaticEventHandler)

		VSL_CHECK_VALIDVALUE_STRINGW(pszClassName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectTypeName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszObjectName);

		VSL_CHECK_VALIDVALUE_STRINGW(pszNameOfEvent);

		VSL_CHECK_VALIDVALUE_STRINGW(pszEventHandlerName);

		VSL_CHECK_VALIDVALUE(itemidInsertionPoint);

		VSL_SET_VALIDVALUE_BSTR(pbstrUniqueMemberID);

		VSL_SET_VALIDVALUE_BSTR(pbstrEventBody);

		VSL_SET_VALIDVALUE(pSpanInsertionPoint);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTAINEDLANGUAGESTATICEVENTBINDING_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
