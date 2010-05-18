/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTFLAVORCFGPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTFLAVORCFGPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectFlavorCfgProviderNotImpl :
	public IVsProjectFlavorCfgProvider
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFlavorCfgProviderNotImpl)

public:

	typedef IVsProjectFlavorCfgProvider Interface;

	STDMETHOD(CreateProjectFlavorCfg)(
		/*[in]*/ IVsCfg* /*pBaseProjectCfg*/,
		/*[out]*/ IVsProjectFlavorCfg** /*ppFlavorCfg*/)VSL_STDMETHOD_NOTIMPL
};

class IVsProjectFlavorCfgProviderMockImpl :
	public IVsProjectFlavorCfgProvider,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFlavorCfgProviderMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectFlavorCfgProviderMockImpl)

	typedef IVsProjectFlavorCfgProvider Interface;
	struct CreateProjectFlavorCfgValidValues
	{
		/*[in]*/ IVsCfg* pBaseProjectCfg;
		/*[out]*/ IVsProjectFlavorCfg** ppFlavorCfg;
		HRESULT retValue;
	};

	STDMETHOD(CreateProjectFlavorCfg)(
		/*[in]*/ IVsCfg* pBaseProjectCfg,
		/*[out]*/ IVsProjectFlavorCfg** ppFlavorCfg)
	{
		VSL_DEFINE_MOCK_METHOD(CreateProjectFlavorCfg)

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pBaseProjectCfg);

		VSL_SET_VALIDVALUE_INTERFACE(ppFlavorCfg);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTFLAVORCFGPROVIDER_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
