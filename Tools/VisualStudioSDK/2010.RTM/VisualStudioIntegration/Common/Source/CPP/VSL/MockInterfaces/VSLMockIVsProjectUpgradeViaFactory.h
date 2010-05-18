/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTUPGRADEVIAFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTUPGRADEVIAFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectUpgradeViaFactoryNotImpl :
	public IVsProjectUpgradeViaFactory
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectUpgradeViaFactoryNotImpl)

public:

	typedef IVsProjectUpgradeViaFactory Interface;

	STDMETHOD(UpgradeProject)(
		/*[in]*/ BSTR /*bstrFileName*/,
		/*[in]*/ VSPUVF_FLAGS /*fUpgradeFlag*/,
		/*[in]*/ BSTR /*bstrCopyLocation*/,
		/*[out]*/ BSTR* /*pbstrUpgradedFullyQualifiedFileName*/,
		/*[in]*/ IVsUpgradeLogger* /*pLogger*/,
		/*[out]*/ BOOL* /*pUpgradeRequired*/,
		/*[out]*/ GUID* /*pguidNewProjectFactory*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpgradeProject_CheckOnly)(
		/*[in]*/ BSTR /*bstrFileName*/,
		/*[in]*/ IVsUpgradeLogger* /*pLogger*/,
		/*[out]*/ BOOL* /*pUpgradeRequired*/,
		/*[out]*/ GUID* /*pguidNewProjectFactory*/,
		/*[out]*/ VSPUVF_FLAGS* /*pUpgradeProjectCapabilityFlags*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(GetSccInfo)(
		/*[in]*/ BSTR /*bstrProjectFileName*/,
		/*[out]*/ BSTR* /*pbstrSccProjectName*/,
		/*[out]*/ BSTR* /*pbstrSccAuxPath*/,
		/*[out]*/ BSTR* /*pbstrSccLocalPath*/,
		/*[out]*/ BSTR* /*pbstrProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectUpgradeViaFactoryMockImpl :
	public IVsProjectUpgradeViaFactory,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectUpgradeViaFactoryMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectUpgradeViaFactoryMockImpl)

	typedef IVsProjectUpgradeViaFactory Interface;
	struct UpgradeProjectValidValues
	{
		/*[in]*/ BSTR bstrFileName;
		/*[in]*/ VSPUVF_FLAGS fUpgradeFlag;
		/*[in]*/ BSTR bstrCopyLocation;
		/*[out]*/ BSTR* pbstrUpgradedFullyQualifiedFileName;
		/*[in]*/ IVsUpgradeLogger* pLogger;
		/*[out]*/ BOOL* pUpgradeRequired;
		/*[out]*/ GUID* pguidNewProjectFactory;
		HRESULT retValue;
	};

	STDMETHOD(UpgradeProject)(
		/*[in]*/ BSTR bstrFileName,
		/*[in]*/ VSPUVF_FLAGS fUpgradeFlag,
		/*[in]*/ BSTR bstrCopyLocation,
		/*[out]*/ BSTR* pbstrUpgradedFullyQualifiedFileName,
		/*[in]*/ IVsUpgradeLogger* pLogger,
		/*[out]*/ BOOL* pUpgradeRequired,
		/*[out]*/ GUID* pguidNewProjectFactory)
	{
		VSL_DEFINE_MOCK_METHOD(UpgradeProject)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

		VSL_CHECK_VALIDVALUE(fUpgradeFlag);

		VSL_CHECK_VALIDVALUE_BSTR(bstrCopyLocation);

		VSL_SET_VALIDVALUE_BSTR(pbstrUpgradedFullyQualifiedFileName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLogger);

		VSL_SET_VALIDVALUE(pUpgradeRequired);

		VSL_SET_VALIDVALUE(pguidNewProjectFactory);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpgradeProject_CheckOnlyValidValues
	{
		/*[in]*/ BSTR bstrFileName;
		/*[in]*/ IVsUpgradeLogger* pLogger;
		/*[out]*/ BOOL* pUpgradeRequired;
		/*[out]*/ GUID* pguidNewProjectFactory;
		/*[out]*/ VSPUVF_FLAGS* pUpgradeProjectCapabilityFlags;
		HRESULT retValue;
	};

	STDMETHOD(UpgradeProject_CheckOnly)(
		/*[in]*/ BSTR bstrFileName,
		/*[in]*/ IVsUpgradeLogger* pLogger,
		/*[out]*/ BOOL* pUpgradeRequired,
		/*[out]*/ GUID* pguidNewProjectFactory,
		/*[out]*/ VSPUVF_FLAGS* pUpgradeProjectCapabilityFlags)
	{
		VSL_DEFINE_MOCK_METHOD(UpgradeProject_CheckOnly)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLogger);

		VSL_SET_VALIDVALUE(pUpgradeRequired);

		VSL_SET_VALIDVALUE(pguidNewProjectFactory);

		VSL_SET_VALIDVALUE(pUpgradeProjectCapabilityFlags);

		VSL_RETURN_VALIDVALUES();
	}
	struct GetSccInfoValidValues
	{
		/*[in]*/ BSTR bstrProjectFileName;
		/*[out]*/ BSTR* pbstrSccProjectName;
		/*[out]*/ BSTR* pbstrSccAuxPath;
		/*[out]*/ BSTR* pbstrSccLocalPath;
		/*[out]*/ BSTR* pbstrProvider;
		HRESULT retValue;
	};

	STDMETHOD(GetSccInfo)(
		/*[in]*/ BSTR bstrProjectFileName,
		/*[out]*/ BSTR* pbstrSccProjectName,
		/*[out]*/ BSTR* pbstrSccAuxPath,
		/*[out]*/ BSTR* pbstrSccLocalPath,
		/*[out]*/ BSTR* pbstrProvider)
	{
		VSL_DEFINE_MOCK_METHOD(GetSccInfo)

		VSL_CHECK_VALIDVALUE_BSTR(bstrProjectFileName);

		VSL_SET_VALIDVALUE_BSTR(pbstrSccProjectName);

		VSL_SET_VALIDVALUE_BSTR(pbstrSccAuxPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrSccLocalPath);

		VSL_SET_VALIDVALUE_BSTR(pbstrProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTUPGRADEVIAFACTORY_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
