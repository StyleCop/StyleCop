/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ITYPECOMP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ITYPECOMP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class ITypeCompNotImpl :
	public ITypeComp
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeCompNotImpl)

public:

	typedef ITypeComp Interface;

	STDMETHOD(Bind)(
		/*[in]*/ LPOLESTR /*szName*/,
		/*[in]*/ ULONG /*lHashVal*/,
		/*[in]*/ WORD /*wFlags*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/,
		/*[out]*/ DESCKIND* /*pDescKind*/,
		/*[out]*/ BINDPTR* /*pBindPtr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(BindType)(
		/*[in]*/ LPOLESTR /*szName*/,
		/*[in]*/ ULONG /*lHashVal*/,
		/*[out]*/ ITypeInfo** /*ppTInfo*/,
		/*[out]*/ ITypeComp** /*ppTComp*/)VSL_STDMETHOD_NOTIMPL
};

class ITypeCompMockImpl :
	public ITypeComp,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ITypeCompMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ITypeCompMockImpl)

	typedef ITypeComp Interface;
	struct BindValidValues
	{
		/*[in]*/ LPOLESTR szName;
		/*[in]*/ ULONG lHashVal;
		/*[in]*/ WORD wFlags;
		/*[out]*/ ITypeInfo** ppTInfo;
		/*[out]*/ DESCKIND* pDescKind;
		/*[out]*/ BINDPTR* pBindPtr;
		HRESULT retValue;
	};

	STDMETHOD(Bind)(
		/*[in]*/ LPOLESTR szName,
		/*[in]*/ ULONG lHashVal,
		/*[in]*/ WORD wFlags,
		/*[out]*/ ITypeInfo** ppTInfo,
		/*[out]*/ DESCKIND* pDescKind,
		/*[out]*/ BINDPTR* pBindPtr)
	{
		VSL_DEFINE_MOCK_METHOD(Bind)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE(lHashVal);

		VSL_CHECK_VALIDVALUE(wFlags);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_SET_VALIDVALUE(pDescKind);

		VSL_SET_VALIDVALUE(pBindPtr);

		VSL_RETURN_VALIDVALUES();
	}
	struct BindTypeValidValues
	{
		/*[in]*/ LPOLESTR szName;
		/*[in]*/ ULONG lHashVal;
		/*[out]*/ ITypeInfo** ppTInfo;
		/*[out]*/ ITypeComp** ppTComp;
		HRESULT retValue;
	};

	STDMETHOD(BindType)(
		/*[in]*/ LPOLESTR szName,
		/*[in]*/ ULONG lHashVal,
		/*[out]*/ ITypeInfo** ppTInfo,
		/*[out]*/ ITypeComp** ppTComp)
	{
		VSL_DEFINE_MOCK_METHOD(BindType)

		VSL_CHECK_VALIDVALUE_STRINGW(szName);

		VSL_CHECK_VALIDVALUE(lHashVal);

		VSL_SET_VALIDVALUE_INTERFACE(ppTInfo);

		VSL_SET_VALIDVALUE_INTERFACE(ppTComp);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ITYPECOMP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
