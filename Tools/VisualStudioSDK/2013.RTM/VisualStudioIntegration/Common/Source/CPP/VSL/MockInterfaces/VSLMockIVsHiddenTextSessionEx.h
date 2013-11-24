/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

This code is a part of the Visual Studio Library.

***************************************************************************/

#ifndef IVSHIDDENTEXTSESSIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
#define IVSHIDDENTEXTSESSIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5

#if _MSC_VER > 1000
#pragma once
#endif

#include "textmgr2.h"

#pragma warning(push)
#pragma warning(disable : 4510) // default constructor could not be generated
#pragma warning(disable : 4610) // can never be instantiated - user defined constructor required
#pragma warning(disable : 4512) // assignment operator could not be generated
#pragma warning(disable : 6011) // Dereferencing NULL pointer (a NULL derference is just another kind of failure for a unit test

namespace VSL
{

class IVsHiddenTextSessionExNotImpl :
	public IVsHiddenTextSessionEx
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextSessionExNotImpl)

public:

	typedef IVsHiddenTextSessionEx Interface;

	STDMETHOD(AddHiddenRegionsEx)(
		/*[in]*/ DWORD /*dwUpdateFlags*/,
		/*[in]*/ long /*cRegions*/,
		/*[in,size_is(cRegions)]*/ NewHiddenRegionEx* /*rgHidReg*/,
		/*[out]*/ IVsEnumHiddenRegions** /*ppEnum*/)VSL_STDMETHOD_NOTIMPL
};

class IVsHiddenTextSessionExMockImpl :
	public IVsHiddenTextSessionEx,
	public MockBase
{

VSL_DECLARE_NONINSTANTIABLE_BASE_CLASS(IVsHiddenTextSessionExMockImpl)

public:

VSL_DEFINE_MOCK_CLASS_TYPDEFS(IVsHiddenTextSessionExMockImpl)

	typedef IVsHiddenTextSessionEx Interface;
	struct AddHiddenRegionsExValidValues
	{
		/*[in]*/ DWORD dwUpdateFlags;
		/*[in]*/ long cRegions;
		/*[in,size_is(cRegions)]*/ NewHiddenRegionEx* rgHidReg;
		/*[out]*/ IVsEnumHiddenRegions** ppEnum;
		HRESULT retValue;
	};

	STDMETHOD(AddHiddenRegionsEx)(
		/*[in]*/ DWORD dwUpdateFlags,
		/*[in]*/ long cRegions,
		/*[in,size_is(cRegions)]*/ NewHiddenRegionEx* rgHidReg,
		/*[out]*/ IVsEnumHiddenRegions** ppEnum)
	{
		VSL_DEFINE_MOCK_METHOD(AddHiddenRegionsEx)

		VSL_CHECK_VALIDVALUE(dwUpdateFlags);

		VSL_CHECK_VALIDVALUE(cRegions);

		VSL_CHECK_VALIDVALUE_MEMCMP(rgHidReg, cRegions*sizeof(rgHidReg[0]), validValues.cRegions*sizeof(validValues.rgHidReg[0]));

		VSL_SET_VALIDVALUE_INTERFACE(ppEnum);

		VSL_RETURN_VALIDVALUES();
	}
};


} // namespace VSL

#pragma warning(pop)

#endif // IVSHIDDENTEXTSESSIONEX_H_10C49CA1_2F46_11D3_A504_00C04F5E0BA5
