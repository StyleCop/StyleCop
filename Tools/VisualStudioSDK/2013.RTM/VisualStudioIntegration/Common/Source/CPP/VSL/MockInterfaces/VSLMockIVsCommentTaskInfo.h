/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMMENTTASKINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMMENTTASKINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsshell.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsCommentTaskInfoNotImpl :
	public IVsCommentTaskInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommentTaskInfoNotImpl)

public:

	typedef IVsCommentTaskInfo Interface;

	STDMETHOD(get_DefaultToken)(
		/*[out,retval]*/ IVsCommentTaskToken** /*ppToken*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_EnumTokens)(
		/*[out,retval]*/ IVsEnumCommentTaskTokens** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_TokenCount)(
		/*[out,retval]*/ long* /*pCount*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCommentTaskInfoMockImpl :
	public IVsCommentTaskInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommentTaskInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCommentTaskInfoMockImpl)

	typedef IVsCommentTaskInfo Interface;
	struct get_DefaultTokenValidValues
	{
		/*[out,retval]*/ IVsCommentTaskToken** ppToken;
		HRESULT retValue;
	};

	STDMETHOD(get_DefaultToken)(
		/*[out,retval]*/ IVsCommentTaskToken** ppToken)
	{
		VSL_DEFINE_MOCK_METHOD(get_DefaultToken)

		VSL_SET_VALIDVALUE_INTERFACE(ppToken);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_EnumTokensValidValues
	{
		/*[out,retval]*/ IVsEnumCommentTaskTokens** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(get_EnumTokens)(
		/*[out,retval]*/ IVsEnumCommentTaskTokens** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(get_EnumTokens)

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_TokenCountValidValues
	{
		/*[out,retval]*/ long* pCount;
		HRESULT retValue;
	};

	STDMETHOD(get_TokenCount)(
		/*[out,retval]*/ long* pCount)
	{
		VSL_DEFINE_MOCK_METHOD(get_TokenCount)

		VSL_SET_VALIDVALUE(pCount);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMMENTTASKINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
