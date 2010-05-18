/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTIONBUILDMANAGER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTIONBUILDMANAGER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolutionBuildManager3NotImpl :
	public IVsSolutionBuildManager3
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionBuildManager3NotImpl)

public:

	typedef IVsSolutionBuildManager3 Interface;

	STDMETHOD(AdviseUpdateSolutionEvents3)(
		/*[in]*/ IVsUpdateSolutionEvents3* /*pIVsUpdateSolutionEvents3*/,
		/*[out]*/ VSCOOKIE* /*pdwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UnadviseUpdateSolutionEvents3)(
		/*[in]*/ VSCOOKIE /*dwCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(AreProjectsUpToDate)(
		/*[in]*/ DWORD /*dwOptions*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(HasHierarchyChangedSinceLastDTEE)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(QueryBuildManagerBusyEx)(
		/*[out]*/ DWORD* /*pdwBuildManagerOperation*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolutionBuildManager3MockImpl :
	public IVsSolutionBuildManager3,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionBuildManager3MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolutionBuildManager3MockImpl)

	typedef IVsSolutionBuildManager3 Interface;
	struct AdviseUpdateSolutionEvents3ValidValues
	{
		/*[in]*/ IVsUpdateSolutionEvents3* pIVsUpdateSolutionEvents3;
		/*[out]*/ VSCOOKIE* pdwCookie;
		HRESULT retValue;
	};

	STDMETHOD(AdviseUpdateSolutionEvents3)(
		/*[in]*/ IVsUpdateSolutionEvents3* pIVsUpdateSolutionEvents3,
		/*[out]*/ VSCOOKIE* pdwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(AdviseUpdateSolutionEvents3)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsUpdateSolutionEvents3);

		VSL_SET_VALIDVALUE(pdwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct UnadviseUpdateSolutionEvents3ValidValues
	{
		/*[in]*/ VSCOOKIE dwCookie;
		HRESULT retValue;
	};

	STDMETHOD(UnadviseUpdateSolutionEvents3)(
		/*[in]*/ VSCOOKIE dwCookie)
	{
		VSL_DEFINE_MOCK_METHOD(UnadviseUpdateSolutionEvents3)

		VSL_CHECK_VALIDVALUE(dwCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct AreProjectsUpToDateValidValues
	{
		/*[in]*/ DWORD dwOptions;
		HRESULT retValue;
	};

	STDMETHOD(AreProjectsUpToDate)(
		/*[in]*/ DWORD dwOptions)
	{
		VSL_DEFINE_MOCK_METHOD(AreProjectsUpToDate)

		VSL_CHECK_VALIDVALUE(dwOptions);

		VSL_RETURN_VALIDVALUES();
	}
	struct HasHierarchyChangedSinceLastDTEEValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(HasHierarchyChangedSinceLastDTEE)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(HasHierarchyChangedSinceLastDTEE)

		VSL_RETURN_VALIDVALUES();
	}
	struct QueryBuildManagerBusyExValidValues
	{
		/*[out]*/ DWORD* pdwBuildManagerOperation;
		HRESULT retValue;
	};

	STDMETHOD(QueryBuildManagerBusyEx)(
		/*[out]*/ DWORD* pdwBuildManagerOperation)
	{
		VSL_DEFINE_MOCK_METHOD(QueryBuildManagerBusyEx)

		VSL_SET_VALIDVALUE(pdwBuildManagerOperation);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTIONBUILDMANAGER3_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
