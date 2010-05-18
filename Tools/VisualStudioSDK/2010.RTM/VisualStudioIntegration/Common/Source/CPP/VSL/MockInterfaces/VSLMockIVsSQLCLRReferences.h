/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSQLCLRREFERENCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSQLCLRREFERENCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "compsvcspkg80.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsSQLCLRReferencesNotImpl :
	public IVsSQLCLRReferences
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSQLCLRReferencesNotImpl)

public:

	typedef IVsSQLCLRReferences Interface;

	STDMETHOD(InvokeNewReferencesDlg)(
		/*[in]*/ IUnknown* /*pConnection*/,
		/*[in]*/ IUnknown* /*pAssemblySupport*/,
		/*[in]*/ SqlAddNewReferenceFlags /*dwAddNewReferenceFlags*/,
		/*[in]*/ LPCWSTR /*szLocalCache*/,
		/*[in]*/ DWORD /*dwProjectPermisionLevel*/,
		/*[in]*/ IVsComponentUser* /*pComponentUserCallback*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpdateReferences)(
		/*[in]*/ IUnknown* /*pConnection*/,
		/*[in]*/ IUnknown* /*pAssemblySupport*/,
		/*[in]*/ SqlReferenceUpdateFlags /*dwReferenceUpdateFlags*/,
		/*[in]*/ ULONG /*cAssemblyCount*/,
		/*[in,size_is(cAssemblyCount)]*/ LPCWSTR[] /*rgszAssemblies*/,
		/*[in]*/ LPCWSTR /*szLocalCache*/,
		/*[in]*/ DWORD /*dwProjectPermisionLevel*/,
		/*[in]*/ IVsSQLCLRReferencesUpdateCallback* /*pCallBack*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSQLCLRReferencesMockImpl :
	public IVsSQLCLRReferences,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSQLCLRReferencesMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSQLCLRReferencesMockImpl)

	typedef IVsSQLCLRReferences Interface;
	struct InvokeNewReferencesDlgValidValues
	{
		/*[in]*/ IUnknown* pConnection;
		/*[in]*/ IUnknown* pAssemblySupport;
		/*[in]*/ SqlAddNewReferenceFlags dwAddNewReferenceFlags;
		/*[in]*/ LPCWSTR szLocalCache;
		/*[in]*/ DWORD dwProjectPermisionLevel;
		/*[in]*/ IVsComponentUser* pComponentUserCallback;
		HRESULT retValue;
	};

	STDMETHOD(InvokeNewReferencesDlg)(
		/*[in]*/ IUnknown* pConnection,
		/*[in]*/ IUnknown* pAssemblySupport,
		/*[in]*/ SqlAddNewReferenceFlags dwAddNewReferenceFlags,
		/*[in]*/ LPCWSTR szLocalCache,
		/*[in]*/ DWORD dwProjectPermisionLevel,
		/*[in]*/ IVsComponentUser* pComponentUserCallback)
	{
		VSL_DEFINE_MOCK_METHOD(InvokeNewReferencesDlg)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pConnection);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAssemblySupport);

		VSL_CHECK_VALIDVALUE(dwAddNewReferenceFlags);

		VSL_CHECK_VALIDVALUE_STRINGW(szLocalCache);

		VSL_CHECK_VALIDVALUE(dwProjectPermisionLevel);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pComponentUserCallback);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpdateReferencesValidValues
	{
		/*[in]*/ IUnknown* pConnection;
		/*[in]*/ IUnknown* pAssemblySupport;
		/*[in]*/ SqlReferenceUpdateFlags dwReferenceUpdateFlags;
		/*[in]*/ ULONG cAssemblyCount;
		/*[in,size_is(cAssemblyCount)]*/ LPCWSTR* rgszAssemblies;
		/*[in]*/ LPCWSTR szLocalCache;
		/*[in]*/ DWORD dwProjectPermisionLevel;
		/*[in]*/ IVsSQLCLRReferencesUpdateCallback* pCallBack;
		HRESULT retValue;
	};

	STDMETHOD(UpdateReferences)(
		/*[in]*/ IUnknown* pConnection,
		/*[in]*/ IUnknown* pAssemblySupport,
		/*[in]*/ SqlReferenceUpdateFlags dwReferenceUpdateFlags,
		/*[in]*/ ULONG cAssemblyCount,
		/*[in,size_is(cAssemblyCount)]*/ LPCWSTR rgszAssemblies[],
		/*[in]*/ LPCWSTR szLocalCache,
		/*[in]*/ DWORD dwProjectPermisionLevel,
		/*[in]*/ IVsSQLCLRReferencesUpdateCallback* pCallBack)
	{
		VSL_DEFINE_MOCK_METHOD(UpdateReferences)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pConnection);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pAssemblySupport);

		VSL_CHECK_VALIDVALUE(dwReferenceUpdateFlags);

		VSL_CHECK_VALIDVALUE(cAssemblyCount);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgszAssemblies, cAssemblyCount*sizeof(rgszAssemblies[0]), validValues.cAssemblyCount*sizeof(validValues.rgszAssemblies[0]));

		VSL_CHECK_VALIDVALUE_STRINGW(szLocalCache);

		VSL_CHECK_VALIDVALUE(dwProjectPermisionLevel);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pCallBack);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSQLCLRREFERENCES_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
