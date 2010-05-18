/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCfgNotImpl :
	public IVsCfg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgNotImpl)

public:

	typedef IVsCfg Interface;

	STDMETHOD(get_DisplayName)(
		/*[out]*/ BSTR* /*pbstrDisplayName*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsDebugOnly)(
		/*[out]*/ BOOL* /*pfIsDebugOnly*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_IsReleaseOnly)(
		/*[out]*/ BOOL* /*pfIsReleaseOnly*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCfgMockImpl :
	public IVsCfg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCfgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCfgMockImpl)

	typedef IVsCfg Interface;
	struct get_DisplayNameValidValues
	{
		/*[out]*/ BSTR* pbstrDisplayName;
		HRESULT retValue;
	};

	STDMETHOD(get_DisplayName)(
		/*[out]*/ BSTR* pbstrDisplayName)
	{
		VSL_DEFINE_MOCK_METHOD(get_DisplayName)

		VSL_SET_VALIDVALUE_BSTR(pbstrDisplayName);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsDebugOnlyValidValues
	{
		/*[out]*/ BOOL* pfIsDebugOnly;
		HRESULT retValue;
	};

	STDMETHOD(get_IsDebugOnly)(
		/*[out]*/ BOOL* pfIsDebugOnly)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsDebugOnly)

		VSL_SET_VALIDVALUE(pfIsDebugOnly);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_IsReleaseOnlyValidValues
	{
		/*[out]*/ BOOL* pfIsReleaseOnly;
		HRESULT retValue;
	};

	STDMETHOD(get_IsReleaseOnly)(
		/*[out]*/ BOOL* pfIsReleaseOnly)
	{
		VSL_DEFINE_MOCK_METHOD(get_IsReleaseOnly)

		VSL_SET_VALIDVALUE(pfIsReleaseOnly);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
