/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSSUPPORTITEMHANDOFF2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSSUPPORTITEMHANDOFF2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

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

class IVsSupportItemHandoff2NotImpl :
	public IVsSupportItemHandoff2
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSupportItemHandoff2NotImpl)

public:

	typedef IVsSupportItemHandoff2 Interface;

	STDMETHOD(OnBeforeHandoffItem)(
		/*[in]*/ VSITEMID /*itemid*/,
		/*[in]*/ IVsProject3* /*pProjDest*/)VSL_STDMETHOD_NOTIMPL
};

class IVsSupportItemHandoff2MockImpl :
	public IVsSupportItemHandoff2,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsSupportItemHandoff2MockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsSupportItemHandoff2MockImpl)

	typedef IVsSupportItemHandoff2 Interface;
	struct OnBeforeHandoffItemValidValues
	{
		/*[in]*/ VSITEMID itemid;
		/*[in]*/ IVsProject3* pProjDest;
		HRESULT retValue;
	};

	STDMETHOD(OnBeforeHandoffItem)(
		/*[in]*/ VSITEMID itemid,
		/*[in]*/ IVsProject3* pProjDest)
	{
		VSL_DEFINE_MOCK_METHOD(OnBeforeHandoffItem)

		VSL_CHECK_VALIDVALUE(itemid);

		VSL_CHECK_VALIDVALUE_INTERFACEPOINTER(pProjDest);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSSUPPORTITEMHANDOFF2_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
