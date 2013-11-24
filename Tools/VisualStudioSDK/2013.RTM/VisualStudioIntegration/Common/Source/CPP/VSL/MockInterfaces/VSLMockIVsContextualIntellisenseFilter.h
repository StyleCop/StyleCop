/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCONTEXTUALINTELLISENSEFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCONTEXTUALINTELLISENSEFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsContextualIntellisenseFilterNotImpl :
	public IVsContextualIntellisenseFilter
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContextualIntellisenseFilterNotImpl)

public:

	typedef IVsContextualIntellisenseFilter Interface;

	STDMETHOD(Initialize)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsTypeVisible)(
		/*[in]*/ LPCOLESTR /*szTypeName*/,
		/*[out]*/ BOOL* /*pfVisible*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsMemberVisible)(
		/*[in]*/ LPCOLESTR /*szMemberSignature*/,
		/*[out]*/ BOOL* /*pfVisible*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL
};

class IVsContextualIntellisenseFilterMockImpl :
	public IVsContextualIntellisenseFilter,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsContextualIntellisenseFilterMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsContextualIntellisenseFilterMockImpl)

	typedef IVsContextualIntellisenseFilter Interface;
	struct InitializeValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		HRESULT retValue;
	};

	STDMETHOD(Initialize)(
		/*[in]*/ IVsHierarchy* pHierarchy)
	{
		VSL_DEFINE_MOCK_METHOD(Initialize)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsTypeVisibleValidValues
	{
		/*[in]*/ LPCOLESTR szTypeName;
		/*[out]*/ BOOL* pfVisible;
		HRESULT retValue;
	};

	STDMETHOD(IsTypeVisible)(
		/*[in]*/ LPCOLESTR szTypeName,
		/*[out]*/ BOOL* pfVisible)
	{
		VSL_DEFINE_MOCK_METHOD(IsTypeVisible)

		VSL_CHECK_VALIDVALUE_STRINGW(szTypeName);

		VSL_SET_VALIDVALUE(pfVisible);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsMemberVisibleValidValues
	{
		/*[in]*/ LPCOLESTR szMemberSignature;
		/*[out]*/ BOOL* pfVisible;
		HRESULT retValue;
	};

	STDMETHOD(IsMemberVisible)(
		/*[in]*/ LPCOLESTR szMemberSignature,
		/*[out]*/ BOOL* pfVisible)
	{
		VSL_DEFINE_MOCK_METHOD(IsMemberVisible)

		VSL_CHECK_VALIDVALUE_STRINGW(szMemberSignature);

		VSL_SET_VALIDVALUE(pfVisible);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCONTEXTUALINTELLISENSEFILTER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
