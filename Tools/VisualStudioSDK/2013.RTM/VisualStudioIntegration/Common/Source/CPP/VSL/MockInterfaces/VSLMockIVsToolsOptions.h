/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSTOOLSOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSTOOLSOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsToolsOptionsNotImpl :
	public IVsToolsOptions
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolsOptionsNotImpl)

public:

	typedef IVsToolsOptions Interface;

	STDMETHOD(IsToolsOptionsOpen)(
		/*[out]*/ BOOL* /*pfOpen*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(RefreshPageVisibility)()VSL_STDMETHOD_NOTIMPL
};

class IVsToolsOptionsMockImpl :
	public IVsToolsOptions,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsToolsOptionsMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsToolsOptionsMockImpl)

	typedef IVsToolsOptions Interface;
	struct IsToolsOptionsOpenValidValues
	{
		/*[out]*/ BOOL* pfOpen;
		HRESULT retValue;
	};

	STDMETHOD(IsToolsOptionsOpen)(
		/*[out]*/ BOOL* pfOpen)
	{
		VSL_DEFINE_MOCK_METHOD(IsToolsOptionsOpen)

		VSL_SET_VALIDVALUE(pfOpen);

		VSL_RETURN_VALIDVALUES();
	}
	struct RefreshPageVisibilityValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(RefreshPageVisibility)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(RefreshPageVisibility)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSTOOLSOPTIONS_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
