/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCOMMANDARGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCOMMANDARGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCommandArgInfoNotImpl :
	public IVsCommandArgInfo
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandArgInfoNotImpl)

public:

	typedef IVsCommandArgInfo Interface;

	STDMETHOD(QueryCommandArgAvailable)(
		/*[out]*/ BOOL* /*pfCmdArgAvailable*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetCommandArg)(
		/*[out]*/ BSTR* /*pbstrCmdArg*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCommandArgInfoMockImpl :
	public IVsCommandArgInfo,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCommandArgInfoMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCommandArgInfoMockImpl)

	typedef IVsCommandArgInfo Interface;
	struct QueryCommandArgAvailableValidValues
	{
		/*[out]*/ BOOL* pfCmdArgAvailable;
		HRESULT retValue;
	};

	STDMETHOD(QueryCommandArgAvailable)(
		/*[out]*/ BOOL* pfCmdArgAvailable)
	{
		VSL_DEFINE_MOCK_METHOD(QueryCommandArgAvailable)

		VSL_SET_VALIDVALUE(pfCmdArgAvailable);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetCommandArgValidValues
	{
		/*[out]*/ BSTR* pbstrCmdArg;
		HRESULT retValue;
	};

	STDMETHOD(GetCommandArg)(
		/*[out]*/ BSTR* pbstrCmdArg)
	{
		VSL_DEFINE_MOCK_METHOD(GetCommandArg)

		VSL_SET_VALIDVALUE_BSTR(pbstrCmdArg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCOMMANDARGINFO_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
