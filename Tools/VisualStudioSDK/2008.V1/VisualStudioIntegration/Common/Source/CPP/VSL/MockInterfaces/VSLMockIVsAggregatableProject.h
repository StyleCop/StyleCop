/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSAGGREGATABLEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSAGGREGATABLEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsAggregatableProjectNotImpl :
	public IVsAggregatableProject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAggregatableProjectNotImpl)

public:

	typedef IVsAggregatableProject Interface;

	STDMETHOD(SetInnerProject)(
		/*[in]*/ IUnknown* /*punkInner*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitializeForOuter)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ LPCOLESTR /*pszLocation*/,
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ VSCREATEPROJFLAGS /*grfCreateFlags*/,
		/*[in]*/ REFIID /*iidProject*/,
		/*[out,iid_is(iidProject)]*/ void** /*ppvProject*/,
		/*[out]*/ BOOL* /*pfCanceled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(OnAggregationComplete)()VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetAggregateProjectTypeGuids)(
		/*[out]*/ BSTR* /*pbstrProjTypeGuids*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetAggregateProjectTypeGuids)(
		/*[in]*/ LPCOLESTR /*lpstrProjTypeGuids*/)VSL_STDMETHOD_NOTIMPL
};

class IVsAggregatableProjectMockImpl :
	public IVsAggregatableProject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsAggregatableProjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsAggregatableProjectMockImpl)

	typedef IVsAggregatableProject Interface;
	struct SetInnerProjectValidValues
	{
		/*[in]*/ IUnknown* punkInner;
		HRESULT retValue;
	};

	STDMETHOD(SetInnerProject)(
		/*[in]*/ IUnknown* punkInner)
	{
		VSL_DEFINE_MOCK_METHOD(SetInnerProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(punkInner);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitializeForOuterValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ LPCOLESTR pszLocation;
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags;
		/*[in]*/ REFIID iidProject;
		/*[out,iid_is(iidProject)]*/ void** ppvProject;
		/*[out]*/ BOOL* pfCanceled;
		HRESULT retValue;
	};

	STDMETHOD(InitializeForOuter)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ LPCOLESTR pszLocation,
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags,
		/*[in]*/ REFIID iidProject,
		/*[out,iid_is(iidProject)]*/ void** ppvProject,
		/*[out]*/ BOOL* pfCanceled)
	{
		VSL_DEFINE_MOCK_METHOD(InitializeForOuter)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_CHECK_VALIDVALUE(iidProject);

		VSL_SET_VALIDVALUE(ppvProject);

		VSL_SET_VALIDVALUE(pfCanceled);

		VSL_RETURN_VALIDVALUES();
	}
	struct OnAggregationCompleteValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(OnAggregationComplete)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(OnAggregationComplete)

		VSL_RETURN_VALIDVALUES();
	}
	struct GetAggregateProjectTypeGuidsValidValues
	{
		/*[out]*/ BSTR* pbstrProjTypeGuids;
		HRESULT retValue;
	};

	STDMETHOD(GetAggregateProjectTypeGuids)(
		/*[out]*/ BSTR* pbstrProjTypeGuids)
	{
		VSL_DEFINE_MOCK_METHOD(GetAggregateProjectTypeGuids)

		VSL_SET_VALIDVALUE_BSTR(pbstrProjTypeGuids);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetAggregateProjectTypeGuidsValidValues
	{
		/*[in]*/ LPCOLESTR lpstrProjTypeGuids;
		HRESULT retValue;
	};

	STDMETHOD(SetAggregateProjectTypeGuids)(
		/*[in]*/ LPCOLESTR lpstrProjTypeGuids)
	{
		VSL_DEFINE_MOCK_METHOD(SetAggregateProjectTypeGuids)

		VSL_CHECK_VALIDVALUE_STRINGW(lpstrProjTypeGuids);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSAGGREGATABLEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
