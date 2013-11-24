/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTIONPERSISTENCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTIONPERSISTENCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolutionPersistenceNotImpl :
	public IVsSolutionPersistence
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionPersistenceNotImpl)

public:

	typedef IVsSolutionPersistence Interface;

	STDMETHOD(SavePackageSolutionProps)(
		/*[in]*/ BOOL /*fPreLoad*/,
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ IVsPersistSolutionProps* /*pPSP*/,
		/*[in]*/ LPCOLESTR /*pszKey*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(SavePackageUserOpts)(
		/*[in]*/ IVsPersistSolutionOpts* /*pPSO*/,
		/*[in]*/ LPCOLESTR /*pszKey*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(LoadPackageUserOpts)(
		/*[in]*/ IVsPersistSolutionOpts* /*pPSO*/,
		/*[in]*/ LPCOLESTR /*pszKey*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolutionPersistenceMockImpl :
	public IVsSolutionPersistence,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionPersistenceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolutionPersistenceMockImpl)

	typedef IVsSolutionPersistence Interface;
	struct SavePackageSolutionPropsValidValues
	{
		/*[in]*/ BOOL fPreLoad;
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ IVsPersistSolutionProps* pPSP;
		/*[in]*/ LPCOLESTR pszKey;
		HRESULT retValue;
	};

	STDMETHOD(SavePackageSolutionProps)(
		/*[in]*/ BOOL fPreLoad,
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ IVsPersistSolutionProps* pPSP,
		/*[in]*/ LPCOLESTR pszKey)
	{
		VSL_DEFINE_MOCK_METHOD(SavePackageSolutionProps)

		VSL_CHECK_VALIDVALUE(fPreLoad);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPSP);

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_RETURN_VALIDVALUES();
	}
	struct SavePackageUserOptsValidValues
	{
		/*[in]*/ IVsPersistSolutionOpts* pPSO;
		/*[in]*/ LPCOLESTR pszKey;
		HRESULT retValue;
	};

	STDMETHOD(SavePackageUserOpts)(
		/*[in]*/ IVsPersistSolutionOpts* pPSO,
		/*[in]*/ LPCOLESTR pszKey)
	{
		VSL_DEFINE_MOCK_METHOD(SavePackageUserOpts)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPSO);

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_RETURN_VALIDVALUES();
	}
	struct LoadPackageUserOptsValidValues
	{
		/*[in]*/ IVsPersistSolutionOpts* pPSO;
		/*[in]*/ LPCOLESTR pszKey;
		HRESULT retValue;
	};

	STDMETHOD(LoadPackageUserOpts)(
		/*[in]*/ IVsPersistSolutionOpts* pPSO,
		/*[in]*/ LPCOLESTR pszKey)
	{
		VSL_DEFINE_MOCK_METHOD(LoadPackageUserOpts)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pPSO);

		VSL_CHECK_VALIDVALUE_STRINGW(pszKey);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTIONPERSISTENCE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
