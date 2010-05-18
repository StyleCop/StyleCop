/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSFILEUPGRADE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSFILEUPGRADE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsFileUpgradeNotImpl :
	public IVsFileUpgrade
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileUpgradeNotImpl)

public:

	typedef IVsFileUpgrade Interface;

	STDMETHOD(UpgradeFile)(
		/*[in]*/ BSTR /*bstrProjectName*/,
		/*[in]*/ BSTR /*bstrFileName*/,
		/*[in]*/ BOOL /*bNoBackup*/,
		/*[in]*/ IVsUpgradeLogger* /*pLogger*/,
		/*[out]*/ BOOL* /*pUpgradeRequired*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(UpgradeFile_CheckOnly)(
		/*[in]*/ BSTR /*bstrProjectName*/,
		/*[in]*/ BSTR /*bstrFileName*/,
		/*[in]*/ BOOL /*bNoBackup*/,
		/*[in]*/ IVsUpgradeLogger* /*pLogger*/,
		/*[out]*/ BOOL* /*pUpgradeRequired*/)VSL_STDMETHOD_NOTIMPL
};

class IVsFileUpgradeMockImpl :
	public IVsFileUpgrade,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsFileUpgradeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsFileUpgradeMockImpl)

	typedef IVsFileUpgrade Interface;
	struct UpgradeFileValidValues
	{
		/*[in]*/ BSTR bstrProjectName;
		/*[in]*/ BSTR bstrFileName;
		/*[in]*/ BOOL bNoBackup;
		/*[in]*/ IVsUpgradeLogger* pLogger;
		/*[out]*/ BOOL* pUpgradeRequired;
		HRESULT retValue;
	};

	STDMETHOD(UpgradeFile)(
		/*[in]*/ BSTR bstrProjectName,
		/*[in]*/ BSTR bstrFileName,
		/*[in]*/ BOOL bNoBackup,
		/*[in]*/ IVsUpgradeLogger* pLogger,
		/*[out]*/ BOOL* pUpgradeRequired)
	{
		VSL_DEFINE_MOCK_METHOD(UpgradeFile)

		VSL_CHECK_VALIDVALUE_BSTR(bstrProjectName);

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

		VSL_CHECK_VALIDVALUE(bNoBackup);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLogger);

		VSL_SET_VALIDVALUE(pUpgradeRequired);

		VSL_RETURN_VALIDVALUES();
	}
	struct UpgradeFile_CheckOnlyValidValues
	{
		/*[in]*/ BSTR bstrProjectName;
		/*[in]*/ BSTR bstrFileName;
		/*[in]*/ BOOL bNoBackup;
		/*[in]*/ IVsUpgradeLogger* pLogger;
		/*[out]*/ BOOL* pUpgradeRequired;
		HRESULT retValue;
	};

	STDMETHOD(UpgradeFile_CheckOnly)(
		/*[in]*/ BSTR bstrProjectName,
		/*[in]*/ BSTR bstrFileName,
		/*[in]*/ BOOL bNoBackup,
		/*[in]*/ IVsUpgradeLogger* pLogger,
		/*[out]*/ BOOL* pUpgradeRequired)
	{
		VSL_DEFINE_MOCK_METHOD(UpgradeFile_CheckOnly)

		VSL_CHECK_VALIDVALUE_BSTR(bstrProjectName);

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

		VSL_CHECK_VALIDVALUE(bNoBackup);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLogger);

		VSL_SET_VALIDVALUE(pUpgradeRequired);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSFILEUPGRADE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
