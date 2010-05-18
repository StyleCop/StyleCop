/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSMDCODEDOMCREATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSMDCODEDOMCREATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "vsmanaged.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVSMDCodeDomCreatorNotImpl :
	public IVSMDCodeDomCreator
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDCodeDomCreatorNotImpl)

public:

	typedef IVSMDCodeDomCreator Interface;

	STDMETHOD(CreateCodeDomProvider)(
		/*[in]*/ IVsHierarchy* /*pHier*/,
		/*[in]*/ VSITEMID /*itemid*/,
		/*[out,retval]*/ IVSMDCodeDomProvider** /*ppProvider*/)VSL_STDMETHOD_NOTIMPL
};

class IVSMDCodeDomCreatorMockImpl :
	public IVSMDCodeDomCreator,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVSMDCodeDomCreatorMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVSMDCodeDomCreatorMockImpl)

	typedef IVSMDCodeDomCreator Interface;
	struct CreateCodeDomProviderValidValues
	{
		/*[in]*/ IVsHierarchy* pHier;
		/*[in]*/ VSITEMID itemid;
		/*[out,retval]*/ IVSMDCodeDomProvider** ppProvider;
		HRESULT retValue;
	};

	STDMETHOD(CreateCodeDomProvider)(
		/*[in]*/ IVsHierarchy* pHier,
		/*[in]*/ VSITEMID itemid,
		/*[out,retval]*/ IVSMDCodeDomProvider** ppProvider)
	{
		VSL_DEFINE_MOCK_METHOD(CreateCodeDomProvider)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pHier);

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_SET_VALIDVALUE_INTERFACE(ppProvider);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSMDCODEDOMCREATOR_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
