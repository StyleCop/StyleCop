/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSPROJECTFLAVORCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSPROJECTFLAVORCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsProjectFlavorCfgNotImpl :
	public IVsProjectFlavorCfg
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFlavorCfgNotImpl)

public:

	typedef IVsProjectFlavorCfg Interface;

	STDMETHOD(get_CfgType)(
		/*[in]*/ REFIID /*iidCfg*/,
		/*[out,iid_is(iidCfg)]*/ void** /*ppCfg*/)VSL_STDMETHOD_NOTIMPL

	STDMETHOD(Close)()VSL_STDMETHOD_NOTIMPL
};

class IVsProjectFlavorCfgMockImpl :
	public IVsProjectFlavorCfg,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsProjectFlavorCfgMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsProjectFlavorCfgMockImpl)

	typedef IVsProjectFlavorCfg Interface;
	struct get_CfgTypeValidValues
	{
		/*[in]*/ REFIID iidCfg;
		/*[out,iid_is(iidCfg)]*/ void** ppCfg;
		HRESULT retValue;
	};

	STDMETHOD(get_CfgType)(
		/*[in]*/ REFIID iidCfg,
		/*[out,iid_is(iidCfg)]*/ void** ppCfg)
	{
		VSL_DEFINE_MOCK_METHOD(get_CfgType)

		VSL_CHECK_VALIDVALUE(iidCfg);

		VSL_SET_VALIDVALUE(ppCfg);

		VSL_RETURN_VALIDVALUES();
	}
	struct CloseValidValues
	{
		HRESULT retValue;
	};

	STDMETHOD(Close)()
	{
		VSL_DEFINE_MOCK_METHOD_NOARGS(Close)

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSPROJECTFLAVORCFG_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
