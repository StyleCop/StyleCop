/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOWNEDPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOWNEDPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsOwnedProjectFactoryNotImpl :
	public IVsOwnedProjectFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOwnedProjectFactoryNotImpl)

public:

	typedef IVsOwnedProjectFactory Interface;

	STDMETHOD(PreCreateForOwner)(
		/*[in]*/ IUnknown* /*pUnkOwner*/,
		/*[out]*/ IUnknown** /*ppUnkInner*/,
		/*[out]*/ VSOWNEDPROJECTOBJECT* /*pCookie*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(InitializeForOwner)(
		/*[in]*/ LPCOLESTR /*pszFilename*/,
		/*[in]*/ LPCOLESTR /*pszLocation*/,
		/*[in]*/ LPCOLESTR /*pszName*/,
		/*[in]*/ VSCREATEPROJFLAGS /*grfCreateFlags*/,
		/*[in]*/ REFIID /*iidProject*/,
		/*[in]*/ VSOWNEDPROJECTOBJECT /*cookie*/,
		/*[out,iid_is(iidProject)]*/ void** /*ppvProject*/,
		/*[out]*/ BOOL* /*pfCanceled*/)VSL_STDMETHOD_NOTIMPL
};

class IVsOwnedProjectFactoryMockImpl :
	public IVsOwnedProjectFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOwnedProjectFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsOwnedProjectFactoryMockImpl)

	typedef IVsOwnedProjectFactory Interface;
	struct PreCreateForOwnerValidValues
	{
		/*[in]*/ IUnknown* pUnkOwner;
		/*[out]*/ IUnknown** ppUnkInner;
		/*[out]*/ VSOWNEDPROJECTOBJECT* pCookie;
		HRESULT retValue;
	};

	STDMETHOD(PreCreateForOwner)(
		/*[in]*/ IUnknown* pUnkOwner,
		/*[out]*/ IUnknown** ppUnkInner,
		/*[out]*/ VSOWNEDPROJECTOBJECT* pCookie)
	{
		VSL_DEFINE_MOCK_METHOD(PreCreateForOwner)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pUnkOwner);

		VSL_SET_VALIDVALUE_INTERFACE(ppUnkInner);

		VSL_SET_VALIDVALUE(pCookie);

		VSL_RETURN_VALIDVALUES();
	}
	struct InitializeForOwnerValidValues
	{
		/*[in]*/ LPCOLESTR pszFilename;
		/*[in]*/ LPCOLESTR pszLocation;
		/*[in]*/ LPCOLESTR pszName;
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags;
		/*[in]*/ REFIID iidProject;
		/*[in]*/ VSOWNEDPROJECTOBJECT cookie;
		/*[out,iid_is(iidProject)]*/ void** ppvProject;
		/*[out]*/ BOOL* pfCanceled;
		HRESULT retValue;
	};

	STDMETHOD(InitializeForOwner)(
		/*[in]*/ LPCOLESTR pszFilename,
		/*[in]*/ LPCOLESTR pszLocation,
		/*[in]*/ LPCOLESTR pszName,
		/*[in]*/ VSCREATEPROJFLAGS grfCreateFlags,
		/*[in]*/ REFIID iidProject,
		/*[in]*/ VSOWNEDPROJECTOBJECT cookie,
		/*[out,iid_is(iidProject)]*/ void** ppvProject,
		/*[out]*/ BOOL* pfCanceled)
	{
		VSL_DEFINE_MOCK_METHOD(InitializeForOwner)

		VSL_CHECK_VALIDVALUE_STRINGW(pszFilename);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszName);

		VSL_CHECK_VALIDVALUE(grfCreateFlags);

		VSL_CHECK_VALIDVALUE(iidProject);

		VSL_CHECK_VALIDVALUE(cookie);

		VSL_SET_VALIDVALUE(ppvProject);

		VSL_SET_VALIDVALUE(pfCanceled);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOWNEDPROJECTFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
