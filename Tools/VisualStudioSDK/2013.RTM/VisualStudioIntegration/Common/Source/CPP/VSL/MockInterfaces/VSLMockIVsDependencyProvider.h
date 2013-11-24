/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSDEPENDENCYPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSDEPENDENCYPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsDependencyProviderNotImpl :
	public IVsDependencyProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDependencyProviderNotImpl)

public:

	typedef IVsDependencyProvider Interface;

	STDMETHOD(EnumDependencies)(
		/*[out]*/ IVsEnumDependencies** /*ppIVsEnumDependencies*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OpenDependency)(
		/*[in]*/ LPCOLESTR /*szDependencyCanonicalName*/,
		/*[out]*/ IVsDependency** /*ppIVsDependency*/)VSL_STDMETHOD_NOTIMPL
};

class IVsDependencyProviderMockImpl :
	public IVsDependencyProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsDependencyProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsDependencyProviderMockImpl)

	typedef IVsDependencyProvider Interface;
	struct EnumDependenciesValidValues
	{
		/*[out]*/ IVsEnumDependencies** ppIVsEnumDependencies;
		HRESULT retValue;
	};

	STDMETHOD(EnumDependencies)(
		/*[out]*/ IVsEnumDependencies** ppIVsEnumDependencies)
	{
		VSL_DEFINE_MOCK_METHOD(EnumDependencies)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsEnumDependencies);

		VSL_RETURN_VALIDVALUES();
	}
	struct OpenDependencyValidValues
	{
		/*[in]*/ LPCOLESTR szDependencyCanonicalName;
		/*[out]*/ IVsDependency** ppIVsDependency;
		HRESULT retValue;
	};

	STDMETHOD(OpenDependency)(
		/*[in]*/ LPCOLESTR szDependencyCanonicalName,
		/*[out]*/ IVsDependency** ppIVsDependency)
	{
		VSL_DEFINE_MOCK_METHOD(OpenDependency)

		VSL_CHECK_VALIDVALUE_STRINGW(szDependencyCanonicalName);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsDependency);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSDEPENDENCYPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
