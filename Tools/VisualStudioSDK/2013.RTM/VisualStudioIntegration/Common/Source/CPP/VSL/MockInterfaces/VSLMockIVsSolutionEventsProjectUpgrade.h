/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSOLUTIONEVENTSPROJECTUPGRADE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSOLUTIONEVENTSPROJECTUPGRADE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSolutionEventsProjectUpgradeNotImpl :
	public IVsSolutionEventsProjectUpgrade
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionEventsProjectUpgradeNotImpl)

public:

	typedef IVsSolutionEventsProjectUpgrade Interface;

	STDMETHOD(OnAfterUpgradeProject)(
		/*[in]*/ IVsHierarchy* /*pHierarchy*/,
		/*[in]*/ VSPUVF_FLAGS /*fUpgradeFlag*/,
		/*[in]*/ BSTR /*bstrCopyLocation*/,
		/*[in]*/ SYSTEMTIME /*stUpgradeTime*/,
		/*[in]*/ IVsUpgradeLogger* /*pLogger*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSolutionEventsProjectUpgradeMockImpl :
	public IVsSolutionEventsProjectUpgrade,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSolutionEventsProjectUpgradeMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSolutionEventsProjectUpgradeMockImpl)

	typedef IVsSolutionEventsProjectUpgrade Interface;
	struct OnAfterUpgradeProjectValidValues
	{
		/*[in]*/ IVsHierarchy* pHierarchy;
		/*[in]*/ VSPUVF_FLAGS fUpgradeFlag;
		/*[in]*/ BSTR bstrCopyLocation;
		/*[in]*/ SYSTEMTIME stUpgradeTime;
		/*[in]*/ IVsUpgradeLogger* pLogger;
		HRESULT retValue;
	};

	STDMETHOD(OnAfterUpgradeProject)(
		/*[in]*/ IVsHierarchy* pHierarchy,
		/*[in]*/ VSPUVF_FLAGS fUpgradeFlag,
		/*[in]*/ BSTR bstrCopyLocation,
		/*[in]*/ SYSTEMTIME stUpgradeTime,
		/*[in]*/ IVsUpgradeLogger* pLogger)
	{
		VSL_DEFINE_MOCK_METHOD(OnAfterUpgradeProject)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHierarchy);

		VSL_CHECK_VALIDVALUE(fUpgradeFlag);

		VSL_CHECK_VALIDVALUE_BSTR(bstrCopyLocation);

		VSL_CHECK_VALIDVALUE(stUpgradeTime);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pLogger);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSOLUTIONEVENTSPROJECTUPGRADE_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
