/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectFactoryNotImpl :
	public IVsProjectFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFactoryNotImpl)

public:

	typedef IVsProjectFactory Interface;

	STDMETHOD(CanCreateProject)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ VSCREATEPROJFLAGS /*grfCreateFlags*/,
		/*[out]*/ BOOL* /*pfCanCreate*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(CreateProject)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ LPCOLESTR /*pszLocation*/,
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ VSCREATEPROJFLAGS /*grfCreateFlags*/,
		/*[in]*/ REFIID /*iidProject*/,
		/*[out,iid_is(iidProject)]*/ void** /*ppvProject*/,
		/*[out]*/ BOOL* /*pfCanceled*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* /*pSP*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL
};

class IVsProjectFactoryMockImpl :
	public IVsProjectFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectFactoryMockImpl)

	typedef IVsProjectFactory Interface;
	struct CanCreateProjectValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags;
		/*[out]*/ BOOL* pfCanCreate;
		HRESULT retValue;
	};

	STDMETHOD(CanCreateProject)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags,
		/*[out]*/ BOOL* pfCanCreate)
	{
		VSL_DEFINE_MOCK_METHOD(CanCreateProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_SET_VALIDVALUE(pfCanCreate);

		VSL_RETURN_VALIDVALUES();
	}
	struct CreateProjectValidValues
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

	STDMETHOD(CreateProject)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ LPCOLESTR pszLocation,
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags,
		/*[in]*/ REFIID iidProject,
		/*[out,iid_is(iidProject)]*/ void** ppvProject,
		/*[out]*/ BOOL* pfCanceled)
	{
		VSL_DEFINE_MOCK_METHOD(CreateProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_CHECK_VALIDVALUE(iidProject);

		VSL_SET_VALIDVALUE(ppvProject);

		VSL_SET_VALIDVALUE(pfCanceled);

		VSL_RETURN_VALIDVALUES();
	}
	struct SetSiteValidValues
	{
		/*[in]*/ IServiceProvider* pSP;
		HRESULT retValue;
	};

	STDMETHOD(SetSite)(
		/*[in]*/ IServiceProvider* pSP)
	{
		VSL_DEFINE_MOCK_METHOD(SetSite)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pSP);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
