/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSAGGREGATABLEPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSAGGREGATABLEPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAggregatableProjectFactoryNotImpl :
	public IVsAggregatableProjectFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAggregatableProjectFactoryNotImpl)

public:

	typedef IVsAggregatableProjectFactory Interface;

	STDMETHOD(GetAggregateProjectType)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[out]*/ BSTR* /*pbstrProjTypeGuid*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(PreCreateForOuter)(
		/*[in]*/ IUnknown* /*punkOuter*/,
		/*[out]*/ IUnknown** /*ppunkProject*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAggregatableProjectFactoryMockImpl :
	public IVsAggregatableProjectFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAggregatableProjectFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAggregatableProjectFactoryMockImpl)

	typedef IVsAggregatableProjectFactory Interface;
	struct GetAggregateProjectTypeValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[out]*/ BSTR* pbstrProjTypeGuid;
		HRESULT retValue;
	};

	STDMETHOD(GetAggregateProjectType)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[out]*/ BSTR* pbstrProjTypeGuid)
	{
		VSL_DEFINE_MOCK_METHOD(GetAggregateProjectType)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_SET_VALIDVALUE_BSTR(pbstrProjTypeGuid);

		VSL_RETURN_VALIDVALUES();
	}
	struct PreCreateForOuterValidValues
	{
		/*[in]*/ IUnknown* punkOuter;
		/*[out]*/ IUnknown** ppunkProject;
		HRESULT retValue;
	};

	STDMETHOD(PreCreateForOuter)(
		/*[in]*/ IUnknown* punkOuter,
		/*[out]*/ IUnknown** ppunkProject)
	{
		VSL_DEFINE_MOCK_METHOD(PreCreateForOuter)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkOuter);

		VSL_SET_VALIDVALUE_INTERFACE(ppunkProject);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSAGGREGATABLEPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
