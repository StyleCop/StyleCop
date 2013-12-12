/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTUPGRADEVIAFACTORY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTUPGRADEVIAFACTORY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectUpgradeViaFactory2NotImpl :
	public IVsProjectUpgradeViaFactory2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectUpgradeViaFactory2NotImpl)

public:

	typedef IVsProjectUpgradeViaFactory2 Interface;

	STDMETHOD(OnUpgradeProjectCancelled)(
		/*[in]*/ BSTR /*bstrFileName*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectUpgradeViaFactory2MockImpl :
	public IVsProjectUpgradeViaFactory2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectUpgradeViaFactory2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectUpgradeViaFactory2MockImpl)

	typedef IVsProjectUpgradeViaFactory2 Interface;
	struct OnUpgradeProjectCancelledValidValues
	{
		/*[in]*/ BSTR bstrFileName;
		HRESULT retValue;
	};

	STDMETHOD(OnUpgradeProjectCancelled)(
		/*[in]*/ BSTR bstrFileName)
	{
		VSL_DEFINE_MOCK_METHOD(OnUpgradeProjectCancelled)

		VSL_CHECK_VALIDVALUE_BSTR(bstrFileName);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTUPGRADEVIAFACTORY2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
