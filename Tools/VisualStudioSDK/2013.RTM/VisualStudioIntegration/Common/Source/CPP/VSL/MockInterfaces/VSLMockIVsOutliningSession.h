/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSOUTLININGSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSOUTLININGSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsOutliningSessionNotImpl :
	public IVsOutliningSession
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutliningSessionNotImpl)

public:

	typedef IVsOutliningSession Interface;

	STDMETHOD(AddOutlineRegions)(
		/*[in]*/ DWORD /*dwOutliningFlags*/,
		/*[in]*/ long /*cRegions*/,
		/*[in,size_is(cRegions)]*/ NewOutlineRegion* /*rgOutlnReg*/)VSL_STDMETHOD_NOTIMPL
};

class IVsOutliningSessionMockImpl :
	public IVsOutliningSession,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsOutliningSessionMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsOutliningSessionMockImpl)

	typedef IVsOutliningSession Interface;
	struct AddOutlineRegionsValidValues
	{
		/*[in]*/ DWORD dwOutliningFlags;
		/*[in]*/ long cRegions;
		/*[in,size_is(cRegions)]*/ NewOutlineRegion* rgOutlnReg;
		HRESULT retValue;
	};

	STDMETHOD(AddOutlineRegions)(
		/*[in]*/ DWORD dwOutliningFlags,
		/*[in]*/ long cRegions,
		/*[in,size_is(cRegions)]*/ NewOutlineRegion* rgOutlnReg)
	{
		VSL_DEFINE_MOCK_METHOD(AddOutlineRegions)

		VSL_CHECK_VALIDVALUE(dwOutliningFlags);

		VSL_CHECK_VALIDVALUE(cRegions);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgOutlnReg, cRegions*sizeof(rgOutlnReg[0]), validValues.cRegions*sizeof(validValues.rgOutlnReg[0]));

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSOUTLININGSESSION_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
