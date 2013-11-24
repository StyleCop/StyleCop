/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSBUILDABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSBUILDABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsBuildableProjectCfg2NotImpl :
	public IVsBuildableProjectCfg2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildableProjectCfg2NotImpl)

public:

	typedef IVsBuildableProjectCfg2 Interface;

	STDMETHOD(GetBuildCfgProperty)(
		/*[in]*/ VSBLDCFGPROPID /*propid*/,
		/*[out]*/ VARIANT* /*pvar*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(StartBuildEx)(
		/*[in]*/ DWORD /*dwBuildId*/,
		/*[in]*/ IVsOutputWindowPane* /*pIVsOutputWindowPane*/,
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL
};

class IVsBuildableProjectCfg2MockImpl :
	public IVsBuildableProjectCfg2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsBuildableProjectCfg2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsBuildableProjectCfg2MockImpl)

	typedef IVsBuildableProjectCfg2 Interface;
	struct GetBuildCfgPropertyValidValues
	{
		/*[in]*/ VSBLDCFGPROPID propid;
		/*[out]*/ VARIANT* pvar;
		HRESULT retValue;
	};

	STDMETHOD(GetBuildCfgProperty)(
		/*[in]*/ VSBLDCFGPROPID propid,
		/*[out]*/ VARIANT* pvar)
	{
		VSL_DEFINE_MOCK_METHOD(GetBuildCfgProperty)

		VSL_CHECK_VALIDVALUE(propid);

		VSL_SET_VALIDVALUE_VARIANT(pvar);

		VSL_RETURN_VALIDVALUES();
	}
	struct StartBuildExValidValues
	{
		/*[in]*/ DWORD dwBuildId;
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane;
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(StartBuildEx)(
		/*[in]*/ DWORD dwBuildId,
		/*[in]*/ IVsOutputWindowPane* pIVsOutputWindowPane,
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(StartBuildEx)

		VSL_CHECK_VALIDVALUE(dwBuildId);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsOutputWindowPane);

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSBUILDABLEPROJECTCFG2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
