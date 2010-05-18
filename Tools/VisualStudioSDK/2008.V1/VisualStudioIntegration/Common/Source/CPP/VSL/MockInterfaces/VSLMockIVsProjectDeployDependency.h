/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTDEPLOYDEPENDENCY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTDEPLOYDEPENDENCY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectDeployDependencyNotImpl :
	public IVsProjectDeployDependency
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectDeployDependencyNotImpl)

public:

	typedef IVsProjectDeployDependency Interface;

	STDMETHOD(get_ProjectInfo)(
		/*[out]*/ IVsHierarchy** /*ppIVsHierarchy*/,
		/*[out]*/ IVsProjectCfg** /*ppIVsProjectCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(get_DeployDependencyURL)(
		/*[out]*/ BSTR* /*pbstrURL*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectDeployDependencyMockImpl :
	public IVsProjectDeployDependency,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectDeployDependencyMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectDeployDependencyMockImpl)

	typedef IVsProjectDeployDependency Interface;
	struct get_ProjectInfoValidValues
	{
		/*[out]*/ IVsHierarchy** ppIVsHierarchy;
		/*[out]*/ IVsProjectCfg** ppIVsProjectCfg;
		HRESULT retValue;
	};

	STDMETHOD(get_ProjectInfo)(
		/*[out]*/ IVsHierarchy** ppIVsHierarchy,
		/*[out]*/ IVsProjectCfg** ppIVsProjectCfg)
	{
		VSL_DEFINE_MOCK_METHOD(get_ProjectInfo)

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsHierarchy);

		VSL_SET_VALIDVALUE_INTERFACE(ppIVsProjectCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct get_DeployDependencyURLValidValues
	{
		/*[out]*/ BSTR* pbstrURL;
		HRESULT retValue;
	};

	STDMETHOD(get_DeployDependencyURL)(
		/*[out]*/ BSTR* pbstrURL)
	{
		VSL_DEFINE_MOCK_METHOD(get_DeployDependencyURL)

		VSL_SET_VALIDVALUE_BSTR(pbstrURL);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTDEPLOYDEPENDENCY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
