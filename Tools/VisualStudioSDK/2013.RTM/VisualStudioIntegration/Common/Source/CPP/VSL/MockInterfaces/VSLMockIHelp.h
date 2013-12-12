/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IHELP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IHELP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IHelpNotImpl :
	public IHelp
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IHelpNotImpl)

public:

	typedef IHelp Interface;

	STDMETHOD(GetHelpFile)(
		/*[out]*/ BSTR* /*pbstr*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetHelpInfo)(
		/*[out]*/ DWORD* /*pdwHelpInfo*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(ShowHelp)(
		/*[in]*/ LPOLESTR /*szHelp*/,
		/*[in]*/ UINT /*fuCommand*/,
		/*[in]*/ DWORD /*dwHelpContext*/)VSL_STDMETHOD_NOTIMPL
};

class IHelpMockImpl :
	public IHelp,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IHelpMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IHelpMockImpl)

	typedef IHelp Interface;
	struct GetHelpFileValidValues
	{
		/*[out]*/ BSTR* pbstr;
		HRESULT retValue;
	};

	STDMETHOD(GetHelpFile)(
		/*[out]*/ BSTR* pbstr)
	{
		VSL_DEFINE_MOCK_METHOD(GetHelpFile)

		VSL_SET_VALIDVALUE_BSTR(pbstr);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetHelpInfoValidValues
	{
		/*[out]*/ DWORD* pdwHelpInfo;
		HRESULT retValue;
	};

	STDMETHOD(GetHelpInfo)(
		/*[out]*/ DWORD* pdwHelpInfo)
	{
		VSL_DEFINE_MOCK_METHOD(GetHelpInfo)

		VSL_SET_VALIDVALUE(pdwHelpInfo);

		VSL_RETURN_VALIDVALUES();
	}
	struct ShowHelpValidValues
	{
		/*[in]*/ LPOLESTR szHelp;
		/*[in]*/ UINT fuCommand;
		/*[in]*/ DWORD dwHelpContext;
		HRESULT retValue;
	};

	STDMETHOD(ShowHelp)(
		/*[in]*/ LPOLESTR szHelp,
		/*[in]*/ UINT fuCommand,
		/*[in]*/ DWORD dwHelpContext)
	{
		VSL_DEFINE_MOCK_METHOD(ShowHelp)

		VSL_CHECK_VALIDVALUE_STRINGW(szHelp);

		VSL_CHECK_VALIDVALUE(fuCommand);

		VSL_CHECK_VALIDVALUE(dwHelpContext);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IHELP_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
