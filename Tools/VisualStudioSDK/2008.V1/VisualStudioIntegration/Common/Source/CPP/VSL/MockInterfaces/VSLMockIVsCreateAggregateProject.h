/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSCREATEAGGREGATEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSCREATEAGGREGATEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsCreateAggregateProjectNotImpl :
	public IVsCreateAggregateProject
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCreateAggregateProjectNotImpl)

public:

	typedef IVsCreateAggregateProject Interface;

	STDMETHOD(CreateAggregateProject)(
		/*[in]*/ LPCOLESTR /*pszProjectTypeGuids*/,
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ LPCOLESTR /*pszLocation*/,
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ VSCREATEPROJFLAGS /*grfCreateFlags*/,
		/*[in]*/ REFIID /*iidProject*/,
		/*[out,iid_is(iidProject)]*/ void** /*ppvProject*/)VSL_STDMETHOD_NOTIMPL
};

class IVsCreateAggregateProjectMockImpl :
	public IVsCreateAggregateProject,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsCreateAggregateProjectMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsCreateAggregateProjectMockImpl)

	typedef IVsCreateAggregateProject Interface;
	struct CreateAggregateProjectValidValues
	{
		/*[in]*/ LPCOLESTR pszProjectTypeGuids;
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ LPCOLESTR pszLocation;
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags;
		/*[in]*/ REFIID iidProject;
		/*[out,iid_is(iidProject)]*/ void** ppvProject;
		HRESULT retValue;
	};

	STDMETHOD(CreateAggregateProject)(
		/*[in]*/ LPCOLESTR pszProjectTypeGuids,
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ LPCOLESTR pszLocation,
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags,
		/*[in]*/ REFIID iidProject,
		/*[out,iid_is(iidProject)]*/ void** ppvProject)
	{
		VSL_DEFINE_MOCK_METHOD(CreateAggregateProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjectTypeGuids);

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_CHECK_VALIDVALUE(iidProject);

		VSL_SET_VALIDVALUE(ppvProject);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSCREATEAGGREGATEPROJECT_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
