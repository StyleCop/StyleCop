/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSREGISTERCUSTOMFINDSCOPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSREGISTERCUSTOMFINDSCOPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsRegisterCustomFindScopeNotImpl :
	public IVsRegisterCustomFindScope
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterCustomFindScopeNotImpl)

public:

	typedef IVsRegisterCustomFindScope Interface;

	STDMETHOD(RegisterCustomFindScope)(
		/*[in]*/ REFGUID /*guidSID*/,
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ VSFINDOPTIONS /*grfEnabledOptions*/,
		/*[out]*/ DWORD_PTR* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnRegisterCustomFindScope)(
		/*[in]*/ DWORD_PTR /*dwCookie*/)VSL_STDMETHOD_NOTIMPL
};

class IVsRegisterCustomFindScopeMockImpl :
	public IVsRegisterCustomFindScope,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsRegisterCustomFindScopeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsRegisterCustomFindScopeMockImpl)

	typedef IVsRegisterCustomFindScope Interface;
	struct RegisterCustomFindScopeValidValues
	{
		/*[in]*/ REFGUID guidSID;
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ VSFINDOPTIONS grfEnabledOptions;
		/*[out]*/ DWORD_PTR* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(RegisterCustomFindScope)(
		/*[in]*/ REFGUID guidSID,
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ VSFINDOPTIONS grfEnabledOptions,
		/*[out]*/ DWORD_PTR* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(RegisterCustomFindScope)

		VSL_CHECK_VALIDVALUE(guidSID);

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(grfEnabledOptions);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnRegisterCustomFindScopeValidValues
	{
		/*[in]*/ DWORD_PTR dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnRegisterCustomFindScope)(
		/*[in]*/ DWORD_PTR dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnRegisterCustomFindScope)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSREGISTERCUSTOMFINDSCOPE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
