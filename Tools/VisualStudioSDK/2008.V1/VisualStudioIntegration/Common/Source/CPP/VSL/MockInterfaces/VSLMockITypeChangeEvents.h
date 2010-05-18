/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITYPECHANGEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITYPECHANGEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ITypeChangeEventsNotImpl :
	public ITypeChangeEvents
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeChangeEventsNotImpl)

public:

	typedef ITypeChangeEvents Interface;

	STDMETHOD(RequestTypeChange)(
		/*[in]*/ CHANGEKIND /*changeKind*/,
		/*[in]*/ ITypeInfo* /*pTInfoBefore*/,
		/*[in]*/ LPOLESTR /*pStrName*/,
		/*[out]*/ INT* /*pfCancel*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AfterTypeChange)(
		/*[in]*/ CHANGEKIND /*changeKind*/,
		/*[in]*/ ITypeInfo* /*pTInfoAfter*/,
		/*[in]*/ LPOLESTR /*pStrName*/)VSL_STDMETHOD_NOTIMPL
};

class ITypeChangeEventsMockImpl :
	public ITypeChangeEvents,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeChangeEventsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITypeChangeEventsMockImpl)

	typedef ITypeChangeEvents Interface;
	struct RequestTypeChangeValidValues
	{
		/*[in]*/ CHANGEKIND changeKind;
		/*[in]*/ ITypeInfo* pTInfoBefore;
		/*[in]*/ LPOLESTR pStrName;
		/*[out]*/ INT* pfCancel;
		HRESULT retValue;
	};

	STDMETHOD(RequestTypeChange)(
		/*[in]*/ CHANGEKIND changeKind,
		/*[in]*/ ITypeInfo* pTInfoBefore,
		/*[in]*/ LPOLESTR pStrName,
		/*[out]*/ INT* pfCancel)
	{
		VSL_DEFINE_MOCK_METHOD(RequestTypeChange)

		VSL_CHECK_VALIDVALUE(changeKind);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTInfoBefore);

		VSL_CHECK_VALIDVALUE_STRINGW(pStrName);

		VSL_SET_VALIDVALUE(pfCancel);

		VSL_RETURN_VALIDVALUES();
	}
	struct AfterTypeChangeValidValues
	{
		/*[in]*/ CHANGEKIND changeKind;
		/*[in]*/ ITypeInfo* pTInfoAfter;
		/*[in]*/ LPOLESTR pStrName;
		HRESULT retValue;
	};

	STDMETHOD(AfterTypeChange)(
		/*[in]*/ CHANGEKIND changeKind,
		/*[in]*/ ITypeInfo* pTInfoAfter,
		/*[in]*/ LPOLESTR pStrName)
	{
		VSL_DEFINE_MOCK_METHOD(AfterTypeChange)

		VSL_CHECK_VALIDVALUE(changeKind);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pTInfoAfter);

		VSL_CHECK_VALIDVALUE_STRINGW(pStrName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITYPECHANGEEVENTS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
