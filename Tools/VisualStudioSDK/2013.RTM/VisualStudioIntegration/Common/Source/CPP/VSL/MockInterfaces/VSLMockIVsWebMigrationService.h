/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSWEBMIGRATIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSWEBMIGRATIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "webmigration.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsWebMigrationServiceNotImpl :
	public IVsWebMigrationService
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebMigrationServiceNotImpl)

public:

	typedef IVsWebMigrationService Interface;

	STDMETHOD(MigrateWeb)(
		/*[in]*/ IVsProject* /*pIVsProj*/,
		/*[in]*/ LPCOLESTR /*pszLocation*/,
		/*[in]*/ LPCOLESTR /*pszProjFile*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(IsWebProject)(
		/*[in]*/ LPCOLESTR /*pszProjFile*/,
		/*[out]*/ BOOL* /*pIsWeb*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetProjectSCCInfo)(
		/*[in]*/ BSTR /*bstrProjectFIle*/,
		/*[out]*/ BSTR* /*pbstrSccProjectName*/,
		/*[out]*/ BSTR* /*pbstrSccAuxPath*/,
		/*[out]*/ BSTR* /*pbstrSccLocalPath*/,
		/*[out]*/ BSTR* /*pbstrProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVsWebMigrationServiceMockImpl :
	public IVsWebMigrationService,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsWebMigrationServiceMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsWebMigrationServiceMockImpl)

	typedef IVsWebMigrationService Interface;
	struct MigrateWebValidValues
	{
		/*[in]*/ IVsProject* pIVsProj;
		/*[in]*/ LPCOLESTR pszLocation;
		/*[in]*/ LPCOLESTR pszProjFile;
		HRESULT retValue;
	};

	STDMETHOD(MigrateWeb)(
		/*[in]*/ IVsProject* pIVsProj,
		/*[in]*/ LPCOLESTR pszLocation,
		/*[in]*/ LPCOLESTR pszProjFile)
	{
		VSL_DEFINE_MOCK_METHOD(MigrateWeb)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pIVsProj);

		VSL_CHECK_VALIDVALUE_STRINGW(pszLocation);

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjFile);

		VSL_RETURN_VALIDVALUES();
	}
	struct IsWebProjectValidValues
	{
		/*[in]*/ LPCOLESTR pszProjFile;
		/*[out]*/ BOOL* pIsWeb;
		HRESULT retValue;
	};

	STDMETHOD(IsWebProject)(
		/*[in]*/ LPCOLESTR pszProjFile,
		/*[out]*/ BOOL* pIsWeb)
	{
		VSL_DEFINE_MOCK_METHOD(IsWebProject)

		VSL_CHECK_VALIDVALUE_STRINGW(pszProjFile);

		VSL_SET_VALIDVALUE(pIsWeb);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetProjectSCCInfoValidValues
	{
		/*[in]*/ BSTR bstrProjectFIle;
		/*[out]*/ BSTR* pbstrSccProjectName;
		/*[out]*/ BSTR* pbstrSccAuxPath;
		/*[out]*/ BSTR* pbstrSccLocalPath;
		/*[out]*/ BSTR* pbstrProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetProjectSCCInfo)(
		/*[in]*/ BSTR bstrProjectFIle,
		/*[out]*/ BSTR* pbstrSccProjectName,
		/*[out]*/ BSTR* pbstrSccAuxPath,
		/*[out]*/ BSTR* pbstrSccLocalPath,
		/*[out]*/ BSTR* pbstrProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetProjectSCCInfo)

		VSL_CHECK_VALIDVALUE_BSTR(bstrProjectFIle);

		VSL_SET_VALIDVALUE_BSTR(pbstrSccProjectName);

		VSL_SET_VALIDVALUE_BSTR(pbstrSccAuxPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrSccLocalPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSWEBMIGRATIONSERVICE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
