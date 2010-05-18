/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef ILICENSEDCLASSMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define ILICENSEDCLASSMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "objext.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class ILicensedClassManagerNotImpl :
	public ILicensedClassManager
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILicensedClassManagerNotImpl)

public:

	typedef ILicensedClassManager Interface;

	STDMETHOD(OnChangeInRequiredClasses)(
		/*[in]*/ IRequireClasses* /*pirc*/)VSL_STDMETHOD_NOTIMPL
};

class ILicensedClassManagerMockImpl :
	public ILicensedClassManager,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(ILicensedClassManagerMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(ILicensedClassManagerMockImpl)

	typedef ILicensedClassManager Interface;
	struct OnChangeInRequiredClassesValidValues
	{
		/*[in]*/ IRequireClasses* pirc;
		HRESULT retValue;
	};

	STDMETHOD(OnChangeInRequiredClasses)(
		/*[in]*/ IRequireClasses* pirc)
	{
		VSL_DEFINE_MOCK_METHOD(OnChangeInRequiredClasses)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pirc);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // ILICENSEDCLASSMANAGER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
